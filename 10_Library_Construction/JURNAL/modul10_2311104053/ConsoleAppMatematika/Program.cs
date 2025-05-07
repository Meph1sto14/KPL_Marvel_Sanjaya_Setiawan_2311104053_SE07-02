using System;
using MatematikaLibraries;

class Program
{
    static void Main()
    {
        Console.WriteLine("FPB(60, 45)");
        Console.WriteLine($"Output: {Matematika.FPB(60, 45)}\n");

        Console.WriteLine("KPK(12, 8)");
        Console.WriteLine($"Output: {Matematika.KPK(12, 8)}\n");

        int[] fungsiTurunan = { 1, 4, -12, 9 };
        Console.WriteLine("Turunan({1, 4, -12, 9})");
        Console.WriteLine($"Output: \"{Matematika.Turunan(fungsiTurunan)}\"\n");

        int[] fungsiIntegral = { 4, 6, -12, 9 };
        Console.WriteLine("Integral({4, 6, -12, 9})");
        Console.WriteLine($"Output: \"{Matematika.Integral(fungsiIntegral)}\"");
    }
}
