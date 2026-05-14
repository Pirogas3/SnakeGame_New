using CSharpSnakeProject.Enums;
using CSharpSnakeProject.Logic.Food;
using CSharpSnakeProject.Maps;
using CSharpSnakeProject.Renderer;
using System;
using System.Collections.Generic;

namespace CSharpSnakeProject.Logic
{
    public class SnakeGameplayState : BaseGameState
    {
        private GameWorld _world;
        private IMap _map;

        public SnakeGameplayState(IMap map, List<IFood> availableFoods, GamePalette palette, IFoodGenerator foodGenerator = null)
        {
            _map = map;
            _world = new GameWorld(map, availableFoods, palette, foodGenerator);
        }

        public override void Reset()
        {
            _world.Reset();
        }

        public override void Update(float deltaTime)
        {
            _world.Update(deltaTime);

            if (_world.IsGameOver)
            {
                // Временно: показываем сообщение и выходим.
                // В будущем заменим на событие или переход в меню.
                Console.Clear();
                Console.SetCursorPosition(_map.Width / 2 - 15, _map.Height / 2);
                Console.WriteLine($"Игра окончена! Ваш счёт: {_world.Score}. Нажмите любую клавишу для выхода.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public override void Draw(ConsoleRenderer renderer)
        {
            _world.Draw(renderer);
        }

        public void SetDirection(SnakeDirection dir)
        {
            _world.SetDirection(dir);
        }
    }
}