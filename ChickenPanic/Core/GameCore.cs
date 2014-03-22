using System.Windows.Controls;
using System.Windows.Input;

namespace ChickenPanic.Core
{
    public class GameCore
    {
        private Canvas worldCanvas;

        public GameCore(Canvas canvas)
        {
            worldCanvas = canvas;

            InitializeCore();
        }

        private void InitializeCore()
        {
            worldCanvas.MouseLeftButtonDown += new MouseButtonEventHandler(WorldCanvas_MouseLeftButtonDown);
        }

        private void WorldCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // TODO Catch and store events!
        }

        public void UpdateGame(int elapsedMilliseconds)
        {
            // TODO Update work!
        }

        public Canvas WorldCanvas
        {
            get { return worldCanvas; }
        }
    }
}
