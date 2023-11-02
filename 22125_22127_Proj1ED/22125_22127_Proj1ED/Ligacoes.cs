using System;
using System.IO;
using System.Windows.Forms;

//Eloisa Paixão de Oliveira - 22127
//Eduarda Graziele de Paiva - 22125

internal class Ligacoes : IComparable<Ligacoes>, IRegistro<Ligacoes>
{
    const int tamOrigem = 15,
          tamDestino = 15,
          tamDistancia = 5;

    const int iniOrigem = 0,
              iniDestino = iniOrigem + tamOrigem,
              iniDistancia = iniDestino + tamDestino;


    string origem, destino, nomeArquivo;
    int distancia;

    public Ligacoes(string origem, string destino, int distancia)
    {
        this.origem = origem;
        this.destino = destino;
        this.distancia = distancia;
    }

    public Ligacoes(string origem, string destino)
    {
        this.origem = origem;
        this.destino = destino;
    }

    public Ligacoes() { }

    public string Origem { get => origem; set => origem = value; }
    public string Destino { get => destino; set => destino = value; }
    public int Distancia { get => distancia; set => distancia = value; }
    public string NomeArquivo { get => nomeArquivo; set => nomeArquivo = value; }


    const int tamanhoRegistro = tamOrigem +     // origem
                                tamDestino +    // destino
                                sizeof(int) +   // distancia
                                sizeof(int);     // custo

    public int TamanhoRegistro { get => tamanhoRegistro; }

    public int CompareTo(Ligacoes outro)
    {
        return (origem.ToUpperInvariant() + destino.ToUpperInvariant()).CompareTo(
                outro.origem.ToUpperInvariant() + outro.destino.ToUpperInvariant());
    }

    public string ParaArquivo()
    {
        return $"{Origem}{Destino}{Distancia:00000}";
    }

    public override string ToString()
    {
        return $"{Origem} {Destino} {Distancia:00000}";
    }

    public void LerRegistro(BinaryReader arquivo, long qualRegistro)
    {
        try
        {
            long bytes = qualRegistro * TamanhoRegistro;
            arquivo.BaseStream.Seek(bytes, SeekOrigin.Begin);

            foreach (char letra in arquivo.ReadChars(tamOrigem))
                if (letra != '\0')
                    origem += letra;

            foreach (char letra in arquivo.ReadChars(tamDestino))
                if (letra != '\0')
                    destino += letra;

            Distancia = arquivo.ReadInt32();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

    }


    public void GravarRegistro(BinaryWriter arquivo)
    {
        if (arquivo != null)    // arquivo aberto?
        {
            arquivo.Write(Origem);
            arquivo.Write(Destino);
            arquivo.Write(Distancia);
        }
    }
}