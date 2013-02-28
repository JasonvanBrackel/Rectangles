using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using vanBrackel.Rectangles.UI.Services;

namespace vanBrackel.Rectangles.UI.Model
{
    public class MainWindowViewModel : ViewModelBase
    {
        private RectangleViewModel _rectangle1;
        private RectangleViewModel _rectangle2;
        private ICommand _clearCommand = new DelegateCommand<MainWindow>(ClearRectangles);
        private IEnumerable<object> _statusItems;

        public MainWindowViewModel()
        {
            _statusItems = new[] {new {Message = "Click and drag on the gray canvas to draw a rectangle."}};
        }

        public RectangleViewModel Rectangle1
        {
            get { return _rectangle1; }
            set
            {
                _rectangle1 = value;
                if(value == null)
                    SetInitialStatus();
                else
                    StatusItems = new[] { new { Message = "Click and drag on the gray canvas to draw another rectangle." } };
                OnPropertyChanged("Rectangle1");
            }
        }

        private void SetInitialStatus()
        {
            StatusItems = new[] {new {Message = "Click and drag on the gray canvas to draw a rectangle."}};
        }

        public RectangleViewModel Rectangle2
        {
            get { return _rectangle2; }
            set
            {
                _rectangle2 = value;
                if (_rectangle1 == null || _rectangle2 == null)
                    SetInitialStatus();
                else
                    CompareRectangles();
                
                OnPropertyChanged("Rectangle2");
            }
        }

        private void CompareRectangles()
        {
            StatusItems = new[] { new{ Message = "Comparing Rectangle, Please Wait..."}, new { Message = "Click on clear, to start over." }} ;
            try
            {
                Task
                    .Factory
                    .StartNew(() => Resolver.Resolve<IComparisonService>().ConductComparison(Rectangle1, Rectangle2))
                    .ContinueWith(
                        task => StatusItems = task.Result,
                        new CancellationToken(),
                        TaskContinuationOptions.None,
                        TaskScheduler.FromCurrentSynchronizationContext()
                    );
            }
            catch (AggregateException ae)
            {
                StatusItems = new[] {new  {Message = "An error occured during comparison: " + ae.InnerExceptions[0].Message }};
            }

        }

        public ICommand ClearCommand
        {
            get { return _clearCommand; }
            set
            {
                _clearCommand = value; OnPropertyChanged("ClearCommand"); }
        }

        public IEnumerable<object> StatusItems
        {
            get { return _statusItems; }
            set { _statusItems = value; OnPropertyChanged("StatusItems"); }
        }

        private static void ClearRectangles(MainWindow window)
        {
            var viewModel = window.DataContext as MainWindowViewModel;
            if(viewModel == null)
                return;

            viewModel.Rectangle1 = null;
            viewModel.Rectangle2 = null;
            window.DrawingBoard.Children.Clear();
            viewModel.SetInitialStatus();
        }
    }
}