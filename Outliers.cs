using System;
using System.Linq;

class Program
{
    static double Percentile(double[] data, double p)
    {
        double index = (p / 100.0) * (data.Length - 1);
        int lower = (int)Math.Floor(index);
        int upper = (int)Math.Ceiling(index);
        if (lower == upper) return data[lower];
        return data[lower] + (data[upper] - data[lower]) * (index - lower);
    }

    static void Main()
    {
        int[] data = {
            115, 182, 191, 31, 196, 1099, 5, 172, 10, 179,
            83, 21, 20, 21, 186, 177, 195, 193, 188, 199,
            62, 109, 105, 183, 110
        };

        Array.Sort(data);

        double[] d = data.Select(x => (double)x).ToArray();

        double q1 = Percentile(d, 25);
        double q3 = Percentile(d, 75);

        double iqr = q3 - q1;

        double lower = q1 - 1.5 * iqr;
        double upper = q3 + 1.5 * iqr;

        foreach (var x in data)
        {
            if (x < lower || x > upper)
                Console.WriteLine(x + " Outlier");
            else
                Console.WriteLine(x + " Normal");
        }
    }
}