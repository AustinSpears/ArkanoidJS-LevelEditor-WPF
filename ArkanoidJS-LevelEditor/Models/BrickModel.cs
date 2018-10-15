using ArkanoidJS_LevelEditor.Enumerations;
using ArkanoidJS_LevelEditor.Constants;

namespace ArkanoidJS_LevelEditor.Models
{
    public class BrickModel
    {
        // Fields
        public double x;
        public double y;
        public int w = Globals.BRICK_WIDTH;
        public int h = Globals.BRICK_HEIGHT;
        public string c = "Green";
        public BrickType brickType = BrickType.Normal;
        public bool broken = true;

        // Constructor
        public BrickModel(double left, double top)
        {
            x = left;
            y = top;
        }
    }
}
