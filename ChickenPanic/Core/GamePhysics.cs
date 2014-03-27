using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System;
namespace ChickenPanic.Core
{
    class GamePhysics : IUpdatable
    {
        private double verticalGravity = 0.5;
        private double velocity = 1;
        private double currentHeight;
        private Size resolution;

        public const double TerminalVelocity = 10;

        public GamePhysics(Size resolution)
        {
            this.resolution = resolution;
            CurrentHeight = resolution.Width / 2 - 25;
        }

        public double VerticalGravity
        {
            get { return verticalGravity; }
            set { verticalGravity = value; }
        }

        public double Velocity
        {
            get { return velocity; }
            set { velocity = value;  }
        }
        public double CurrentHeight
        {
            get { return currentHeight; }
            set { currentHeight = value; }
        }

        public void Update(int ms)
        {
            CurrentHeight +=VerticalGravity + Velocity;
            Velocity += VerticalGravity;
            Velocity = Math.Min(Velocity, GamePhysics.TerminalVelocity);
        }

        public void chickenJump()
        {
            Velocity = -10;
        }
        public bool inBounds()
        {
            return (CurrentHeight <= resolution.Height && CurrentHeight >= 0);
        }
    }
}
