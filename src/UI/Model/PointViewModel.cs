namespace vanBrackel.Rectangles.UI.Model
{
    public class PointViewModel : ViewModelBase
    {
        private double _xCoordinate;
        private double _yCoordinate;

        public double XCoordinate
        {
            get { return _xCoordinate; }
            set
            {
                _xCoordinate = value;
                OnPropertyChanged();
            }
        }

        public double YCoordinate
        {
            get { return _yCoordinate; }
            set
            {
                _yCoordinate = value;
                OnPropertyChanged();
            }
        }
    }
}