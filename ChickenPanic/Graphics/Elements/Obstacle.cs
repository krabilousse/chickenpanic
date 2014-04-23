using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ChickenPanic.Graphics.Elements
{
    class Obstacle : DynamicGraphic
    {
        public Obstacle(double x, double y, double width, double height, double xSpeed, double ySpeed, double weight)
            : base(x, y, width, height, xSpeed, ySpeed, weight)
        {
            this.representation.Source =  new BitmapImage(new Uri("/test.png", UriKind.Relative));
        }
    }
}
