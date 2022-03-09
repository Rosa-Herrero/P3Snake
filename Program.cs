using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace P3Snake
{

    class Program
    {
        public static Random randomNumbersGenerator = new Random();

        private static Snake player;

        private static int lastFoodTime;
     
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Screen.InitialScreen();
            
            Init();

            bool gameOver = false;
            while (!gameOver)
            {
                Thread.Sleep(Hud.GetSleepTime());
                gameOver = Upate();
                Hud.Draw(Environment.TickCount - lastFoodTime);
                CheckTimer();
            }
            Screen.GameOverScreen();
        }
        private static void Init()
        {
            player = new Snake();
            
            Item.itemsList.Add(new Obstacle(GenerateNewPosition()));
            Item.itemsList.Add(new Obstacle(GenerateNewPosition()));
            Item.itemsList.Add(new Obstacle(GenerateNewPosition()));
            Item.itemsList.Add(new Obstacle(GenerateNewPosition()));
            Item.itemsList.Add(new Obstacle(GenerateNewPosition()));
            Item.itemsList.Add(new Obstacle(GenerateNewPosition()));
            Item.itemsList.Add(new Apple(GenerateNewPosition()));
            Item.itemsList.Add(new Apple(GenerateNewPosition()));
            Item.itemsList.Add(new Apple(GenerateNewPosition()));
            Item.itemsList.Add(new SpeedUp(GenerateNewPosition()));

            foreach(Item anItem in Item.itemsList)
            {
                anItem.Draw();
            }

            lastFoodTime = Environment.TickCount;
        }
        public static Position GenerateNewPosition()
        {
            Position newPosition;
            do
            {
                int row = randomNumbersGenerator.Next(1, Console.WindowHeight-1);
                int col = randomNumbersGenerator.Next(1, Console.WindowWidth-1);
                newPosition = new Position(row, col);
            }
            while (player.Contains(newPosition) || Item.Contains(newPosition));
            return newPosition;
        }
        private static bool Upate()
        {
            bool gameOver = false;
            if (Console.KeyAvailable)
            {
                gameOver = player.Move(Console.ReadKey().Key);
            }
            else
            {
                gameOver = player.Move(ConsoleKey.Spacebar);
            }

            if (gameOver) return gameOver;

            foreach (Item aItem in Item.itemsList)
            {
                Position itemPos = aItem.GetPosition();

                if (player.getHead() == itemPos)
                {
                    gameOver = aItem.Eaten();

                    // feeding the snake
                    aItem.SetPosition(GenerateNewPosition());
                    aItem.Draw();
                    Item obs = new Obstacle(GenerateNewPosition());
                    Item.itemsList.Add(obs);
                    obs.Draw();

                    lastFoodTime = Environment.TickCount;

                    return gameOver;
                }
            }
            // moving...
            player.Move();
            return gameOver;
        }
        private static void CheckTimer()
        {
            //Hacer Tickcoun interno a food
            if (Environment.TickCount - lastFoodTime >= Hud.GetFoodDissapearTime())
            {
                int countObstacles = 0;
                foreach (Item aItem in Item.itemsList)
                {
                    if (aItem.GetType() != typeof(Obstacle))
                    {
                        aItem.SetPosition(GenerateNewPosition());
                        aItem.Draw();
                    }
                    else
                    {
                        countObstacles++;
                    }
                }
                for (int i = 0; i < countObstacles; i++)
                {
                    Item newObstacle = new Obstacle(GenerateNewPosition());
                    Item.itemsList.Add(newObstacle);
                    newObstacle.Draw();
                }
                lastFoodTime = Environment.TickCount;
            }
        }
    }
}