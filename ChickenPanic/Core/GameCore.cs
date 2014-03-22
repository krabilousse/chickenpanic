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

        private int factor;

        private GamePhysics physics;

        private Size resolution;

        public GameCore(Canvas canvas)
        {
            var content = Application.Current.Host.Content;

            double scale = (double)content.ScaleFactor / 100;

            int h = (int)Math.Ceiling(content.ActualHeight * scale);

            int w = (int)Math.Ceiling(content.ActualWidth * scale);

            resolution = new Size(w, h);

            worldCanvas = canvas;

            InitializeCore();
        }

        private void InitializeCore()
        {
            worldCanvas.MouseLeftButtonDown += new MouseButtonEventHandler(WorldCanvas_MouseLeftButtonDown);

            test = new Rectangle();
            physics = new GamePhysics();
            factor = 1;

            test.Width = 50;
            test.Height = 50;

            physics.CurrentHeight = resolution.Width / 2 - 25;

            Canvas.SetLeft(test, 50);
            Canvas.SetTop(test, resolution.Width / 2-25);

            test.Fill = new SolidColorBrush(Colors.Red);
            worldCanvas.Children.Add(test);
        }

        private void WorldCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // TODO Catch and store events!
            Debug.WriteLine("Tits" + physics.CurrentHeight);
            physics.VerticalGravity *= (-1);
        }

        public void UpdateGame(int elapsedMilliseconds)
        {
            Debug.WriteLine("ms " + elapsedMilliseconds);
            physics.CurrentHeight += physics.VerticalGravity + physics.Velocity;
            physics.Velocity += physics.VerticalGravity * 0.05;
            physics.Velocity = Math.Min(physics.Velocity, GamePhysics.TerminalVelocity);
            Canvas.SetTop(test, physics.CurrentHeight);
            /*if (factor == 1)
            {
                test.Width += elapsedMilliseconds * 0.1;
            }
            else if (factor == -1)
            {
                test.Width -= elapsedMilliseconds * 0.1;
            }

            if (test.Width > 300)
            {
                factor = -1;
            }
            else if (test.Width < 50)
            {
                factor = 1;
            }*/
        }

        public Canvas WorldCanvas
        {
            get { return worldCanvas; }
        }
    }
}
