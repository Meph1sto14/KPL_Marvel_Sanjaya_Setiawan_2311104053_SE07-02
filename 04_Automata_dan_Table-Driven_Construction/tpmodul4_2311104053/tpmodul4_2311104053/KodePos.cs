using System;
using System.Collections.Generic;

class KodePos
{
    private static readonly Dictionary<string, string> kodePosMap = new Dictionary<string, string>
    {
        {"Batununggal", "40266"},
        {"Kujangsari", "40287"},
        {"Mengger", "40267"},
        {"Wates", "40256"},
        {"Cijaura", "40287"},
        {"Jatisari", "40286"},
        {"Margasari", "40286"},
        {"Sekejati", "40286"},
        {"Kebonwaru", "40272"},
        {"Maleer", "40274"},
        {"Samoja", "40273"}
    };

    public static void TampilkanSemuaKodePos()
    {
        Console.WriteLine("===== DAFTAR KODE POS =====");
        foreach (var entry in kodePosMap)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Menampilkan semua kode pos tanpa input
        KodePos.TampilkanSemuaKodePos();

        // Program Door Machine
        Console.WriteLine("\n===== PROGRAM DOOR MACHINE =====");
        DoorMachine pintu = new DoorMachine();

        pintu.CurrentState();  // Menampilkan status awal
        pintu.ToggleLock();    // Mengubah status kunci
        pintu.OpenDoor();      // Mencoba membuka pintu
        pintu.CloseDoor();     // Menutup pintu kembali
        pintu.ToggleLock();    // Mengunci pintu kembali

        Console.WriteLine("\nProgram selesai. Tekan Enter untuk keluar.");
        Console.ReadLine();
    }
}