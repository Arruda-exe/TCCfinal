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
            this.dtpData = new System.Windows.Forms.DateTimePicker();
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
            this.pnlTabe.Location = new System.Drawing.Point(3, 5);
            this.pnlTabe.Name = "pnlTabe";
            this.pnlTabe.Size = new System.Drawing.Size(2143, 1095);
            this.pnlTabe.TabIndex = 0;
            // 
            // dtpData
            // 
            this.dtpData.Font = new System.Drawing.Font("Mongolian Baiti", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpData.Location = new System.Drawing.Point(1052, 345);
            this.dtpData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(320, 26);
            this.dtpData.TabIndex = 32;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(1114, 674);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(175, 29);
            this.lblSaldo.TabIndex = 31;
            this.lblSaldo.Text = "SALDO ATUAL";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Mongolian Baiti", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(1214, 589);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(94, 52);
            this.btnCalcular.TabIndex = 30;
            this.btnCalcular.Text = "calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnCadastra
            // 
            this.btnCadastra.Font = new System.Drawing.Font("Mongolian Baiti", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastra.Location = new System.Drawing.Point(1096, 503);
            this.btnCadastra.Name = "btnCadastra";
            this.btnCadastra.Size = new System.Drawing.Size(92, 49);
            this.btnCadastra.TabIndex = 29;
            this.btnCadastra.Text = "cadastrar";
            this.btnCadastra.UseVisualStyleBackColor = true;
            this.btnCadastra.Click += new System.EventHandler(this.btnCadastra_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(439, 46);
            this.label4.TabIndex = 28;
            this.label4.Text = "MONTE SUA TABELA";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("Mongolian Baiti", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(1096, 589);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(94, 52);
            this.btnAtualizar.TabIndex = 27;
            this.btnAtualizar.Text = "atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Mongolian Baiti", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(1214, 503);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(92, 49);
            this.btnExcluir.TabIndex = 26;
            this.btnExcluir.Text = "excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(1162, 406);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(168, 26);
            this.txtValor.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1095, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 23;
            this.label3.Text = "valor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1096, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1093, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "descrição";
            // 
            // comboDescricao
            // 
            this.comboDescricao.FormattingEnabled = true;
            this.comboDescricao.Location = new System.Drawing.Point(1195, 241);
            this.comboDescricao.Name = "comboDescricao";
            this.comboDescricao.Size = new System.Drawing.Size(121, 28);
            this.comboDescricao.TabIndex = 20;
            // 
            // radioSaida
            // 
            this.radioSaida.AutoSize = true;
            this.radioSaida.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSaida.Location = new System.Drawing.Point(1230, 148);
            this.radioSaida.Name = "radioSaida";
            this.radioSaida.Size = new System.Drawing.Size(86, 29);
            this.radioSaida.TabIndex = 19;
            this.radioSaida.TabStop = true;
            this.radioSaida.Text = "saida";
            this.radioSaida.UseVisualStyleBackColor = true;
            this.radioSaida.CheckedChanged += new System.EventHandler(this.radioSaida_CheckedChanged_1);
            // 
            // radioEntrada
            // 
            this.radioEntrada.AutoSize = true;
            this.radioEntrada.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEntrada.Location = new System.Drawing.Point(1100, 148);
            this.radioEntrada.Name = "radioEntrada";
            this.radioEntrada.Size = new System.Drawing.Size(109, 29);
            this.radioEntrada.TabIndex = 18;
            this.radioEntrada.TabStop = true;
            this.radioEntrada.Text = "entrada";
            this.radioEntrada.UseVisualStyleBackColor = true;
            this.radioEntrada.CheckedChanged += new System.EventHandler(this.radioEntrada_CheckedChanged_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1016, 865);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // Vertabelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTabe);
            this.Name = "Vertabelas";
            this.Size = new System.Drawing.Size(2211, 1103);
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
