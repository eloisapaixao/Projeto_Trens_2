using System;
using System.Collections.Generic;

//Eloisa Paixão de Oliveira - 22127
//Eduarda Graziele de Paiva - 22125
public class PilhaLista<Dado> : Stack<Dado> where Dado : IComparable<Dado>
{
    NoLista<Dado> topo;
    int tam;
    public PilhaLista() 
    {
        topo = null;
        tam = 0;
    }
    public int tamanho ()
    {
        return this.tam;
    }
    public bool estaVazia ()
    {
        return topo == null;
    }
    public void empilhar(Dado o)
    {
       
        NoLista<Dado> novoNo = new NoLista<Dado>(o, topo);
        topo = novoNo; 
        tam++; 
    }
    public Dado oTopo()
    {
        if (estaVazia())
            throw new Exception("Underflow da pilha");
        return topo.Info;
    }
    public Dado desempilhar()
    {
        if (estaVazia())
            throw new Exception("Underflow da pilha");
        Dado o = topo.Info; 
        topo = topo.Prox;
        tam--;
        return o; 
    }

    public List<Dado> Listar()
    {
        List<Dado> lista = new List<Dado>();

        NoLista<Dado> atual = topo;
        while (atual != null)
        {
            lista.Add(atual.Info);
            atual = atual.Prox;
        }
        return lista;
    }
}
