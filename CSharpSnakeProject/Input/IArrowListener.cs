using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSnakeProject.Input
{
    public interface IArrowListener
    {
        void OnArrowUp();
        void OnArrowDown();
        void OnArrowLeft();
        void OnArrowRight();
    }
}