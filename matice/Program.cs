namespace matice
{
    class Program
    {
        static void Main()
        {
            Matice matice1 = new Matice(2,3);
            Matice matice2 = new Matice(3,3);

            matice1.Vypis_matici();
            matice2.Vypis_matici();

            matice1.Napln_matici();
            matice2.Napln_matici();

            // Matice vysledek_scitani = matice1 + matice2;
            // vysledek_scitani.Vypis_matici();

            // Matice vysledek_nasobeni = matice1*matice2;
            // vysledek_nasobeni.Vypis_matici();

            // Console.WriteLine(matice1.Soucet_diagonaly());

            matice2.Transpozice(Matice.Operace.sloupce, 1, 2);

        }
    }
}
