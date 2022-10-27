using System.Threading;
public static class Sistema
{
    public static List<Dog> Dogs { get; set; } = new List<Dog>();
    public static List<Dog> DogsPcomprar { get; set; } = new List<Dog>() {new Pug(), new Bulldog(), new Dachshund(), new Husky(), new Pinscher()};
    public static float TotalDinheiro { get; set; } = 2000;
    public static int TotalPontos { get; set; } = 0;
    public static void AddDog(int codDog)
    {
        for (int i = 0; i < Sistema.DogsPcomprar.Count; i++)
        {
            Sistema.Dogs.Add(Sistema.DogsPcomprar[codDog]);
        }
    }
    public static void MostrarDogs()
    {
        Console.WriteLine($"Seu saldo de petiscos {Sistema.TotalDinheiro}.00");
        Console.WriteLine($"Dogs Disponiveis Para Compra: ");
        for (int i = 0; i < Sistema.DogsPcomprar.Count; i++)
        {
            Console.WriteLine($"\n{Sistema.DogsPcomprar[i].IdDog} - {Sistema.DogsPcomprar[i].Name} - Petiscos Necessarios: {Sistema.DogsPcomprar[i].ValorDog}.00");
        }
        int codDog = int.Parse((Console.ReadLine()));
        ComprarDogs(codDog, Sistema.TotalDinheiro);
        Console.ReadKey();
    }

    public static void ComprarDogs(int codDog, float Dinheiro)
    {
        if (codDog > Sistema.DogsPcomprar.Count - 1)
        {
            Console.WriteLine("\nAnimal não encontrado!");
            Thread.Sleep(2000);
        }
        else
        {
            if (Sistema.TotalDinheiro <= 0 || Sistema.TotalDinheiro < Sistema.DogsPcomprar[codDog].ValorDog)
            {
                Console.WriteLine("\n-------------------- Petiscos abaixo do necessário --------------------");
                Console.ReadKey();
            }
            else
            {
                AddDog(codDog);
                float valorMaq = Sistema.DogsPcomprar[codDog].ValorDog;
                Sistema.TotalDinheiro -= valorMaq;
                Console.WriteLine($"\nNovo saldo de petiscos {Sistema.TotalDinheiro}.00");
                Sistema.TotalPontos += Sistema.DogsPcomprar[codDog].PontsClick;
                for (int i = 0; i < Sistema.DogsPcomprar.Count; i++)
                {
                    Sistema.DogsPcomprar[i].ValorDogXp(TotalPontos);
                }
                Console.WriteLine("\nNovo animal adquirido com sucesso!");
            }
        }
    }

    public static void ReceberDinheiro()
    {
        Sistema.TotalDinheiro += (1f * Sistema.TotalPontos);
    }

    public static void Jogada()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n\n=================== TO DIG MONEY ===================");
            Console.WriteLine($"Seu saldo de petiscos {Sistema.TotalDinheiro}.00");
            Console.WriteLine("Alimentar animal para encontrar dinheiro (0)");
            Console.WriteLine("Visualizar Dogs para comprar (1)");
            Console.WriteLine("Encerrar jogo (6) ");
            var option = Console.ReadKey().Key;
            if (option == ConsoleKey.D0)
            {
                if(Sistema.TotalPontos == 0)
                {
                    Console.WriteLine($"\n-------------------- Você não possui dogs ainda, adicione um animal para gerar dinheiro --------------------");
                    Thread.Sleep(2000);
                }
                else
                    ReceberDinheiro();
                Console.Clear();
            }
            else if (option == ConsoleKey.D1)
            {
                Console.Clear();
                MostrarDogs();
                Console.Clear();
            }
            else if (option == ConsoleKey.D6)
            {
                Console.WriteLine($"\n-------------------- Seu saldo de Petiscos final {Sistema.TotalDinheiro}.00 -------------------- \n\n");
                break;
            }
        }
    }
}