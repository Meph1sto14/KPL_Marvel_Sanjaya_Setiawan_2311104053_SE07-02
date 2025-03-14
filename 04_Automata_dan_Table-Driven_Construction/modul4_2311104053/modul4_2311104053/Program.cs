using System;

namespace modul4_2311104053
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bagian Table-Driven Technique
            Console.Write("Masukkan nama buah: ");
            string buah = Console.ReadLine();

            string kode = KodeBuah.GetKodeBuah(buah);
            Console.WriteLine($"Kode buah {buah}: {kode}");

            Console.WriteLine();

            // Bagian State-Based Construction
            Console.Write("Masukkan NIM: ");
            long nim = long.Parse(Console.ReadLine());

            PosisiKarakterGame karakter = new PosisiKarakterGame(nim);

            // Simulasi State
            Console.WriteLine("Simulasi perubahan state karakter:");
            Console.WriteLine("State awal: Berdiri");

            karakter.TekanTombol('S'); // Berdiri -> Jongkok
            karakter.PrintState();

            karakter.TekanTombol('X'); // Jongkok -> Terbang
            karakter.PrintState();

            karakter.TekanTombol('S'); // Terbang -> Berdiri
            karakter.PrintState();

            karakter.TekanTombol('W'); // Berdiri -> Tengkurap
            karakter.PrintState();

            karakter.TekanTombol('S'); // Tengkurap -> Berdiri
            karakter.PrintState();

            karakter.TekanTombol('J'); // Berdiri -> Jongkok
            karakter.PrintState();
        }
    }
}
