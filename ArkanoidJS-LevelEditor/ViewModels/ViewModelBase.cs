using System.ComponentModel;

namespace ArkanoidJS_LevelEditor.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        // INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
