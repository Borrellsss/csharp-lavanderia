public abstract class MacchinaLavanderia 
{
    public string Nome { get; protected set; }
    public bool IsAccesa { get; protected set; }
    public bool InFunzione { get; protected set; }
    public double Incasso { get; protected set; }
    public int TempoRimanente { get; protected set; }
    public abstract bool AvviaProgramma(string programma);
}