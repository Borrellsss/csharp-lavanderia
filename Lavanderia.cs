public class Lavanderia
{
    public string Nome { get; set; }
    public Lavatrice[] Lavatrici { get; set; }
    public Asciugatrice[] Asciugatrici { get; set; }

    public Lavanderia(string nome)
    {
        this.Nome = nome;

        this.Lavatrici = new Lavatrice[5];

        Lavatrice lavatrice1 = new Lavatrice("lavatrice1", 0, 0);
        Lavatrice lavatrice2 = new Lavatrice("lavatrice2", 1000, 500);
        Lavatrice lavatrice3 = new Lavatrice("lavatrice3", 1000, 500);
        Lavatrice lavatrice4 = new Lavatrice("lavatrice4", 1000, 500);
        Lavatrice lavatrice5 = new Lavatrice("lavatrice5", 1000, 500);

        this.Lavatrici[0] = lavatrice1;
        this.Lavatrici[1] = lavatrice2;
        this.Lavatrici[2] = lavatrice3;
        this.Lavatrici[3] = lavatrice4;
        this.Lavatrici[4] = lavatrice5;

        this.Asciugatrici = new Asciugatrice[5];

        Asciugatrice asciugatrice1 = new Asciugatrice("asciugatrice1");
        Asciugatrice asciugatrice2 = new Asciugatrice("asciugatrice2");
        Asciugatrice asciugatrice3 = new Asciugatrice("asciugatrice3");
        Asciugatrice asciugatrice4 = new Asciugatrice("asciugatrice4");
        Asciugatrice asciugatrice5 = new Asciugatrice("asciugatrice5");

        this.Asciugatrici[0] = asciugatrice1;
        this.Asciugatrici[1] = asciugatrice2;
        this.Asciugatrici[2] = asciugatrice3;
        this.Asciugatrici[3] = asciugatrice4;
        this.Asciugatrici[4] = asciugatrice5;
    }

    public void StampaMacchineLavanderia(string scelta)
    {
        if(scelta == "lavatrici")
        {
            for(int i = 0; i < Lavatrici.Length; i++)
            {
                Lavatrice lavatriceCorrente = Lavatrici[i];

                Console.WriteLine($"lavatrice numero {i + 1}");
                Console.WriteLine($"nome: {lavatriceCorrente.Nome}");
                Console.WriteLine($"quantità detersivo rimanente: {lavatriceCorrente.Detersivo} ml");
                Console.WriteLine($"quantità ammorbidente rimanente: {lavatriceCorrente.Ammorbidente} ml");
                Console.WriteLine($"incasso totale lavatrice: {lavatriceCorrente.Incasso} euro");
                Console.WriteLine("--------------------------------------------------------------");
            }
        }
        else if(scelta == "asciugatrici")
        {
            for (int i = 0; i < Asciugatrici.Length; i++)
            {
                Asciugatrice asciugatriceCorrente = Asciugatrici[i];

                Console.WriteLine($"asciugatrice numero {i + 1}");
                Console.WriteLine($"nome: {asciugatriceCorrente.Nome}");
                Console.WriteLine($"incasso totale lavatrice: {asciugatriceCorrente.Incasso} euro");
                Console.WriteLine("--------------------------------------------------------------");
            }
        }
        else if(scelta == "tutto")
        {
            Console.WriteLine("------------------------------ LAVATRICI ------------------------------");
            for (int i = 0; i < Lavatrici.Length; i++)
            {
                Lavatrice lavatriceCorrente = Lavatrici[i];

                Console.WriteLine($"lavatrice numero {i + 1}");
                Console.WriteLine($"nome: {lavatriceCorrente.Nome}");
                Console.WriteLine($"quantità detersivo rimanente: {lavatriceCorrente.Detersivo} ml");
                Console.WriteLine($"quantità ammorbidente rimanente: {lavatriceCorrente.Ammorbidente} ml");
                Console.WriteLine($"incasso totale lavatrice: {lavatriceCorrente.Incasso} euro");
                Console.WriteLine("------------------------------------------------------------");
            }

            Console.WriteLine();

            Console.WriteLine("------------------------------ ASCIUGATRICI ------------------------------");
            for (int i = 0; i < Asciugatrici.Length; i++)
            {
                Asciugatrice asciugatriceCorrente = Asciugatrici[i];

                Console.WriteLine($"asciugatrice numero {i + 1}");
                Console.WriteLine($"nome: {asciugatriceCorrente.Nome}");
                Console.WriteLine($"incasso totale lavatrice: {asciugatriceCorrente.Incasso} euro");
                Console.WriteLine("------------------------------------------------------------");
            }
        }
        else
        {
            Console.WriteLine("mi spiace ma non hai digitato correttamente");
        }
    }
    public void StatoLavatrici()
    {
        string[] programmiLavatrici = { "rinfrescante", "rinnovante", "sgrassante", "nessuno" };

        for (int i = 0; i < Lavatrici.Length; i++)
        {
            int indiceRandom = new Random().Next(0, programmiLavatrici.Length);

            string programmaCorrente = programmiLavatrici[indiceRandom];

            bool statoLavatrice = Lavatrici[i].AvviaProgramma(programmaCorrente);

            if (statoLavatrice)
            {
                Console.WriteLine($"lavatrice numero {i + 1}");
                Console.WriteLine($"programma {Lavatrici[i]}: {programmaCorrente}");
                Console.WriteLine($"detersivo rimanente: {Lavatrici[i].Detersivo}");
                Console.WriteLine($"ammorbidente rimanente: {Lavatrici[i].Ammorbidente}");
                Console.WriteLine("stato: in funzione");
                Console.WriteLine($"totale incasso: {Lavatrici[i].Incasso} euro");
                Console.WriteLine($"tempo rimanente: {Lavatrici[i].TempoRimanente - new Random().Next(0, Lavatrici[i].TempoRimanente)} min");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"lavatrice numero {i + 1}");
                Console.WriteLine("stato: non in funzione");
                Console.WriteLine();
            }
        }
    }

    public void StatoAsciugatrici()
    {
        string[] programmiAsciugatrici = { "rapido", "intensivo", "nessuno" };

        for (int i = 0; i < Asciugatrici.Length; i++)
        {
            int indiceRandom = new Random().Next(0, programmiAsciugatrici.Length);

            string programmaCorrente = programmiAsciugatrici[indiceRandom];

            bool statoAsciugatrice = Asciugatrici[i].AvviaProgramma(programmaCorrente);

            if (statoAsciugatrice)
            {
                Console.WriteLine($"asciugatrice numero {i + 1}");
                Console.WriteLine($"programma {Asciugatrici[i]}: {programmaCorrente}");
                Console.WriteLine("stato: in funzione");
                Console.WriteLine($"totale incasso: {Asciugatrici[i].Incasso}");
                Console.WriteLine($"tempo rimanente: {Asciugatrici[i].TempoRimanente - new Random().Next(0, Asciugatrici[i].TempoRimanente)} min");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"asciugatrice numero {i + 1}");
                Console.WriteLine("stato: non in funzione");
                Console.WriteLine();
            }
        }
    }
}