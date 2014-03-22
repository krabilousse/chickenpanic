using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ChickenPanic.Core
{
    public class GameCore
    {
        private Canvas worldCanvas;

        private Rectangle test;

        private int factor;

        public GameCore(Canvas canvas)
        {
            worldCanvas = canvas;

            InitializeCore();
        }

        private void InitializeCore()
        {
            worldCanvas.MouseLeftButtonDown += new MouseButtonEventHandler(WorldCanvas_MouseLeftButtonDown);

            test = new Rectangle();

            factor = 1;

            test.Width = 50;
            test.Height = 50;

            Canvas.SetLeft(test, 50);
            Canvas.SetTop(test, 50);

            test.Fill = new SolidColorBrush(Colors.Red);

            worldCanvas.Children.Add(test);
        }

        private void WorldCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // TODO Catch and store events!
        }

        public void UpdateGame(int elapsedMilliseconds)
        {
            // TODO Update work!

            if (factor == 1)
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
            }
        }

        public Canvas WorldCanvas
        {
            get { return worldCanvas; }
        }
    }
}
