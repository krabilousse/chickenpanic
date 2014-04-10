using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenPanic.Graphics;

namespace ChickenPanic.Core
{
    class GameGenerator
    {
        private int number = 0;
        private List<DynamicGraphic> obstacles = new List<DynamicGraphic>();
        private int oldTime = 0;
        private int randomNumber = 10;


        public void updateObstacles()
        {
            int currentTime = System.DateTime.Now.Second;
            if (currentTime - oldTime >= randomNumber)
            {
                addNewObstacle();
                oldTime = currentTime;

                Random random = new Random();
                randomNumber = (int)random.Next(2, 5);

                removeOldObstacle();
            }
        }

        private void addNewObstacle()
        {
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
            number++;
        }

        private void addNormalObstacle()
        {
            DynamicGraphic obstacle = null;

            obstacles.Add(obstacle);
        }

        private void addSpecialObstacle()
        {
            DynamicGraphic obstacle = null;

            obstacles.Add(obstacle);
        }

        private void addSuperSpecialObstacle()
        {
            DynamicGraphic obstacle = null;

            obstacles.Add(obstacle);
        }

        private void removeOldObstacle()
        {
            List<DynamicGraphic> obstaclesToRemove = null;
            foreach(DynamicGraphic dg in obstacles)
            {
                if(false /* dg.isOut()*/)
                {
                    obstaclesToRemove.Add(dg);
                }
            }

            foreach (DynamicGraphic toRemove in obstaclesToRemove)
            {
                obstacles.Remove(toRemove);
            }
        }
    }
}
