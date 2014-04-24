using ChickenPanic.Core;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChickenPanic.Graphics.Characters
{
    public class Chicken : DynamicGraphic
    {
        private RotateTransform rotateTransform;

        private BitmapImage chicken01;
        private BitmapImage chicken02;

        private long changeTo01;

        public Chicken(double x, double y, double width, double height, double xSpeed, double ySpeed, double weight)
            : base(x, y, width, height, xSpeed, ySpeed, weight)
        {
            chicken01 = new BitmapImage(new Uri("/chiken01.png", UriKind.Relative));
            chicken02 = new BitmapImage(new Uri("/chiken02.png", UriKind.Relative));

            representation.Source = chicken01;

            changeTo01 = 0;

            rotateTransform = new RotateTransform();
        }

        public override void Update(int elapsedMilliseconds)
        {
            if (changeTo01 > 0 && changeTo01 - elapsedMilliseconds <= 0)
            {
                representation.Source = chicken01;
            }
            changeTo01 -= elapsedMilliseconds;

            rotateTransform.Angle = YSpeed * 30;

            representation.RenderTransform = rotateTransform;
        }

        public void DoFlap()
        {
            YSpeed = -0.75;

            representation.Source = chicken02;

            changeTo01 = 200;
        }
    }
}
