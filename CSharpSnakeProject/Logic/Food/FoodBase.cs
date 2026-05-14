using CSharpSnakeProject.Maps;
using CSharpSnakeProject.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSnakeProject.Logic.Food
{
    public abstract class FoodBase : IFood
    {
        public abstract char Symbol { get; }
        public abstract string Name { get; }
        public abstract int ScoreValue { get; }
        public abstract ConsoleColor Color { get; }

        public virtual bool IsValidPosition(Cell position, IMap map, List<Cell> snakeBody)
        {
            if (position.X <= 2 || position.X >= map.Width - 3 ||
                position.Y <= 2 || position.Y >= map.Height - 3)
            {
                return false;
            }
            return !snakeBody.Contains(position) &&
                   !map.GetWalls().Contains(position);
        }
    }
}