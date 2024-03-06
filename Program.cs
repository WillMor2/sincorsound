// Sincor Sounda
string mensagemDeBoasVindas = "Boas vindos ao Sincor Sound!";
//List<string> listaDasBandas = new List<string> {"Sincor", "RBD", "The Pussycat Dolls"};
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("RBD", new List<int> { 10,9,7});
bandasRegistradas.Add("The Pussycat Dolls", new List<int>());


void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗██╗███╗░░██╗░█████╗░░█████╗░██████╗░  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██║████╗░██║██╔══██╗██╔══██╗██╔══██╗  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║██╔██╗██║██║░░╚═╝██║░░██║██████╔╝  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║██║╚████║██║░░██╗██║░░██║██╔══██╗  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝██║██║░╚███║╚█████╔╝╚█████╔╝██║░░██║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░╚═╝╚═╝░░╚══╝░╚════╝░░╚════╝░╚═╝░░╚═╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas); 
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um grupo ou banda");
    Console.WriteLine("Digite 2 para mostrar todos os grupos ou bandas");
    Console.WriteLine("Digite 3 para avaliar um grupo ou banda");
    Console.WriteLine("Digite 4 para exibir a média um grupo ou banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: NotaMediaDaBanda();
            break;
        case -1: Console.WriteLine("Obrigado por utilizar o Sincor Sound!");
            break;
        default: Console.WriteLine("Opcão inválida!");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de grupos/bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todos os grupos/bandas registrados");

    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
        //Console.WriteLine($"Banda/Grupo: {listaDasBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Grupo/Banda: {banda}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}


void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asterisco = string.Empty.PadLeft(quantidadeDeLetras,'*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}

void AvaliarUmaBanda()
{
    //digite qual grupo/banda deseja avaliar
    // se o grupo/banda existir no dicionario >> atribuir uma nota
    // senão, volta ao menu pricipal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar grupo/banda");
    Console.Write("Digite o nome do grupo/banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"\nQual a nota que {nomeDaBanda} merece? ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota foi registrada com sucesso para {nomeDaBanda}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else
    {
        Console.WriteLine($"\n{nomeDaBanda} não foi encontrado!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void NotaMediaDaBanda()
{
    //digite qual grupo/banda deseja saber a média
    // se o grupo/banda e as notas existirem no dicionario e lista >> atribuir a média
    // senão, volta ao menu pricipal

    Console.Clear();
    ExibirTituloDaOpcao("\nExibir média do grupo/banda");
    Console.Write("\nDigite o nome do grupo/banda que deseja consultar a média das notas: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDasBandas = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA média do grupo/banda {notasDasBandas.Average()}.");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\n{nomeDaBanda} não foi adicionada!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();
