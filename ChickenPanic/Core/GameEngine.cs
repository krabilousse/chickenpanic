using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChickenPanic.Core
{
    public class GameEngine
    {
        private long deltaTime;
        private long lastFrame;

        private GameCore gameCore;

        private Stopwatch renderingStopwatch;

        public GameEngine(Canvas worldCanvas)
        {
            renderingStopwatch = new Stopwatch();

            gameCore = new GameCore(worldCanvas);
        }

        public void LaunchEngine()
        {
            if (renderingStopwatch.IsRunning)
            {
                return;
            }

            CompositionTarget.Rendering += new EventHandler(GameEngine_Rendering);

            lastFrame = 0;

            renderingStopwatch.Start();
        }

        private void GameEngine_Rendering(object sender, EventArgs e)
        {
            deltaTime = renderingStopwatch.ElapsedMilliseconds - lastFrame;
            lastFrame += deltaTime;

            gameCore.UpdateGame((int) deltaTime);
        }
    }
}
