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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            
        }

        private void pcMapa_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void LimparCampos()
        {
            
        }

        private void btnAcharCaminho_Click(object sender, EventArgs e)
        {
            
        }

        private void pcMapa_Click(object sender, EventArgs e)
        {

        }

        private void frmMapa_Load_1(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                arvore = new Arvore<Cidade>();
                //aqui teremos o arquivo de dados e montaremos a árvore
                arvore.LerArquivoDeRegistros(dlgAbrir.FileName);
                if (dlgAbrir.ShowDialog() == DialogResult.OK)
                {
                    // instanciamos um fluxo de arquivo
                    FileStream fluxoCaminhos = new FileStream(dlgAbrir.FileName, FileMode.Open);
                    // e um leitor do arquivo binário
                    BinaryReader arquivoCaminhos = new BinaryReader(fluxoCaminhos);

                    // percorre cada registro dentre os registros do arquivo de caminho
                    for (int registro = 0;
                        registro < (int)fluxoCaminhos.Length / new Ligacoes().TamanhoRegistro;
                        registro++)
                    {
                        Ligacoes ligacoes = new Ligacoes();
                        ligacoes.LerRegistro(arquivoCaminhos, registro);
                        ligacoes.NomeArquivo = dlgAbrir.FileName;

                        if (arvore.Existe(new Cidade(ligacoes.Origem)))
                            arvore.Atual.Info.Ligacoes.InserirEmOrdem(ligacoes);
                    }
                }
            }
            pcMapa.Invalidate();
        }
    }
}
