using System;

namespace oap_labs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите число N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            int sum = 0; // Переменная для накопления суммы
            
            // Цикл for: от 1 до n включительно
            for (int i = 1; i <= n; i++)
            {
                sum = sum + i; // или sum += i;
            }
            
            Console.WriteLine($"Сумма чисел от 1 до {n} = {sum}");
            
            // Чтобы консоль не закрылась сразу
            Console.Write("Нажмите ENTER для выхода...");
            Console.ReadLine();
        }
    }
}