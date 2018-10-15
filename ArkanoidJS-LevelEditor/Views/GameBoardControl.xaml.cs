using System.Windows.Controls;
using System.Windows.Input;
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

        // Methods
        private BrickViewModel GetBrickFromSender(object sender)
        {
            return (sender as Rectangle).DataContext as BrickViewModel;
        }

        private void ApplySettingsToSelectedBrick(object sender)
        {
            board.ApplySettingsToSelectedBrick(GetBrickFromSender(sender));
        }

        private void BreakBrick(object sender)
        {
            GetBrickFromSender(sender).Broken = true;
        }

        // Events
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                ApplySettingsToSelectedBrick(sender);
            }
            else if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                BreakBrick(sender);
            }
        }

        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                ApplySettingsToSelectedBrick(sender);
            }
            else if(Mouse.RightButton == MouseButtonState.Pressed)
            {
                BreakBrick(sender);
            }
        }
    }
}
