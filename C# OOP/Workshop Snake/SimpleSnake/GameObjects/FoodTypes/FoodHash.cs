namespace SimpleSnake.GameObjects.FoodTypes
{
    internal class FoodHash : Food
    {
        private const char foodSymbol = '#';
        private const int points = 3;
        public FoodHash(Wall wall)
            : base(wall, foodSymbol, points)
        {
        }
    }
}
