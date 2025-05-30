using System;

namespace modul13_2311104053
{
    class Program
    {
        static void Main(string[] args)
        {
            PusatDataSingleton data1 = PusatDataSingleton.GetDataSingleton();
            PusatDataSingleton data2 = PusatDataSingleton.GetDataSingleton();

            Console.Write("Masukkan jumlah anggota kelompok (tidak termasuk asisten): ");
            int jumlahAnggota = int.Parse(Console.ReadLine());

            for (int i = 0; i < jumlahAnggota; i++)
            {
                Console.Write($"Masukkan nama anggota ke-{i + 1}: ");
                string anggota = Console.ReadLine();
                data1.AddSebuahData(anggota);
            }

            Console.Write("Masukkan nama asisten praktikum: ");
            string asisten = Console.ReadLine();
            data1.AddSebuahData(asisten);

            Console.WriteLine("\nIsi data dari data2:");
            data2.PrintSemuaData();

            Console.WriteLine("\nMenghapus nama asisten praktikum...");
            data2.HapusSebuahData(data2.GetSemuaData().Count - 1);

            Console.WriteLine("\nIsi data dari data1 setelah penghapusan:");
            data1.PrintSemuaData();

            Console.WriteLine($"\nJumlah data di data1: {data1.GetSemuaData().Count}");
            Console.WriteLine($"Jumlah data di data2: {data2.GetSemuaData().Count}");
        }
    }
}
