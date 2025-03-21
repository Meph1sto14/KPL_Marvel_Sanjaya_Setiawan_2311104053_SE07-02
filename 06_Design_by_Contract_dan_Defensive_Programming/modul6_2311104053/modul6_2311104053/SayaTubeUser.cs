using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul6_2311104053
{
    class SayaTubeUser
    {
        private string Username;
        private List<SayaTubeVideo> uploadedVideos;

        public SayaTubeUser(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length > 100)
                throw new ArgumentException("Username tidak boleh kosong dan maksimal 100 karakter.");

            this.Username = username;
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
                total += video.PlayCount;
            }
            return total;
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine($"User: {Username}");
            for (int i = 0; i < Math.Min(uploadedVideos.Count, 8); i++)
            {
                Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].Title}");
            }
        }
    }
}
