public abstract class Dog 
{
    public string? Name { get; set; }
    public int PontsClick { get; protected set; }
    public float ValorDog { get; protected set; }
    public int IdDog { get; protected set; }
    public virtual void ValorDogXp (int TotalPontos) { }

}

public class Pug : Dog
{
    public Pug()
    {
        this.Name = "Pug com Falta de Ar";
        this.PontsClick = 10;
        this.ValorDog = 1000f;
        this.IdDog = 0;
    }

    public override void ValorDogXp(int TotalPontos)
    {
        if (Sistema.TotalPontos > (this.PontsClick * 0.5))
            this.ValorDog += (0.5f * 100f);
    }

}

public class Bulldog : Dog
{
    public Bulldog()
    {
        this.Name = "Bulldog de Condominío";
        this.PontsClick = 12;
        this.ValorDog = 1550f;
        this.IdDog = 1;
    }

    public override void ValorDogXp(int TotalPontos)
    {
        if (Sistema.TotalPontos > (this.PontsClick * 0.3))
            this.ValorDog += (0.3f * 100f);
    }

} 

public class Dachshund : Dog
{
    public Dachshund()
    {
        this.Name = "Salsichinha Preguiçoso";
        this.PontsClick = 14;
        this.ValorDog = 2360f;
        this.IdDog = 2;
    }

    public override void ValorDogXp(int TotalPontos)
    {
        if (Sistema.TotalPontos > (this.PontsClick * 0.35))
            this.ValorDog += (0.35f * 100f);
    }

}

public class Husky : Dog
{
    public Husky()
    {
        this.Name = "Gudan Modo Turbo";
        this.PontsClick = 17;
        this.ValorDog = 9875f;
        this.IdDog = 3;
    }

    public override void ValorDogXp(int TotalPontos)
    {
        if (Sistema.TotalPontos > (this.PontsClick * 0.25))
            this.ValorDog += (0.4f * 100f);
    }

}

public class Pinscher : Dog
{
    public Pinscher()
    {
        this.Name = "Pinscher feroz";
        this.PontsClick = 24;
        this.ValorDog = 18899f;
        this.IdDog = 4;
    }

    public override void ValorDogXp(int TotalPontos)
    {
        if (Sistema.TotalPontos > (this.PontsClick * 0.15))
            this.ValorDog += (0.42f * 100f);
    }

}