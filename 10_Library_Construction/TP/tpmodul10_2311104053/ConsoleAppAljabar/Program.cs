using System;
using AljabarLibraries;

namespace ConsoleAppAljabar
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input1 = { 1, -3, -10 };
            double[] hasilAkar = Aljabar.AkarPersamaanKuadrat(input1);

            Console.WriteLine("Akar Persamaan Kuadrat({1, -3, -10})");
            Console.WriteLine($"Output: {{{hasilAkar[0]}, {hasilAkar[1]}}}");

            double[] input2 = { 2, -3 };
            double[] hasilKuadrat = Aljabar.HasilKuadrat(input2);

            Console.WriteLine();
            Console.WriteLine("Hasil Kuadrat({2, -3})");
            Console.WriteLine($"Output: {{{hasilKuadrat[0]}, {hasilKuadrat[1]}, {hasilKuadrat[2]}}}");
        }
    }
}
