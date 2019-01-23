using System;
using ClassLibrary;

namespace ConsoleApp7
{
    class Program
    {
        /// <summary>
        /// Метод для считывания корректных размеров поля
        /// </summary>
        /// <param name="message">Сообщения которое необходимо вывести при считывание значения</param>
        /// <param name="maxvalue">Максимальное значение которое может принемать введённое значение</param>
        /// <returns></returns>
        static uint ReadUint(string message, uint maxvalue)
        {
            uint ans;
            Console.WriteLine(message);
            while (!uint.TryParse(Console.ReadLine(), out ans) || maxvalue < ans || ans == 0)
            {
                Console.WriteLine("incorrect input");
            }
            return ans;
        }

        /// <summary>
        /// Метод для считывания корректной строки описывающей путь робот 
        /// </summary>
        /// <returns></returns>
        static string ReadString()
        {
            Console.WriteLine("enter work path");
            string Way = Console.ReadLine();
            while(!CorrectWay(Way))
            {
                Console.WriteLine("invalid string");
                Way = Console.ReadLine();
            }
            return Way;
        }

        /// <summary>
        /// Метод проверки строки на корректность
        /// </summary>
        /// <param name="Way"></param>
        /// <returns></returns>
        static bool CorrectWay(string Way)
        {
            foreach (var item in Way)
            {
                if(item != 'R' && item != 'B' && item != 'F' && item != 'L')
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                uint maxX = ReadUint("Input the size of the field vertically", 200), //размер поля по горизонтали
                maxY = ReadUint("input the size of the box horizontally", 200); // размер поля по вертикали
                Display display = new Display(maxX, maxY); // обект класса необходимый для отоброжения пути робота
                Steps delDR = new Steps(display.R); // направо
                Steps delDL = new Steps(display.L); // налево
                Steps delDF = new Steps(display.F); // вперед
                Steps delDB = new Steps(display.B); // назад

                Robot rob = new Robot(); // конкретный робот
                Steps delR = new Steps(rob.Right); // направо
                Steps delL = new Steps(rob.Left); // налево
                Steps delF = new Steps(rob.Forward); // вперед
                Steps delB = new Steps(rob.Backward); // назад

                Steps WayAns = null; // Многоадресный делигат хронящий путь робота 

                string way = ReadString();
                Console.WriteLine(rob.Position()); // сообщить координаты
                foreach (var item in way)
                {
                    if (item == 'R')
                    {
                        WayAns += delDR + delR;
                    }
                    else if (item == 'L')
                    {
                        WayAns += delDL + delL;
                    }
                    else if (item == 'F')
                    {
                        WayAns += delDF + delF;
                    }
                    else
                    {
                        WayAns += delDB + delB;
                    }
                } // запись пути робота в делегат
                bool chek = false;
                try
                {
                    WayAns(); // запуск робота по пути 
                }
                catch (IndexOutOfRangeException)
                {
                    chek = !chek;
                    Console.WriteLine("Error! \nThe robot went beyond the field!");
                } // обработка на случай если робот выйдет за приделыполя
                if (!chek)
                {
                    for (int i = 0; i < maxY; i++)
                    {
                        for (int j = 0; j < maxX; j++)
                        {
                            if (display.field[j, i] == '+')
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("+ ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (display.field[j, i] == '*')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("* ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.Write("  ");
                            }
                        }
                        Console.WriteLine();
                    } // Вод поля с отмеченым путём робота
                    Console.WriteLine(rob.Position()); // сообщить координаты
                }
                Console.WriteLine("To end the program, press the Escape key, to restart the program, press any other key.");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
