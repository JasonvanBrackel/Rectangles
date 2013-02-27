using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using vanBrackel.Rectangles.UI.Model;

namespace vanBrackel.Rectangles.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
        }

        private MainWindowViewModel GetViewModel()
        {
            return (_viewModel = (_viewModel ?? DataContext as MainWindowViewModel));
        }

        private Point _startPosition;
        private Rectangle _rectangle;

        private void DrawingBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released || _rectangle == null)
                return;

            var pos = e.GetPosition(DrawingBoard);

            var x = Math.Min(pos.X, _startPosition.X);
            var y = Math.Min(pos.Y, _startPosition.Y);

            var w = Math.Max(pos.X, _startPosition.X) - x;
            var h = Math.Max(pos.Y, _startPosition.Y) - y;

            _rectangle.Width = w;
            _rectangle.Height = h;

            Canvas.SetLeft(_rectangle, x);
            Canvas.SetTop(_rectangle, y);
        }

        private void DrawingBoard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPosition = e.GetPosition(DrawingBoard);
            _rectangle = new Rectangle()
            {
                Stroke = Brushes.Black
            };
            Canvas.SetTop(_rectangle, _startPosition.Y);
            Canvas.SetLeft(_rectangle, _startPosition.X);
            DrawingBoard.Children.Add(_rectangle);
        }

        private void DrawingBoard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var viewModel = GetViewModel();
            if (viewModel == null)
            {
                if(DrawingBoard.Children.Contains(_rectangle))
                    DrawingBoard.Children.Remove(_rectangle);
                return;
            }

            var endingPoint = e.GetPosition(DrawingBoard);

            if (viewModel.Rectangle1 == null)
                viewModel.Rectangle1 = CreateRectangleViewModel(endingPoint);
            else if (viewModel.Rectangle2 == null)
                viewModel.Rectangle2 = CreateRectangleViewModel(endingPoint);
            else
                DrawingBoard.Children.Remove(_rectangle);

        }

        private RectangleViewModel CreateRectangleViewModel(Point endingPoint)
        {
            if (_startPosition.X < endingPoint.X)
                endingPoint.X--;
                
            if (_startPosition.Y < endingPoint.Y)
                endingPoint.Y--;

            return new RectangleViewModel
                {
                    StartingPoint = new PointViewModel() {XCoordinate = _startPosition.X, YCoordinate = _startPosition.Y},
                    EndingPoint = new PointViewModel() {XCoordinate = endingPoint.X, YCoordinate = endingPoint.Y},
                };
        }
    }
}
