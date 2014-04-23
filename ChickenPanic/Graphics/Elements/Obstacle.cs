using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ChickenPanic.Graphics.Elements
{
    class Obstacle : DynamicGraphic
    {
        public Obstacle(double x, double y, double width, double height, double xSpeed, double ySpeed, double weight, int orientation)
            : base(x, y, width, height, xSpeed, ySpeed, weight)
        {
            if (orientation == -1)
                this.representation.Source =  new BitmapImage(new Uri("/obstacle01.png", UriKind.Relative));
            else if(orientation == 1)
                this.representation.Source = new BitmapImage(new Uri("/obstacle02.png", UriKind.Relative));
        }
    }
}
