// using System;

// class SayaTubeVideo
// {
//     private int id;
//     private string title;
//     private int playCount;

//     public SayaTubeVideo(string title)
//     {
//         if (string.IsNullOrEmpty(title) || title.Length > 100)
//             throw new ArgumentException("Judul tidak boleh kosong dan maksimal 100 karakter.");

//         this.id = new Random().Next(10000, 99999);
//         this.title = title;
//         this.playCount = 0;
//     }

//     public void IncreasePlayCount(int count)
//     {
//         if (count > 10000000)
//             throw new ArgumentException("Penambahan play count maksimal 10 juta.");

//         checked
//         {
//             if (playCount + count < playCount) // Cek overflow
//                 throw new OverflowException("Play count melebihi batas integer.");

//             playCount += count;
//         }
//     }

//     public void PrintVideoDetails()
//     {
//         Console.WriteLine($"ID: {id}");
//         Console.WriteLine($"Title: {title}");
//         Console.WriteLine($"Play Count: {playCount}");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Marvel Sanjaya Setiawan");
//         video.PrintVideoDetails();

//         try
//         {
//             video.IncreasePlayCount(5000000);
//             video.PrintVideoDetails();

//             video.IncreasePlayCount(15000000); // Akan menimbulkan error
//         }
//         catch (OverflowException e)
//         {
//             Console.WriteLine("Overflow Error: " + e.Message);
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine("Error: " + e.Message);
//         }
//     }
// }

using System;
using System.Diagnostics;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Debug.Assert(!string.IsNullOrEmpty(title) && title.Length <= 100, "Judul video tidak boleh kosong dan maksimal 100 karakter.");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count <= 0 || count > 10000000)
        {
            throw new ArgumentException("Input play count harus antara 1 hingga 10.000.000.");
        }

        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("ERROR: Play count melebihi batas integer.");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }
}

class Program
{
    static void Main()
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Marvel Sanjaya Setiawan");

        try
        {
            for (int i = 0; i < 100; i++)
            {
                video.IncreasePlayCount(100000);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }

        video.PrintVideoDetails();
    }
}