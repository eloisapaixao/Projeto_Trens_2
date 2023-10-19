using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Eloisa Paixão de Oliveira - 22127
//Eduarda Graziele de Paiva - 22125

//classe genérica que armazena um dado da nossa lista, não especifica o que vai ser armazenado.
//info e prox tem que ser comparáveis.
public class NoLista<Dado> where Dado : IComparable<Dado> //os elementos se tornam comparáveis.
                                                          //interface comparativa. Ele exige que as classes podem ser comparadas. Garante que é comparável.
                                                          //retorna zero se forem iguais ou negativo se são diferentes.
{
    //info é qualque coisa que o Dado estiver armazenando.
    Dado info;

    //prox é um nó lista.
    NoLista<Dado> prox;

    //no nome do construtor não coloca o tipo da classe.
    public NoLista(Dado novaInfo, NoLista<Dado> proximo)
    {
        Info = novaInfo;
        Prox = proximo;
    }

    public NoLista(Dado novaInfo)
    {
        Info = novaInfo;
        Prox = null;
    }

    public Dado Info
    {
        get => info;
        set
        {
            if (value != null)
                info = value;
        }
    }

    public NoLista<Dado> Prox
    {
        get => prox;
        set => prox = value;
    }

}
