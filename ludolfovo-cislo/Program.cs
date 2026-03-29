
using System.IO.Pipes;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

double eulerovo_cislo(int n)
{
    double vysledek = 0;
    double mezivysledek = 0;
    int a_1 = 1;
    for (int i = 0; i < n; i++)
    {
        double vzorecek = 1 / (Math.Pow(a_1, 2));
        mezivysledek += vzorecek;
        a_1 += 1;
    }

    vysledek = Math.Sqrt(mezivysledek * 6);

    return vysledek;
}

double Leibnizovo_cislo(int n)
{
    double vysledek = 0;
    double mezivysledek = 0;
    int a_1 = 1;
    for (int i = 0; i < n; i++)
    {
        double vzorecek = Math.Pow(-1, a_1 - 1) / (2 * a_1 - 1);
        mezivysledek += vzorecek;
        a_1 += 1;
    }

    vysledek = mezivysledek * 4;

    return vysledek;
}

double vietovo_cislo(int n)
{
    double vysledek;
    double a_1 = Math.Sqrt(1.0 / 2);
    double a_predchozi = a_1;
    double mezivysledek = a_1;

    for (int i = 0; i < n; i++)
    {
        double a_n = Math.Sqrt(1.0 / 2 + (1.0 / 2) * a_predchozi);
        a_predchozi = a_n;
        mezivysledek = mezivysledek * a_n;
    }

    vysledek = 2 / mezivysledek;

    return vysledek;
}

// = a1 * a2 * a3 * ... an
// Math.PI
// presnost na x deset mist = napr. 4 => hledam PI 3.1415
// 1..10000
// fce1 => N=56
// fce2 => N=2000
// fce3 => N=400

///
/// Priklad:
///     pozadovana_presnost < (Math.PI - x)
///     0.01 < 3.1415926 - 3.561 => FALSE
///     0.01 < 3.1415926 - 3.422 => FALSE
///     0.01 < 3.1415926 - 3.138 => TRUE
// bool ma_pi_dostatecnou_presnost(double x, double pozadovana_presnost) {}

// void porovnavani_funkci(int pocet_desetinnych_mist)
// {
// fce1, fce2, fce3 pro vypocet PI

// vypocitej PI pomoci fce1 s presnosti na pocet_desetinnych_mist
//      volej fce1 se zvysujicim se poctem iteraci dokud nedostanu PI s danou presnosti    

// vypocitej PI pomoci fce2 s presnosti na pocet_desetinnych_mist

// vypocitej PI pomoci fce3 s presnosti na pocet_desetinnych_mist

// serad fce1, fce2, fce3 podle toho, kolik potrebovali iteraci k dosazeni PI s danou presnosti

// }


void porovnavani_funkci(int pocet_desetinnych_mist)
{
    //seradit funkce podle nejnizsiho cisla (n) ktere dojde k vysledku
    double euler;
    double leibniz;
    double viet;

    double pi = Math.PI;
    string pi_ve_string = pi.ToString();
    int cela_delka_pi = pi_ve_string.Count();
    string pozadovana_delka_pi = pi_ve_string.Remove(pocet_desetinnych_mist + 2);
    
    Console.WriteLine("Pozadovana presnost pi: " + pozadovana_delka_pi);
    Console.WriteLine();

    int n_euler = 0;
    int n_leibniz = 0;
    int n_viet = 0;

    for (int i = 1; n_euler == 0 || n_leibniz == 0 || n_viet == 0; i++)
    {
        if (n_euler == 0)
        {
            euler = eulerovo_cislo(i);
            if (euler.ToString().StartsWith(pozadovana_delka_pi) && n_euler == 0)
            {
                n_euler = i;
            }
        }
        if (n_leibniz == 0)
        {
            leibniz = Leibnizovo_cislo(i);
            if (leibniz.ToString().StartsWith(pozadovana_delka_pi) && n_leibniz == 0)
            {
                n_leibniz = i;
            }
        }

        if (n_viet == 0)
        {
            viet = vietovo_cislo(i);
            if (viet.ToString().StartsWith(pozadovana_delka_pi) && n_viet == 0)
            {
                n_viet = i;
            }
        }
    }

    string nejrychlejsi = "";
    string prostredni = "";
    string nejpomalejsi = "";

    int[] vysledky =  {n_euler, n_leibniz, n_viet };
    Array.Sort(vysledky);

    if (vysledky[0] == n_euler)
    {
        nejrychlejsi = $"Eulerova posloupnost {n_euler} clenu";
    }
    else if(vysledky[0] == n_leibniz)
    {
        nejrychlejsi = $"Leibnizova posloupnst {n_leibniz} clenu";
    }
    else if(vysledky[0] == n_viet)
    {
        nejrychlejsi = $"Vietova posloupnost {n_viet} clenu";
    }

    if (vysledky[1] == n_euler)
    {
        prostredni = $"Eulerova posloupnost {n_euler} clenu";
    }
    else if(vysledky[1] == n_leibniz)
    {
        prostredni = $"Leibnizova posloupnst {n_leibniz} clenu";
    }
    else if(vysledky[1] == n_viet)
    {
        prostredni = $"Vietova posloupnost {n_viet} clenu";
    }

    if (vysledky[2] == n_euler)
    {
        nejpomalejsi = $"Eulerova posloupnost {n_euler} clenu";
    }
    else if(vysledky[2] == n_leibniz)
    {
        nejpomalejsi = $"Leibnizova posloupnst {n_leibniz} clenu";
    }
    else if(vysledky[2] == n_viet)
    {
        nejpomalejsi = $"Vietova posloupnost {n_viet} clenu";
    }

    Console.WriteLine("Nejrychlejsi: " + nejrychlejsi);
    Console.WriteLine("Prostredni: " + prostredni);
    Console.WriteLine("Nejpomalejsi: " + nejpomalejsi);
    Console.WriteLine();

}

Console.Clear();
Console.WriteLine("Eulerovo cislo: " + eulerovo_cislo(11000));
Console.WriteLine("Leibnizovo cislo: " + Leibnizovo_cislo(500));
Console.WriteLine("Vietovo cislo: " + vietovo_cislo(3));
Console.WriteLine();
porovnavani_funkci(4);