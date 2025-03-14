using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Bagian A: Menerima input karakter dan menentukan vokal atau konsonan
        Console.Write("Masukkan satu huruf: ");
        char inputChar = Console.ReadKey().KeyChar;
        Console.WriteLine(); // Baris baru untuk output selanjutnya

        if (char.IsLetter(inputChar))
        {
            char upperChar = char.ToUpper(inputChar);
            if (upperChar == 'A' || upperChar == 'I' || upperChar == 'U' || upperChar == 'E' || upperChar == 'O')
            {
                Console.WriteLine($"Huruf {inputChar} merupakan huruf vokal");
            }
            else
            {
                Console.WriteLine($"Huruf {inputChar} merupakan huruf konsonan");
            }
        }
        else
        {
            Console.WriteLine("Input bukan huruf.");
        }

        // Bagian B: Array bilangan genap
        int[] evenNumbers = new int[5];
        for (int i = 0; i < 5; i++)
        {
            evenNumbers[i] = 2 + (2 * i); // Mengisi array dengan 5 bilangan genap dimulai dari 2
            Console.WriteLine($"Angka genap {i + 1}: {evenNumbers[i]}");
        }
    }
}