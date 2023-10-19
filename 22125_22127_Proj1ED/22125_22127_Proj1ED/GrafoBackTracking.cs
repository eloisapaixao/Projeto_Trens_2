using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Eloisa Paixão de Oliveira - 22127
//Eduarda Graziele de Paiva - 22125

class GrafoBacktracking<Dado> : IComparable<Dado>, IRegistro<Movimento>
{
    int qtasCidades;
    int[,] matriz;

    public GrafoBacktracking(int[,] matriz, int qtasCidades)
    {
        this.qtasCidades = qtasCidades;
        this.matriz = matriz;
    }

    public int QtasCidades { get => qtasCidades; set => qtasCidades = value; }
    public int[,] Matriz { get => matriz; set => matriz = value; }

    public PilhaLista<Movimento> BuscarCaminho(int origem, int destino)
    {
        int cidadeAtual, saidaAtual;
        bool achouCaminho = false,
        naoTemSaida = false;
        bool[] passou = new bool[qtasCidades];
        // inicia os valores de “passou” pois ainda não foi em nenhuma cidade
        for (int indice = 0; indice < qtasCidades; indice++)
            passou[indice] = false;
        cidadeAtual = origem;
        saidaAtual = 0;
        var pilha = new PilhaLista<Movimento>();
        while (!achouCaminho && !naoTemSaida)
        {
            naoTemSaida = (cidadeAtual == origem && saidaAtual == qtasCidades && pilha.estaVazia());
            if (!naoTemSaida)
            {
                while ((saidaAtual < qtasCidades) && !achouCaminho)
                {
                    if (matriz[cidadeAtual, saidaAtual] == 0)
                        saidaAtual++;
                    else
                        // se já passou pela cidade testada, vê se a próxima cidade permite saída
                        if (passou[saidaAtual])
                        saidaAtual++;
                    else
                            // se chegou na cidade desejada, empilha o local
                            // e termina o processo de procura de caminho
                            if (saidaAtual == destino)
                    {

                        Movimento movim = new Movimento(cidadeAtual, saidaAtual);
                        pilha.empilhar(movim);
                        achouCaminho = true;
                    }
                    else
                    {

                        Movimento movim = new Movimento(cidadeAtual, saidaAtual);
                        pilha.empilhar(movim);
                        passou[cidadeAtual] = true;
                        cidadeAtual = saidaAtual; // muda para a nova cidade
                        saidaAtual = 0; // reinicia busca de saídas da nova
                                        // cidade a partir da primeira cidade

                    }
                }
            } /// if ! naoTemSaida
            if (!achouCaminho)
                if (!pilha.estaVazia())
                {
                    var movim = pilha.desempilhar();
                    saidaAtual = movim.Destino;
                    cidadeAtual = movim.Origem;
                    saidaAtual++;
                }
        }
        var saida = new PilhaLista<Movimento>();
        if (achouCaminho)
        { // desempilha a configuração atual da pilha
          // para a pilha da lista de parâmetros
            while (!pilha.estaVazia())
            {
                Movimento movim = pilha.desempilhar();
                saida.empilhar(movim);
            }
        }
        return saida;
    }
}