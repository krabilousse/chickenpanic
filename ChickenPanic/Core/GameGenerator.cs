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
        private int elapsedMilliseconds = 0;
        private Canvas canvas;
        private GamePhysics physics;
        private Size resolution;


        public GameGenerator(ref Canvas worldCanvas, ref GamePhysics gamePhysics)
        {
            canvas = worldCanvas;
            physics = gamePhysics;

            var content = Application.Current.Host.Content;
            resolution = new Size(content.ActualWidth, content.ActualHeight);
        }

        public List<Obstacle> Oblstacles { get; set; }

        public void UpdateObstacles(int elapsedMilliseconds)
        {
            this.elapsedMilliseconds += elapsedMilliseconds;
            if (this.elapsedMilliseconds >= randomNumber)
            {
                addNewObstacle();
                removeOldObstacle();

                this.elapsedMilliseconds = 0;

                Random random = new Random();
                randomNumber = (int)random.Next(1000, 2000);

            }
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
            double x = resolution.Height;
            double y = (double)new Random().Next(-250, 0);
            double width = 50;
            double height = 300;

            /*
            Rectangle representation = new Rectangle();
            representation.Width = width;
            representation.Height = height;
            representation.Fill = new SolidColorBrush(Colors.Green);
            */

            double xSpeed = -0.5;
            double ySpeed = 0;
            double weight = 0;

            Obstacle obstacle1 = new Obstacle(x, y, width, height, xSpeed, ySpeed, weight, -1);
            obstacles.Add(obstacle1);
            physics.DynamicGraphicsList.Add(obstacle1);
            canvas.Children.Add(obstacle1.GetRepresentation());

            y += 500;
            Obstacle obstacle2 = new Obstacle(x, y, width, height, xSpeed, ySpeed, weight, 1);
            obstacles.Add(obstacle2);
            physics.DynamicGraphicsList.Add(obstacle2);
            canvas.Children.Add(obstacle2.GetRepresentation());

            physics.Update(0);

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
                if (dg.X + dg.Width < 0)
                {
                    obstaclesToRemove.Add(dg);
                }
            }

            foreach (Obstacle toRemove in obstaclesToRemove)
            {
                canvas.Children.Remove(toRemove.GetRepresentation());
                obstacles.Remove(toRemove);
                physics.DynamicGraphicsList.Remove(toRemove);
            }
        }
    }
}
