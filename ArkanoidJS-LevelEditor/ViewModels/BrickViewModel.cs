﻿using ArkanoidJS_LevelEditor.Enumerations;
using ArkanoidJS_LevelEditor.Models;
using System.ComponentModel;
using System.Windows.Media;

namespace ArkanoidJS_LevelEditor.ViewModels
{
    public class BrickViewModel : INotifyPropertyChanged
    {
        // Fields
        private readonly BrickModel brick;

        // Properties
        public double Left
        {
            get { return brick.x; }
            set { brick.x = value; }
        }

        public double Top
        {
            get { return brick.y; }
            set { brick.y = value; }
        }

        public int Width
        {
            get { return brick.w; }
            set { brick.w = value; }
        }

        public int Height
        {
            get { return brick.h; }
            set { brick.h = value; }
        }

        public string Color
        {
            get { return brick.c; }
            set { brick.c = value; }
        }

        public bool Broken
        {
            get { return brick.broken; }
            set { brick.broken = value; }
        }

        public BrickType Type
        {
            get { return brick.brickType; }
            set { brick.brickType = value; }
        }

        // Constructor
        public BrickViewModel(double left, double top)
        {
            brick = new BrickModel(left, top);
        }

        // INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
