
Menu();


static void Menu()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Divisão");
        Console.WriteLine("4 - Multiplicação");
        Console.WriteLine("5 - Sair");
        Console.WriteLine("----------");
        Console.WriteLine("Selecione uma opção: ");

        if (short.TryParse(Console.ReadLine(), out short res))
        {
            switch (res)
            {
                case 1: OperacaoMatematica(Soma); break;
                case 2: OperacaoMatematica(Subtracao); break;
                case 3: OperacaoMatematica(Divisao); break;
                case 4: OperacaoMatematica(Multiplicacao); break;
                case 5: Environment.Exit(0); return;
                default: Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar."); Console.ReadKey(); break;
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }
    }
}

static void OperacaoMatematica(Func<float, float, float> operacao)
{
    Console.Clear();

    float v1, v2;
    if (!TentarObterValor("Informe o primeiro valor:", out v1))
    {
        Console.WriteLine("Entrada inválida para o primeiro valor.");
        AguardarUsuario();
        return;
    }

    if (!TentarObterValor("Informe o segundo valor:", out v2))
    {
        Console.WriteLine("Entrada inválida para o segundo valor.");
        AguardarUsuario();
        return;
    }

    float resultado = operacao(v1, v2);
    Console.WriteLine($"O resultado da operação é {resultado}");
    AguardarUsuario();
}

static bool TentarObterValor(string mensagem, out float valor)
{
    Console.WriteLine(mensagem);
    return float.TryParse(Console.ReadLine(), out valor);
}

static void AguardarUsuario()
{
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();
}



static float Soma(float a, float b) => a + b;
static float Subtracao(float a, float b) => a - b;
static float Divisao(float a, float b) => b != 0 ? a / b : throw new ArgumentException("Divisão por zero.");
static float Multiplicacao(float a, float b) => a * b;
