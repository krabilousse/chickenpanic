using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows;
using System;
using ChickenPanic.Graphics;
using ChickenPanic.Graphics.Characters;

namespace ChickenPanic.Core
{
    public class GameCore
    {
        private Canvas worldCanvas;

        private Chicken test;

        private GamePhysics gamePhysics;

        public GameCore(Canvas canvas)
        {
            worldCanvas = canvas;

            InitializeCore();
        }

        private void InitializeCore()
        {
            worldCanvas.MouseLeftButtonDown += new MouseButtonEventHandler(WorldCanvas_MouseLeftButtonDown);

            test = new Chicken(100, 100, 100, 100, 0, 0, 100);
            gamePhysics = new GamePhysics();

            worldCanvas.Children.Add(test.GetRepresentation());
        }

        private void WorldCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            test.YSpeed = -10;
        }

        public void UpdateGame(int elapsedMilliseconds)
        {
            gamePhysics.Update(elapsedMilliseconds);
        }

        public Canvas WorldCanvas
        {
            get { return worldCanvas; }
        }
    }
}
