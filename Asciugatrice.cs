public class Asciugatrice : MacchinaLavanderia, IInterazioneMacchina
{
    public ProgrammaAsciugatrice[] Programmi { get; set; }

    public Asciugatrice(string nome)
    {
        this.Programmi = new ProgrammaAsciugatrice[2];
        this.Programmi[0] = new ProgrammaAsciugatrice("rapido", 2, 30);
        this.Programmi[1] = new ProgrammaAsciugatrice("intensivo", 4, 60);

        this.Nome = nome;
        this.InFunzione = false;
        this.Incasso = 0;
    }

    public override bool AvviaProgramma(string programma)
    {
        for(int i = 0; i < Programmi.Length; i++)
        {
            if (Programmi[i].Nome == programma)
            {
                this.InFunzione = true;
                this.Incasso += (0.50 * Programmi[i].Costo);
                this.TempoRimanente = Programmi[i].Durata;
                return true;
            }
        }
        
        return false;
    }

    public void AccendiMacchina()
    {
        if (this.IsAccesa)
        {
            Console.WriteLine("Asciugatrice già accesa!");
        }
        else
        {
            Console.WriteLine("Asciugatrice accesa correttamente");
            this.IsAccesa = true;
        }
    }
    public void SpegniMacchina()
    {
        if (this.IsAccesa)
        {
            Console.WriteLine("Asciugatrice spenta correttamente");
            this.IsAccesa = false;
        }
        else
        {
            Console.WriteLine("Asciugatrice già spenta!");
        }
    }
    public void ApriMacchina()
    {
        if (this.InFunzione)
        {
            Console.WriteLine("Devi attendere che l' Asciugatrice termini il programma di asciugatura");
        }
        else
        {
            Console.WriteLine("Oblò Asciugatrice aperto");
        }
    }

    public void ChiudiMacchina()
    {
        if (this.InFunzione)
        {
            Console.WriteLine("Devi attendere che l' Asciugatrice termini il programma di asciugatura");
        }
        else
        {
            Console.WriteLine("Oblò Asciugatrice chiuso");
        }
    }
}