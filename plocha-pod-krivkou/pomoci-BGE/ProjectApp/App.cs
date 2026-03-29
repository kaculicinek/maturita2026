using BasicGraphicsEngine; // Grafické vykreslování.
using System.Numerics;     // Integrovaná implementace vektorů, matic a jejich operací. 
using System.Drawing;
using System.Xml;      // Integrovaná implementace barev kompatibilní s BasicGraphicsEngine.


namespace ProjectApp
{

    internal class App : Application
    {
        public App(string title, uint viewportWidth, uint viewportHeight) : base(title, viewportWidth, viewportHeight)
        {
            Settings.BackgroundColor = Color.WhiteSmoke;
            Settings.CameraSceneHeight = 35;
        }

        public float pocatecniXOsy = -20f;
        public float pocatecniYOsy = -15f;

        List<DrawableObject> ObjektyVeScene = new List<DrawableObject>();

        public override void Setup()
        {
            // Pracovní úkol 1: vytvoření všech požadovaných dvojic objektů ve scéně.
            VytvorScenu();
            // Pracovní úkol 3: ruční ověření kolizí mezi relevantními dvojicemi.
            DrawFunction(10, 30, 5f);
            //Settings.CameraPosition = new Vector3(-10, 20, 0);

        }

        public override void Loop(float dt)
        {

        }

        private void VytvorScenu()
        {
            Line osaX = new Line(new Vector3(-20f, -15f, 0f), new Vector3(40f, 0f, 0f), 0.08f, Color.Black);
            Line osaY = new Line(new Vector3(-20f, -15f, 0f), new Vector3(0f, 30f, 0f), 0.08f, Color.Black);
            pridejDoSceny(osaX);
            pridejDoSceny(osaY);

            // Particle bod = new Particle(new Vector3(-10, -10, 0), 15f, Color.Black);
            // pridejDoSceny(bod);
        }

        void pridejDoSceny(DrawableObject obj)
        {
            ObjektyVeScene.Add(obj);
            AddObject(obj);
        }

        public static void ZmenBarvu(DrawableObject obj1)
        {
            obj1.SetColor(Color.Red);
        }
        // Func<float, float, float, float> funkce
        public void DrawFunction(float intervalZacatek, float intervalKonec, float pocetDeleniIntervalu)
        {

            float interval = intervalKonec - intervalZacatek;
            float velikostDilku = interval / pocetDeleniIntervalu;

            float x = pocatecniXOsy + intervalZacatek;
            float y = pocatecniYOsy;

            float plochaPodKrivkou = 0;
            // var vysledek = func(a, b, x);

            for (int i = 0; i < pocetDeleniIntervalu; i++)
            {
                float posun = intervalZacatek + i * velikostDilku;
                float hodnotaY = SpocitejHodnotuFunkce(0.5f, 10f, posun); //rika pro jakou funkci a jake x ma y spocitat
                y = pocatecniYOsy + hodnotaY;

                Particle bod = new Particle(new Vector3(x, y, 0), 15f, Color.Black);
                Bar bar = new Bar(new Vector3(pocatecniXOsy + posun, pocatecniYOsy , 0f), new Vector3(0, hodnotaY, 0f), velikostDilku*0.46f, Color.Violet);

                // TODO: posunout grafy o pulku velikosti dilku aby neprecihoval prvni graf
                plochaPodKrivkou += bar.GetArea();

                pridejDoSceny(bar);
                pridejDoSceny(bod);
                x += velikostDilku;
            }

            Console.WriteLine("Plocha pod krivkou: " + plochaPodKrivkou);

        }

        public float SpocitejHodnotuFunkce(float a, float b, float x)
        {
            float y = a * x + b;
            return y;
        }


    }

}
