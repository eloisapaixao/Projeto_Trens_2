using System;
using System.IO;

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

    public int CompareTo(Ligacoes outro)
    {
        return (origem.ToUpperInvariant() + destino.ToUpperInvariant()).CompareTo(
                outro.origem.ToUpperInvariant() + outro.destino.ToUpperInvariant());
    }

    public Ligacoes LerRegistro(StreamReader arquivo)
    {
        if (arquivo != null) // arquivo aberto?
        {
            string linha = arquivo.ReadLine();
            origem = linha.Substring(iniOrigem, tamOrigem);
            destino = linha.Substring(iniDestino, tamDestino);
            Distancia = int.Parse(linha.Substring(iniDistancia, tamDistancia));
            Custo = int.Parse(linha.Substring(iniCusto, tamCusto));
            return this; // retorna o próprio objeto Contato, com os dados
        }
        return default(Ligacoes);
    }
    public void GravarRegistro(StreamWriter arq)
    {
        if (arq != null)  // arquivo de saída aberto?
        {
            arq.WriteLine(ParaArquivo());
        }
    }
    public string ParaArquivo()
    {
        return $"{Origem}{Destino}{Distancia:00000}{Custo:00000}";
    }

    public override string ToString()
    {
        return $"{Origem} {Destino} {Distancia:00000} {Custo:00000}";
    }
}