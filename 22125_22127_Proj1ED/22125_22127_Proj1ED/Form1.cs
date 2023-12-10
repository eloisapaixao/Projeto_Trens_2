using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22125_22127_Proj1ED
{
    public partial class frmMapa : Form
    {
        public frmMapa()
        {
            InitializeComponent();
        }

        Arvore<Cidade> arvore;
        private Cidade cidadeSelecionada;
        Grafo oGrafo = new Grafo(null);

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtDestino.Clear();
            txtOrigem.Clear();
            nudCoordenadaX.Value = nudCoordenadaY.Value = 0;
            nudDistancia2.Value = 0;
            dgvRotas.Rows.Clear();
        }

        private void frmMapa_Load_1(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                arvore = new Arvore<Cidade>();
                arvore.LerArquivoDeRegistros(dlgAbrir.FileName);

                if (dlgLigacoes.ShowDialog() == DialogResult.OK)
                {
                    FileStream cidadesLigacoes = new FileStream(dlgLigacoes.FileName, FileMode.Open);
                    BinaryReader arquivoLigacoes = new BinaryReader(cidadesLigacoes);

                    for (int registro = 0;
                        registro < (int)cidadesLigacoes.Length / new Ligacoes().TamanhoRegistro;
                        registro++)
                    {
                        Ligacoes ligacoes = new Ligacoes();
                        ligacoes.LerRegistro(arquivoLigacoes, registro);
                        ligacoes.NomeArquivo = dlgLigacoes.FileName;

                        if (arvore.Existe(new Cidade(ligacoes.Origem)))
                            arvore.Atual.Info.Ligacoes.InserirEmOrdem(ligacoes);
                    }
                    arquivoLigacoes.Close();
                    cidadesLigacoes.Close();
                }

                if (arvore.Tamanho() > 0)
                {
                    cidadeSelecionada = arvore.Raiz.Info;
                    Preencher();
                }
            }
        }

        private void pcArvore_Paint(object sender, PaintEventArgs e)
        {
            arvore.DesenharArvore(pcArvore.Width / 2, 0, e.Graphics);
        }

        private void pcMapa_Paint(object sender, PaintEventArgs e)
        {
            Percorrer(arvore.Raiz);

            void Percorrer(NoArvore<Cidade> noCidade)
            {
                if (noCidade == null)
                    return;

                Cidade cidade = noCidade.Info;

                int x = (int)(cidade.X * pcMapa.Width);
                int y = (int)(cidade.Y * pcMapa.Height);
                ComboBoxComplete(noCidade);


                // a cidade selecionada fica em destaque na cor vermelha, as demais
                // permanecem na cor preta
                Brush brush = cidade == cidadeSelecionada ? Brushes.Black : Brushes.Red;

                e.Graphics.FillEllipse(brush, new Rectangle(x, y, 6, 6));

                e.Graphics.DrawString(cidade.Nome, new Font("Arial", 10), brush, x - cidade.Nome.Length * 2 - 10, y - 15);

                Percorrer(noCidade.Esq);
                Percorrer(noCidade.Dir);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            string nomeCidade = txtNome.Text.Trim();
            double xCidade = (double)nudCoordenadaX.Value;
            double yCidade = (double)nudCoordenadaY.Value;

            if (nomeCidade == "" || xCidade == 0 || yCidade == 0)
                MessageBox.Show("Erro! Verifique se os campos estão preenchidos corretamente.");

            else
            {
                Cidade cidade = new Cidade(nomeCidade, xCidade, yCidade);

                if (!arvore.Existe(cidade))
                {
                    arvore.IncluirNovoRegistro(cidade);
                    cidadeSelecionada = cidade;
                    MessageBox.Show("Inclusão feita com sucesso!");
                    LimparCampos();
                    Preencher();
                    pcArvore.Invalidate();
                    pcMapa.Invalidate();
                }

                else
                    MessageBox.Show("Erro ao incluir a cidade. Verifique se a cidade já existe!");
            }
        }

        private void Preencher()
        {
            if (cidadeSelecionada != null)
            {
                txtNome.Text = cidadeSelecionada.Nome;
                nudCoordenadaX.Value = (decimal)cidadeSelecionada.X;
                nudCoordenadaY.Value = (decimal)cidadeSelecionada.Y;

                dgvRotas.Rows.Clear();
                var cid = cidadeSelecionada.Ligacoes;
                if (!cid.EstaVazia)
                {
                    //QuantosNos está vazio porque os dados não estão sendo armazenados na lista
                    dgvRotas.RowCount = cid.QuantosNos;

                    Ligacoes lig = cid.Primeiro.Info;

                    lig.Destino = txtDestino.Text;
                    lig.Origem = txtOrigem.Text;

                    lig.Distancia = (int)nudDistancia2.Value;

                    var posicaoAtual = cid.PosicaoAtual;

                    cid.IniciarPercursoSequencial();
                    int n = 0;
                    while (cid.PodePercorrer())
                    {
                        dgvRotas.Columns.Add($"{n}", "");
                        dgvRotas.Rows[n].Cells[0].Value = cid.Atual.Info.Destino;
                        dgvRotas.Rows[n].Cells[1].Value = cid.Atual.Info.Distancia;
                        dgvRotas.Rows[n].Cells[2].Value = cid.Atual.Info.Origem;
                        n++;
                    }
                    cid.PosicaoAtual = posicaoAtual;
                }
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            string cidadeNome = txtNome.Text.Trim();

            if (string.IsNullOrWhiteSpace(cidadeNome))
            {
                MessageBox.Show("Erro! Verifique se o campo está preenchido corretamente.");
            }
            else
            {
                // Verifica se a cidade existe na árvore
                Cidade cidadeProcurada = new Cidade(cidadeNome);

                if (arvore.Existe(cidadeProcurada))
                {
                    // Obtem a cidade encontrada na árvore
                    Cidade cidadeEncontrada = arvore.DadoAtual();

                    // Atualiza os campos na interface com as informações da cidade
                    nudCoordenadaX.Value = (decimal)cidadeEncontrada.X;
                    nudCoordenadaY.Value = (decimal)cidadeEncontrada.Y;

                    // Atualiza a cidade selecionada e os campos da interface
                    cidadeSelecionada = cidadeEncontrada;
                    ListaSimples<Ligacoes> rotasEncontradas = cidadeEncontrada.Ligacoes;
                    Preencher();

                    pcMapa.Invalidate();
                    pcArvore.Invalidate();
                }
                else
                {
                    MessageBox.Show("Cidade não encontrada!");
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //gravará os dados armazenados na arvore no arquivo fornecido pelo usuário 
            arvore.GravarArquivoDeRegistros(dlgAbrir.FileName);

            var destino = new FileStream(dlgLigacoes.FileName, FileMode.Create);
            var arquivo = new BinaryWriter(destino);
            CircularEmOrdem(arvore.Raiz, (NoArvore<Cidade> no) =>
            {
                no.Info.Ligacoes.GravarRegistros(arquivo);
            });
            arquivo.Close();

            MessageBox.Show("Registros salvos!");
        }
        void CircularEmOrdem(NoArvore<Cidade> r, Action<NoArvore<Cidade>> operacao)
        {
            if (r != null)
            {
                CircularEmOrdem(r.Esq, operacao);
                operacao(r);
                CircularEmOrdem(r.Dir, operacao);
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string cidadeARemover = txtNome.Text.Trim();

            if (cidadeARemover == "")
                MessageBox.Show("Campo cidade está vazio, preencha-o corretamente!");
            else
            {
                if (arvore.ApagarNo(new Cidade(cidadeARemover)))
                {
                    cidadeSelecionada = arvore.Raiz.Info;
                    LimparCampos();
                    MessageBox.Show("Cidade removida com sucesso!!");
                    Preencher();
                    pcMapa.Invalidate();
                    pcMapa.Invalidate();
                }
                else
                {
                    MessageBox.Show("Erro ao remover cidade. Cidade não encontrada!");
                }
            }
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();

            // confere se o nome está vazio, se der true mostra a mensagem de erro
            if (nome == "")
            {
                MessageBox.Show("Campo do nome vazio!");
            }
            else
            {
                Cidade cidade = new Cidade(nome);

                if (arvore.Existe(cidade))
                {
                    double cidadeX = (double)nudCoordenadaX.Value;
                    double cidadeY = (double)nudCoordenadaY.Value;

                    if (cidadeX == 0 || cidadeY == 0)
                    {
                        MessageBox.Show("Coordenadas inválidas!");
                        return;
                    }
                    else
                    {
                        cidade.X = cidadeX;
                        cidade.Y = cidadeY;

                        cidade.Ligacoes = arvore.Atual.Info.Ligacoes;

                        if (arvore.ApagarNo(cidade))
                        {
                            arvore.IncluirNovoRegistro(cidade);
                            MessageBox.Show("Cidade alterada com sucesso!");
                            LimparCampos();
                            Preencher();
                            pcMapa.Invalidate();
                            pcMapa.Invalidate();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível alterar a cidade!");
                        }
                    }

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Text = " ";
            nudCoordenadaX.Value = 0;
            nudCoordenadaY.Value = 0;
        }

        private void btnIncluirCaminho_Click(object sender, EventArgs e)
        {
            string nomeOrigem = txtOrigem.Text;
            string nomeDestino = txtDestino.Text;
            int distancia = (int)nudDistancia2.Value;

            if (nomeOrigem == "" || nomeDestino == "" || distancia == 0)
                MessageBox.Show("Dados inválidos! Preencha-os corretamente");

            else
            {
                var origem = new Cidade(nomeOrigem);
                var destino = new Cidade(nomeDestino);

                if (arvore.Existe(destino) && arvore.Existe(origem))
                {
                    var ligacao = new Ligacoes(nomeOrigem, nomeDestino, distancia);
                    ligacao.NomeArquivo = dlgLigacoes.FileName;
                    arvore.Atual.Info.Ligacoes.InserirEmOrdem(ligacao);
                    MessageBox.Show("Caminho incluído com sucesso!");
                    cidadeSelecionada = arvore.Raiz.Info;
                    Preencher();
                    pcMapa.Invalidate();
                    pcArvore.Invalidate();
                }

                else
                    MessageBox.Show("Não foi possível incluir o caminho!");
            }
        }

        private void btnExcluirCaminho_Click(object sender, EventArgs e)
        {
            string origem = txtOrigem.Text.Trim();
            string destino = txtDestino.Text.Trim();
            int distancia = (int)nudDistancia2.Value;
            if (origem == "" || destino == "" || distancia == 0)
                MessageBox.Show("Erro! Verifique se os campos estão preenchidos corretamente.");

            else
                if (arvore.Existe(new Cidade(destino)) && arvore.Existe(new Cidade(origem)))
            {
                if (arvore.Atual.Info.Ligacoes.RemoverDado(new Ligacoes(origem, destino, distancia)))
                {
                    MessageBox.Show("Caminho removido com sucesso!!");
                    Preencher();
                    pcMapa.Invalidate();
                    pcMapa.Invalidate();
                }
                else
                {
                    MessageBox.Show("Erro ao remover caminho. Caminho não encontrado!");
                }
            }
            else
                MessageBox.Show("Não foi possível excluir o caminho!");

        }

        private void btnAlterarCaminho_Click(object sender, EventArgs e)
        {
            string origem = cidadeSelecionada.Nome;
            string destino = txtDestino.Text.Trim();

            // confere se o nome está vazio, se der true mostra a mensagem de erro
            if (string.IsNullOrEmpty(origem) && string.IsNullOrEmpty(destino))
            {
                MessageBox.Show("Campos vazios!");
                return;
            }
            else
            {
                int distancia = (int)nudDistancia2.Value;

                if (distancia == 0)
                    MessageBox.Show("Valor inválido para distancia!");

                else
                    if (arvore.Existe(new Cidade(destino)) && arvore.Existe(new Cidade(origem)))
                {
                    Ligacoes ligacao = new Ligacoes(txtOrigem.Text, txtDestino.Text, distancia);
                    ligacao.NomeArquivo = dlgLigacoes.FileName;

                    if (arvore.Atual.Info.Ligacoes.RemoverDado(ligacao))
                    {
                        arvore.Atual.Info.Ligacoes.InserirEmOrdem(ligacao);
                        MessageBox.Show("Caminho alterado com sucesso!");
                        Preencher();
                        pcMapa.Invalidate();
                        pcMapa.Invalidate();
                    }

                    else
                        MessageBox.Show("Não foi possível alterar o caminho!");
                }
            }
        }

        private void btnProcurarCaminho_Click(object sender, EventArgs e)
        {
            string origem = txtOrigem.Text.Trim();
            string destino = txtDestino.Text.Trim();

            if (origem == "" || destino == "")
            {
                MessageBox.Show("Erro! Verifique se os campos estão preenchidos corretamente.");
            }
            else
            {
                // Verificar se ambas as cidades existem
                if (arvore.Existe(new Cidade(destino)) && arvore.Existe(new Cidade(origem)))
                {
                    // Verificar se a ligação existe
                    if (arvore.Atual.Info.Ligacoes.ExisteDado(new Ligacoes(origem, destino)))
                    {
                        // A ligação existe, obter informações e atualizar campos
                        Ligacoes ligacoes = arvore.Atual.Info.Ligacoes.Atual.Info;
                        nudDistancia2.Value = (decimal)ligacoes.Distancia;
                        //Preencher();
                        pcMapa.Invalidate();
                        pcArvore.Invalidate();
                    }
                    else
                    {
                        // A ligação não foi encontrada, limpar campos
                        LimparCampos();
                        MessageBox.Show("Erro! Ligação não localizada!");
                    }
                }
                else
                {
                    MessageBox.Show("Caminho inválido!");
                }
            }
        }

        private void btnBuscarCaminho_Click(object sender, EventArgs e)
        {
            MontarGrafo();
            lsbCaminhos.Items.Clear();
            lsbCaminhos.Items.Add(" ");
            lsbCaminhos.Items.Add("Menores caminhos:");
            lsbCaminhos.Items.Add(" ");
            lsbCaminhos.Items.Add(oGrafo.Caminho(cbOrigem.SelectedIndex, cbDestino.SelectedIndex, lsbCaminhos));
            lsbCaminhos.Items.Add(" ");
        }

        void MontarGrafo()
        {
            arvore.Atual = arvore.Raiz;
            CriarVertices(arvore.Atual);

            arvore.Atual = arvore.Raiz;
            CriarArestas(arvore.Atual);

            void CriarVertices(NoArvore<Cidade> no)
            {
                if (no != null)
                {
                    CriarVertices(no.Esq);
                    oGrafo.NovoVertice(no.Info.Nome);
                    CriarVertices(no.Dir);
                }
            }

            void CriarArestas(NoArvore<Cidade> no)
            {
                if (no != null)
                {
                    CriarArestas(no.Esq);
                    foreach (Ligacoes lig in no.Info.Ligacoes.Lista())
                    {
                        oGrafo.NovaAresta(cbOrigem.Items.IndexOf(lig.Origem), cbDestino.Items.IndexOf(lig.Destino), lig.Distancia);
                    }
                    CriarArestas(no.Dir);
                }
            }
        }
        ListaSimples<Cidade> cidades;
        void ComboBoxComplete()
        {
            cidades = new ListaSimples<Cidade>();
            cidades.ler(dlgAbrir.FileName);

            cidades = new Cidade[listaCidades.Tamanho];
            for (int i = 0; i < listaCidades.Tamanho; i++)
            {
                cidades[i] = listaCidades[i];
                cbOrigem.Items.Add(cidades[i].Nome);
                cbDestino.Items.Add(cidades[i].Nome);
            }
            cbOrigem.SelectedIndex = 0;
            cbDestino.SelectedIndex = 0;
        }

        int PosicaoGrafo(string cidade)
        {
            arvore.Atual = arvore.Raiz;
            int posicao = 0;

            for (int i = 0; arvore.Atual != null; i++)
            {
                arvore.Atual = arvore.Atual.Esq;
                if (arvore.Atual.Info.Nome == cidade)
                    posicao = i;
                arvore.Atual = arvore.Atual.Dir;
            }

            return posicao;
        }
    }
}