using ArkanoidJS_LevelEditor.Constants;
using System.Collections.ObjectModel;

namespace ArkanoidJS_LevelEditor.ViewModels
{
    public class GameBoardViewModel : ViewModelBase
    {
        // Properties
        public EditBrickViewModel EditBrickVM { get; set; } = new EditBrickViewModel();
        public ObservableCollection<BrickViewModel> Bricks { get; set; } = new ObservableCollection<BrickViewModel>();

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
            // Toggle the broken status
            selectedBrick.Broken = !selectedBrick.Broken;
        }
    }
}
