using System;

class DoorMachine
{
    private bool isLocked = false;
    private bool isOpen = false;

    public void CurrentState()
    {
        Console.WriteLine($"Pintu {(isLocked ? "terkunci" : "tidak terkunci")} dan {(isOpen ? "terbuka" : "tertutup")}");
    }

    public void ToggleLock()
    {
        isLocked = !isLocked;
        Console.WriteLine($"Pintu sekarang {(isLocked ? "terkunci" : "tidak terkunci")}");
    }

    public void OpenDoor()
    {
        if (isLocked)
        {
            Console.WriteLine("Tidak bisa membuka pintu, karena terkunci!");
        }
        else
        {
            isOpen = true;
            Console.WriteLine("Pintu berhasil dibuka.");
        }
    }

    public void CloseDoor()
    {
        isOpen = false;
        Console.WriteLine("Pintu telah ditutup.");
    }
}