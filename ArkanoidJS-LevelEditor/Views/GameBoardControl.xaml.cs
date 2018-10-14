using System.Windows.Controls;
using System.Windows.Shapes;
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

        // Events
        private void Rectangle_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            BrickViewModel bvm = (sender as Rectangle).DataContext as BrickViewModel;
            board.ApplySettingsToSelectedBrick(bvm);
        }
    }
}
