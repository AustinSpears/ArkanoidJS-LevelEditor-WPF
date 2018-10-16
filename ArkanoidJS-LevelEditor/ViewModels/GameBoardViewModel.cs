using ArkanoidJS_LevelEditor.Constants;
using ArkanoidJS_LevelEditor.MVVM_Helpers;
using Newtonsoft.Json;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using ArkanoidJS_LevelEditor.Models;
using System.Linq;

namespace ArkanoidJS_LevelEditor.ViewModels
{
    public class GameBoardViewModel : ViewModelBase
    {
        // Properties
        public EditBrickViewModel EditBrickVM { get; set; } = new EditBrickViewModel();
        public List<BrickViewModel> Bricks { get; set; } = new List<BrickViewModel>();

        private RelayCommand _exportcommand;
        public RelayCommand ExportCommand
        {
            get
            {
                if(_exportcommand == null)
                {
                    _exportcommand = new RelayCommand(ExportToJsonFile);
                }

                return _exportcommand;
            }
        }

        // Constructor
        public GameBoardViewModel()
        {
            int cols = 10;
            int rows = 30;
            for(int i = 0; i < cols; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    Bricks.Add(new BrickViewModel(
                        i * Globals.BRICK_WIDTH, 
                        j * Globals.BRICK_HEIGHT));
                }
            }
        }

        // Methods
        private void ExportToJsonFile(object parameter)
        {
            // Open file save dialog
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Json File|*.json";
            saveDialog.Title = "Save a Json File";
            saveDialog.ShowDialog();

            // Bail out if the user cancelled the save file dialog
            if(string.IsNullOrWhiteSpace(saveDialog.FileName)) { return; }

            using (StreamWriter sw = new StreamWriter(saveDialog.OpenFile()))
            {
                List<BrickModel> brickModels = Bricks.Select(bvm => bvm.Brick).ToList();
                string jsonBrickList = JsonConvert.SerializeObject(brickModels);
                sw.WriteLine(jsonBrickList);
            }
        }

        public void ApplySettingsToSelectedBrick(BrickViewModel selectedBrick)
        {
            if (EditBrickVM.ApplyColor)
            {
                // If the colors match, then toggle broken like normal
                if(selectedBrick.Color == EditBrickVM.SelectedColor)
                {
                    selectedBrick.Broken = !selectedBrick.Broken;
                }
                // If the colors don't match, then swap the color without breaking the brick
                else
                {
                    selectedBrick.Color = EditBrickVM.SelectedColor;
                    if(selectedBrick.Broken)
                    {
                        selectedBrick.Broken = false;
                    }
                }
            }
            // Default behavior is simply to toggle the broken status
            else
            {
                selectedBrick.Broken = !selectedBrick.Broken;
            }

            // Apply the type if necessary
            if (EditBrickVM.ApplyType)
            {
                selectedBrick.Type = EditBrickVM.SelectedBrickType;
            }
        }
    }
}
