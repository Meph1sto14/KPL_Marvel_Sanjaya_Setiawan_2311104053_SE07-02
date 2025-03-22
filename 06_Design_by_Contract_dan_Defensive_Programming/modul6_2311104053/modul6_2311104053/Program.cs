using System;
using System.Collections.Generic;

namespace modul6_2311104053
{
    class Program
    {
        static void Main(string[] args)
        {
            SayaTubeUser user = new SayaTubeUser("Marvel Sanjaya Setiawan");

            List<string> videoTitles = new List<string>
            {
                "The Dark Knight",
                "Inception",
                "Interstellar",
                "Avengers: Endgame",
                "The Matrix",
                "Spider-Man: No Way Home",
                "Parasite",
                "Joker",
                "Tenet",
                "The Shawshank Redemption"
            };


            List<SayaTubeVideo> videos = new List<SayaTubeVideo>();
            foreach (var title in videoTitles)
            {
                videos.Add(new SayaTubeVideo(title));
            }

            for (int i = 0; i < 10; i++)
            {
                user.AddVideo(videos[i]);
            }

            int[] playCounts = { 4100000, 7000000, 4600000, 6200000, 5300000, 3700000, 4800000, 8300000 };
            for (int i = 0; i < playCounts.Length; i++)
            {
                videos[i].IncreasePlayCount(playCounts[i]);
            }

            user.PrintAllVideoPlaycount();

            Console.WriteLine("\nTesting IncreasePlayCount...");
            SayaTubeVideo testVideo = new SayaTubeVideo("Test Video");
            testVideo.IncreasePlayCount(11500000);
            testVideo.PrintVideoDetails();

            Console.WriteLine("\nTesting Overflow...");
            try
            {
                testVideo.IncreasePlayCount(26000000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
