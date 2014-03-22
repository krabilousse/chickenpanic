using ChickenPanic.Core;
using Microsoft.Phone.Controls;

namespace ChickenPanic
{
    public partial class MainPage : PhoneApplicationPage
    {
        private GameEngine gameEngine;

        public MainPage()
        {
            InitializeComponent();
            LaunchGameEngine();
        }

        public void LaunchGameEngine()
        {
            gameEngine = new GameEngine(worldCanvas);
            gameEngine.LaunchEngine();
        }
    }
}