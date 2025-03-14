using System;

namespace modul4_2311104053
{
    public class PosisiKarakterGame
    {
        private string state = "Berdiri";
        private readonly int nimMod;

        public PosisiKarakterGame(long nim)
        {
            nimMod = (int)(nim % 3); // Menghitung hasil mod dari NIM
        }

        public void TekanTombol(char tombol)
        {
            if (nimMod == 0)
            {
                if (tombol == 'S') Console.WriteLine("Tombol arah bawah ditekan");
                if (tombol == 'W') Console.WriteLine("Tombol arah atas ditekan");
            }

            if (state == "Berdiri" && tombol == 'S')
            {
                state = "Jongkok";
                Console.WriteLine("State berubah menjadi: Jongkok");
            }
            else if (state == "Jongkok" && tombol == 'W')
            {
                state = "Berdiri";
                Console.WriteLine("State berubah menjadi: Berdiri");
                if (nimMod == 1) Console.WriteLine("Posisi standby");
            }
            else if (state == "Jongkok" && tombol == 'X')
            {
                state = "Terbang";
                Console.WriteLine("State berubah menjadi: Terbang");
                if (nimMod == 2) Console.WriteLine("Posisi take off");
            }
            else if (state == "Terbang" && tombol == 'S')
            {
                state = "Berdiri";
                Console.WriteLine("State berubah menjadi: Berdiri");
            }
            else if (state == "Terbang" && tombol == 'J')
            {
                state = "Jongkok";
                Console.WriteLine("State berubah menjadi: Jongkok");
                if (nimMod == 2) Console.WriteLine("Posisi landing");
            }
            else if (state == "Berdiri" && tombol == 'W')
            {
                state = "Tengkurap";
                Console.WriteLine("State berubah menjadi: Tengkurap");
                if (nimMod == 1) Console.WriteLine("Posisi istirahat");
            }
            else
            {
                Console.WriteLine("Input tombol tidak valid!");
            }
        }

        public void PrintState()
        {
            Console.WriteLine($"State saat ini: {state}");
        }
    }
}
