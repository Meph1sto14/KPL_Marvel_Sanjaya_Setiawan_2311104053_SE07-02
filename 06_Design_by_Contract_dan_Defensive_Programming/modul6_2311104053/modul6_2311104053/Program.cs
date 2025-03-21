﻿using System;

namespace modul6_2311104053
{
    class Program
    {
        static void Main()
        {
            try
            {
                SayaTubeUser user = new SayaTubeUser("Marvel Sanjaya Setiawan");

                for (int i = 1; i <= 10; i++)
                {
                    SayaTubeVideo video = new SayaTubeVideo($"Review Film {i} oleh Marvel Sanjaya Setiawan");
                    user.AddVideo(video);
                }

                user.PrintAllVideoPlaycount();

                SayaTubeVideo videoTest = new SayaTubeVideo("Test Video");
                videoTest.IncreasePlayCount(25000001);

                user.PrintAllVideoPlaycount();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
