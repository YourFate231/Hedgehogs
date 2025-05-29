using System;
using System.Diagnostics;
class Program
{
    /// <summary> 
    /// Метод, який розраховує мінімальну кількість зустрічей, які потрібно провести, щоб досягти цілі.
    /// </summary>
    /// <param name="population">Масив з кількістю їжачків кожного кольору</param>
    /// <param name="target">Бажаний колір</param>
    /// <returns>Мінімальна кількість зустрічей або -1, якщо неможливо</returns>
    static int MinMeetings(int[] population, int target)
    {
        //Загальна кількість їжачків
        int total = population[0] + population[1] + population[2];

        //Якщо всі їжачки вже одного кольору - зустрічі не потрібні
        if (population[target] == total)
            return 0;

        //Скільки кольорів присутні (ненульова кількість)
        int nonZeroColors = 0;
        for (int i = 0; i < 3; i++)
        {
            if (population[i] > 0) 
                nonZeroColors++;
        }

        //Якщо всі їжачки одного кольору - неможливо досягти цілі
        if (nonZeroColors == 1)
            return -1;

        //Кількість двох інших кольорів
        int a = population[(target + 1) % 3];
        int b = population[(target + 2) % 3];

        //Якщо сума двох інших кольорів непарна - неможливо досягти цілі
        if ((a+b) % 2 != 0)
            return -1;
        return Math.Max(a, b);
    }
    static void Main()
    {
        int[] population = new int[3] {8, 1, 9};
        
        int target = 1;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int result = MinMeetings(population, target);

        stopwatch.Stop();

        Console.WriteLine("Result: " + result);
        Console.WriteLine("Time: " + stopwatch.Elapsed.TotalMicroseconds + "ms");


    }
}
