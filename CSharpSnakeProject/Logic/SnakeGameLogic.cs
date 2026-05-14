using CSharpSnakeProject.Enums;
using CSharpSnakeProject.Logic.Food;
using CSharpSnakeProject.Maps;
using CSharpSnakeProject.Renderer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSnakeProject.Logic
{
    public class SnakeGameLogic : BaseGameLogic
    {
        private SnakeGameplayState _gameplayState;

        public SnakeGameLogic()
        {
            // Создаём карту (можно менять на разные типы карт, и переопределять символ стен, если необходимо)
            IMap map = new BasicMap(50, 25);

            // Настраиваем доступную еду
            List<IFood> availableFoods = new List<IFood>
            {
            new Apple(),
            new Carrot()
            };

            GamePalette palette = CreatePalette(); //Палитра цветов для разных элементов игры

            _gameplayState = new SnakeGameplayState(
                map, //обязательно задаем карту
                availableFoods, //обязательно задаем список еды
                palette, //обязательно задаем палитру цветов
                null //можно задать генератор еды
            );
        }

        private void GotoGameplay()
        {
            ChangeState(_gameplayState);
            _gameplayState.Reset();
        }

        public override void OnArrowUp()
        {
            if (currentState != _gameplayState) return;
            _gameplayState.SetDirection(SnakeDirection.Up);
        }

        public override void OnArrowDown()
        {
            if (currentState != _gameplayState) return;
            _gameplayState.SetDirection(SnakeDirection.Down);
        }

        public override void OnArrowLeft()
        {
            if (currentState != _gameplayState) return;
            _gameplayState.SetDirection(SnakeDirection.Left);
        }

        public override void OnArrowRight()
        {
            if (currentState != _gameplayState) return;
            _gameplayState.SetDirection(SnakeDirection.Right);
        }

        public override void Update(float deltaTime)
        {
            if (currentState != _gameplayState)
            {
                GotoGameplay();
            }
        }

        public override GamePalette CreatePalette()
        {
            return new GamePalette(
                background: ConsoleColor.Black,
                food: ConsoleColor.Red,
                walls: ConsoleColor.White,
                snakeBody: ConsoleColor.Green,
                snakeHead: ConsoleColor.Blue,
                score: ConsoleColor.White
            );
        }
    }
}