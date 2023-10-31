using System;
using System.IO;
using System.Windows.Forms;

//Eloisa Paixão de Oliveira - 22127
//Eduarda Graziele de Paiva - 22125

internal class Ligacoes : IComparable<Ligacoes>, IRegistro<Ligacoes>
{
    const int tamOrigem = 15,
          tamDestino = 15,
          tamDistancia = 5,
          tamCusto = 5;

    const int iniOrigem = 0,
              iniDestino = iniOrigem + tamOrigem,
              iniDistancia = iniDestino + tamDestino,
              iniCusto = iniDistancia + tamDistancia;


    string origem, destino;
    int distancia, custo;

    public Ligacoes(string origem, string destino, int distancia, int custo)
    {
        this.origem = origem;
        this.destino = destino;
        this.distancia = distancia;
        this.custo = custo;
    }

    public Ligacoes() { }

    public string Origem { get => Origem; set => Origem = value; }
    public string Destino { get => Destino; set => Destino = value; }
    public int Distancia { get => distancia; set => distancia = value; }
    public int Custo { get => custo; set => custo = value; }


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
        return $"{Origem}{Destino}{Distancia:00000}{Custo:00000}";
    }

    public override string ToString()
    {
        return $"{Origem} {Destino} {Distancia:00000} {Custo:00000}";
    }

    public void LerRegistro(BinaryReader arquivo, long qualRegistro)
    {
        if (arquivo != null)
            try
            {
                long qtosBytes = qualRegistro * TamanhoRegistro;
                arquivo.BaseStream.Seek(qtosBytes, SeekOrigin.Begin);
                // arquivo leia TamanhoRegistro bytes e separe pelos campos:

                char[] umaOrigem = new char[tamOrigem]; // vetor de 30 char
                umaOrigem = arquivo.ReadChars(tamOrigem);  // lê 30 chars
                string origemLida = new string(umaOrigem);

                char[] umDestino = new char[tamDestino]; // vetor de 30 char
                umDestino = arquivo.ReadChars(tamDestino);  // lê 30 chars
                string destinoLido = new string(umDestino);

                Distancia = arquivo.ReadInt32();
                Custo = arquivo.ReadInt32();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }

    public void GravarRegistro(BinaryWriter arquivo)
    {
        if (arquivo != null)    // arquivo aberto?
        {
            arquivo.Write(Origem);
            arquivo.Write(Destino);
            arquivo.Write(Distancia);
            arquivo.Write(Custo);
        }
    }
}