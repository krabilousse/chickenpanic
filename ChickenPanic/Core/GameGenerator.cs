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
using ChickenPanic.Graphics.Surroundings;


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

        private Background background01;
        private Background background02;
        private Background background03;

        public GameGenerator(ref Canvas worldCanvas, ref GamePhysics gamePhysics)
        {
            canvas = worldCanvas;
            physics = gamePhysics;

            double backgroundY = Application.Current.Host.Content.ActualWidth - 214;

            background01 = new Background(0, backgroundY, 795, 214, 0, 0, 0);
            background02 = new Background(795, backgroundY, 795, 214, 0, 0, 0);
            background03 = new Background(1590, backgroundY, 795, 214, 0, 0, 0);

            background01.Y = backgroundY;
            background02.Y = backgroundY;
            background03.Y = backgroundY;

            Rectangle blueBehind = new Rectangle();
            blueBehind.Width = Application.Current.Host.Content.ActualHeight;
            blueBehind.Height = Application.Current.Host.Content.ActualWidth;
            blueBehind.Fill = new SolidColorBrush(Color.FromArgb(255, 153, 217, 234));

            canvas.Children.Add(blueBehind);

            canvas.Children.Add(background01.GetRepresentation());
            canvas.Children.Add(background02.GetRepresentation());
            canvas.Children.Add(background03.GetRepresentation());

            var content = Application.Current.Host.Content;
            resolution = new Size(content.ActualWidth, content.ActualHeight);
        }

        public List<Obstacle> Oblstacles { get; set; }

        public void UpdateObstacles(int elapsedMilliseconds)
        {
            BidBackground();

            this.elapsedMilliseconds += elapsedMilliseconds;
            if (this.elapsedMilliseconds >= randomNumber)
            {
                addNewObstacle();
                removeOldObstacle();

                this.elapsedMilliseconds = 0;

                Random random = new Random();
                randomNumber = (int)random.Next(750, 900);

            }
        }

        private void BidBackground()
        {
            background01.X -= 5;
            background02.X -= 5;
            background03.X -= 5;

            if (background01.X <= -795)
            {
                background01.X = 1590;
            }

            if (background02.X <= -795)
            {
                background02.X = 1590;
            }

            if (background03.X <= -795)
            {
                background03.X = 1590;
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
            double y = (double)new Random().Next(-200, -50);
            double width = 50;
            double height = 300;

            /*
            Rectangle representation = new Rectangle();
            representation.Width = width;
            representation.Height = height;
            representation.Fill = new SolidColorBrush(Colors.Green);
            */

            double xSpeed = new Random().NextDouble() * -1;

            if (xSpeed > -0.5)
            {
                xSpeed = -0.5;
            }
            else if (xSpeed < -0.7)
            {
                xSpeed = -0.7;
            }

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
