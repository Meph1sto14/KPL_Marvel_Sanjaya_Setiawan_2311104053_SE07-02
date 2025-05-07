using System;

namespace AljabarLibraries
{
    public static class Aljabar
    {
        public static double[] AkarPersamaanKuadrat(double[] persamaan)
        {
            double a = persamaan[0];
            double b = persamaan[1];
            double c = persamaan[2];
            double diskriminan = b * b - 4 * a * c;

            if (diskriminan < 0)
            {
                throw new ArgumentException("Persamaan tidak memiliki akar real.");
            }

            double akar1 = (-b + Math.Sqrt(diskriminan)) / (2 * a);
            double akar2 = (-b - Math.Sqrt(diskriminan)) / (2 * a);
            return new double[] { akar1, akar2 };
        }

        public static double[] HasilKuadrat(double[] persamaan)
        {
            double a = persamaan[0];
            double b = persamaan[1];

            double hasilA = a * a;
            double hasilB = 2 * a * b;
            double hasilC = b * b;

            return new double[] { hasilA, hasilB, hasilC };
        }
    }
}
