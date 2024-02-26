Menu();

static void Menu()
{
    bool continuar = true;
    do
    {
        Console.Clear();
        Console.WriteLine("O que você deseja fazer?");
        Console.WriteLine("1 - Abrir arquivo");
        Console.WriteLine("2 - Criar novo arquivo");
        Console.WriteLine("0 - Sair");
        if (short.TryParse(Console.ReadLine(), out short option))
        {
            switch (option)
            {
                case 0: continuar = false; break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: MostrarMensagem("Opção inválida. Por favor, tente novamente."); break;
            }
        }
        else
        {
            MostrarMensagem("Entrada inválida. Por favor, insira um número.");
        }
    } while (continuar);
}

static void Abrir()
{
    Console.Clear();
    Console.WriteLine("Qual caminho do arquivo?");
    string? path = Console.ReadLine();

    if (path == null)
    {
        throw new ArgumentNullException(nameof(path), "O caminho do arquivo não pode ser nulo.");
    }

    try
    {
        using (var file = new StreamReader(path))
        {
            Console.WriteLine(file.ReadToEnd());
        }
    }
    catch (Exception ex)
    {
        MostrarMensagem($"Erro ao abrir o arquivo: {ex.Message}");
        return;
    }

    Console.ReadLine();
}

static void Editar()
{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
    Console.WriteLine("----------------");
    string text = "";
    ConsoleKeyInfo key;

    do
    {
        var input = Console.ReadLine();
        text += input + Environment.NewLine;
        key = Console.ReadKey();
    }
    while (key.Key != ConsoleKey.Escape);

    Salvar(text);
}

static void Salvar(string text)
{
    Console.Clear();
    Console.WriteLine("Qual caminho para salvar o arquivo?");
    var path = Console.ReadLine();
    if (path == null)
    {
        throw new ArgumentNullException(nameof(path), "O caminho do arquivo não pode ser nulo.");
    }

    try
    {
        using (var file = new StreamWriter(path))
        {
            file.Write(text);
        }
        MostrarMensagem($"Arquivo {path} salvo com sucesso!");
    }
    catch (Exception ex)
    {
        MostrarMensagem($"Erro ao salvar o arquivo: {ex.Message}");
    }
}

static void MostrarMensagem(string mensagem)
{
    Console.WriteLine(mensagem);
    Console.WriteLine("Pressione qualquer tecla para continuar...");
    Console.ReadKey();
}
