using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChickenPanic.Graphics.Elements
{
    class Obstacle : DynamicGraphic
    {
        public Obstacle(double x, double y, double width, double height, double xSpeed, double ySpeed, double weight)
            : base(x, y, width, height, xSpeed, ySpeed, weight)
        {

        }
    }
}
