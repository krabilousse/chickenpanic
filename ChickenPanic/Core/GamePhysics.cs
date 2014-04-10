using ChickenPanic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ChickenPanic.Core
{
    public class GamePhysics : IUpdatable
    {
        private const double MAX_X_SPEED = 5.0;
        private const double MAX_Y_SPEED = 5.0;

        private double xSpeedFactor;
        private double ySpeedfactor;

        private List<DynamicGraphic> dynamicGraphicsList;

        public GamePhysics()
        {
            xSpeedFactor = 0.0;
            ySpeedfactor = 0.00981; // 9.81 m/s -> 0.00981 mm/s

            dynamicGraphicsList = new List<DynamicGraphic>();
        }

        public void Update(int elapsedMilliseconds)
        {
            foreach(DynamicGraphic dynamicGraphic in dynamicGraphicsList)
	        {
                /* Update position */
                dynamicGraphic.X += dynamicGraphic.XSpeed * elapsedMilliseconds;
                dynamicGraphic.Y += dynamicGraphic.YSpeed * elapsedMilliseconds;

                /* Check collisions */
                // TODO collisions with other objects

                /* Update speed */
                dynamicGraphic.XSpeed += dynamicGraphic.Weight * xSpeedFactor * elapsedMilliseconds;
                dynamicGraphic.YSpeed += dynamicGraphic.Weight * ySpeedfactor * elapsedMilliseconds;

                /* Limit max speed */
                if (dynamicGraphic.XSpeed > MAX_X_SPEED)
                {
                    dynamicGraphic.XSpeed = MAX_X_SPEED;
                }

                if (dynamicGraphic.YSpeed > MAX_Y_SPEED)
                {
                    dynamicGraphic.YSpeed = MAX_Y_SPEED;
                }
	        }
        }

        public double XSpeedFactor
        {
            get { return xSpeedFactor; }
            set { xSpeedFactor = value; }
        }

        public double YSpeedFactor
        {
            get { return ySpeedfactor; }
            set { ySpeedfactor = value; }
        }

        public List<DynamicGraphic> DynamicGraphicsList
        {
            get { return dynamicGraphicsList; }
            set { dynamicGraphicsList = value; }
        }
    }
}
