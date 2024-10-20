using SimpleSnake.GameObjects.FoodTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private const char emptySpace = ' ';

        private Queue<Point> snakeElements;
        private Wall wall;
        private Food[] food;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;
            snakeElements = new Queue<Point>();
            food = new Food[3];
            foodIndex = RandomFoodNumber;
            GetFoods();
            CreateFood();
            CreateSnake();
        }

        public int FoodEaten { get; set; }
        public int RandomFoodNumber =>
            new Random().Next(0, this.food.Length);

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            this.food[0] = new FoodHash(this.wall);
            this.food[1] = new FoodDollar(this.wall);
            this.food[2] = new FoodAsterisk(this.wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (food[foodIndex].IsFoodPoint(snakeNewHead))
            {
                Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(emptySpace);

            return true;
        }

        private void CreateFood()
        {
            foodIndex = this.RandomFoodNumber;
            food[foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int foodPoints = food[foodIndex].FoodPoints;

            for (int i = 0; i < foodPoints; i++)
            {
                snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            FoodEaten += foodPoints;
            CreateFood();
        }
    }
}