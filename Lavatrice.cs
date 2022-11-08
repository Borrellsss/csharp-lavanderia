public class Lavatrice : MacchinaLavanderia, IInterazioneMacchina
{
    public ProgrammaLavatrice[] Programmi { get; set; }
    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }
    

    public Lavatrice(string nome, int detersivo, int ammorbiddente)
    {
        this.Programmi = new ProgrammaLavatrice[3];
        this.Programmi[0] = new ProgrammaLavatrice("rinfrescante", 20, 5, 2, 20);
        this.Programmi[1] = new ProgrammaLavatrice("rinnovante", 40, 10, 3, 40);
        this.Programmi[2] = new ProgrammaLavatrice("sgrassante", 60, 15, 4, 60);

        this.Nome = nome;
        this.Detersivo = detersivo;
        this.Ammorbidente = ammorbiddente;
        this.InFunzione = false;
        this.Incasso = 0;
    }

    public override bool AvviaProgramma(string programma)
    {
        for (int i = 0; i < Programmi.Length; i++)
        {
            if (Programmi[i].Nome == programma)
            {
                if(this.Detersivo >= Programmi[i].QuantitàDetersivo && this.Ammorbidente >= Programmi[i].QuantitàAmmorbidente)
                {
                    this.Detersivo -= Programmi[i].QuantitàDetersivo;
                    this.Ammorbidente -= Programmi[i].QuantitàAmmorbidente;
                    this.InFunzione = true;
                    this.Incasso += (0.50 * Programmi[i].Costo);
                    this.TempoRimanente = Programmi[i].Durata;
                    return true;
                } 
            }
        }

        return false;
    }

    public void AccendiMacchina()
    {
        if(this.IsAccesa)
        {
            Console.WriteLine("Lavatrice già accesa!");
        }
        else
        {
            Console.WriteLine("Lavatrice accesa correttamente");
            this.IsAccesa = true;
        }
    }
    public void SpegniMacchina()
    {
        if (this.IsAccesa)
        {
            Console.WriteLine("Lavatrice spenta correttamente");
            this.IsAccesa = false;
        }
        else
        {
            Console.WriteLine("Lavatrice già spenta!");
        }
    }
    public void ApriMacchina()
    {
        if(this.InFunzione)
        {
            Console.WriteLine("Devi attendere che la Lavatrice termini il lavaggio");
        }
        else
        {
            Console.WriteLine("Oblò Lavatrice aperto");
        }
    }

    public void ChiudiMacchina()
    {
        if (this.InFunzione)
        {
            Console.WriteLine("Devi attendere che la Lavatrice termini il lavaggio");
        }
        else
        {
            Console.WriteLine("Oblò Lavatrice chiuso");
        }
    }
}