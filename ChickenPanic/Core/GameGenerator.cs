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
using System.Diagnostics;


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
                randomNumber = (int)random.Next(1000, 1000);
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
            double y = 0; // à définir;
            double width = 50;
            double height = 50;

            /*
            Rectangle representation = new Rectangle();
            representation.Width = width;
            representation.Height = height;
            representation.Fill = new SolidColorBrush(Colors.Green);
            */

            double xSpeed = -0.5;
            double ySpeed = 0;
            double weight = 0;

            Obstacle obstacle = new Obstacle(x, y, width, height, xSpeed, ySpeed, weight);
            obstacles.Add(obstacle);
            physics.DynamicGraphicsList.Add(obstacle);
            canvas.Children.Add(obstacle.GetRepresentation());
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
                Debug.WriteLine("dgx :" + dg.X + " " + obstacles.Count());
                if (dg.X + dg.Width < 0)
                {
                    Debug.WriteLine("remove:" + dg.Width);
                    obstaclesToRemove.Add(dg);
                }
            }

            foreach (Obstacle toRemove in obstaclesToRemove)
            {
                obstacles.Remove(toRemove);
                canvas.Children.Remove(toRemove.GetRepresentation());
                physics.DynamicGraphicsList.Remove(toRemove);
            }
        }
    }
}
