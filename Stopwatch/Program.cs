
using System.Threading;
using System;

Menu();

static void Menu()
{
    do
    {
        Console.Clear();
        Console.WriteLine("S = Segundo => 10s = 10 segundos");
        Console.WriteLine("M = Minuto => 1m = 1 minuto");
        Console.WriteLine("0 = Sair");
        Console.WriteLine("Quanto tempo deseja contar?");

        try
        {
            string data = Console.ReadLine().ToLower();
            if (string.IsNullOrWhiteSpace(data) || data == "0")
                return;

            var timeSpan = ParseTimeSpan(data);
            if (timeSpan == null)
            {
                ShowError("Formato de tempo inválido.");
                continue;
            }

            PreStart(timeSpan.Value);
        }
        catch (Exception ex)
        {
            ShowError($"Erro: {ex.Message}");
        }
    } while (true);
}

static TimeSpan? ParseTimeSpan(string data)
{
    if (string.IsNullOrEmpty(data)) return null;


    char type = data[data.Length - 1];
    if (!int.TryParse(data.Substring(0, data.Length - 1), out int timeValue))
        return null;


    switch (type)
    {
        case 's':
            return TimeSpan.FromSeconds(timeValue);
        case 'm':
            return TimeSpan.FromMinutes(timeValue);
        default:
            return null;
    }
}


static void PreStart(TimeSpan timeSpan)
{
    Console.Clear();
    Console.WriteLine("Ready...");
    Thread.Sleep(1000);
    Console.WriteLine("Set...");
    Thread.Sleep(1000);
    Console.WriteLine("Go...");
    Thread.Sleep(2500);

    Start(timeSpan);
}

static void Start(TimeSpan timeSpan)
{
    var stopWatchEnd = DateTime.Now.Add(timeSpan);
    do
    {
        Console.Clear();
        TimeSpan remainingTime = stopWatchEnd - DateTime.Now;
        Console.WriteLine($"Tempo Restante: {remainingTime.Seconds}");
        Thread.Sleep(1000);
    } while (DateTime.Now < stopWatchEnd);

    Console.Clear();
    Console.WriteLine("Stopwatch finalizado");
    Thread.Sleep(2500);
}

static void ShowError(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
    Thread.Sleep(2500);
}