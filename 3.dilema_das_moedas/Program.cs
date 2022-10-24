Mundo.GerarJogadores(500, 250, 250); 

while (Mundo.Rodada < 50000)
{
    Mundo.Jogada();
}
Console.WriteLine($"Rodadas: {Mundo.Rodada}");
Console.WriteLine($"Falidos: {Mundo.Falido}");
Console.WriteLine($"TotalMoedas: {Mundo.TotalMoedas}");