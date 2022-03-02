using MetrologyApp.Models;

namespace MetrologyApp.Mathematics
{
    public static class Calculate
    {
        public static double Deviation(NominalPoint np, ActualPoint ap)
        {
            if(np != null && ap != null)
            {
                if((ap.X > 0) && (ap.Y > 0) && (ap.Z > 0) && (np.X > 0) && (np.Y > 0) && (np.Z > 0))
                {
                    return Math.Sqrt(
                    Math.Pow((ap.X - np.X), 2) +
                    Math.Pow((ap.Y - np.Y), 2) +
                    Math.Pow((ap.Z - np.Z), 2)
                    );
                }

            }

         return -1;


        }

        public static double AveragePoint(double x, int i)
        {
            if(x > 0 && i > 0)
                return x / i;

            return -1;
        }
    }
}
