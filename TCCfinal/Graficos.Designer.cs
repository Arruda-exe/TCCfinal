namespace TCCfinal
{
    partial class Graficos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxTipoGrafico = new System.Windows.Forms.ComboBox();
            this.btnVerGrafico = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(719, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Escolha qual modelo de grafico voce deseja";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.comboBoxTipoGrafico);
            this.panel1.Controls.Add(this.btnVerGrafico);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(293, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1323, 904);
            this.panel1.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(26, 132);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(673, 535);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // comboBoxTipoGrafico
            // 
            this.comboBoxTipoGrafico.FormattingEnabled = true;
            this.comboBoxTipoGrafico.Location = new System.Drawing.Point(723, 201);
            this.comboBoxTipoGrafico.Name = "comboBoxTipoGrafico";
            this.comboBoxTipoGrafico.Size = new System.Drawing.Size(277, 28);
            this.comboBoxTipoGrafico.TabIndex = 3;
            // 
            // btnVerGrafico
            // 
            this.btnVerGrafico.Location = new System.Drawing.Point(781, 308);
            this.btnVerGrafico.Name = "btnVerGrafico";
            this.btnVerGrafico.Size = new System.Drawing.Size(162, 72);
            this.btnVerGrafico.TabIndex = 2;
            this.btnVerGrafico.Text = "Ver grafico atual";
            this.btnVerGrafico.UseVisualStyleBackColor = true;
            this.btnVerGrafico.Click += new System.EventHandler(this.btnVerGrafico_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(777, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "visualize seu grafico";
            // 
            // Graficos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Graficos";
            this.Size = new System.Drawing.Size(1619, 907);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVerGrafico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTipoGrafico;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
