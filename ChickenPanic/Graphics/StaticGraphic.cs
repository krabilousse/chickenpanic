using ChickenPanic.Core;
using System;
using System.Windows;

namespace ChickenPanic.Graphics
{
    public abstract class StaticGraphic : IUpdatable, IDrawable
    {
        protected double x;
        protected double y;

        protected double width;
        protected double height;

        protected UIElement representation;

        public StaticGraphic(double x, double y, double width, double height, UIElement representation)
        {
            this.x = x;
            this.y = y;

            this.width = width;
            this.height = height;

            this.representation = representation;
        }

        public virtual void Update(int elapsedMilliseconds)
        { }

        public UIElement GetRepresentation()
        {
            return representation;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public UIElement Representation
        {
            get { return representation; }
            set { representation = value; }
        }
    }
}
