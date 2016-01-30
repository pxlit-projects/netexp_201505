using System.ComponentModel;

namespace BruPark.Apps.WPF.Models
{
    public abstract class AbstractModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;



        protected void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
