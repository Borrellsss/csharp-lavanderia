//Una lavanderia è aperta 24 ore su 24 e permette ai clienti di servirsi autonomamente di 5 Lavatrici e 5 Asciugatrici.
//I clienti che usufruiscono delle macchine, possono effettuare diversi programmi di lavaggio e asciugatura
//ognuno con un costo diverso (in gettoni) e di una specifica durata. Ogni gettone costa 0.50 centesimi
//di euro e ogni lavaggio consuma detersivo e ammorbidente dai serbatoi della lavatrice.
//Ogni lavatrice può tenere fino ad un massimo di 1 litro di detersivo e 500ml di ammorbidente.
//I programmi di lavaggio hanno quindi queste caratteristiche
//Rinfrescante, costo di 2 gettoni, durata di 20 minuti, consumo di 20ml di detersivo e 5ml di ammorbidente.
//Rinnovante, costo di 3 gettoni, durata di 40 minuti, consumo di 40ml di detersivo e 10ml di ammorbidente.
//Sgrassante, costo di 4 gettoni, durata di 60 minuti, consumo di 60 ml di detersivo e 15ml di ammorbidente.
//Le asciugatrici invece hanno soltanto due programmi di asciugatura, rapido 2 gettoni e
//intenso 4 gettoni della durata di 30 minuti e 60 minuti rispettivamente.
//Si richiede di creare un sistema di controllo in grado di riportare lo stato della lavanderia, in particolare si vuole richiedere:
//1 - Lo stato generale di utilizzo delle macchine: un elenco di tutte le macchine che
//semplicemente dica quali sono in funzione e quali non lo sono (in lavaggio / asciugatura oppure ferme)
//2 - Possa essere richiesto il dettaglio di una macchina: Tutte le informazioni relative alla macchina,
//nome del macchinario, stato del macchinario (in funzione o no), tipo di lavaggio in corso, quantità di detersivo
//presente (se una lavatrice), durata del lavaggio, tempo rimanente alla fine del lavaggio.
//3 - l’attuale incasso generato dall’utilizzo delle macchine.

Lavanderia nuovaLavanderia = new Lavanderia("Nuova Lavanderia");

nuovaLavanderia.StatoLavatrici();
nuovaLavanderia.StatoAsciugatrici();
nuovaLavanderia.StampaMacchineLavanderia("tutto");

//-----------------------------------------------------------------------------------------------------------------

public class Lavatrice
{
    public string Nome { get; }
    public ProgrammaLavatrice[] Programmi { get; set; }
    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }
    public bool Stato { get; set; }
    public double Incasso { get; set; }
    public int TempoRimanente { get; set; }

    public Lavatrice(string nome, int detersivo, int ammorbiddente)
    {
        this.Programmi = new ProgrammaLavatrice[3];
        this.Programmi[0] = new ProgrammaLavatrice("rinfrescante", 20, 5, 2, 20);
        this.Programmi[1] = new ProgrammaLavatrice("rinnovante", 40, 10, 3, 40);
        this.Programmi[2] = new ProgrammaLavatrice("sgrassante", 60, 15, 4, 60);

        this.Nome = nome;
        this.Detersivo = detersivo;
        this.Ammorbidente = ammorbiddente;
        this.Stato = false;
        this.Incasso = 0;
    }

    public bool AvviaProgramma(string programma)
    {
        for (int i = 0; i < Programmi.Length; i++)
        {
            if (Programmi[i].Nome == programma)
            {
                if(this.Detersivo >= Programmi[i].QuantitàDetersivo && this.Ammorbidente >= Programmi[i].QuantitàAmmorbidente)
                {
                    this.Detersivo -= Programmi[i].QuantitàDetersivo;
                    this.Ammorbidente -= Programmi[i].QuantitàAmmorbidente;
                    this.Stato = true;
                    this.Incasso += (0.50 * Programmi[i].Costo);
                    this.TempoRimanente = Programmi[i].Durata;
                    return true;
                } 
            }
        }

        return false;
    }
}

public class ProgrammaLavatrice
{
    public string Nome { get; }
    public int QuantitàDetersivo { get; }
    public int QuantitàAmmorbidente { get; }
    public int Costo { get; }
    public int Durata { get; set; }

    public ProgrammaLavatrice(string nome, int quantitàDetersivo, int quantitàAmmorbidente, int costo, int durata)
    {
        this.Nome = nome;
        this.QuantitàDetersivo = quantitàDetersivo;
        this.QuantitàAmmorbidente = quantitàAmmorbidente;
        this.Costo = costo;
        this.Durata = durata;
    }
}

//-----------------------------------------------------------------------------------------------------------------

public class Asciugatrice
{
    public string Nome { get; }
    public ProgrammaAsciugatrice[] Programmi { get; set; }
    public bool Stato { get; set; }
    public double Incasso { get; set; }
    public int TempoRimanente { get; set; }

    public Asciugatrice(string nome)
    {
        this.Programmi = new ProgrammaAsciugatrice[2];
        this.Programmi[0] = new ProgrammaAsciugatrice("rapido", 2, 30);
        this.Programmi[1] = new ProgrammaAsciugatrice("intensivo", 4, 60);

        this.Nome = nome;
        this.Stato = false;
        this.Incasso = 0;
    }

    public bool AvviaProgramma(string programma)
    {
        for(int i = 0; i < Programmi.Length; i++)
        {
            if (Programmi[i].Nome == programma)
            {
                this.Stato = true;
                this.Incasso += (0.50 * Programmi[i].Costo);
                this.TempoRimanente = Programmi[i].Durata;
                return true;
            }
        }
        
        return false;
    }
}

public class ProgrammaAsciugatrice
{
    public string Nome { get; }
    public int Costo { get; }
    public int Durata { get; set; }

    public ProgrammaAsciugatrice(string nome, int costo, int durata)
    {
        this.Nome = nome;
        this.Costo = costo;
        this.Durata = durata;
    }
}

//-----------------------------------------------------------------------------------------------------------------

public class Lavanderia
{
    public string Nome { get; set; }
    public Lavatrice[] Lavatrici { get; set; }
    public Asciugatrice[] Asciugatrici { get; set; }

    public Lavanderia(string nome)
    {
        this.Nome = nome;

        this.Lavatrici = new Lavatrice[5];

        Lavatrice lavatrice1 = new Lavatrice("lavatrice1", 1000, 500);
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
            Console.WriteLine("------- LAVATRICI -------");
            for (int i = 0; i < Lavatrici.Length; i++)
            {
                Lavatrice lavatriceCorrente = Lavatrici[i];

                Console.WriteLine($"lavatrice numero {i + 1}");
                Console.WriteLine($"nome: {lavatriceCorrente.Nome}");
                Console.WriteLine($"quantità detersivo rimanente: {lavatriceCorrente.Detersivo} ml");
                Console.WriteLine($"quantità ammorbidente rimanente: {lavatriceCorrente.Ammorbidente} ml");
                Console.WriteLine($"incasso totale lavatrice: {lavatriceCorrente.Incasso} euro");
                Console.WriteLine("--------------------------------------------------------------");
            }

            Console.WriteLine();

            Console.WriteLine("------- ASCIUGATRICI -------");
            for (int i = 0; i < Asciugatrici.Length; i++)
            {
                Asciugatrice asciugatriceCorrente = Asciugatrici[i];

                Console.WriteLine($"asciugatrice numero {i + 1}");
                Console.WriteLine($"nome: {asciugatriceCorrente.Nome}");
                Console.WriteLine($"incasso totale lavatrice: {asciugatriceCorrente.Incasso} euro");
                Console.WriteLine("--------------------------------------------------------------");
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
                Console.WriteLine($"totale incasso: {Lavatrici[i].Incasso}");
                Console.WriteLine($"tempo rimanente: {Lavatrici[i].TempoRimanente} min");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"lavatrice numero {i + 1}");
                Console.WriteLine($"programma {Lavatrici[i]}: {programmaCorrente}");
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
                Console.WriteLine($"tempo rimanente: {Asciugatrici[i].TempoRimanente} min");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"asciugatrice numero {i + 1}");
                Console.WriteLine($"programma {Asciugatrici[i]}: {programmaCorrente}");
                Console.WriteLine("stato: non in funzione");
                Console.WriteLine();
            }
        }
    }
}