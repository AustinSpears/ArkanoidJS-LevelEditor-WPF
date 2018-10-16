using ArkanoidJS_LevelEditor.Enumerations;
using ArkanoidJS_LevelEditor.Models;
using ArkanoidJS_LevelEditor.MVVM_Helpers;
using System;

namespace ArkanoidJS_LevelEditor.ViewModels
{
    public class BrickViewModel : ViewModelBase
    {
        // Properties
        public BrickModel Brick { get; private set; }

        public double Left
        {
            get { return Brick.x; }
            set { Brick.x = value; }
        }

        public double Top
        {
            get { return Brick.y; }
            set { Brick.y = value; }
        }

        public int Width
        {
            get { return Brick.w; }
            set { Brick.w = value; }
        }

        public int Height
        {
            get { return Brick.h; }
            set { Brick.h = value; }
        }

        public string Color
        {
            get { return Brick.c; }
            set
            {
                Brick.c = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        public bool Broken
        {
            get { return Brick.broken; }
            set
            {
                Brick.broken = value;
                OnPropertyChanged(nameof(Broken));
            }
        }

        public BrickType Type
        {
            get { return Brick.brickType; }
            set
            {
                Brick.brickType = value;
                OnPropertyChanged(nameof(SelectedBrickType));
            }
        }

        public string SelectedBrickType
        {
            get { return Enum.GetName(Type.GetType(), Type); }
        }

        // Constructor
        public BrickViewModel(double left, double top)
        {
            Brick = new BrickModel(left, top);
        }
    }
}
