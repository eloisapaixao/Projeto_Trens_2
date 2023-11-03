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
                            arvore.Atual.Info.Ligacao.InserirEmOrdem(ligacoes);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

                if (!cidadeSelecionada.Ligacao.EstaVazia)
                {
                    //QuantosNos está vazio porque os dados não estão sendo armazenados na lista
                    dgvRotas.RowCount = cidadeSelecionada.Ligacao.QuantosNos;

                    Ligacoes lig = cidadeSelecionada.Ligacao.Primeiro.Info;

                    lig.Destino = txtDestino.Text;
                    lig.Origem = txtOrigem.Text;

                    lig.Distancia = (int)nudDistancia2.Value;

                    cidadeSelecionada.Ligacao.IniciarPercursoSequencial();

                    int linha = 0;
                    while (cidadeSelecionada.Ligacao.PodePercorrer())
                    {
                        Ligacoes caminho = cidadeSelecionada.Ligacao.Atual.Info;

                        dgvRotas[linha, 0].Value = caminho.Destino;
                        dgvRotas[linha, 1].Value = caminho.Distancia;
                        dgvRotas[linha, 2].Value = caminho.Origem;
                    }
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
                    ListaSimples<Ligacoes> rotasEncontradas = cidadeEncontrada.Ligacao;
                    PreencherLigacoes(rotasEncontradas);

                    pcMapa.Invalidate();
                    pcArvore.Invalidate();
                }
                else
                {
                    MessageBox.Show("Cidade não encontrada!");
                }
            }
        }

        private void PreencherLigacoes(ListaSimples<Ligacoes> rotasEncontradas)
        {
            if (cidadeSelecionada != null)
            {
                txtNome.Text = cidadeSelecionada.Nome;
                nudCoordenadaX.Value = (decimal)cidadeSelecionada.X;
                nudCoordenadaY.Value = (decimal)cidadeSelecionada.Y;

                dgvRotas.Rows.Clear();

                // Verifica se a lista não está vazia
                if (rotasEncontradas != null && rotasEncontradas.QuantosNos > 0)
                {
                    dgvRotas.RowCount = rotasEncontradas.QuantosNos;

                    int linha = 0;
                    var atual = rotasEncontradas.Primeiro;

                    while (atual != null)
                    {
                        Ligacoes rota = atual.Info;
                        dgvRotas[linha, 0].Value = rota.Destino;
                        dgvRotas[linha, 1].Value = rota.Distancia;
                        dgvRotas[linha, 2].Value = rota.Origem;

                        atual = atual.Prox;
                        linha++;
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dlgSalvar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    arvore.GravarArquivoDeRegistros(dlgSalvar.FileName);

                    if (dlgSalvarCaminho.ShowDialog() == DialogResult.OK)
                    {
                        FileStream cidadesLigacoes = new FileStream(dlgLigacoes.FileName, FileMode.Open);
                        BinaryWriter arquivoLigacoes = new BinaryWriter(cidadesLigacoes);

                        List<Cidade> arvoreLista = arvore.Listar();
                        foreach (Cidade cidade in arvoreLista)
                        {
                            ListaSimples<Ligacoes> caminhos = cidade.Ligacao;

                            List<Ligacoes> caminhosListados = caminhos.Lista();
                            foreach (Ligacoes ligacaoLista in caminhosListados)
                            {
                                ligacaoLista.GravarRegistro(arquivoLigacoes);
                            }
                        }

                        arquivoLigacoes.Close();
                    }

                }
                catch (IOException)
                {
                    Console.WriteLine("Erro salvar arquivo");
                }
            }
        }

        private void tbCidades_SelectedIndexChanged(object sender, EventArgs e)
        {

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

                if(arvore.Existe(cidade))
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

                        cidade.Ligacao = arvore.Atual.Info.Ligacao;

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
            txtNome.Text = cidadeSelecionada.Nome;
            nudCoordenadaX.Value = (decimal)cidadeSelecionada.X;
            nudCoordenadaY.Value = (decimal)cidadeSelecionada.Y;
        }

        private void btnIncluirCaminho_Click(object sender, EventArgs e)
        {
            string origem = txtOrigem.Text.Trim();
            string destino = txtDestino.Text.Trim();
            int distancia = (int)nudDistancia2.Value;

            if (origem == "" || destino == "" || distancia == 0)
                MessageBox.Show("Erro! Verifique se os campos estão preenchidos corretamente.");

            else
            {
                // se ambas as cidades existem
                if (arvore.Existe(new Cidade(origem)) && arvore.Existe(new Cidade(destino)))
                {
                    Ligacoes ligacoes = new Ligacoes(origem, destino, distancia);
                    ligacoes.NomeArquivo = dlgLigacoes.FileName;
                    arvore.Atual.Info.Ligacao.InserirEmOrdem(ligacoes);
                    MessageBox.Show("Inclusão feita com sucesso!");
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
                if (arvore.Atual.Info.Ligacao.RemoverDado(new Ligacoes(origem, destino, distancia)))
                {
                    LimparCampos();
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
            string origem = txtOrigem.Text.Trim();
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
                        Ligacoes ligacao = new Ligacoes(origem, destino, distancia);
                        ligacao.NomeArquivo = dlgLigacoes.FileName;

                        if (arvore.Atual.Info.Ligacao.RemoverDado(ligacao))
                        {
                            arvore.Atual.Info.Ligacao.InserirEmOrdem(ligacao);
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
    }
}
