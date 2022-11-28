public class CasoCovid
{
    public bool IsCovid { get; set; }
    public bool IsDead { get; set; }
    public int Doses { get; set; }
    public string Vacina { get; set; }

    public int Idade { get; set; }

    public override string ToString()
        => $"{IsCovid} {IsDead} {Doses}";


}