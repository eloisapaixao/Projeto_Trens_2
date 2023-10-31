using System;
using System.IO;
using System.Windows.Forms;

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

    const int tamanhoRegistro = tamNome +     // nome
                                sizeof(decimal) +   // tamanho x
                                sizeof(decimal);     // tamanho y


    string nome;
    decimal y, x;

    public string Nome
    {
        get => nome;
        set
        {
            if (nome.Length < tamNome || nome.Length > tamNome)
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

    public int TamanhoRegistro { get => tamanhoRegistro; }
    public void GravarRegistro(BinaryWriter arquivo)
    {
        if (arquivo != null)    // arquivo aberto?
        {
            char[] umNome = new char[tamNome];
            for (int i = 0; i < tamNome; i++)
                umNome[i] = this.nome[i];
            arquivo.Write(umNome);
            arquivo.Write(X);
            arquivo.Write(Y);
        }
    }
    public string ParaArquivo()
    {
        return Nome + "        " + X.ToString() + "     " + Y.ToString();
    }

    public override string ToString()
    {
        return Nome.PadRight(tamNome + 1, ' ') + X.ToString().PadLeft(tamX + 1, ' ') + Y.ToString().PadLeft(tamY + 1, ' ');
    }

    public void LerRegistro(BinaryReader arquivo, long qualRegistro)
    {
        if (arquivo != null)
            try
            {
                long qtosBytes = qualRegistro * TamanhoRegistro;
                arquivo.BaseStream.Seek(qtosBytes, SeekOrigin.Begin);
                // arquivo leia TamanhoRegistro bytes e separe pelos campos:

                char[] umNome = new char[tamNome]; // vetor de 30 char
                umNome = arquivo.ReadChars(tamNome);  // lê 30 chars
                string nomeLido = new string(umNome);

                Nome = nomeLido;
                X = arquivo.ReadDecimal();
                Y = arquivo.ReadDecimal();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }
}
