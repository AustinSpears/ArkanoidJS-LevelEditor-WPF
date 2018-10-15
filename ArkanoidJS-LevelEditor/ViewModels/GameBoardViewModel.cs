using ArkanoidJS_LevelEditor.Constants;
using System.Collections.Generic;

namespace ArkanoidJS_LevelEditor.ViewModels
{
    public class GameBoardViewModel : ViewModelBase
    {
        // Properties
        public EditBrickViewModel EditBrickVM { get; set; } = new EditBrickViewModel();
        public List<BrickViewModel> Bricks { get; set; } = new List<BrickViewModel>();

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
        }
    }
}
