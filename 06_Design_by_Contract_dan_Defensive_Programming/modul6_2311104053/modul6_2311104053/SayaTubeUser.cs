using System;
using System.Collections.Generic;

namespace modul6_2311104053
{
    class SayaTubeUser
    {
        private int id;
        private string username;
        private List<SayaTubeVideo> uploadedVideos;

        public SayaTubeUser(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length > 100)
                throw new ArgumentException("Username tidak boleh kosong dan maksimal 100 karakter.");

            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.username = username;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }

        public void AddVideo(SayaTubeVideo video)
        {
            if (video == null)
                throw new ArgumentNullException("Video tidak boleh null.");

            uploadedVideos.Add(video);
        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (var video in uploadedVideos)
            {
                total += video.GetPlayCount();
            }
            return total;
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine($"\"User: {username}\"");
            for (int i = 0; i < Math.Min(uploadedVideos.Count, 10); i++)
            {
                Console.WriteLine($"\"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}\"");
            }
        }

    }
}
