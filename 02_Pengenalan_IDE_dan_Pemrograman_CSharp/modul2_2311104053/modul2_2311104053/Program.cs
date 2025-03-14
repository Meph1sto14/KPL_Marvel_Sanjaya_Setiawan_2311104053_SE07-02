using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Bagian A: Input nama praktikan
        Console.Write("Masukkan nama Anda: ");
        string nama = Console.ReadLine();
        Console.WriteLine($"Selamat datang, {nama}!");

        // Bagian B: Array dengan 50 elemen
        int[] array = new int[50];
        for (int i = 0; i < 50; i++)
        {
            array[i] = i;
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

        // Bagian C: Input angka dan cek bilangan prima
        Console.Write("Masukkan angka (1-10000): ");
        string input = Console.ReadLine();
        int angka = Convert.ToInt32(input);

        bool isPrima = true;
        if (angka <= 1)
        {
            isPrima = false;
        }
        else
        {
            for (int i = 2; i <= Math.Sqrt(angka); i++)
            {
                if (angka % i == 0)
                {
                    isPrima = false;
                    break;
                }
            }
        }

        if (isPrima)
        {
            Console.WriteLine($"Angka {angka} merupakan bilangan prima");
        }
        else
        {
            Console.WriteLine($"Angka {angka} bukan merupakan bilangan prima");
        }
    }
}