namespace TCCfinal
{
    partial class Vertabelas
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTabe = new System.Windows.Forms.Panel();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnCadastra = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboDescricao = new System.Windows.Forms.ComboBox();
            this.radioSaida = new System.Windows.Forms.RadioButton();
            this.radioEntrada = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.pnlTabe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTabe
            // 
            this.pnlTabe.Controls.Add(this.dtpData);
            this.pnlTabe.Controls.Add(this.lblSaldo);
            this.pnlTabe.Controls.Add(this.btnCalcular);
            this.pnlTabe.Controls.Add(this.btnCadastra);
            this.pnlTabe.Controls.Add(this.label4);
            this.pnlTabe.Controls.Add(this.btnAtualizar);
            this.pnlTabe.Controls.Add(this.btnExcluir);
            this.pnlTabe.Controls.Add(this.txtValor);
            this.pnlTabe.Controls.Add(this.label3);
            this.pnlTabe.Controls.Add(this.label2);
            this.pnlTabe.Controls.Add(this.label1);
            this.pnlTabe.Controls.Add(this.comboDescricao);
            this.pnlTabe.Controls.Add(this.radioSaida);
            this.pnlTabe.Controls.Add(this.radioEntrada);
            this.pnlTabe.Controls.Add(this.dataGridView1);
            this.pnlTabe.Location = new System.Drawing.Point(2, 3);
            this.pnlTabe.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTabe.Name = "pnlTabe";
            this.pnlTabe.Size = new System.Drawing.Size(1163, 712);
            this.pnlTabe.TabIndex = 0;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(743, 438);
            this.lblSaldo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(108, 18);
            this.lblSaldo.TabIndex = 31;
            this.lblSaldo.Text = "SALDO ATUAL";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(809, 383);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(63, 34);
            this.btnCalcular.TabIndex = 30;
            this.btnCalcular.Text = "calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnCadastra
            // 
            this.btnCadastra.Location = new System.Drawing.Point(731, 327);
            this.btnCadastra.Margin = new System.Windows.Forms.Padding(2);
            this.btnCadastra.Name = "btnCadastra";
            this.btnCadastra.Size = new System.Drawing.Size(61, 32);
            this.btnCadastra.TabIndex = 29;
            this.btnCadastra.Text = "cadastrar";
            this.btnCadastra.UseVisualStyleBackColor = true;
            this.btnCadastra.Click += new System.EventHandler(this.btnCadastra_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(302, 31);
            this.label4.TabIndex = 28;
            this.label4.Text = "MONTE SUA TABELA";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(731, 383);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(63, 34);
            this.btnAtualizar.TabIndex = 27;
            this.btnAtualizar.Text = "atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(809, 327);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(61, 32);
            this.btnExcluir.TabIndex = 26;
            this.btnExcluir.Text = "excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(788, 261);
            this.txtValor.Margin = new System.Windows.Forms.Padding(2);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(113, 20);
            this.txtValor.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(730, 264);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "valor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(728, 194);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(728, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "descrição";
            // 
            // comboDescricao
            // 
            this.comboDescricao.FormattingEnabled = true;
            this.comboDescricao.Location = new System.Drawing.Point(788, 154);
            this.comboDescricao.Margin = new System.Windows.Forms.Padding(2);
            this.comboDescricao.Name = "comboDescricao";
            this.comboDescricao.Size = new System.Drawing.Size(82, 21);
            this.comboDescricao.TabIndex = 20;
            // 
            // radioSaida
            // 
            this.radioSaida.AutoSize = true;
            this.radioSaida.Location = new System.Drawing.Point(820, 96);
            this.radioSaida.Margin = new System.Windows.Forms.Padding(2);
            this.radioSaida.Name = "radioSaida";
            this.radioSaida.Size = new System.Drawing.Size(50, 17);
            this.radioSaida.TabIndex = 19;
            this.radioSaida.TabStop = true;
            this.radioSaida.Text = "saida";
            this.radioSaida.UseVisualStyleBackColor = true;
            this.radioSaida.CheckedChanged += new System.EventHandler(this.radioSaida_CheckedChanged_1);
            // 
            // radioEntrada
            // 
            this.radioEntrada.AutoSize = true;
            this.radioEntrada.Location = new System.Drawing.Point(733, 96);
            this.radioEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.radioEntrada.Name = "radioEntrada";
            this.radioEntrada.Size = new System.Drawing.Size(61, 17);
            this.radioEntrada.TabIndex = 18;
            this.radioEntrada.TabStop = true;
            this.radioEntrada.Text = "entrada";
            this.radioEntrada.UseVisualStyleBackColor = true;
            this.radioEntrada.CheckedChanged += new System.EventHandler(this.radioEntrada_CheckedChanged_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 57);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(677, 562);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(701, 224);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(236, 20);
            this.dtpData.TabIndex = 32;
            // 
            // Vertabelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTabe);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Vertabelas";
            this.Size = new System.Drawing.Size(1474, 717);
            this.pnlTabe.ResumeLayout(false);
            this.pnlTabe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTabe;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnCadastra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboDescricao;
        private System.Windows.Forms.RadioButton radioSaida;
        private System.Windows.Forms.RadioButton radioEntrada;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtpData;
    }
}
