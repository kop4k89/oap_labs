using System;

namespace oap_labs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Таблица умножения:");
            Console.WriteLine();
            
            // Внешний цикл для множителей (строки)
            for (int i = 1; i <= 10; i++)
            {
                // Внутренний цикл для множимого (столбцы)
                for (int j = 1; j <= 10; j++)
                {
                    // Выводим произведение с форматированием
                    Console.Write($"{i * j,4}"); // Число 4 задаёт ширину вывода
                }
                Console.WriteLine(); // Переход на новую строку после каждого множителя
            }
            
            Console.WriteLine();
            Console.Write("Нажмите ENTER для выхода...");
            Console.ReadLine();
        }
    }
}