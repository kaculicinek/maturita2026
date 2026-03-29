using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace vektor
{
    class Vektor
    {
        private double a;
        private double b;
        private double c;

        public Vektor(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public static Vektor operator +(Vektor vektor1, Vektor vektor2)
        {
            double x;
            double y;
            double z;

            x = vektor1.a + vektor2.a;
            y = vektor1.b + vektor2.b;
            z = vektor1.c + vektor2.c;

            return new Vektor(x, y, z);
        }

        public static double operator *(Vektor vektor1, Vektor vektor2)
        {
            double x;
            double y;
            double z;

            double soucin;

            x = vektor1.a * vektor2.a;
            y = vektor1.b * vektor2.b;
            z = vektor1.c * vektor2.c;

            soucin = x + y + z;

            return soucin;
        }

        public static double Odchylka_vektoru(Vektor vektor1, Vektor vektor2)
        {
            double odchylka;

            odchylka = Math.Acos((vektor1 * vektor2) /(vektor1.Velikost_vektoru()*vektor2.Velikost_vektoru()));
            odchylka = odchylka * 180 / Math.PI; // prevod z radianu na stupne

            return odchylka;
        }

        public double Velikost_vektoru()
        {
            double velikost;
            double x = a;
            double y = b;
            double z = c;

            velikost = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));

            return velikost;
        }

        public void Vypis_vektor()
        {
            Console.WriteLine($"({a}, {b}, {c})");
        }
    }
}