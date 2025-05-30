using System;
using System.Collections.Generic;

namespace modul13_2311104053
{
    public sealed class PusatDataSingleton
    {
        private static PusatDataSingleton _instance;
        public List<string> DataTersimpan;

        private PusatDataSingleton()
        {
            DataTersimpan = new List<string>();
        }

        public static PusatDataSingleton GetDataSingleton()
        {
            if (_instance == null)
            {
                _instance = new PusatDataSingleton();
            }
            return _instance;
        }

        public List<string> GetSemuaData()
        {
            return DataTersimpan;
        }

        public void PrintSemuaData()
        {
            Console.WriteLine("Isi data:");
            foreach (var data in DataTersimpan)
            {
                Console.WriteLine($"- {data}");
            }
        }

        public void AddSebuahData(string input)
        {
            DataTersimpan.Add(input);
        }

        public void HapusSebuahData(int index)
        {
            if (index >= 0 && index < DataTersimpan.Count)
            {
                DataTersimpan.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Index tidak valid.");
            }
        }
    }
}
