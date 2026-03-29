double EulerovaFunkce(double n)
{
    double a1 = 1;
    double aktualniA;
    double soucet = a1;
    double ziskaniPI;

    for (int i = 2; i < n + 2; i++)
    {
        aktualniA = 1 / Math.Pow(i, 2);
        soucet += aktualniA;
    }

    ziskaniPI = Math.Sqrt(soucet * 6);

    return ziskaniPI;
}

double LeibnizovaFunkce(double n)
{
    int a1 = 1;
    double aktualniA;
    double soucet = a1;
    double ziskaniPI;

    for (int i = 2; i < n + 2; i++)
    {
        aktualniA = Math.Pow(-1, i - 1) / (2 * i - 1);
        soucet += aktualniA;
    }

    ziskaniPI = soucet * 4;
    return ziskaniPI;
}

double VietovaFunkce(double n)
{
    double predchoziA = Math.Sqrt(1.0 / 2);
    double aktualniA;
    double soucin = predchoziA;
    double ziskaniPI;

    for (int i = 2; i < n + 2; i++)
    {
        aktualniA = Math.Sqrt((1.0 / 2) + ((1.0 / 2) * predchoziA));
        predchoziA = aktualniA;
        soucin *= aktualniA;
    }

    ziskaniPI = 2 / soucin;
    return ziskaniPI;
}

void PorovnejFunkce(double pozadovanaPresnost)
{
    bool EulerPridan = false;
    bool LeibnizPridan = false;
    bool VietPridan = false;

    double pi = Math.PI;
    double n = 1000;

    List<(string nazev, double n)> vysledky = new List<(string nazev, double n)>();

    for(int i = 1; i < n && vysledky.Count <3; i++)
    {
        if(Math.Abs(pi - EulerovaFunkce(i)) <= pozadovanaPresnost && EulerPridan==false)
        {
            vysledky.Add(("Eulerovo cislo", i));
            Console.WriteLine("Eulerovo cislo: " + $"n = {i}, {vysledky.Count}.");
            EulerPridan = true;
        }

        if(Math.Abs(pi - LeibnizovaFunkce(i)) <= pozadovanaPresnost && LeibnizPridan==false)
        {
            vysledky.Add(("Leibnizovo cislo", i));
            Console.WriteLine("Leibnizovo cislo: " + $"n = {i}, {vysledky.Count}.");
            LeibnizPridan = true;
        }

        if(Math.Abs(pi - VietovaFunkce(i)) <= pozadovanaPresnost && VietPridan==false)
        {
            vysledky.Add(("Vietovo cislo", i));
            Console.WriteLine("Vietovo cislo: " + $"n = {i}, {vysledky.Count}.");
            VietPridan = true;
        }
    }
}

Console.Clear();
Console.WriteLine("PI: " + Math.PI);
Console.WriteLine();

// Console.WriteLine("eulerova metoda: " + EulerovaFunkce(300));
// Console.WriteLine("Leibnizova metoda: " + LeibnizovaFunkce(600));
// Console.WriteLine("Vietova metoda: " + VietovaFunkce(100));
Console.WriteLine();
Console.WriteLine("Porovnani aproximaci PI: ");
Console.WriteLine();

PorovnejFunkce(0.001);


