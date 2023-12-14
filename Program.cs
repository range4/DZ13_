﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ13
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Thread thread1 = new Thread(new ThreadStart(PrintNumbers));
            Thread thread2 = new Thread(new ThreadStart(PrintNumbers));
            Thread thread3 = new Thread(new ThreadStart(PrintNumbers));
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Thread.Sleep(1000);

            Console.WriteLine("Задание 2");
            Console.WriteLine("Введите число:");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Некорректно введены данные");
                return;
            }
            Task<long> factorialTask = FactorialAsync(number);
            factorialTask.Wait();
            Console.WriteLine($"Факториал числа {number} равен {factorialTask.Result}");
            Console.WriteLine($"Квадрат числа {number} равен {GetNumberSquare(number)}");
            Console.ReadKey();

            Console.WriteLine("Задание 3");
            Refl refl = new Refl();
            MethodInfo[] methods = refl.GetType().GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
            Console.ReadKey();
        }

        static void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static int GetNumberSquare(int number)
        {
            return number * number;
        }

        static async Task<long> FactorialAsync(int number)
        {
            await Task.Delay(8000);
            long factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
