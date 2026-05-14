using CSharpSnakeProject.Maps;
using CSharpSnakeProject.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSnakeProject.Logic.Food
{
    public class FoodGenerator : IFoodGenerator
    {
        private readonly Random _random = new Random();

        public Cell GenerateFood(IFood food, IMap map, List<Cell> snakeBody)
        {
            Cell newFood;
            int attempts = 0;
            const int maxAttempts = 100;

            do
            {
                newFood = new Cell(
                    _random.Next(3, map.Width - 3),
                    _random.Next(3, map.Height - 3)
                );
                attempts++;

                // Если много попыток не увенчались успехом, расширяем область поиска
                if (attempts > maxAttempts / 2)
                {
                    newFood = new Cell(
                        _random.Next(1, map.Width - 1),
                _random.Next(1, map.Height - 1)
                    );
                }
            } while (!food.IsValidPosition(newFood, map, snakeBody) && attempts < maxAttempts);

            if (attempts >= maxAttempts)
            {
                throw new InvalidOperationException("Не удалось сгенерировать еду за допустимое число попыток");
            }

            return newFood;
        }
    }
}