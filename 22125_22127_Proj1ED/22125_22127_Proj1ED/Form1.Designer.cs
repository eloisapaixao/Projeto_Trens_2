using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _22125_22127_Proj1ED
{
    partial class frmMapa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapa));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsbArquivo = new System.Windows.Forms.ListBox();
            this.nudCoordenadaY = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudCoordenadaX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dlgSalvar = new System.Windows.Forms.OpenFileDialog();
            this.dgvRotas = new System.Windows.Forms.DataGridView();
            this.c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCidades = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.txtOrigem = new System.Windows.Forms.TextBox();
            this.btnIncluirCaminho = new System.Windows.Forms.Button();
            this.nudDistancia2 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pcMapa = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pcArvore = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnProcurar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.dlgLigacoes = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoordenadaY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoordenadaX)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotas)).BeginInit();
            this.tbCidades.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistancia2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcMapa)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcArvore)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsbArquivo);
            this.groupBox1.Controls.Add(this.nudCoordenadaY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudCoordenadaX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 285);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cidades";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lsbArquivo
            // 
            this.lsbArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbArquivo.FormattingEnabled = true;
            this.lsbArquivo.Location = new System.Drawing.Point(5, 97);
            this.lsbArquivo.Name = "lsbArquivo";
            this.lsbArquivo.Size = new System.Drawing.Size(303, 173);
            this.lsbArquivo.TabIndex = 8;
            // 
            // nudCoordenadaY
            // 
            this.nudCoordenadaY.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudCoordenadaY.DecimalPlaces = 5;
            this.nudCoordenadaY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.nudCoordenadaY.Location = new System.Drawing.Point(108, 72);
            this.nudCoordenadaY.Name = "nudCoordenadaY";
            this.nudCoordenadaY.Size = new System.Drawing.Size(191, 20);
            this.nudCoordenadaY.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Coordenada Y: ";
            // 
            // nudCoordenadaX
            // 
            this.nudCoordenadaX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudCoordenadaX.DecimalPlaces = 5;
            this.nudCoordenadaX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.nudCoordenadaX.Location = new System.Drawing.Point(108, 47);
            this.nudCoordenadaX.Name = "nudCoordenadaX";
            this.nudCoordenadaX.Size = new System.Drawing.Size(191, 20);
            this.nudCoordenadaX.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Coordenada X: ";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(108, 21);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(191, 20);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome da cidade:";
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 599);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(825, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "Registros: ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabel1.Text = "Registros:";
            // 
            // dlgSalvar
            // 
            this.dlgSalvar.FileName = "openFileDialog1";
            // 
            // dgvRotas
            // 
            this.dgvRotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c1,
            this.c2,
            this.c3});
            this.dgvRotas.Location = new System.Drawing.Point(321, 381);
            this.dgvRotas.Name = "dgvRotas";
            this.dgvRotas.RowTemplate.Height = 25;
            this.dgvRotas.Size = new System.Drawing.Size(490, 134);
            this.dgvRotas.TabIndex = 4;
            // 
            // c1
            // 
            this.c1.HeaderText = "Destino";
            this.c1.Name = "c1";
            this.c1.Width = 150;
            // 
            // c2
            // 
            this.c2.HeaderText = "Distancia";
            this.c2.Name = "c2";
            this.c2.Width = 150;
            // 
            // c3
            // 
            this.c3.HeaderText = "Origem";
            this.c3.Name = "c3";
            this.c3.Width = 150;
            // 
            // tbCidades
            // 
            this.tbCidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCidades.Controls.Add(this.tabPage1);
            this.tbCidades.Controls.Add(this.tabPage2);
            this.tbCidades.Location = new System.Drawing.Point(0, 49);
            this.tbCidades.Name = "tbCidades";
            this.tbCidades.SelectedIndex = 0;
            this.tbCidades.Size = new System.Drawing.Size(825, 547);
            this.tbCidades.TabIndex = 7;
            this.tbCidades.SelectedIndexChanged += new System.EventHandler(this.tbCidades_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.pcMapa);
            this.tabPage1.Controls.Add(this.dgvRotas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(817, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cidades";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.txtDestino);
            this.groupBox2.Controls.Add(this.txtOrigem);
            this.groupBox2.Controls.Add(this.btnIncluirCaminho);
            this.groupBox2.Controls.Add(this.nudDistancia2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(3, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 219);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Caminhos";
            // 
            // txtDestino
            // 
            this.txtDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestino.Location = new System.Drawing.Point(145, 39);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(125, 20);
            this.txtDestino.TabIndex = 51;
            // 
            // txtOrigem
            // 
            this.txtOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrigem.Location = new System.Drawing.Point(10, 39);
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(125, 20);
            this.txtOrigem.TabIndex = 50;
            // 
            // btnIncluirCaminho
            // 
            this.btnIncluirCaminho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIncluirCaminho.Location = new System.Drawing.Point(108, 108);
            this.btnIncluirCaminho.Name = "btnIncluirCaminho";
            this.btnIncluirCaminho.Size = new System.Drawing.Size(67, 50);
            this.btnIncluirCaminho.TabIndex = 49;
            this.btnIncluirCaminho.Text = "Incluir Caminho";
            this.btnIncluirCaminho.UseVisualStyleBackColor = true;
            this.btnIncluirCaminho.Click += new System.EventHandler(this.btnIncluirCaminho_Click);
            // 
            // nudDistancia2
            // 
            this.nudDistancia2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDistancia2.Location = new System.Drawing.Point(62, 70);
            this.nudDistancia2.Name = "nudDistancia2";
            this.nudDistancia2.Size = new System.Drawing.Size(244, 20);
            this.nudDistancia2.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(142, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Tempo:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "Distância:";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(97, 39);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(1, 21);
            this.comboBox3.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(141, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Destino:";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 39;
            this.label16.Text = "Origem:";
            // 
            // pcMapa
            // 
            this.pcMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcMapa.Image = ((System.Drawing.Image)(resources.GetObject("pcMapa.Image")));
            this.pcMapa.Location = new System.Drawing.Point(321, 6);
            this.pcMapa.Name = "pcMapa";
            this.pcMapa.Size = new System.Drawing.Size(490, 369);
            this.pcMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcMapa.TabIndex = 2;
            this.pcMapa.TabStop = false;
            this.pcMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pcMapa_Paint);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pcArvore);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(817, 521);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Árvore";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pcArvore
            // 
            this.pcArvore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcArvore.Location = new System.Drawing.Point(3, 3);
            this.pcArvore.Name = "pcArvore";
            this.pcArvore.Size = new System.Drawing.Size(811, 515);
            this.pcArvore.TabIndex = 0;
            this.pcArvore.TabStop = false;
            this.pcArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.pcArvore_Paint);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProcurar,
            this.toolStripSeparator2,
            this.btnNovo,
            this.btnCancelar,
            this.btnSalvar,
            this.toolStripSeparator3,
            this.btnAlterar,
            this.btnExcluir,
            this.toolStripSeparator5,
            this.btnSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(378, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnProcurar
            // 
            this.btnProcurar.Image = global::_22125_22127_Proj1ED.Properties.Resources.lupa;
            this.btnProcurar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(56, 35);
            this.btnProcurar.Text = "Procurar";
            this.btnProcurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = global::_22125_22127_Proj1ED.Properties.Resources.documento;
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(40, 35);
            this.btnNovo.Text = "Novo";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::_22125_22127_Proj1ED.Properties.Resources.cancelar;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(57, 35);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::_22125_22127_Proj1ED.Properties.Resources.salve_;
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(42, 35);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::_22125_22127_Proj1ED.Properties.Resources.lixo;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(46, 35);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSair
            // 
            this.btnSair.Image = global::_22125_22127_Proj1ED.Properties.Resources.sair;
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(30, 35);
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click_1);
            // 
            // dlgLigacoes
            // 
            this.dlgLigacoes.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Caminhos encontrados";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(122, 494);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Km do caminho selecionado (xxxxx Km)";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(46, 35);
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // frmMapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 621);
            this.Controls.Add(this.tbCidades);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMapa";
            this.Text = "Mapeamento de cidades";
            this.Load += new System.EventHandler(this.frmMapa_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoordenadaY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoordenadaX)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotas)).EndInit();
            this.tbCidades.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistancia2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcMapa)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcArvore)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private ListBox lsbArquivo;
        private NumericUpDown nudCoordenadaY;
        private Label label4;
        private NumericUpDown nudCoordenadaX;
        private Label label3;
        private TextBox txtNome;
        private Label label2;
        private PictureBox pcMapa;
        private OpenFileDialog dlgAbrir;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private OpenFileDialog dlgSalvar;
        private DataGridView dgvRotas;
        private TabControl tbCidades;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolStripButton btnNovo;
        private ToolStripButton btnCancelar;
        private ToolStripButton btnSalvar;
        private ToolStripButton btnExcluir;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnSair;
        private ToolStrip toolStrip1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnProcurar;
        private OpenFileDialog dlgLigacoes;
        private Label label1;
        private Label label11;
        private GroupBox groupBox2;
        private Button btnIncluirCaminho;
        private NumericUpDown nudDistancia2;
        private Label label12;
        private Label label14;
        private ComboBox comboBox3;
        private Label label15;
        private Label label16;
        private PictureBox pcArvore;
        private TextBox txtDestino;
        private TextBox txtOrigem;
        private DataGridViewTextBoxColumn c1;
        private DataGridViewTextBoxColumn c2;
        private DataGridViewTextBoxColumn c3;
        private ToolStripButton btnAlterar;
    }
}

