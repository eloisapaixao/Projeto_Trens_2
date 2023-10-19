using System;
using System.Windows.Forms;

//Eloisa Paixão de Oliveira - 22127
//Eduarda Graziele de Paiva - 22125
class ListaDupla<Dado> : IDados<Dado>
                where Dado : IComparable<Dado>, IRegistro<Dado>, new()
{
    NoDuplo<Dado> primeiro, ultimo, atual;
    int quantosNos;

    public ListaDupla()
    {
        primeiro = ultimo = atual = null;
        quantosNos = 0;
    }
    private Situacao situacao;
    public Situacao SituacaoAtual  //implementar onde for solicitado a mudanca de situação
    {
        get => situacao;
        set => situacao = value;
    }
    int posicaoAtual = 0;
    public int PosicaoAtual //implementar onde tiver uma condição de repetição que percorre a lista
    {
        get => posicaoAtual;
        set => posicaoAtual = value;
    }
    public bool EstaNoInicio
    {
        get => atual == primeiro;
    }
    public bool EstaNoFim
    {
        get => atual == ultimo;
    }
    public bool EstaVazio
    {
        get => primeiro == null;
    }          // (bool) Verificar se está vazia
    public int Tamanho => quantosNos;

    internal NoDuplo<Dado> Primeiro { get => primeiro; set => primeiro = value; }
    internal NoDuplo<Dado> Ultimo { get => ultimo; set => ultimo = value; }
    internal NoDuplo<Dado> Atual { get => atual; set => atual = value; }

    public void LerDados(string nomeArquivo)    // fará a lei       ura e armazenamento dos dados do arquivo cujo nome é passado por parâmetro
    {
        situacao = Situacao.navegando;
        var arquivo = new StreamReader(nomeArquivo);
        while (!arquivo.EndOfStream)
        {
            var dado = new Dado();
            Incluir(dado.LerRegistro(arquivo));
        }
    }                          
    public void GravarDados(string nomeArquivo)  // gravará sequencialmente, no arquivo cujo nome é passado por parâmetro, os dados armazenados na lista
    {
        situacao = Situacao.incluindo;
        var arquivo = new StreamWriter(nomeArquivo);
        atual = primeiro;
        posicaoAtual = 0;
        while (atual != null)
        {
            posicaoAtual++;
            atual.Info.GravarRegistro(arquivo);
            atual = atual.Prox;
        }
    }
    public void PosicionarNoPrimeiro()        // Posicionar atual no primeiro nó para ser acessado
    {
        situacao = Situacao.pesquisando;
        if (!EstaVazio)
            if (!EstaNoInicio)
                atual = primeiro;
    }
    public void RetrocederPosicao()        // Retroceder atual para o nó anterior para ser acessado
    {
        situacao = Situacao.pesquisando;
        if (!EstaVazio)
        {
            if (atual.Ant != null)
                atual = atual.Ant;
            else
                throw new Exception("Anterior não existe");
        }
    }
    public void AvancarPosicao()
    {
        situacao = Situacao.pesquisando;
        if (!EstaVazio)
            if (atual.Prox != null)
                atual = atual.Prox;
    }
    public void PosicionarNoUltimo()        // posicionar atual no último nó para ser acessado
    {
        situacao = Situacao.pesquisando;
        if (!EstaVazio)
            if (!EstaNoFim)
                atual = ultimo;
    }
    public void PosicionarEm(int posicaoDesejada)
    {
        situacao = Situacao.pesquisando;
        if (!EstaVazio)
        {
            if (posicaoDesejada == 0)
                atual = primeiro;
            else
                if (posicaoDesejada == Tamanho - 1)
                atual = ultimo;
            else
            {
                atual.Ant = null;
                atual = primeiro;
                for (int i = 0; i < posicaoDesejada; i++)
                {
                    atual.Ant = atual;
                    atual = atual.Prox;
                }
            }
        }
    }

    // (bool) Pesquisar Dado procurado em ordem crescente; a pesquisa
    // posicionará o ponteiro atual no nó procurado quando este
    // or encontrado ou, se não achar, no nó seguinte a local
    // onde deveria estar o nó procurado
    public bool Existe(Dado procurado, out int ondeEsta)
    {
        situacao = Situacao.pesquisando;
        int c = 0;
        bool existe = false;
        atual = primeiro;
        ondeEsta = -1;

        while (atual != null)
        {
            if (atual.Info.CompareTo(procurado) == 0)
            {
                ondeEsta = c;
                existe = true;
                break;
            }
            atual = atual.Prox;
            c++;
        }

        return existe;
    }
    public bool Excluir(Dado dadoAExcluir)
    {
        situacao = Situacao.excluindo;
        var dadoExcluido = new NoDuplo<Dado>(dadoAExcluir);

        if (!EstaVazio)
        {
            if (dadoExcluido.Info.CompareTo(primeiro.Info) == 0) //se existe, ele é o primeiro?
            {
                primeiro = primeiro.Prox; // então o primeiro passará a ser o próximo
                atual = primeiro; // o atual será o primeiro
            }
            else
                if (dadoExcluido.Info.CompareTo(ultimo.Info) == 0)
            {
                ultimo = atual.Ant;
                atual = ultimo;
                atual.Ant = ultimo.Ant;
            }
            else
            {
                atual = primeiro;
                while (atual != null && dadoExcluido.Info.CompareTo(atual.Info) != 0)
                {
                    atual = atual.Prox;
                }

                atual.Ant.Prox = atual.Prox;
                atual.Prox.Ant = atual.Ant;
                atual = atual.Prox;
            }
            quantosNos--;
            return true;
        }
        return false;
    }
    public bool IncluirNoInicio(Dado novoValor)
    {
        situacao = Situacao.incluindo;
        var novoNo = new NoDuplo<Dado>(novoValor);
        if (EstaVazio)
            ultimo = novoNo;

        primeiro.Prox = primeiro;
        primeiro = novoNo;
        primeiro.Ant = null;
        atual = primeiro;
        return true;
    }
    public bool IncluirAposFim(Dado novoValor)
    {
        situacao = Situacao.incluindo;
        var novoNo = new NoDuplo<Dado>(novoValor);
        if (EstaVazio)
            primeiro = novoNo;
        else
            ultimo.Prox = novoNo;
        novoNo.Ant = ultimo;
        ultimo = novoNo;
        return true;
    }
    public bool Incluir(Dado novoValor)         // (bool) Inserir nó com Dado em ordem crescente
    {
        situacao = Situacao.incluindo;
        var novoNo = new NoDuplo<Dado>(novoValor);
        bool incluiu = false;

        if (EstaVazio)
        {
            primeiro = ultimo = novoNo;
            quantosNos++;
            incluiu = true;
        }
        else if (novoNo.Info.CompareTo(primeiro.Info) < 0)
        {
            IncluirNoInicio(novoValor);
            quantosNos++;
            incluiu = true;
        }
        else if (novoNo.Info.CompareTo(ultimo.Info) > 0)
        {
            IncluirAposFim(novoValor);
            quantosNos++;
            incluiu = true;
        }
        else
        {
            //verifica se o novo nó é maior que todos os outros nós da lista até achar um maior que ele 
            // para ser inserido
            atual = primeiro;
            while (atual != null && novoNo.Info.CompareTo(atual.Info) > 0)
            {
                atual = atual.Prox;
            }

            var anterior = atual.Ant;
            anterior.Prox = novoNo;
            novoNo.Ant = anterior;
            novoNo.Prox = atual;
            atual.Ant = novoNo;
            quantosNos++;
            incluiu = true;
        }

        return incluiu;
    }
    public bool Incluir(Dado novoValor, int posicaoDeInclusao)  // inclui novo nó na posição indicada da lista
    {
        situacao = Situacao.incluindo;
        var novoNo = new NoDuplo<Dado>(novoValor);
        bool incluiu = false;
        atual = primeiro;
        if (posicaoDeInclusao <= 0)
        {
            IncluirNoInicio(novoValor);
            incluiu = true;
        }
        else
            if (posicaoDeInclusao > Tamanho - 1)
        {
            IncluirAposFim(novoValor);
            incluiu = true;
        }
        else
        {
            for (int c = 0; c <= posicaoDeInclusao; c++)
            {
                atual.Ant = atual;
                atual = atual.Prox;
            }
            novoNo.Prox = atual;
            atual.Ant = novoNo;
            quantosNos++;
            incluiu = true;
        }
        return incluiu;
    }
    public Dado this[int indice]
    {
        get => this[indice];
        set => this[indice] = value;
    }
    public Dado DadoAtual()  // retorna o dado atualmente visitado
    {
        if (atual == null)
            throw new Exception("Lista vazia!!");
        return atual.Info;
    }
    public void ExibirDados()   // lista os dados armazenados na lista em modo console
    {
        atual = primeiro;
        while (atual != null)
        {
            Console.WriteLine(atual.Info.ParaArquivo() + "\n");
            atual = atual.Prox;
        }
    }
    public void ExibirDados(ListBox lista)  // lista os dados armazenados na lista no listbox passado como parâmetro
    {
        lista.Items.Clear();
        atual = primeiro;
        while (atual != null)
        {
            lista.Items.Add(atual.Info.ParaArquivo());
            atual = atual.Prox;
        }
    }
    public void ExibirDados(ComboBox lista) // lista os dados armazenados na lista no combobox passado como parâmetro
    {
        atual = primeiro;
        while (atual != null)
        {
            lista.Items.Add(atual.Info.ParaArquivo());
            atual = atual.Prox;
        }
    }
    public void ExibirDados(TextBox lista)
    {
        atual = primeiro;
        while (atual != null)
        {
            lista.Text = atual.Info.ParaArquivo();
            atual = atual.Prox;
        }
    }
    public void Ordenar()
    {
        situacao = Situacao.editando;
        var listaOrdenada = new ListaDupla<Dado>();
        while (!this.EstaVazio)
        {
            this.atual = this.primeiro;
            NoDuplo<Dado> oMenor;
            oMenor = this.primeiro;
            this.atual.Ant = null;
            while (this.atual != null)
            {
                if (this.atual.Info.CompareTo(oMenor.Info) < 0)
                {
                    oMenor = this.atual;
                }
                atual.Ant = atual;
                this.atual = atual.Prox;
            }
            if (oMenor.Ant == null)
            {
                oMenor.Prox = null;
                primeiro = primeiro.Prox;
                primeiro.Ant = null;
            }
            else
            {
                oMenor.Ant.Prox = oMenor.Prox;
                oMenor.Prox.Ant = oMenor.Ant;
            }
            this.quantosNos--;
            listaOrdenada.IncluirAposFim(oMenor.Info);
        }
        this.primeiro = listaOrdenada.primeiro;
        this.ultimo = listaOrdenada.ultimo;
        this.atual = listaOrdenada.atual;
        this.quantosNos = listaOrdenada.quantosNos;
    }
}