using System;

public class ExceptionTest
{
    static double SafeDivision(double x, double y)
    {
        if (y == 0)
            throw new DivideByZeroException();

        return x / y;
    }

    public static void Main()
    {
        // Input untuk pengujian. Ubah nilai a dan b untuk melihat perilaku exception handling.
        double a = 98, b = 0;
        double result;

        try
        {
            result = SafeDivision(a, b);
            Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Attempted to divide by zero.");
        }
    }
}