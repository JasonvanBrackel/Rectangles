using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace vanBrackel.Rectangles.UI.Model
{
    public class RectangleViewModel : ViewModelBase
    {
        private PointViewModel _startingPoint;
        private PointViewModel _endingPoint;

        public PointViewModel StartingPoint
        {
            get { return _startingPoint; }
            set { _startingPoint = value; OnPropertyChanged("StartingPoint"); }
        }

        public PointViewModel EndingPoint
        {
            get { return _endingPoint; }
            set { _endingPoint = value; OnPropertyChanged("EndingPoint"); }
        }
    }
}
