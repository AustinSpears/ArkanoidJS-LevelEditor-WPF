using ArkanoidJS_LevelEditor.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ArkanoidJS_LevelEditor.ViewModels
{
    public class EditBrickViewModel : ViewModelBase
    {
        // Properties
        private bool _applyColor = true;
        public bool ApplyColor
        {
            get { return _applyColor; }
            set
            {
                _applyColor = value;
                OnPropertyChanged(nameof(ApplyColor));
            }
        }

        private bool _applyType = true;
        public bool ApplyType
        {
            get { return _applyType; }
            set
            {
                _applyType = value;
                OnPropertyChanged(nameof(ApplyType));
            }
        }

        public List<string> Colors { get; set; } = new List<string>();

        public string SelectedColor { get; set; } = "ForestGreen";

        private BrickType _selectedBrickType;
        public BrickType SelectedBrickType
        {
            get => _selectedBrickType;
            set
            {
                _selectedBrickType = value;
                OnPropertyChanged(nameof(SelectedBrickType));
            }
        }

        public IEnumerable<BrickType> BrickTypes
        {
            get
            {
                return Enum.GetValues(typeof(BrickType)).Cast<BrickType>();
            }
        }

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
