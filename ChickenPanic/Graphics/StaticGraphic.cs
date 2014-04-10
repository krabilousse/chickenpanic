using ChickenPanic.Core;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ChickenPanic.Graphics
{
    public abstract class StaticGraphic : IDrawable, IUpdatable
    {
        protected double x;
        protected double y;

        protected double width;
        protected double height;

        protected Image representation;

        public StaticGraphic(double x, double y, double width, double height)
            : base()
        {
            representation = new Image();

            X = x;
            Y = y;

            Width = width;
            Height = height;

        }

        public UIElement GetRepresentation()
        {
            return representation; 
        }

        public virtual void Update(int elapsedMilliseconds)
        { }

        public double X
        {
            get { return x; }
            set 
            {
                Canvas.SetLeft(representation, x);
                x = value; 
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                Canvas.SetTop(representation, y);
                y = value;
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                representation.Width = width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                representation.Height = height = value;
            }
        }
    }
}
