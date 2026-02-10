using System;
using System.Collections.Generic;

namespace oap_labs
{
    internal class Program
    {
        static void Task1_BusNumbers()
        {
            Console.WriteLine("=== Задача 1: Проверка номеров автобусов ===");
            Console.WriteLine("Номер должен быть формата: БУКВА-ЦИФРА-ЦИФРА-ЦИФРА-БУКВА-БУКВА");
            Console.WriteLine("Разрешенные буквы: A, B, C, E, H, K, M, O, P, T, X, Y");
            Console.WriteLine("Введите номера (пустая строка для выхода):\n");
            
            string allowedLetters = "ABCEHKMOPTXY";
            
            while (true)
            {
                Console.Write("Номер: ");
                string input = Console.ReadLine();
                
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Завершение проверки номеров.");
                    break;
                }
                
                if (input.Length != 6)
                {
                    Console.WriteLine($"  НЕПРАВИЛЬНО: нужно 6 символов, а у вас {input.Length}");
                    continue;
                }
                
                bool isValid = true;
                
                if (!allowedLetters.Contains(input[0].ToString()))
                {
                    Console.WriteLine($"  НЕПРАВИЛЬНО: 1-й символ '{input[0]}' не из разрешенных букв");
                    isValid = false;
                }
                
                for (int i = 1; i <= 3; i++)
                {
                    if (!char.IsDigit(input[i]))
                    {
                        Console.WriteLine($"  НЕПРАВИЛЬНО: {i+1}-й символ '{input[i]}' не цифра");
                        isValid = false;
                    }
                }
                
                for (int i = 4; i <= 5; i++)
                {
                    if (!allowedLetters.Contains(input[i].ToString()))
                    {
                        Console.WriteLine($"  НЕПРАВИЛЬНО: {i+1}-й символ '{input[i]}' не из разрешенных букв");
                        isValid = false;
                    }
                }
                
                if (isValid)
                {
                    Console.WriteLine($"  ПРАВИЛЬНО: номер '{input}' соответствует стандарту");
                }
                Console.WriteLine();
            }
        }
        
        static void Task2_BinaryCompression()
        {
            Console.WriteLine("=== Задача 2: Сжатие бинарных последовательностей ===");
            Console.WriteLine("Правило: '1' → 'a', '01' → 'b', '001' → 'c', ..., '0...01' → соответствующая буква");
            Console.Write("Введите бинарную последовательность (только 0 и 1): ");
            
            string input = Console.ReadLine();
            string result = "";
            int i = 0;
            
            while (i < input.Length)
            {
                int zeroCount = 0;
                
                while (i < input.Length && input[i] == '0')
                {
                    zeroCount++;
                    i++;
                }
                
                if (i >= input.Length || input[i] != '1')
                {
                    Console.WriteLine("ОШИБКА: некорректная последовательность! После нулей должна быть 1.");
                    return;
                }
                
                char compressedChar = (char)('a' + zeroCount);
                result += compressedChar;
                
                i++; 
            }
            
            Console.WriteLine($"Исходная строка: {input}");
            Console.WriteLine($"Сжатая строка:   {result}");
            
            Console.WriteLine("\nСоответствие:");
            i = 0;
            int resultIndex = 0;
            while (i < input.Length)
            {
                int start = i;
                while (i < input.Length && input[i] == '0') i++;
                if (i < input.Length && input[i] == '1')
                {
                    int length = i - start + 1;
                    string pattern = new string('0', length - 1) + "1";
                    Console.WriteLine($"  {pattern} → {result[resultIndex]}");
                    i++;
                    resultIndex++;
                }
            }
        }
        
        static void Task3_Arrows()
        {
            Console.WriteLine("=== Задача 3: Подсчет стрелок ===");
            Console.WriteLine("Стрелки: '>>-->' (направо) и '<--<<' (налево)");
            Console.Write("Введите последовательность (символы >, <, -): ");
            
            string input = Console.ReadLine();
            int arrowCount = 0;
            List<string> foundArrows = new List<string>();
            List<int> positions = new List<int>();
            
            for (int i = 0; i <= input.Length - 5; i++)
            {
                string substring = input.Substring(i, 5);
                
                if (substring == ">>-->" || substring == "<--<<")
                {
                    arrowCount++;
                    foundArrows.Add(substring);
                    positions.Add(i);
                }
            }
            
            Console.WriteLine($"\nВ последовательности найдено стрелок: {arrowCount}");
            
            if (arrowCount > 0)
            {
                Console.WriteLine("Найденные стрелки:");
                for (int j = 0; j < foundArrows.Count; j++)
                {
                    string direction = (foundArrows[j] == ">>-->") ? "направо" : "налево";
                    Console.WriteLine($"  Позиция {positions[j]}: {foundArrows[j]} ({direction})");
                }
            }
            else
            {
                Console.WriteLine("Стрелки не найдены.");
            }
        }
        
        static void Task4_Numerologist()
        {
            Console.WriteLine("=== Задача 4: Нумеролог ===");
            Console.WriteLine("Сводим число к одной цифре, суммируя все цифры");
            Console.Write("Введите число (может быть очень большим): ");
            
            string number = Console.ReadLine();
            int steps = 0;
            
            Console.WriteLine($"\nНачальное число: {number}");
            Console.WriteLine("Процесс преобразования:");
            
            while (number.Length > 1)
            {
                int sum = 0;
                
                foreach (char digitChar in number)
                {
                    sum += (int)char.GetNumericValue(digitChar);
                }
                
                number = sum.ToString();
                steps++;
                
                Console.WriteLine($"  Шаг {steps}: сумма цифр = {number}");
            }
            
            Console.WriteLine($"\nИтоговая цифра: {number}");
            Console.WriteLine($"Потребовалось шагов: {steps}");
            
            string[] predictions = {
                "1: Лидерство, независимость, амбиции",
                "2: Дипломатия, сотрудничество, чувствительность",
                "3: Творчество, общительность, оптимизм",
                "4: Практичность, стабильность, трудолюбие",
                "5: Свобода, приключения, адаптивность",
                "6: Ответственность, гармония, забота",
                "7: Анализ, духовность, интуиция",
                "8: Успех, богатство, власть",
                "9: Гуманизм, завершение, мудрость"
            };
            
            if (number.Length == 1 && char.IsDigit(number[0]))
            {
                int digit = int.Parse(number);
                if (digit >= 1 && digit <= 9)
                {
                    Console.WriteLine($"\nНумерологическое предсказание для цифры {digit}:");
                    Console.WriteLine($"  {predictions[digit - 1]}");
                }
            }
        }
        
        static void Task5_Anagram()
        {
            Console.WriteLine("=== Задача 5: Проверка перестановки букв (анаграмма) ===");
            Console.WriteLine("Пример: 'listen' и 'silent' - анаграммы");
            Console.Write("Введите два слова через пробел: ");
            
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            
            if (words.Length < 2)
            {
                Console.WriteLine("ОШИБКА: нужно ввести два слова!");
                return;
            }
            
            string word1 = words[0].ToLower();
            string word2 = words[1].ToLower();
            
            char[] chars1 = word1.ToCharArray();
            char[] chars2 = word2.ToCharArray();
            
            Array.Sort(chars1);
            Array.Sort(chars2);
            
            string sorted1 = new string(chars1);
            string sorted2 = new string(chars2);
            
            bool isAnagramBySort = sorted1 == sorted2;
            
            bool isAnagramByCount = true;
            
            if (word1.Length != word2.Length)
            {
                isAnagramByCount = false;
            }
            else
            {
                Dictionary<char, int> charCount = new Dictionary<char, int>();
                
                foreach (char c in word1)
                {
                    if (charCount.ContainsKey(c))
                        charCount[c]++;
                    else
                        charCount[c] = 1;
                }
                
                foreach (char c in word2)
                {
                    if (!charCount.ContainsKey(c))
                    {
                        isAnagramByCount = false;
                        break;
                    }
                    
                    charCount[c]--;
                    if (charCount[c] == 0)
                        charCount.Remove(c);
                }
                
                if (charCount.Count > 0)
                    isAnagramByCount = false;
            }
            
            Console.WriteLine($"\nСлова: '{words[0]}' и '{words[1]}'");
            Console.WriteLine($"Длина слов: {word1.Length} и {word2.Length} символов");
            
            if (isAnagramBySort && isAnagramByCount)
            {
                Console.WriteLine("✓ Результат: ЭТО АНАГРАММЫ");
                Console.WriteLine("  (оба метода проверки подтверждают)");
            }
            else if (!isAnagramBySort && !isAnagramByCount)
            {
                Console.WriteLine("✗ Результат: ЭТО НЕ АНАГРАММЫ");
                
                Console.WriteLine("\nБуквенный состав слов:");
                Console.Write($"  '{words[0]}': ");
                DisplayLetterCount(word1);
                
                Console.Write($"  '{words[1]}': ");
                DisplayLetterCount(word2);
            }
            else
            {
                Console.WriteLine("⚠ Результат: МЕТОДЫ ДАЛИ РАЗНЫЙ РЕЗУЛЬТАТ");
                Console.WriteLine($"  Метод сортировки: {(isAnagramBySort ? "анаграммы" : "не анаграммы")}");
                Console.WriteLine($"  Метод подсчета: {(isAnagramByCount ? "анаграммы" : "не анаграммы")}");
            }
        }
        
        static void DisplayLetterCount(string word)
        {
            Dictionary<char, int> count = new Dictionary<char, int>();
            
            foreach (char c in word)
            {
                if (char.IsLetter(c))
                {
                    if (count.ContainsKey(c))
                        count[c]++;
                    else
                        count[c] = 1;
                }
            }
            
            var sortedLetters = new List<char>(count.Keys);
            sortedLetters.Sort();
            
            foreach (char letter in sortedLetters)
            {
                Console.Write($"{letter}({count[letter]}) ");
            }
            Console.WriteLine();
        }
        
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите задачу для выполнения:");
            Console.WriteLine("  1. Номера автобусов (проверка формата)");
            Console.WriteLine("  2. Сжатие бинарных последовательностей");
            Console.WriteLine("  3. Стрелки (поиск подстрок)");
            Console.WriteLine("  4. Нумеролог (суммирование цифр)");
            Console.WriteLine("  5. Перестановка (проверка анаграмм)");
            Console.WriteLine("  0. Выход из программы");
            Console.WriteLine();
            Console.Write("Ваш выбор: ");
        }
        
        public static void Main(string[] args)
        {
            Console.Title = "Лабораторная работа №4 - Строки в C#";
            
            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Task1_BusNumbers();
                        WaitForContinue();
                        break;
                        
                    case "2":
                        Console.Clear();
                        Task2_BinaryCompression();
                        WaitForContinue();
                        break;
                        
                    case "3":
                        Console.Clear();
                        Task3_Arrows();
                        WaitForContinue();
                        break;
                        
                    case "4":
                        Console.Clear();
                        Task4_Numerologist();
                        WaitForContinue();
                        break;
                        
                    case "5":
                        Console.Clear();
                        Task5_Anagram();
                        WaitForContinue();
                        break;
                        
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Выход из программы.");
                        Console.WriteLine("Спасибо за использование!");
                        Console.WriteLine("\nНажмите любую клавишу для завершения...");
                        Console.ReadKey();
                        return;
                        
                    default:
                        Console.WriteLine("\nНеверный выбор! Пожалуйста, введите число от 0 до 5.");
                        WaitForContinue();
                        break;
                }
            }
        }
        
        static void WaitForContinue()
        {
            Console.WriteLine("\n════════════════════════════════════════");
            Console.WriteLine("Нажмите Enter для возврата в меню...");
            Console.ReadLine();
        }
    }
}