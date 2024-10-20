using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private Wall wall;
        private Snake snake;
        private Direction direction;
        private double sleepTime;
        private Point[] pointsOfDirection;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            sleepTime = 100;
            pointsOfDirection = new Point[4];
        }

        public void Run()
        {
            CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(pointsOfDirection[(int)direction]);

                if (isMoving == false)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = wall.LeftX + 2;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? Yes/No");

            Console.SetCursorPosition(leftX, topY + 2);
            string input = Console.ReadLine();

            if (input == "Yes")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Console.Clear();
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("Game over");
            Environment.Exit(0);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }

            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }

            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }

            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void CreateDirections()
        {
            pointsOfDirection[0] = new Point(1, 0);
            pointsOfDirection[1] = new Point(-1, 0);
            pointsOfDirection[2] = new Point(0, 1);
            pointsOfDirection[3] = new Point(0, -1);
        }
    }
}
