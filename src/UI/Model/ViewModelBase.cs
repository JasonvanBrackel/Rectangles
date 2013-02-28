using System.ComponentModel;
using System.Runtime.CompilerServices;
using vanBrackel.Rectangles.UI.Annotations;
using vanBrackel.Rectangles.UI.IoC;

namespace vanBrackel.Rectangles.UI.Model
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public IDependencyResolver Resolver { get { return DependencyResolver.GetInstance(); } }
    }
}
