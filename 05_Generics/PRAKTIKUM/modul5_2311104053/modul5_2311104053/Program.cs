using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<int> arr = new List<int> { 0, 1, 2, 3, 4 }; // Gunakan List<int> sebagai pengganti array
        List<int> list = new List<int>();
        for (int x = 5; x < 10; x++)
        {
            list.Add(x);
        }
        ProcessItems<int>(arr);
        ProcessItems<int>(list);
    }

    static void ProcessItems<T>(IList<T> coll)
    {
        // IsReadOnly returns True for array-based collections and False for List<T>.
        Console.WriteLine("IsReadOnly returns {0} for this collection.", coll.IsReadOnly);

        // Hapus elemen ke-4 jika koleksi tidak read-only
        if (!coll.IsReadOnly)
        {
            coll.RemoveAt(4);
        }

        foreach (T item in coll)
        {
            Console.Write(item.ToString() + " ");
        }
        Console.WriteLine();
    }
}