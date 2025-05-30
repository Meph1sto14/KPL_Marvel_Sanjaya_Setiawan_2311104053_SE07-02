using System;

public class Program
{
    public static void Main(string[] args)
    {
        PrintCharacterType();
        PrintEvenNumbers();
    }

    /// <summary>
    /// Menerima satu karakter dari input dan menentukan apakah vokal atau konsonan.
    /// </summary>
    private static void PrintCharacterType()
    {
        Console.Write("Masukkan satu huruf: ");
        char inputChar = Console.ReadKey().KeyChar;
        Console.WriteLine(); // Pindah baris setelah input

        if (char.IsLetter(inputChar))
        {
            char upperChar = char.ToUpper(inputChar);

            // Mengecek apakah huruf adalah vokal
            if (upperChar == 'A' || upperChar == 'I' || upperChar == 'U' || upperChar == 'E' || upperChar == 'O')
            {
                Console.WriteLine($"Huruf '{inputChar}' merupakan huruf vokal.");
            }
            else
            {
                Console.WriteLine($"Huruf '{inputChar}' merupakan huruf konsonan.");
            }
        }
        else
        {
            Console.WriteLine("Input bukan huruf.");
        }
    }

    /// <summary>
    /// Menampilkan 5 bilangan genap pertama dimulai dari 2.
    /// </summary>
    private static void PrintEvenNumbers()
    {
        const int jumlahAngka = 5;
        int[] evenNumbers = new int[jumlahAngka];

        for (int i = 0; i < jumlahAngka; i++)
        {
            evenNumbers[i] = 2 + (2 * i); // Mengisi array dengan bilangan genap
            Console.WriteLine($"Angka genap ke-{i + 1}: {evenNumbers[i]}");
        }
    }
}