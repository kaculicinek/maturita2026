namespace vektor
{
    class Vektor
    {
        private double x;
        private double y;

        public Vektor(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vektor(Bod bod1, Bod bod2)
        {
            x = bod2.vratX() - bod1.vratX();
            y = bod2.vratY() - bod1.vratY();
        }

        public double vratX()
        {
            return x;
        }

        public double vratY()
        {
            return y;
        }

        public static Vektor operator +(Vektor vektor1, Vektor vektor2)
        {
            double x = vektor1.vratX() + vektor2.vratX();
            double y = vektor1.vratY() + vektor2.vratY();
            return new Vektor(x, y);
        }

        public static Vektor operator -(Vektor vektor1, Vektor vektor2)
        {
            double x = vektor1.vratX() - vektor2.vratX();
            double y = vektor1.vratY() - vektor2.vratY();
            return new Vektor(x, y);
        }

        public static Vektor operator -(Vektor vektor)
        {
            return new Vektor(-vektor.vratX(), -vektor.vratY());
        }

        public static Vektor operator *(double cislo, Vektor vektor)
        {
            double x = cislo * vektor.vratX();
            double y = cislo * vektor.vratY();
            return new Vektor(x, y);
        }

        public static double operator *(Vektor vektor1, Vektor vektor2)
        {
            double soucinX = vektor1.vratX() * vektor2.vratX();
            double soucinY = vektor1.vratY() * vektor2.vratY();
            return soucinX + soucinY;
        }

        public double length() // len()
        {
            return Math.Round(Math.Sqrt(Math.Pow(vratX(), 2) + Math.Pow(vratY(), 2)), 3);
        }

        public static double length(Vektor vektor)
        {
            return vektor.length();
        }

        public double odchylka(Vektor vektor) //dev(v)
        {
            double citatel = Math.Abs(this * vektor);
            double jmenovatel = length() * vektor.length();
            double zlomek = citatel / jmenovatel;
            double uhel = Math.Acos(zlomek) * 180 / Math.PI;
            Math.Round(uhel, 3);
            return uhel;
        }

        public static double odchylka(Vektor vektor1, Vektor vektor2)
        {
            return vektor1.odchylka(vektor2);
        }

        public Vektor jednotkovy() //dir()
        {
            double velikost = length();
            double x = this.x / velikost;
            double y = this.y / velikost;
            x = Math.Round(x, 3);
            y = Math.Round(y, 3);
            return new Vektor(x, y);
        }

        public static Vektor jednotkovy(Vektor vektor)
        {
            return vektor.jednotkovy();
        }

        public Vektor normalovy(bool right = true)
        {
            Vektor normalovyVektor;
            if (right)
            {
                normalovyVektor = new Vektor(-y, x);
            }
            else
            {
                normalovyVektor = new Vektor(y, -x);
            }
            return normalovyVektor.jednotkovy();
        }

        public static Vektor normalovy(Vektor vektor)
        {
            return vektor.normalovy();
        }

        public Vektor rotate(double uhel)
        {
            double uhelVRadianech = uhel * Math.PI / 180.0;
            double noveX = x * Math.Cos(uhelVRadianech) - y * Math.Sin(uhelVRadianech);
            double noveY = x * Math.Sin(uhelVRadianech) + y * Math.Cos(uhelVRadianech);
            noveX = Math.Round(noveX, 3);
            noveY = Math.Round(noveY, 3);
            Vektor novy = new Vektor(noveX, noveY);
            return novy;
        }

        public static Vektor rotate(Vektor vektor, double uhel)
        {
            return vektor.rotate(uhel);
        }

        public void Print()
        {
            Console.WriteLine($"({x}, {y})");
        }

        public static void Print(Vektor vektor)
        {
            Console.WriteLine($"({vektor.vratX()}, {vektor.vratY()})");
        }

    }
}