using System;

namespace modul6_2311104053
{
    class Program
    {
        static void Main(string[] args)
        {
            SayaTubeUser user = new SayaTubeUser("Marvel Sanjaya Setiawan");

            user.AddVideo(new SayaTubeVideo("The Dark Knight"));
            user.AddVideo(new SayaTubeVideo("Inception"));
            user.AddVideo(new SayaTubeVideo("Interstellar"));
            user.AddVideo(new SayaTubeVideo("Avengers: Endgame"));
            user.AddVideo(new SayaTubeVideo("The Matrix"));
            user.AddVideo(new SayaTubeVideo("Spider-Man: No Way Home"));
            user.AddVideo(new SayaTubeVideo("Parasite"));
            user.AddVideo(new SayaTubeVideo("Joker"));
            user.AddVideo(new SayaTubeVideo("Tenet"));
            user.AddVideo(new SayaTubeVideo("The Shawshank Redemption"));

            user.PrintAllVideoPlaycount();

            Console.ReadKey();
        }
    }
}
