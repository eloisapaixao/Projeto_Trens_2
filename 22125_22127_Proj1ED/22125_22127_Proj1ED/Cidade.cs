using System;
using System.IO;

//Eloisa Paixão de Oliveira - 22127
//Eduarda Graziele de Paiva - 22125

class Cidade : IComparable<Cidade>, IRegistro<Cidade>
{
    const int tamNome = 15,
              tamX = 6,
              tamY = 6;

    const int iniNome = 0,
              iniX = iniNome + tamNome,
              iniY = iniX + tamX;

    string nome;
    decimal y, x;

    public string Nome
    {
        get => nome;
        set
        {
            if(nome.Length < tamNome || nome.Length > tamNome)
                nome = value.PadRight(tamNome, ' ').Substring(0, tamNome);
        }
    }
    public decimal X 
    { 
        get => x; 
        set => x = value; 
    }
    public decimal Y { get => y; set => y = value; }
    public Cidade() { }

    public Cidade(string nome, decimal x, decimal y)
    {
        this.nome = nome;
        this.x = x;
        this.y = y;
    }

    public int CompareTo(Cidade outro)
    {
        return nome.ToUpperInvariant().CompareTo(outro.nome.ToUpperInvariant());
    }

    public Cidade LerRegistro(StreamReader arquivo)
    {
        if (arquivo != null) // arquivo aberto?
        {
            string linha = arquivo.ReadLine();
            nome = linha.Substring(iniNome, tamNome);

            x = decimal.Parse(linha.Substring(iniX, tamX));

            y = decimal.Parse(linha.Substring(iniY));

            return this; // retorna o próprio objeto Contato, com os dados
        }
        return default(Cidade);
    }
    public String LerRegistros(StreamReader arquivo)
    {
        string l = "";
        if (arquivo != null) // arquivo aberto?
        {
            string linha = arquivo.ReadLine();
            nome = linha.Substring(iniNome, tamNome);

            x = decimal.Parse(linha.Substring(iniX, tamX));

            y = decimal.Parse(linha.Substring(iniY));
            l = ToString();
            return l; // retorna o próprio objeto Contato, com os dados
        }
        return "";
    }

    public void GravarRegistro(StreamWriter arq)
    {
        if (arq != null)  // arquivo de saída aberto?
        {
            arq.WriteLine(this.ToString());
        }
    }
    public string ParaArquivo()
    {
        return Nome + "        " + X.ToString() + "     " + Y.ToString();
    }

    public override string ToString()
    {
        return Nome.PadRight(tamNome+1, ' ') + X.ToString().PadLeft(tamX+1, ' ') + Y.ToString().PadLeft(tamY+1, ' ');
    }
}
