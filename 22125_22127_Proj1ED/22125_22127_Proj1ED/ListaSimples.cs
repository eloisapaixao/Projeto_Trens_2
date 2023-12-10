using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ListaSimples<Dado>
    where Dado : IComparable<Dado>, IRegistro<Dado>
{
    private NoLista<Dado> primeiro;
    private NoLista<Dado> ultimo;
    private NoLista<Dado> anterior, atual;
    private int quantosNos;

    private bool primeiroAcessoDoPercurso;

    public ListaSimples()
    {
        primeiro = ultimo = anterior = atual = null;
        quantosNos = 0;
        primeiroAcessoDoPercurso = false;
    }

    public void IniciarPercursoSequencial()
    {
        primeiroAcessoDoPercurso = true;
        atual = primeiro;
        anterior = null;
    }

    public bool PodePercorrer()
    {
        if (!primeiroAcessoDoPercurso)
        {
            anterior = atual;
            atual = atual.Prox;
        }
        else
            primeiroAcessoDoPercurso = false;

        return atual != null;
    }
    public void PercorrerLista()
    {
        atual = primeiro;
        while (atual != null)
        {
            Console.WriteLine(atual.Info);
            atual = atual.Prox;
        }
    }

    public bool EstaVazia
    {
        get { return primeiro == null; }
    }

    public NoLista<Dado> Primeiro
    {
        get
        {
            return primeiro;
        }
    }

    public NoLista<Dado> Ultimo
    {
        get
        {
            return ultimo;
        }
    }

    public int QuantosNos { get => quantosNos; set => quantosNos = value; }

    public NoLista<Dado> Atual
    {
        get
        {
            return atual;
        }
    }

    public int PosicaoAtual
    {
        get
        {
            var dadoAtual = Atual;

            int i = 0;
            atual = primeiro;
            while (atual != dadoAtual)
            {
                atual = atual.Prox;
                i++;
            }

            return i;
        }

        set
        {
            if (!EstaVazia && value < this.QuantosNos)
            {
                int posicao = value;
                atual = primeiro;
                for (int i = 0; i < value; i++)
                    atual = atual.Prox;
            }
        }
    }

    public void InserirAntesDoInicio(Dado novoDado)
    {
        var novoNo = new NoLista<Dado>(novoDado);
        if (EstaVazia)          // se a lista está vazia, estamos
            ultimo = novoNo;    // incluindo o 1o e o último nós!

        novoNo.Prox = primeiro;
        primeiro = novoNo;
        quantosNos++;
    }

    public void InserirAposFim(Dado novoDado)
    {
        var novoNo = new NoLista<Dado>(novoDado);
        if (EstaVazia)
            primeiro = novoNo;
        else
            ultimo.Prox = novoNo;

        ultimo = novoNo;
        ultimo.Prox = null;
        quantosNos++;
    }

    public void Listar(ListBox umListBox)
    {
        umListBox.Items.Clear();
        atual = primeiro;
        while (atual != null)
        {
            umListBox.Items.Add(atual.Info.ToString());
            atual = atual.Prox;
        }
    }

    public bool ExisteDado(Dado outroProcurado)
    {
        anterior = null;
        atual = primeiro;
        // Em seguida, é verificado se a lista está vazia. Caso esteja, é
        // retornado false ao local de chamada, indicando que a chave não foi
        // encontrada, e atual e anterior ficam valendo null
        if (EstaVazia)
            return false;
        // a lista não está vazia, possui nós
        // dado procurado é menor que o primeiro dado da lista:
        // portanto, dado procurado não existe
        if (outroProcurado.CompareTo(primeiro.Info) < 0)
            return false;
        // dado procurado é maior que o último dado da lista:
        // portanto, dado procurado não existe
        if (outroProcurado.CompareTo(ultimo.Info) > 0)
        {
            anterior = ultimo;
            atual = null;
            return false;
        }

        // caso não tenha sido definido que a chave está fora dos limites de
        // chaves da lista, vamos procurar no seu interior
        // o apontador atual indica o primeiro nó da lista e consideraremos que
        // ainda não achou a chave procurada nem chegamos ao final da lista
        bool achou = false;
        bool fim = false;
        // repete os comandos abaixo enquanto não achou o RA nem chegou ao
        // final da lista
        while (!achou && !fim)
            // se o apontador atual vale null, indica final da lista
            if (atual == null)
                fim = true;
            // se não chegou ao final da lista, verifica o valor da chave atual
            else
            // verifica igualdade entre chave procurada e chave do nó atual
            if (outroProcurado.CompareTo(atual.Info) == 0)
                achou = true;
            else
            // se chave atual é maior que a procurada, significa que
            // a chave procurada não existe na lista ordenada e, assim,
            // termina a pesquisa indicando que não achou. Anterior
            // aponta o anterior ao atual, que foi acessado por
            // último
            if (atual.Info.CompareTo(outroProcurado) > 0)
                fim = true;
            else
            {
                // se não achou a chave procurada nem uma chave > que ela,
                // então a pesquisa continua, de maneira que o apontador
                // anterior deve apontar o nó atual e o apontador atual
                // deve seguir para o nó seguinte
                anterior = atual;
                atual = atual.Prox;
            }
        // por fim, caso a pesquisa tenha terminado, o apontador atual
        // aponta o nó onde está a chave procurada, caso ela tenha sido
        // encontrada, ou o nó onde ela deveria estar para manter a
        // ordenação da lista. O apontador anterior aponta o nó anterior
        // ao atual
        return achou; // devolve o valor da variável achou, que indica
    } // se a chave procurada foi ou não encontrado

    public void InserirEmOrdem(Dado dados)
    {
        if (EstaVazia) // se a lista está vazia, então o
            InserirAntesDoInicio(dados); // novo nó é o primeiro da lista
        else
          // testa se nova chave < primeira chave
          if (dados.CompareTo(primeiro.Info) < 0)  // novo nó será ligado
            InserirAntesDoInicio(dados);          // antes do primeiro
        else
            // testa se nova chave > última chave
            if (dados.CompareTo(ultimo.Info) > 0)
            InserirAposFim(dados);  // cria nó e o liga no fim da lista
        else
              if (!ExisteDado(dados))  // insere entre os nós anterior 
        {                        // e atual 
            var novo = new NoLista<Dado>(dados, null);
            anterior.Prox = novo; // liga anterior ao novo
            novo.Prox = atual; // e novo no atual
            if (anterior == ultimo) // se incluiu ao final da lista,
                ultimo = novo; // atualiza o apontador ultimo
            quantosNos++;
        }
        else
            throw new Exception("Já existe!");
    }

    public bool RemoverDado(Dado aExcluir)
    {
        if (ExisteDado(aExcluir))
        {  // lista não está vazia, temos um 1o e um último
            if (atual == primeiro)  // caso especial
            {
                primeiro = primeiro.Prox;
                atual = primeiro;
                if (primeiro == null)  // se esvaziou a lista!!!!
                    ultimo = null;     // ultimo passa a apontar nada
            }
            else
                if (atual == ultimo)  // caso especial
            {
                ultimo = anterior;
                ultimo.Prox = null;
                atual = ultimo;
            }
            else  // caso geral, nó interno sendo excluído
            {
                anterior.Prox = atual.Prox;
                atual = atual.Prox;
            }

            quantosNos--;
            return true;  // conseguiu excluir
        }

        return false;
    }
    private void InserirNoMeio(Dado dados)
    {
        var novo = new NoLista<Dado>(dados, null); // guarda dados no
                                                   // novo nó
                                                   // existeChave() encontrou intervalo de inclusão do novo nó
        anterior.Prox = novo; // liga anterior ao novo
        novo.Prox = atual; // e novo no atual
        if (anterior == ultimo) // se incluiu ao final da lista,
            ultimo = novo; // atualiza o apontador ultimo
        quantosNos++; // incrementa número de nós da lista
    }

    public void Ordenar()
    {
        ListaSimples<Dado> ordenada = new ListaSimples<Dado>();
        while (!this.EstaVazia)
        {
            // achar o menor de todos
            // remover o menor de todos
            // incluir o menor de todos já removido na lista ordenada
        }
        this.primeiro = ordenada.primeiro;
        this.ultimo = ordenada.ultimo;
        this.quantosNos = ordenada.quantosNos;
    }

    public int Contar()
    {
        int cont = 0;

        for (atual = primeiro;
             atual != null;
             cont++, atual = atual.Prox) ;

        return cont;
    }

    private void InserirAposFim(NoLista<Dado> noAntigo)
    {
        if (EstaVazia)
            primeiro = noAntigo;
        else
            ultimo.Prox = noAntigo;
        ultimo = noAntigo;
        noAntigo.Prox = null;
        quantosNos++;
    }
    public void SepararEmDuasListas(
        ref ListaSimples<Dado> l1,
        ref ListaSimples<Dado> l2)
    {
        l1 = new ListaSimples<Dado>();
        l2 = new ListaSimples<Dado>();
        while (!this.EstaVazia)
        {
            atual = this.primeiro;
            NoLista<Dado> aux = atual.Prox;
            /*if (atual.Info.Separar())
                l2.InserirAposFim(atual);
            else
                l1.InserirAposFim(atual);
            this.primeiro = aux;
            this.quantosNos--;*/
        }
        this.ultimo = null;
    }

    public ListaSimples<Dado> Juntar(
        ListaSimples<Dado> outra)
    {
        var lista3 = new ListaSimples<Dado>();
        this.atual = this.primeiro;
        outra.atual = outra.primeiro;

        NoLista<Dado> aux = null;
        while (this.atual != null && outra.atual != null)
        {
            if (this.atual.Info.CompareTo(
                outra.atual.Info) < 0)
            {
                aux = this.atual.Prox;
                lista3.InserirAposFim(this.atual);
                this.atual = aux;
                this.quantosNos--;
            }
            else
              if (outra.atual.Info.CompareTo(
                   this.atual.Info) < 0)
            {
                aux = outra.atual.Prox;
                lista3.InserirAposFim(outra.atual);
                outra.atual = aux;
                outra.quantosNos--;
            }
            else
            {
                aux = this.atual.Prox;
                lista3.InserirAposFim(this.atual);
                this.atual = aux;
                outra.atual = outra.atual.Prox;
                this.quantosNos--;
                outra.quantosNos--;
            }
        }  // while

        if (lista3.ultimo != null) // se houve casamento
            if (this.atual == null) // acabou o percurso da lista1
            {
                lista3.ultimo.Prox = outra.atual;
                lista3.ultimo = outra.ultimo;
                lista3.quantosNos += outra.quantosNos;
            }
            else
            {
                lista3.ultimo.Prox = this.atual;
                lista3.ultimo = this.ultimo;
                lista3.quantosNos += this.quantosNos;
            }
        this.primeiro = this.ultimo = outra.primeiro = outra.ultimo = null;
        this.quantosNos = outra.quantosNos = 0;
        return lista3;
    }

    public void Inverter()
    {
        if (!EstaVazia)
        {
            NoLista<Dado> um = primeiro;
            NoLista<Dado> dois = um.Prox;
            while (dois != null)
            {
                NoLista<Dado> tres = dois.Prox;
                dois.Prox = um;
                um = dois;
                dois = tres;
            }
            ultimo = primeiro;
            primeiro = um;
            ultimo.Prox = null;
        }
    }

    public List<Dado> Lista()
    {
        var lista = new List<Dado>();
        atual = primeiro;
        while (atual != null)
        {
            lista.Add(atual.Info);
            atual = atual.Prox;
        }
        return lista;
    }

    public void GravarRegistros(BinaryWriter arq)
    {
        var posicaoAtual = PosicaoAtual;
        this.IniciarPercursoSequencial();
        while (PodePercorrer())
        {
            this.Atual.Info.GravarRegistro(arq);
        }
        PosicaoAtual = posicaoAtual;
    }

    public void LerRegistro(string nomeArquivo)
    {
        StreamReader arq = new StreamReader(nomeArquivo);
        while (!arq.EndOfStream)
        {
            Dado dado = new Dado();
            this.Incluir(dado.LerRegistro(arq));
        }
        arq.Close();
    }
}

