using System.Drawing;
using System.Numerics;
using BasicGraphicsEngine;

public class Bar : Line
{   
    private float sirka;
    private float Vyska;
    public Bar(Vector3 pocatecniBod, Vector3 vyska, float tloustka, Color barva): base(pocatecniBod, vyska, tloustka, barva)
    {
        sirka = tloustka/0.46f;
        Vyska = vyska.Y;
    }

    public float GetArea()
    {
        float obsahObdelniku = sirka*Vyska;
        return obsahObdelniku;
    }
}