namespace matice
{
    class Matice
    {

        double[,] vytvorena_matice;
        int rozmer_m;
        int rozmer_n;

        public enum Operace{radky, sloupce};

        //indexer - aby se k matici dalo pristupovat pomoci indexu
        public double this[int i, int j]
        {
            get { return vytvorena_matice[i, j]; }
            set { vytvorena_matice[i, j] = value; }
        }


        public Matice(int rozmer_m, int rozmer_n)
        {
            double[,] matice = new double[rozmer_m, rozmer_n];
            vytvorena_matice = matice;
            this.rozmer_m = rozmer_m;
            this.rozmer_n = rozmer_n;

            // naplni matici nulami
            for (int i = 0; i < rozmer_m; i++)
            {
                for (int j = 0; j < rozmer_n; j++)
                {
                    matice[i, j] = 0;
                }
            }
        }

        // funkce na naplneni matice cisly
        public void Napln_matici()
        {
            bool plati = true;
            for (int i = 0; i < rozmer_m; i++)
            {
                for (int j = 0; j < rozmer_n; j++)
                {
                    Console.Clear();
                    Vypis_matici();
                    Console.WriteLine();
                    Console.WriteLine($"Jsem na pozici [{i},{j}], zadej cislo: ");
                    vytvorena_matice[i, j] = Double.Parse(Console.ReadLine());
                }
            }
        }

        // funkce na vypsani matice
        public void Vypis_matici()
        {
            for (int i = 0; i < rozmer_m; i++)
            {
                for (int j = 0; j < rozmer_n; j++)
                {
                    Console.Write(vytvorena_matice[i, j] + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static Matice operator +(Matice matice1, Matice matice2)
        {
            if (matice1.rozmer_m == matice2.rozmer_m && matice1.rozmer_n == matice2.rozmer_n)
            {
                double mezivypocet;
                Matice vysledek = new Matice(matice1.rozmer_m, matice1.rozmer_n);
                for (int i = 0; i < matice1.rozmer_m; i++)
                {
                    for (int j = 0; j < matice1.rozmer_n; j++)
                    {
                        vysledek[i, j] = matice1[i, j] + matice2[i, j];
                    }
                }
                return vysledek;
            }
            else return null;

        }

        // pretizeni operatoru na nasobeni
        public static Matice operator *(Matice matice1, Matice matice2)
        {
            if (matice1.rozmer_n == matice2.rozmer_m)
            {
                int m;
                int n;

                int l = 0;

                m = matice1.rozmer_m; // velikost m1
                n = matice2.rozmer_n; // velikost n2

                Matice vysledek = new Matice(m, n);
                double mezivysledek = 0;
                bool plati = true;

                for (int i = 0; i < m; i++) // m = vysledny rozmer m matice
                {
                    for (int j = 0; j < matice1.rozmer_n; j++)
                    {
                        while (plati)
                        {
                            mezivysledek = mezivysledek + (matice1[i, l] * matice2[l, j]);
                            l++;
                            if (l >= n)
                            {
                                plati = false;
                            }
                        }

                        vysledek[i, j] = mezivysledek;
                        Console.WriteLine(vysledek[i, j]);
                        plati = true;
                        l = 0;
                        mezivysledek = 0;
                    }
                }
                return vysledek;
            }
            else return null;
        }

        // funkce na soucet diagonaly
        public double Soucet_diagonaly()
        {
            if (rozmer_m == rozmer_n)
            {
                double vysledek = 0;
                int i = 0;
                int j = 0;

                while (i < rozmer_m && j < rozmer_n)
                {
                    vysledek = vysledek + vytvorena_matice[i,j];
                    i++;
                    j++;
                }
                return vysledek;
            }
            else return -1000;

        }

        // funkce na prohozeni radku a sloupcu
        public void Transpozice(Operace operace, int index1, int index2)
        {
            if(operace == Operace.radky)
            {
                double ulozene_cislo_z_radku;

                for(int i = 0; i < rozmer_n; i++)
                {
                    ulozene_cislo_z_radku = vytvorena_matice[index1,i];
                    vytvorena_matice[index1,i] = vytvorena_matice[index2,i];
                    vytvorena_matice[index2,i] = ulozene_cislo_z_radku;
                }
                Console.Clear();
                Vypis_matici();
            }
            else if (operace == Operace.sloupce)
            {
                double ulozene_cislo_ze_sloupecku;

                for(int i = 0; i < rozmer_m; i++)
                {
                    ulozene_cislo_ze_sloupecku = vytvorena_matice[i,index1];
                    vytvorena_matice[i,index1] = vytvorena_matice[i,index2];
                    vytvorena_matice[i,index2] = ulozene_cislo_ze_sloupecku;
                }
                Console.Clear();
                Vypis_matici();
            }
        }
    }
}