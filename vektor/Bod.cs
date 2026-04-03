
namespace vektor
{
    public class Bod
    {
        private double x;
        private double y;

        public Bod(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double vratX()
        {
            return this.x;
        }
        public double vratY()
        {
            return this.y;
        }
    }
}