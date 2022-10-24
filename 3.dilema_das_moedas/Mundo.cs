using System;

public static class Mundo 
{
    public static Player[] Players { get; private set; } = new Player[1000]; 
    private static int index { get; set; } = 0; 
    public static int Falido { get; private set; }
    public static int TotalMoedas { get; set; } = Mundo.Players.Length;
    public static int Rodada { get; set; } = 10;

    public static void Jogada()  
    {
        Random r = new Random();
        Player jogador1, jogador2; 
        while (true) 
        {
            jogador1 = Mundo.Players[ 
                r.Next(Mundo.Players.Length)
            ];
            jogador2 = Mundo.Players[r.Next(Mundo.Players.Length)];
            if ((jogador1.Moeda > 0 && jogador2.Moeda > 0) && jogador1 != jogador2)
                break;
        }

        int moedasIniciais = jogador1.Moeda + jogador2.Moeda;

        if (jogador1.Decidir() && jogador2.Decidir())
        {
            jogador1.Recebe(1);
            jogador2.Recebe(1);
            // Mundo.TotalMoedas += 2;
        }
        else if (jogador1.Decidir() && !jogador2.Decidir()) 
        {
            jogador1.Recebe(-1);
            jogador2.Recebe(4);
            Mundo.TotalMoedas += 3;
        }
        else if (!jogador1.Decidir() && jogador2.Decidir())  
        {
            jogador1.Recebe(4);
            jogador2.Recebe(-1);
            // Mundo.TotalMoedas += 3;
        }
        else
        {
            jogador1.Recebe(0);
            jogador1.Recebe(0);
        }

        if (jogador1.Moeda == 0)
            Mundo.Falido++;
        if (jogador2.Moeda == 0)
            Mundo.Falido++;

        int moedasFinais = jogador1.Moeda + jogador2.Moeda;
        int novasMoedas = moedasFinais - moedasIniciais;
        Mundo.TotalMoedas += novasMoedas;
        Mundo.Rodada += 1;
    }
    private static void addJogador(Player jogador) 
    {
        Mundo.Players[Mundo.index] = jogador;
        Mundo.index++;
    }
    public static void GerarJogadores(int cooperadores, int trapaceiros, int vingativos) 
    {
        if (cooperadores + trapaceiros + vingativos > Mundo.Players.Length) 
            throw new Exception();
        for (int i = 0; i < cooperadores; i++) 
        {
            Mundo.addJogador(new Cooperador()); 
        }
        for (int i = 0; i < trapaceiros; i++)
        {
            Mundo.addJogador(new Trapaceiro());
        }
        for (int i = 0; i < vingativos; i++)
        {
            Mundo.addJogador(new Vingativo());
        }
    }
}