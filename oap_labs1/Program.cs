using System;

namespace oap_labs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Сколько чисел Фибоначчи вывести? N = ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            if (n <= 0)
            {
                Console.WriteLine("N должно быть больше 0");
            }
            else if (n == 1)
            {
                Console.WriteLine("0");
            }
            else
            {
                long a = 0; // Первое число
                long b = 1; // Второе число
                int count = 2; // Уже вывели 2 числа
                
                Console.Write($"{a} {b} ");
                
                // Цикл while для оставшихся чисел
                while (count < n)
                {
                    long next = a + b; // Следующее число
                    Console.Write($"{next} ");
                    
                    // Сдвигаем числа для следующей итерации
                    a = b;
                    b = next;
                    count++;
                }
                
                Console.WriteLine();
            }
            
            Console.Write("Нажмите ENTER для выхода...");
            Console.ReadLine();
        }
    }
}