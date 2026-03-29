using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using SQLiteCs;


namespace ProjectApp;

internal class Program
{
    static void Main(string[] args)
    {
        //priklad1();
        //priklad3();
        priklad4();

    }

    static void priklad1()
    {
        Database db = new Database("test.db");
        db.SetTestingMode(true);

        db.NonQuery(@"
            CREATE TABLE IF NOT EXISTS user (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT NOT NULL);
        ");

        db.NonQuery(@"
            INSERT INTO user (name)
            VALUES ('Jan Dolezal'),
                ('Jindrich Dvorak'),
                ('Jakub Dvorak');
        ");

        PrintQueryResult(db, "SELECT name FROM user;");
        DataTable dataTable = db.QueryAsTable("SELECT * FROM user");
        PrintDataTable(dataTable);

        db.CloseDatabase();
    }

    static void priklad3()
    {
        Database csfd = new Database("csfd.db");


        PrintQueryResult(csfd, "SELECT COUNT(country) AS [pocet ceskych filmu] FROM moviesTop100 WHERE country LIKE '%Če%'");
        PrintQueryResult(csfd, "SELECT title, country, MAX(rating) FROM moviesTop100 WHERE country LIKE '%Če%'");
        PrintQueryResult(csfd, "SELECT title, country, MIN(rating) FROM moviesTop100 WHERE country LIKE '%Če%'");
        PrintQueryResult(csfd, "SELECT title, year FROM moviesTop100 WHERE actors LIKE '%Christian Bale%'");
        
        DataTable dataTableCSFD = csfd.QueryAsTable("SELECT id, title, year FROM moviesTop100");
        PrintDataTable(dataTableCSFD);
    }

    static void priklad4()
    {
        Database mojeDatabaze = new Database("autorAKniha.db");
        mojeDatabaze.NonQuery(@"CREATE TABLE IF NOT EXISTS Autor(id INTEGER PRIMARY KEY AUTOINCREMENT, jmeno TEXT NOT NULL, rokNarozeni INTEGER)");
        mojeDatabaze.NonQuery(@"INSERT INTO Autor (jmeno, rokNarozeni) VALUES ('J.R.R. Tolkien', 1892), ('Daniel Abraham', 1969), ('Brandon Sanderson', 1975)");

        mojeDatabaze.NonQuery(@"CREATE TABLE IF NOT EXISTS Kniha(id INTEGER PRIMARY KEY AUTOINCREMENT, jmeno TEXT NOT NULL, idAutora INTEGER, rokVydani INTEGER, zanr TEXT)");
        mojeDatabaze.NonQuery(@"INSERT INTO Kniha (jmeno, idAutora, rokVydani, zanr) 
                                VALUES ('The Hobbit', 1, 1937, 'fantasy'),
                                        ('LotR: The Fellowship of the Ring', 1, 1954, 'fantasy'), 
                                        ('LotR: The Two Towers', 1, 1954, 'fantasy'),
                                        ('LotR: Return of the King', 1, 1955, 'fantasy'),

                                        ('Cibola Burn', 2, 2014, 'sci-fi'),
                                        ('Leviathan Wakes', 2, 2011, 'sci-fi'),
                                        ('Abaddons Gate', 2, 2013, 'sci-fi'),
                                        ('Calibans War', 2, 2012, 'sci-fi'),

                                        ('The Way of Kings', 3, 2010, 'fantasy'),
                                        ('Oathbringer', 3, 2017, 'fantasy'),
                                        ('Words of Radiance', 3, 2014, 'fantasy'),
                                        ('Rythm of War', 3, 2020, 'fantasy')");
        
        PrintQueryResult(mojeDatabaze, "SELECT * FROM Autor");
        PrintQueryResult(mojeDatabaze, "SELECT * FROM Kniha");

        PrintQueryResult(mojeDatabaze, "SELECT * FROM Autor JOIN Kniha On Autor.id = Kniha.idAutora");
        PrintQueryResult(mojeDatabaze, "SELECT Autor.jmeno, Count(Kniha.idAutora) AS [pocet knih] FROM Autor JOIN Kniha ON Autor.id = Kniha.idAutora GROUP BY autor.jmeno ");
        PrintQueryResult(mojeDatabaze, "SELECT Autor.jmeno, MIN(Kniha.rokVydani), MAX(kniha.rokVydani) FROM Autor JOIN Kniha ON Autor.id = Kniha.idAutora GROUP BY Autor.jmeno");

        mojeDatabaze.NonQuery("DROP TABLE Autor");
        mojeDatabaze.NonQuery("DROP TABLE Kniha");
    }

    // vyresene
    public static void PrintQueryResult(Database database, string sqlQuery)
    {
        QueryResult data = database.Query(sqlQuery);

        foreach (string colName in data.ColumnNames)
        {
            Console.Write($"{colName,-30} ");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', data.ColumnCount * 32));

        for (int i = 0; i < data.RowCount; i++)
        {
            for (int j = 0; j < data.ColumnCount; j++)
            {
                Console.Write($"{data.Rows[i][j],-30} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void PrintDataTable(DataTable dataTable)
    {
        for (int k = 0; k < dataTable.Columns.Count; k++)
        {
            Console.Write($"{dataTable.Columns[k],-30}");
        }

        Console.WriteLine();
        Console.WriteLine($"{new string('-', dataTable.Columns.Count * 32)}");

        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                Console.Write($"{dataTable.Rows[i][j],-30}");
            }
            Console.WriteLine();
        }
    }
}
