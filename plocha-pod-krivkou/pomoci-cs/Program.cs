
namespace plocha_pod_krivkou
{
    using System;
    using System.Net.NetworkInformation;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography.X509Certificates;

    enum Funkce { LINEARNI, KONSTANTNI };
    class Program
    {
        static void Main()
        {
            //Console.WriteLine(integral(1,11,50));
            Porovnej(3,10);

        }
        
        static double Vzorec_funkce(double x, Funkce typ_funkce)
        {
            double y = 0;

            if(typ_funkce == Funkce.KONSTANTNI)
            {
                y = 7;
            }
            else if (typ_funkce == Funkce.LINEARNI)
            {
                y = x + 2;
            }

            return y;
        }

        static double Integral(Funkce typ_funkce, double a, double b, int n) //zeptat se na funkci f do parametru integral
        {
            double obsah = 0;
            for (int i = 0; i < n; i++)
            {
                double velikost_jednoho_dilku = (b - a) / n;
                double aktualni_x = a + (velikost_jednoho_dilku) * i;
                obsah = obsah + Vzorec_funkce(aktualni_x, typ_funkce) * (velikost_jednoho_dilku);
            }
            return obsah;
        }

        static void Porovnej(double a, double b)
        {
            double presny_obsah_konstantni = Vzorec_funkce(b, Funkce.KONSTANTNI) * (b - a);
            double presny_obsah_linearni = (Vzorec_funkce(a, Funkce.LINEARNI) + Vzorec_funkce(b, Funkce.LINEARNI)) * (b - a) /2; // vzorec pro vypocet lichobezniku

            Console.WriteLine($"integral konstantni: {Integral(Funkce.KONSTANTNI, a, b, 200)}");
            Console.WriteLine($"presny vypocet konstantni: {presny_obsah_konstantni}");

            Console.WriteLine($"integral linearni: {Integral(Funkce.LINEARNI, a, b, 22000)}");
            Console.WriteLine($"presny vypocet linearni: {presny_obsah_linearni}");
        }
    }
}
