
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var query = read()
    .Where(c => c.IsCovid)
    .GroupBy(c => c.Doses) 
    .Select(g => new
        {
            qtdDoses = g.Key,
            letalidade = g.Average(c => c.IsDead ? 1.0 : 0.0) //
        }); 

foreach (var cl in query)
{
    Console.WriteLine($"Doses: {cl.qtdDoses}, " + 
        $"Letalidade: {cl.letalidade}");
}

var covidCases = read()
    .Where(c => c.IsCovid);


var letalGroup = covidCases
    .GroupBy(c => c.Doses)
    .Select(g => new {
        qtdDoses = g.Key,
        letalidade = g.Average(c => c.IsDead ? 1.0 : 0.0)
    });

var vacinados = covidCases
    .Where(c => c.Doses > 0);

var grupoVacinais = vacinados
    .Select(x =>
    {
        if (x.Vacina.Contains("BUT") || x.Vacina.Contains("NAVAC") || x.Vacina.Contains("BUTATAN") || x.Vacina.Contains("TATAN") ||  
                x.Vacina.Contains("SINOVAC") || x.Vacina.Contains("VAC"))//
            return new {
                vacina = "CORONAVAC",
                caso = x
            };
        else if (x.Vacina.Contains("ASTRA") || x.Vacina.Contains("AZTRA") || x.Vacina.Contains("FIOCRUZ") || x.Vacina.Contains("OXFORD") || 
                    x.Vacina.Contains("BIOMANGUINHOS") || x.Vacina.Contains("ZENECA") || x.Vacina.Contains("NICA") || x.Vacina.Contains("NIKA")) //
            return new {
                vacina = "ASTRAZENICA",
                caso = x
            };
        else if (x.Vacina.Contains("PFIZER") || x.Vacina.Contains("PFISER") || x.Vacina.Contains("PIZER") || x.Vacina.Contains("COMIRNATY")) 
            return new {
                vacina = "PFIZER",
                caso = x
            };
        
        return new {
                vacina = "DESCONHECIDO",
                caso = x
        };
    })
    .GroupBy(x => x.vacina)
    .Select(x => new {
        gpVacinas = x.Key,
        qtdPessoas = x.Count(),
        vacinados = x.Count(),
        letalidade = (x.Where(x => x.caso.IsDead).Count() / (float)x.Count())*100
    });

var faixasEtarias = vacinados
                    .Select( c =>
                    {
                        if (c.Idade < 12)
                        {
                            return new{
                                faixaEtaria = "Criança mais velha",
                                Caso = c
                            };
                        }
                        if (c.Idade < 30)
                        {
                            return new{
                                faixaEtaria = "Adulto responsável",
                                Caso = c
                            };
                        }
                        if (c.Idade < 50)
                        {
                            return new{
                                faixaEtaria = "Adulto de meia idade",
                                Caso = c
                            };
                        }
                        return new{
                                faixaEtaria = "Idoso",
                                Caso = c
                            };


                    })
                    .GroupBy( c => c.faixaEtaria)
                    .Select(g => new {faixasEtaria = g.Key, qtd = g.Count(), Letalidade = g.Average(x => x.Caso.IsDead ? 1.1 :0.0)}); 

foreach (var fe in faixasEtarias )
{
    Console.WriteLine($"Faixa etaria: {fe.faixasEtaria}, " +  $"Quantidade de pessoas: {fe.qtd}, " +  $"Letalidade: {fe.Letalidade}");
}


foreach (var inf in grupoVacinais)
{
    Console.WriteLine($"Vacina ID: {inf.gpVacinas} - Qtd de pessoas: {inf.qtdPessoas}");
    Console.WriteLine($"Taxa de letalidade: {inf.letalidade}");
}

foreach (var lg in letalGroup)
{
    Console.WriteLine($"Doses: {lg.qtdDoses}, " + 
        $"Letalidade: {lg.letalidade}");
}



IEnumerable<CasoCovid> read()
{
    StreamReader reader = new StreamReader("INFLUD22-24-10-2022.csv"); 

    var firstLine = reader.ReadLine(); 
    var header = firstLine.Split(';')
        .ToList(); 
    
    int classfin = header.IndexOf("\"CLASSI_FIN\""); 
    int evolucao = header.IndexOf("\"EVOLUCAO\"");

    int dose1 = header.IndexOf("\"DOSE_1_COV\"");
    int dose2 = header.IndexOf("\"DOSE_2_COV\"");

     int lab = header.IndexOf("\"LAB_PR_COV\"");

    int idade = header.IndexOf("\"NU_IDADE_N\"");


    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine(); 
        var data = line.Split(';');

        var caso = new CasoCovid(); 
        //
        caso.IsCovid = data[classfin] == "5"; 
        caso.IsDead = data[evolucao] == "2";

    
        int doses = 0;
        if (data[dose1] != "\"\"")
            doses++;
        if (data[dose2] != "\"\"")
            doses++;

        caso.Doses = doses;
        caso.Vacina = data[lab];
        
        if(int.TryParse(data[idade], out int i))
        {
            if(i < 0)
                i = -i;
            caso.Idade = i;
        }
        else continue;

        yield return caso;
    }

    reader.Close();
}

