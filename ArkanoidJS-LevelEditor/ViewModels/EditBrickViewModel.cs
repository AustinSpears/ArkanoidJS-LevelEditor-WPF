using System.Collections.Generic;
using System.Reflection;

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

        public List<string> Colors { get; set; } = new List<string>();

        public string SelectedColor { get; set; } = "ForestGreen";

        // Constructor
        public EditBrickViewModel()
        {
            InitColors();
        }

        // Methods
        private void InitColors()
        {
            // Get all named colors
            var cType = typeof(System.Windows.Media.Colors);
            var cProperty = cType.GetProperties();
            foreach (PropertyInfo prop in cProperty)
            {
                Colors.Add(prop.Name);
            }
        }
    }
}
