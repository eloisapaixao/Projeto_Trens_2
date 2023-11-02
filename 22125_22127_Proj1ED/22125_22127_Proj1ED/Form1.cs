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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            nudCoordenadaX.Value = 0;
            nudCoordenadaY.Value = 0;
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
                    cidadesLigacoes.SetLength(0);
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

                    lig.Distancia = (int) nudDistancia2.Value;

                    cidadeSelecionada.Ligacao.IniciarPercursoSequencial();

                    int linha = 0;
                    while (cidadeSelecionada.Ligacao.PodePercorrer())
                    {
                        Ligacoes caminho = cidadeSelecionada.Ligacao.Atual.Info;

                        dgvRotas.Rows[linha].Cells[0].Value = caminho.Destino;
                        dgvRotas.Rows[linha].Cells[1].Value = caminho.Distancia;
                        dgvRotas.Rows[linha++].Cells[2].Value = caminho.Origem;
                    }
                }
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            string origem = txtOrigem.Text.Trim();
            string destino = txtDestino.Text.Trim();

            if (origem == "" || destino == "")
                MessageBox.Show("Erro! Verifique se os campos estão preenchidos corretamente.");

            else
            {
                // se ambas as cidades existem
                if (arvore.Existe(new Cidade(destino)) && arvore.Existe(new Cidade(origem)))
                {
                    // se a exclusão deu certo
                    if (arvore.Atual.Info.Ligacao.ExisteDado(new Ligacoes(origem, destino)))
                    {
                        Ligacoes ligacoes = arvore.Atual.Info.Ligacao.Atual.Info;
                        nudDistancia2.Value = ligacoes.Distancia;
                        pcMapa.Invalidate();
                        pcArvore.Invalidate();
                    }

                    else
                    {
                        LimparCampos();
                        MessageBox.Show("Erro! Ligação não localizada!");
                    }
                }

                else
                    MessageBox.Show("Caminho inválido!");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void tbCidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
