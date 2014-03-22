using ChickenPanic.Core;
using System;
using System.Windows;

namespace ChickenPanic.Graphics
{
    public abstract class DynamicGraphic : StaticGraphic, ICollisionable
    {
        // XXX temp
        private const double X_SPEED_FACTOR = 1.0;
        private const double Y_SPEED_FACTOR = 9.81;

        protected double xSpeed;
        protected double ySpeed;

        protected double weight;

        public DynamicGraphic(double x, double y, double width, double height, UIElement representation, double xSpeed, double ySpeed, double weight)
            : base(x, y, width, height, representation)
        {
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;

            this.weight = weight;
        }

        public override void Update(int elapsedMilliseconds)
        {
            // TODO implements with gamePhysics

        }

        public override void CollisionOccurred(int collisionType)
        { }

        public double XSpeed
        {
            get { return xSpeed; }
            set { xSpeed = value; }
        }

        public double YSpeed
        {
            get { return ySpeed; }
            set { ySpeed = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}
