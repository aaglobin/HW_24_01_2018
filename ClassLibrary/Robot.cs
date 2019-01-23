using System;

namespace ClassLibrary
{
    /// <summary>
    /// Заданный класс из презентации без изменений
    /// </summary>
    public class Robot
    {
        // класс для представления робота
        int x=0, y=0; // положение робота на плоскости
        public void Right() { x++; } // направо
        public void Left() { x--; } // налево
        public void Forward() { y++; } // вперед
        public void Backward() { y--; } // назад
        public string Position()
        { // сообщить координаты
            return String.Format("The Robot position: x={0}, y={1}", x, y);
        }
    }
    public delegate void Steps();
}
