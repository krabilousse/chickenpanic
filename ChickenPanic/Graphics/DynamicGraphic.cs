using ChickenPanic.Core;
using System;
using System.Windows;

namespace ChickenPanic.Graphics
{
    public abstract class DynamicGraphic : StaticGraphic, ICollisionable
    {
        protected double xSpeed;
        protected double ySpeed;

        protected double weight;

        public DynamicGraphic(double x, double y, double width, double height, double xSpeed, double ySpeed, double weight)
            : base(x, y, width, height)
        {
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;

            this.weight = weight;
        }

        public virtual void CollisionOccurred(int collisionType)
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
