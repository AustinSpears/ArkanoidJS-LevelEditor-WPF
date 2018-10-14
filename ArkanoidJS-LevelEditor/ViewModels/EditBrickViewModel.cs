namespace ArkanoidJS_LevelEditor.ViewModels
{
    public class EditBrickViewModel : ViewModelBase
    {
        // Properties
        private bool _applyColor;
        public bool ApplyColor
        {
            get { return _applyColor; }
            set
            {
                _applyColor = value;
                OnPropertyChanged(nameof(ApplyColor));
            }
        }
    }
}
