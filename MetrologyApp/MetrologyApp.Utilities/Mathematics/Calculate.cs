using MetrologyApp.Models;
using MetrologyApp.Utilities;

namespace MetrologyApp.Mathematics
{
    public static class Calculate
    {
        public static double Deviation(NominalPoint np, ActualPoint ap)
        {

            return Math.Sqrt(
                Math.Pow((ap.X - np.X), 2) +
                Math.Pow((ap.Y - np.Y), 2) +
                Math.Pow((ap.Z - np.Z), 2)
                );
        }

        public static double AveragePoint(double x, int i)
        {
            return x / i;
        }
    }
}
