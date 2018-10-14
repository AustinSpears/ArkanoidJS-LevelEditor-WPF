using System.Windows.Controls;
using ArkanoidJS_LevelEditor.ViewModels;

namespace ArkanoidJS_LevelEditor.Views
{
    public partial class GameBoardControl : UserControl
    {
        // Fields
        private readonly GameBoardViewModel board = new GameBoardViewModel();

        // Constructor
        public GameBoardControl()
        {
            DataContext = board;
            InitializeComponent();
        }
    }
}
