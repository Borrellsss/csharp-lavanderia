public class ProgrammaLavatrice : ProgrammaMacchinaLavanderia
{
    public int QuantitàDetersivo { get; }
    public int QuantitàAmmorbidente { get; }

    public ProgrammaLavatrice(string nome, int quantitàDetersivo, int quantitàAmmorbidente, int costo, int durata)
    {
        this.Nome = nome;
        this.QuantitàDetersivo = quantitàDetersivo;
        this.QuantitàAmmorbidente = quantitàAmmorbidente;
        this.Costo = costo;
        this.Durata = durata;
    }
}