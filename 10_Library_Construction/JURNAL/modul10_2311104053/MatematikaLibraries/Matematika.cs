using System;
using System.Text;

namespace MatematikaLibraries
{
    public static class Matematika
    {
        public static int FPB(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static int KPK(int a, int b)
        {
            return (a * b) / FPB(a, b);
        }

        public static string Turunan(int[] koefisien)
        {
            StringBuilder hasil = new StringBuilder();
            int derajatAwal = koefisien.Length - 1;

            for (int i = 0; i < koefisien.Length - 1; i++)
            {
                int pangkatBaru = derajatAwal - i - 1;
                int koefTurunan = koefisien[i] * (derajatAwal - i);

                if (koefTurunan == 0)
                    continue;

                if (hasil.Length > 0)
                    hasil.Append(koefTurunan > 0 ? " + " : " - ");
                else if (koefTurunan < 0)
                    hasil.Append("-");

                int absKoef = Math.Abs(koefTurunan);
                if (absKoef != 1 || pangkatBaru == 0)
                    hasil.Append(absKoef);

                if (pangkatBaru > 1)
                    hasil.Append($"x{pangkatBaru}");
                else if (pangkatBaru == 1)
                    hasil.Append("x");
            }

            return hasil.ToString();
        }


        public static string Integral(int[] koefisien)
        {
            StringBuilder hasil = new StringBuilder();
            int pangkat = koefisien.Length;

            for (int i = 0; i < koefisien.Length; i++)
            {
                double nilai = (double)koefisien[i] / pangkat;

                if (hasil.Length > 0)
                    hasil.Append(nilai > 0 ? " + " : " - ");
                else if (nilai < 0)
                    hasil.Append("-");

                double absNilai = Math.Abs(nilai);
                if (absNilai != 1)
                    hasil.Append($"{absNilai}");

                if (pangkat > 1)
                    hasil.Append($"x{pangkat}");
                else if (pangkat == 1)
                    hasil.Append("x");

                pangkat--;
            }

            hasil.Append(" + C");
            return hasil.ToString();
        }

    }
}
