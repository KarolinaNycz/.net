using Microsoft.Extensions.DependencyInjection;
using MyLibrary;
using MyServices;
using Newtonsoft.Json;

// Konfiguracja kontenera DI
var serviceProvider = new ServiceCollection()
    .AddSingleton<ILoggerService, ConsoleLogger>()
    .BuildServiceProvider();

// Pobranie loggera
var logger = serviceProvider.GetService<ILoggerService>();

logger?.Log("Aplikacja uruchomiona.");

// Użycie kalkulatora
int sum = Calculator.Add(10, 15);
int difference = Calculator.Subtract(20, 7);

logger?.Log($"Wynik dodawania: {sum}");
logger?.Log($"Wynik odejmowania: {difference}");

// Serializacja do JSON
var result = new
{
    Operation = "Add",
    A = 10,
    B = 15,
    Result = sum
};

string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);

Console.WriteLine();
Console.WriteLine("JSON:");
Console.WriteLine(jsonResult);