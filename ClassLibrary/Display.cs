namespace ClassLibrary
{
    /// <summary>
    /// Класс для отображения передвижения робота из класса Robot
    /// field - поле по которому двигается робот. В нём храниться его путь отмеченный '+' и текущая позиция '*'
    /// x и y - текущие кардинат робота 
    /// </summary>
    public class Display
    {
        public char[,] field;
        public int x, y;

        /// <summary>
        /// Конструктор, создающей поля для робота и задающий начальные координаты (0;0)
        /// </summary>
        /// <param name="maxx"></param>
        /// <param name="maxy"></param>
        public Display (uint maxx, uint maxy)
        {
            x = 0;
            y = 0;
            field = new char[maxx, maxy];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    field[i, j] = ' ';
                }
            }
        }

        /// <summary>
        /// Сдвиг робота на одну клетку вправо
        /// </summary>
        public void R()
        {
            field[x, y] = '+';
            ++x;
            field[x, y] = '*';
        }

        /// <summary>
        /// Сдвиг робота на одну клетку в лево
        /// </summary>
        public void L()
        {
            field[x, y] = '+';
            --x;
            field[x, y] = '*';
        }

        /// <summary>
        /// Сдвиг робота на одну клетку в верх
        /// </summary>
        public void F()
        {
            field[x, y] = '+';
            ++y;
            field[x, y] = '*';
        }

        /// <summary>
        /// Сдвиг робота на одну клетку в низ
        /// </summary>
        public void B()
        {
            field[x, y] = '+';
            --y;
            field[x, y] = '*';
        }
    }
}
