class Penjumlahan
{
    public static T JumlahTigaAngka<T>(T a, T b, T c) where T : struct
    {
        dynamic x = a, y = b, z = c;
        return x + y + z;
    }
}
