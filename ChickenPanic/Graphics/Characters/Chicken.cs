using ChickenPanic.Core;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ChickenPanic.Graphics.Characters
{
    public class Chicken : DynamicGraphic
    {
        public Chicken(double x, double y, double width, double height, double xSpeed, double ySpeed, double weight)
            : base(x, y, width, height, xSpeed, ySpeed, weight)
        {
            representation.Source = new BitmapImage(new Uri("/test.png", UriKind.Relative));
        }
    }
}
