using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        CovidConfig config = CovidConfig.LoadFromFile("covid_config.json");

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu;
        while (!double.TryParse(Console.ReadLine()?.Replace(',', '.'),
                                 NumberStyles.Any, 
                                 CultureInfo.InvariantCulture,
                                 out suhu))
        {
            Console.WriteLine("Input suhu tidak valid. Masukkan angka (gunakan titik sebagai pemisah desimal jika perlu):");
        }

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? (Masukkan angka)");
        int hariDemam;
        while (!int.TryParse(Console.ReadLine(), out hariDemam) || hariDemam < 0)
        {
            Console.WriteLine("Input hari tidak valid. Masukkan angka bulat non-negatif:");
        }

        bool suhuNormal = false;

        if (string.Equals(config.satuan_suhu, "celcius", StringComparison.OrdinalIgnoreCase))
        {
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (string.Equals(config.satuan_suhu, "fahrenheit", StringComparison.OrdinalIgnoreCase))
        {
            suhuNormal = suhu >= 97.7 && suhu <= 99.5;
        }
        else
        {
            Console.WriteLine($"Peringatan: Satuan suhu '{config.satuan_suhu}' dalam konfigurasi tidak dikenali. Pengecekan suhu mungkin tidak akurat.");
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
            Console.WriteLine("Menggunakan rentang suhu Celcius (36.5 - 37.5) sebagai default.");
        }


        bool hariCukup = hariDemam < config.batas_hari_demam;

        if (suhuNormal && hariCukup)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
            if (!suhuNormal)
            {
                Console.WriteLine($"- Suhu badan ({suhu} {config.satuan_suhu}) di luar rentang normal.");
            }
            if (!hariCukup)
            {
                Console.WriteLine($"- Gejala demam terakhir terjadi kurang dari {config.batas_hari_demam} hari yang lalu ({hariDemam} hari).");
            }
        }

        Console.WriteLine("\nTekan Enter untuk mengubah satuan suhu di memori...");
        Console.ReadLine();

        config.UbahSatuan();
        Console.WriteLine($"Satuan suhu telah diubah menjadi: {config.satuan_suhu}");

        Console.WriteLine("\nTekan Enter untuk keluar...");
        Console.ReadLine();
    }
}