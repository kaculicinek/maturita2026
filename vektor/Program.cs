namespace vektor
{
    class Program
    {
        static void Main()
        {
            Vektor maly = new Vektor(1, 2, 3);
            Vektor velky = new Vektor(5, 6, 7);

            double velikost_maly = maly.Velikost_vektoru();
            double soucin = maly*velky;
            Vektor novy = maly + velky;

            Console.Clear();
            Console.WriteLine(soucin);
            novy.Vypis_vektor();
            double odchylka = Vektor.Odchylka_vektoru(maly, velky);
            Console.WriteLine(odchylka);
        }
    }
}
