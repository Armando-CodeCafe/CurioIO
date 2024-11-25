namespace io; // Definieert de namespace io

class Program // Definieert de Program klasse
{
    static void Main(string[] args) // Hoofdfunctie van het programma
    {
        List<Person> personen = []; // Initialiseer een lijst om personen op te slaan
        for (int i = 0; i < 5; i++) // Loop om 5 personen in te voeren
        {
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
            personen.Add(p); // Voegt het Person object toe aan de lijst
        }
        SavePeople(personen); // Slaat de lijst van personen op in een bestand
        List<Person> people = LoadPeople(); // Laadt de lijst van personen uit het bestand
        foreach (Person person in people) // Loop door elke persoon in de geladen lijst
        {
            Console.WriteLine(person.Name + " " + person.Age + " " + person.Height); // Toont de gegevens van elke persoon
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