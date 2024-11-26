namespace io; // Definieert de namespace io
using Dumpify;
class Program // Definieert de Program klasse
{
    public static string fileName = "people.csv";
    static void Main(string[] args) // Hoofdfunctie van het programma
    {
        Console.Clear();
        Console.WriteLine("Wat is je naam?"); // Vraagt de gebruiker om hun naam
        string naam = Console.ReadLine(); // Leest de naam in
        Console.WriteLine("Wat is je leeftijd?"); // Vraagt de gebruiker om hun leeftijd
        int leeftijd = int.Parse(Console.ReadLine()); // Leest en converteert de leeftijd naar een integer
        Console.WriteLine("Wat is je lengte?"); // Vraagt de gebruiker om hun lengte
        float lengte = float.Parse(Console.ReadLine()); // Leest en converteert de lengte naar een float
        Person p = new Person(); // Maakt een nieuw Person object aan
        p.Name = naam; // Stelt de naam in
        p.Age = leeftijd; // Stelt de leeftijd in
        p.Height = lengte; // Stelt de lengte in
        AddPersonCSV(p);
        List<Person> people = LoadPeopleCSV(); // Laadt de lijst van personen uit het bestand
        foreach (Person person in people) // Loop door elke persoon in de geladen lijst
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(person.Name.PadRight(20, '-') + "|");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(person.Age.ToString().PadLeft(3, '-') + "|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(person.Height.ToString("0.00").PadRight(3, '-'));
            Console.ResetColor();

        }
    }
    static void AddPersonCSV(Person person)
    {
        List<Person> existingPeople = LoadPeopleCSV();
        existingPeople.Add(person);

        StreamWriter writer = new StreamWriter(fileName);
        writer.WriteLine("Name,Age,Height");
        foreach (Person p in existingPeople)
        {
            writer.WriteLine($"{p.Name},{p.Age},{p.Height}");
        }
        writer.Close();
    }
    static List<Person> LoadPeopleCSV()
    {
        if (File.Exists(fileName))
        {
            StreamReader reader = new StreamReader(fileName);
            reader.ReadLine();
            List<Person> people = new List<Person>();
            while (!reader.EndOfStream)
            {
                string regel = reader.ReadLine();
                string[] data = regel.Split(",");
                Person person = new Person
                {
                    Name = data[0],
                    Age = int.Parse(data[1]),
                    Height = float.Parse(data[2])
                };
                people.Add(person);
            }
            reader.Close();
            return people;

        }
        else
        {
            return [];

        }
    }
    static void SavePeople(List<Person> people) // Methode om personen op te slaan
    {
        StreamWriter writer = new StreamWriter("people.txt"); // Opent een StreamWriter om naar people.txt te schrijven

        foreach (Person p in people) // Loop door elke persoon
        {
            writer.WriteLine($"{p.Name},{p.Age},{p.Height}"); // Schrijft de naam, leeftijd en lengte naar het bestand
        }
        writer.Close(); // Sluit de StreamWriter
    }

    static List<Person> LoadPeople() // Methode om personen te laden
    {
        List<Person> people = new List<Person>(); // Maakt een nieuwe lijst voor personen
        StreamReader reader = new StreamReader("people.txt"); // Opent een StreamReader om people.txt te lezen
        string? currentLine = reader.ReadLine(); // Leest de eerste regel

        while (currentLine != null) // Terwijl er nog regels zijn om te lezen
        {
            string[] woorden = currentLine.Split(","); // Splitst de regel in woorden op basis van de komma
            Person p = new Person(); // Maakt een nieuw Person object aan
            p.Name = woorden[0]; // Stelt de naam in
            p.Age = int.Parse(woorden[1]); // Stelt de leeftijd in
            p.Height = float.Parse(woorden[2]); // Stelt de lengte in
            people.Add(p); // Voegt het Person object toe aan de lijst
            currentLine = reader.ReadLine(); // Leest de volgende regel
        }
        reader.Close(); // Sluit de StreamReader
        return people; // Geeft de lijst van personen terug
    }
}