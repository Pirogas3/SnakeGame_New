using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSnakeProject.Input
{
    public class ConsoleInput
    {
        private readonly HashSet<IArrowListener> arrowListeners = new();

        public void Subscribe(IArrowListener l)
        {
            arrowListeners.Add(l);
        }


        public void Update()
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        foreach (var l in arrowListeners) l.OnArrowUp();
                        break;
                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        foreach (var l in arrowListeners) l.OnArrowDown();
                        break;
                    case ConsoleKey.LeftArrow or ConsoleKey.A:
                        foreach (var l in arrowListeners) l.OnArrowLeft();
                        break;
                    case ConsoleKey.RightArrow or ConsoleKey.D:
                        foreach (var l in arrowListeners) l.OnArrowRight();
                        break;
                }
            }
        }
    }
}