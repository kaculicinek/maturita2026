using BasicGraphicsEngine; // Grafické vykreslování.
using System.Numerics;     // Integrovaná implementace vektorů, matic a jejich operací. 
using System.Drawing;      // Integrovaná implementace barev kompatibilní s BasicGraphicsEngine.


namespace ProjectApp;

internal class App : Application
{
    public App(string title, uint viewportWidth, uint viewportHeight) : base(title, viewportWidth, viewportHeight)
    {
        Settings.BackgroundColor = Color.WhiteSmoke;
        Settings.CameraSceneHeight = 35;
    }

    List<DrawableObject> ObjektyVeScene = new List<DrawableObject>();

    public override void Setup()
    {
        // Pracovní úkol 1: vytvoření všech požadovaných dvojic objektů ve scéně.
        VytvorScenu();
        // Pracovní úkol 3: ruční ověření kolizí mezi relevantními dvojicemi.
        Kolize.DetectCollisions(ObjektyVeScene);

    }

    public override void Loop(float dt)
    {

    }

    private void VytvorScenu()
    {
        Circle kruh1 = new Circle(new Vector3(-17f, 10f, -0.3f), 3f, Color.DarkGreen);
        Circle kruh2 = new Circle(new Vector3(-11f, 10f, 0f), 2f, new Vector4(0.15f, 0.90f, 0.45f, 0.55f));

        Circle kruh1P = new Circle(new Vector3(-3f, 10f, -0.3f), 3f, Color.DarkGreen);
        Circle kruh2P = new Circle(new Vector3(1f, 10f, 0f), 2f, new Vector4(0.15f, 0.90f, 0.45f, 0.55f));

        Quad obdelnik1P = new Quad(new Vector3(11, 10, -0.2f), 8, 5, Color.LightBlue);
        Quad obdelnik2P = new Quad(new Vector3(15, 12, 0), 8, 3, Color.LightSeaGreen);

        Quad obdelnik1 = new Quad(new Vector3(11, -5, 0f), 8, 5, Color.LightBlue);
        Quad obdelnik2 = new Quad(new Vector3(14f, -5, 0.2f), 3, 4, Color.LightSeaGreen);

        Quad obdelnik3 = new Quad(new Vector3(-17f, -5f, 0f), 5f, 4f, Color.BlueViolet);
        Circle kruh3 = new Circle(new Vector3(-10f, -5f, 0.2f), 2f, new Vector4(0.7f, 0.20f, 1f, 0.55f));

        Quad obdelnik3P = new Quad(new Vector3(-3, -5, -0.2f), 5, 4, Color.BlueViolet);
        Circle kruh3P = new Circle(new Vector3(0.5f, -8.0f, 0f), 2f, new Vector4(0.7f, 0.20f, 1f, 0.55f));


        pridejDoSceny(kruh1);
        pridejDoSceny(kruh2);
        pridejDoSceny(kruh1P);
        pridejDoSceny(kruh2P);

        pridejDoSceny(obdelnik1);
        pridejDoSceny(obdelnik2);
        pridejDoSceny(obdelnik1P);
        pridejDoSceny(obdelnik2P);

        pridejDoSceny(kruh3);
        pridejDoSceny(obdelnik3);
        pridejDoSceny(kruh3P);
        pridejDoSceny(obdelnik3P);
        
        Console.WriteLine("Manualni overeni kolize: ");
        Console.WriteLine("Kolize 2 kruhu: " + Kolize.Kolize2Kruhu(kruh1, kruh2));
        Console.WriteLine("Kolize 2 kruhuP: " + Kolize.Kolize2Kruhu(kruh1P, kruh2P));
        Console.WriteLine("Kolize 2 obdelniku: " + Kolize.Kolize2Obdelniku(obdelnik1, obdelnik2));
        Console.WriteLine("Kolize 2 obdelnikuP: " + Kolize.Kolize2Obdelniku(obdelnik1P, obdelnik2P));
        Console.WriteLine("Kolize kruhu a obdelniku: " + Kolize.KolizeKruhuAObdelniku(kruh3, obdelnik3));
        Console.WriteLine("Kolize kruhu a obdelnikuP: " + Kolize.KolizeKruhuAObdelniku(kruh3P, obdelnik3P));
    }

        void pridejDoSceny(DrawableObject obj){
            ObjektyVeScene.Add(obj);
            AddObject(obj);
        }

        public static void ZmenBarvu(DrawableObject obj1)
        {
            obj1.SetColor(Color.Red);
        }


}
