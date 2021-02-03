using System;
namespace ApiSad.Utils
{
    public static class TemperaturaUtil
    {
        static Random rng;

        public static decimal TemperaturaAleatoria()
        {
           if (rng == null)
            {
                rng = new Random();
            }
            return rng.Next(-35, 55);
           
        }
    }
}
