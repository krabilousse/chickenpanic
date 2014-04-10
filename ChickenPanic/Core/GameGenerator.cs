using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenPanic.Graphics.Elements;
using ChickenPanic.Core;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;


namespace ChickenPanic.Core
{
    class GameGenerator
    {
        private int number = 0;
        private List<Obstacle> obstacles = new List<Obstacle>();
        private int randomNumber = 10;
        private Size resolution;
        private int elapsedMilliseconds = 0;
        private Canvas canvas;
        private GamePhysics physics;


        public GameGenerator(ref Canvas worldCanvas, ref GamePhysics gamePhysics)
        {
            canvas = worldCanvas;
            physics = gamePhysics;

        }

        public List<Obstacle> Oblstacles { get; set; }

        public void UpdateObstacles(int elapsedMilliseconds)
        {
            this.elapsedMilliseconds += elapsedMilliseconds;
            if (this.elapsedMilliseconds >= randomNumber)
            {
                addNewObstacle();
                elapsedMilliseconds = 0;

                Random random = new Random();
                randomNumber = (int)random.Next(2000, 3000);

                removeOldObstacle();
            }
            // TODO : physics

        }

        private void addNewObstacle()
        {
            /*
            if (number % 20 == 0)
            {
                addSuperSpecialObstacle();
            }
            else if (number % 5 == 0)
            {
                addSpecialObstacle();
            }
            else
            {
                addNormalObstacle();
            }
             */
            addNormalObstacle();
            number++;
        }

        private void addNormalObstacle()
        {
            double x = resolution.Width;
            double y = 100; // à définir;
            double width = 20;
            double height = 100;
            
            Rectangle representation = new Rectangle();
            representation.Width = width;
            representation.Height = height;
            representation.Fill = new SolidColorBrush(Colors.Green);
            

            double xSpeed = -10;
            double ySpeed = 0;
            double weight = 100;

            Obstacle obstacle = new Obstacle(x, y, width, height, xSpeed, ySpeed, weight);
            obstacles.Add(obstacle);
            canvas.Children.Add(representation);
            physics.DynamicGraphicsList.Add(obstacle);
            // TODO : add image to canvas
        }

        private void addSpecialObstacle()
        {
            Obstacle obstacle = null;

            obstacles.Add(obstacle);
        }

        private void addSuperSpecialObstacle()
        {
            Obstacle obstacle = null;

            obstacles.Add(obstacle);
        }

        private void removeOldObstacle()
        {
            List<Obstacle> obstaclesToRemove = new List<Obstacle>();
            foreach (Obstacle dg in obstacles)
            {
                if (dg.X + dg.Weight < 0)
                {
                    obstaclesToRemove.Add(dg);
                }
            }

            foreach (Obstacle toRemove in obstaclesToRemove)
            {
                obstacles.Remove(toRemove);
                //canvas.Children.Remove();
                physics.DynamicGraphicsList.Remove(toRemove);
            }
        }
    }
}
