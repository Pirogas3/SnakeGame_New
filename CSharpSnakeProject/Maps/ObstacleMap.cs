using CSharpSnakeProject.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSnakeProject.Maps
{
    public class ObstacleMap : IMap
    {
        public int Width { get; }
        public int Height { get; }

        private readonly List<Cell> _walls;
        private readonly char _wallSymbol;

        public ObstacleMap(int width, int height, char wallSymbol = '█')
        {
            Width = width;
            Height = height;
            _wallSymbol = wallSymbol;
            _walls = GenerateWalls();
        }

        private List<Cell> GenerateWalls()
        {
            var walls = new List<Cell>();

            // Границы
            for (int x = 0; x < Width; x++)
            {
                walls.Add(new Cell(x, 0));
                walls.Add(new Cell(x, Height - 1));
            }
            for (int y = 1; y < Height - 1; y++)
            {
                walls.Add(new Cell(0, y));
                walls.Add(new Cell(Width - 1, y));
            }

            // Препятствия внутри
            for (int y = Height / 4; y < 3 * Height / 4; y += 2)
            {
                for (int x = Width / 4; x < 3 * Width / 4; x += 2)
                {
                    walls.Add(new Cell(x, y));
                }
            }

            return walls;
        }

        public IEnumerable<Cell> GetWalls() => _walls;
        public char GetWallSymbol(Cell position) => _wallSymbol;
    }
}