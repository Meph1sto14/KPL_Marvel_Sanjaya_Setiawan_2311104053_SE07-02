using System;

public class Program
{
    public static void Main(string[] args)
    {
        PrintWelcomeMessage();
        DisplayNumberArray();
        CheckPrimeNumber();
    }

    /// <summary>
    /// Bagian A: Menerima input nama dan menampilkan sapaan.
    /// </summary>
    private static void PrintWelcomeMessage()
    {
        Console.Write("Masukkan nama Anda: ");
        string userName = Console.ReadLine();
        Console.WriteLine($"Selamat datang, {userName}!");
    }

    /// <summary>
    /// Bagian B: Menampilkan angka 0 sampai 49 dengan format khusus.
    /// </summary>
    private static void DisplayNumberArray()
    {
        int[] numbers = new int[50];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i;
            string output = i.ToString();

            if (i % 2 == 0 && i % 3 == 0)
            {
                output += "#$#$";
            }
            else if (i % 2 == 0)
            {
                output += "##";
            }
            else if (i % 3 == 0)
            {
                output += "$$";
            }

            Console.WriteLine(output);
        }
    }

    /// <summary>
    /// Bagian C: Mengecek apakah input angka merupakan bilangan prima.
    /// </summary>
    private static void CheckPrimeNumber()
    {
        Console.Write("Masukkan angka (1-10000): ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int number))
        {
            Console.WriteLine("Input bukan angka yang valid.");
            return;
        }

        bool isPrime = IsPrime(number);

        if (isPrime)
        {
            Console.WriteLine($"Angka {number} merupakan bilangan prima.");
        }
        else
        {
            Console.WriteLine($"Angka {number} bukan merupakan bilangan prima.");
        }
    }

    /// <summary>
    /// Fungsi untuk mengecek bilangan prima.
    /// </summary>
    /// <param name="number">Angka yang akan dicek</param>
    /// <returns>True jika prima, else false</returns>
    private static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}
