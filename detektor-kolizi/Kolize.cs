using BasicGraphicsEngine;
using System.Numerics;

namespace ProjectApp
{
    internal static class Kolize
    {
        public static bool Kolize2Kruhu(Circle kruh1, Circle kruh2)
        {
            bool kolize = false;
            // ziskani stredu kruhu
            Vector2 stred1 = kruh1.GetPosition2D();
            Vector2 stred2 = kruh2.GetPosition2D();
            Vector2 rozdilStredu = stred1 - stred2;
            float vzdalenostStredu = rozdilStredu.Length();

            // velikosti polomeru soucet
            float polomer1 = kruh1.GetRadius();
            float polomer2 = kruh2.GetRadius();
            float soucetPolomeru = polomer1 + polomer2;

            if(vzdalenostStredu <= soucetPolomeru)
            {
                kolize = true;
            }
            else kolize = false;
            // vzdalenost stredu
            // je vzdalenost stredu <= souctu polomeru pak je kolize true
            return kolize;
        }

        public static bool Kolize2Obdelniku(Quad obdelnik1, Quad obdelnik2)
        {
            bool kolize = false;

            float sirka1 = obdelnik1.GetWidth();
            float vyska1 = obdelnik1.GetHeight();
            float sirka2 = obdelnik2.GetWidth();
            float vyska2 = obdelnik2.GetHeight();

            Vector2 stred1 = obdelnik1.GetPosition2D();
            Vector2 stred2 = obdelnik2.GetPosition2D();

            float vzdalenostStreduX = Math.Abs(stred1.X - stred2.X);
            float vzdalenostStreduY = Math.Abs(stred1.Y - stred2.Y);

            float soucetPolovinSirek = (sirka1 + sirka2) /2;
            float soucetPolovinVysek = (vyska1 + vyska2) /2;

            if((vzdalenostStreduX <= soucetPolovinSirek)&&(vzdalenostStreduY<=soucetPolovinVysek))
            {
                kolize = true;
            }
            return kolize;
        }

        public static bool KolizeKruhuAObdelniku(Circle kruh, Quad obdelnik)
        {
            bool kolize = false;

            Vector2 stredObdelniku = obdelnik.GetPosition2D();
            Vector2 stredKruhu = kruh.GetPosition2D();

            float sirkaObdelniku = obdelnik.GetWidth();
            float vyskaObdelniku = obdelnik.GetHeight();
            float polomerKruhu = kruh.GetRadius();

            // VYPOCET PREKRYTI PRO KRUH A OBDELNIK
            // promenne pro jednotlive hrany obdelniku
            // rozdil vzdalenosti nejblizsiho bou x a y od stredu kruhu x a y
            // prekryv zjistim rozdilem - plus nebo minus u vysledku (bod-polomer) minus=je prekryv, plus=neni prekryv

            float levyOkraj = stredObdelniku.X - sirkaObdelniku/2;
            float pravyOkraj = stredObdelniku.X + sirkaObdelniku/2;
            float horniOkraj = stredObdelniku.Y + vyskaObdelniku/2;
            float dolniOkraj = stredObdelniku.Y - vyskaObdelniku/2;

            float nejblizsiX;
            float nejblizsiY;

            if(stredKruhu.X < levyOkraj)
            {
                nejblizsiX = levyOkraj;
            }
            else if(stredKruhu.X > pravyOkraj)
            {
                nejblizsiX = pravyOkraj;
            }
            else nejblizsiX = stredKruhu.X;


            if(stredKruhu.Y < dolniOkraj)
            {
                nejblizsiY = dolniOkraj;
            }
            else if(stredKruhu.Y > horniOkraj)
            {
                nejblizsiY = horniOkraj;
            }
            else nejblizsiY = stredKruhu.Y;

            float rozdilX = nejblizsiX - stredKruhu.X;
            float rozdilY = nejblizsiY - stredKruhu.Y;

            double velikostVektoruRozdilu = Math.Sqrt(Math.Pow(rozdilX, 2) + Math.Pow(rozdilY, 2));
            double rozdilVzdalenostiStreduABodu = velikostVektoruRozdilu - polomerKruhu;

            if (rozdilVzdalenostiStreduABodu <= 0)
            {
                kolize = true;
            }
            // velikost vektoru rozdilX, rozdilYx

            return kolize;
        }


        public static bool KolizeObjektu(DrawableObject obj1, DrawableObject obj2)
        {
            bool kolize = false;

            if(obj1 is Quad && obj2 is Circle){
                kolize = KolizeKruhuAObdelniku((Circle)obj2, (Quad)obj1);
            }
            else if(obj1 is Circle && obj2 is Quad)
            {
                kolize = KolizeKruhuAObdelniku((Circle)obj1, (Quad)obj2);
            }
            else if(obj1 is Circle && obj2 is Circle)
            {
                kolize = Kolize2Kruhu(obj1 as Circle, (Circle)obj2);
            }
            else if(obj1 is Quad && obj2 is Quad)
            {
                kolize = Kolize2Obdelniku((Quad)obj1, (Quad)obj2);
            }
            else kolize = false;

            return kolize;
        }

        public static void DetectCollisions(List<DrawableObject> listObjektu)
        {
            bool kolize;

            Console.WriteLine("Automaticka detekce kolizi: ");

            for(int i = 0; i<listObjektu.Count; i++)
            {
                for(int j = i+1; j<listObjektu.Count; j++)
                {
                    kolize = KolizeObjektu(listObjektu[i], listObjektu[j]);
                    if(kolize == true)
                    {
                        App.ZmenBarvu(listObjektu[i]);
                        App.ZmenBarvu(listObjektu[j]);
                        Console.WriteLine("Kolize zaznamenana: " + listObjektu[i] + " " + listObjektu[j]);
                    }
                }
            }
        }
    }
}