using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChickenPanic.Core
{
    class GamePhysics
    {
        private double verticalGravity = 1;
        private double velocity = 1;
        private double currentHeight;

        public const double TerminalVelocity = 5;

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
    }
}
