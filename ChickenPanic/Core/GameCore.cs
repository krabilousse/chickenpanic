using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows;
using System;

namespace ChickenPanic.Core
{
    public class GameCore
    {
        private Canvas worldCanvas;

        private Rectangle test;

        private GamePhysics physics;

        public GameCore(Canvas canvas)
        {

            physics = new GamePhysics(ScreenResolution());

            worldCanvas = canvas;

            InitializeCore();
        }

        private static Size ScreenResolution()
        {
            var content = Application.Current.Host.Content;

            double scale = (double)content.ScaleFactor / 100;

            int h = (int)Math.Ceiling(content.ActualHeight * scale);

            int w = (int)Math.Ceiling(content.ActualWidth * scale);

            return new Size(w, h);
        }

        private void InitializeCore()
        {
            worldCanvas.MouseLeftButtonDown += new MouseButtonEventHandler(WorldCanvas_MouseLeftButtonDown);

            test = new Rectangle();

            test.Width = 50;
            test.Height = 50;

            Canvas.SetLeft(test, 50);

            test.Fill = new SolidColorBrush(Colors.Red);
            worldCanvas.Children.Add(test);
        }

        private void WorldCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // TODO Catch and store events!
            physics.chickenJump();
        }



        public void UpdateGame(int elapsedMilliseconds)
        {
            //Debug.WriteLine("ms " + elapsedMilliseconds);
            physics.Update(elapsedMilliseconds);
            RotateTransform rt = new RotateTransform();
            rt.Angle = physics.Velocity*3;
            test.RenderTransform = rt;
            Canvas.SetTop(test, physics.CurrentHeight);
            
        }

        public Canvas WorldCanvas
        {
            get { return worldCanvas; }
        }
    }
}
