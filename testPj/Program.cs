using System;
using testPj.Data;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";

        DatabaseService databaseService = new DatabaseService(connectionString);

        var examples = databaseService.GetAll();

        foreach (var example in examples)
        {
            Console.WriteLine($"ID: {example.Id}, Name: {example.Name}");
        }
    }
}