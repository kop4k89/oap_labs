using System;

namespace oap_labs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите число N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            long factorial = 1; // Используем long, так как факториал быстро растёт
            
            // Цикл for для вычисления факториала
            for (int i = 1; i <= n; i++)
            {
                factorial = factorial * i; // или factorial *= i;
            }
            
            Console.WriteLine($"{n}! = {factorial}");
            
            // Чтобы консоль не закрылась сразу
            Console.Write("Нажмите ENTER для выхода...");
            Console.ReadLine();
        }
    }
}