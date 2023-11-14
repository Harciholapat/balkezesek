using ConsoleApp2;

string[] lines = File.ReadAllLines("balkezesek.csv");

List<Balkezes> Balkezesek = new List<Balkezes>();

for (int i = 1; i < lines.Length; i++)
{
    Balkezes balkezes = new Balkezes(lines[i]);

    Balkezesek.Add(balkezes);
}

Console.WriteLine("3. feladat:");
numberOfLines(Balkezesek);

Console.WriteLine("4. feladat:");
nameHeightLastPlayedInOct99(Balkezesek);

Console.WriteLine("5. feladat:");

averageWeightOfPlayersPlayedInYear(Balkezesek, yearQuery(Balkezesek));

static void averageWeightOfPlayersPlayedInYear(List<Balkezes> Balkezesek, DateTime queriedDate)
{
    Console.WriteLine("6. feladat:");
    double averageWeightDividend = 0;
    int averageWeightDivisor = 0;

    foreach (var balkezes in Balkezesek)
    {
        if (queriedDate.Year == balkezes.elso.Year || queriedDate.Year == balkezes.utolso.Year || (queriedDate.Year > balkezes.elso.Year && queriedDate.Year < balkezes.utolso.Year))
        {
            averageWeightDividend += balkezes.suly;
            averageWeightDivisor++;
        }
    }

    Console.WriteLine(string.Format("{0:0.00}", averageWeightDividend / averageWeightDivisor) + " font");
}

static DateTime yearQuery(List<Balkezes> Balkezesek)
{
    DateTime lowerTreshold = new DateTime(1990, 01, 01);
    DateTime upperTreshold = new DateTime(1999, 12, 31);
    bool queriedDateIsCorrect;
    DateTime queriedDate;

    do
    {
        Console.WriteLine("Kérek egy 1990 és 1999 közötti évszámot: ");
        queriedDate = Convert.ToDateTime(Console.ReadLine() + ",01,01");

        if (!(queriedDate >= lowerTreshold && queriedDate < upperTreshold))
        {
            Console.WriteLine("Hibás adat!");
            queriedDateIsCorrect = false;
        }
        else
        {
            queriedDateIsCorrect = true;
        }


    } while (!queriedDateIsCorrect);

    return queriedDate;
}

static void nameHeightLastPlayedInOct99(List<Balkezes> Balkezesek)
{
    DateTime dateBeginning = new DateTime(1999, 10, 01);
    DateTime dateEnd = new DateTime(1999, 10, 31);
    foreach (var balkezes in Balkezesek)
    {
        if (balkezes.utolso > dateBeginning && balkezes.utolso < dateEnd)
        {
            Console.WriteLine(balkezes.nev + ", " + String.Format("{0:0.0}", balkezes.magassag * 2.54) + " cm");
        }
    }
}

static void numberOfLines(List<Balkezes> Balkezesek)
{
    Console.WriteLine(Balkezesek.Count);
}

