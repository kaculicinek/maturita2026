namespace vektor
{
    class Program
    {
        static void Main()
        {
            Vektor vektor1 = new Vektor(3, 5);
            Vektor vektor2 = new Vektor(0, 1);

            Vektor scitaniVektoru = vektor1 + vektor2;
            Vektor odcitaniVektoru = vektor1 - vektor2;
            Vektor opacny = -vektor2;
            Vektor soucinVS = 4 * vektor1;
            double soucinVV = vektor1 * vektor2;

            Bod a = new Bod(0, 0);
            Bod b = new Bod(5, 0);
            Bod c = new Bod(2, 5);
            

            Vektor.Print(scitaniVektoru);
            Vektor.Print(odcitaniVektoru);
            Vektor.Print(opacny);
            Vektor.Print(soucinVS);

            Console.WriteLine(soucinVV);
            soucinVS.Print();
            Console.WriteLine(Vektor.length(vektor1));
            Console.WriteLine(vektor2.length());
            Console.WriteLine(vektor1.odchylka(vektor2));
            Console.WriteLine(Vektor.odchylka(vektor1, vektor2));

            Vektor.Print(vektor1.jednotkovy());
            Vektor.Print(opacny);
            Vektor.Print(vektor1.normalovy(false));
            Vektor.Print(vektor1.rotate(30));

            

            delkaUsecky(a, b);
            stredUsecky(a,b);
            obsahTrojuhelniku(a, b, c);
            jePravouhly(a,b,c);
            otoceni(a, b, c);

            void delkaUsecky(Bod A, Bod B)
            {
                Vektor vektor = new Vektor(A, B);
                Console.WriteLine("velikost usecky: "+vektor.length());
                
            }

            void stredUsecky(Bod a, Bod b)
            {
                double stredX = (a.vratX() + b.vratX()) / 2;
                double stredY = (a.vratY() + b.vratY()) / 2;
                Bod stred = new Bod(stredX, stredY);
                Console.WriteLine("stred usecky: " + $"[{stredX}, {stredY}]");
            }

            void jePravouhly(Bod A, Bod B, Bod C)
            {
                Vektor AB = new Vektor(A, B);
                Vektor BC = new Vektor(B, C);
                Vektor AC = new Vektor(A, C);

                double soucinA = AB*BC;
                double soucinB = AB*AC;
                double soucinC = BC*AC;

                if(soucinA == 0 || soucinB == 0 || soucinC == 0)
                {
                    Console.WriteLine("trojuhlenik ABC je pravouhly");
                }
                else
                {
                    Console.WriteLine("trojuhelnik ABC neni pravouhly");
                }

            }

            void obsahTrojuhelniku(Bod A, Bod B, Bod C)
            {
                Vektor AB = new Vektor(A, B);
                Vektor BC = new Vektor(B, C);
                Vektor AC = new Vektor(A, C);

                double delkaAB = AB.length();
                double delkaBC = BC.length();
                double delkaAC = AC.length();

                double pulkaObvodu = (delkaAB + delkaBC + delkaAC) /2.0;

                double obsah = Math.Sqrt(pulkaObvodu*(pulkaObvodu - delkaAB)*(pulkaObvodu - delkaBC)*(pulkaObvodu - delkaAC));
                obsah = Math.Round(obsah, 2);
                Console.WriteLine("Obsah trojuhelniku ABC: " + obsah);
            }

            void otoceni(Bod a, Bod b, Bod c)
            {
                Vektor AB = new Vektor(a, b);
                Vektor AC = new Vektor(a, c);

                Vektor otocenyAB = AB.rotate(90);
                Vektor otocenyAC = AC.rotate(90);

                double bx = a.vratX() + otocenyAB.vratX(); 
                double by = a.vratY() + otocenyAB.vratY();

                double cx = a.vratX() + otocenyAC.vratX(); 
                double cy = a.vratY() + otocenyAC.vratY();

                Bod B = new Bod(bx, by);
                Bod C = new Bod(cx, cy);

                Console.WriteLine("Souradnice otocenych bodu: " + $"A[{a.vratX()}, {a.vratY()}] "+ $"B[{bx}, {by}] " + $"C[{cx}, {cy}]");

            }

        }
    }
}