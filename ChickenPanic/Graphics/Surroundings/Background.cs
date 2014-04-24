using ChickenPanic.Core;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChickenPanic.Graphics.Surroundings
{
    public class Background : DynamicGraphic
    {
        public Background(double x, double y, double width, double height, double xSpeed, double ySpeed, double weight)
            : base(x, y, width, height, xSpeed, ySpeed, weight)
        {
            representation.Source = new BitmapImage(new Uri("/background.png", UriKind.Relative));
        }
    }
}
