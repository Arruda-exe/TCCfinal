using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCCfinal
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            ConfigurarListView();
        }
        private void ConfigurarListView()
        {
            // Limpa colunas existentes
            listView1.Columns.Clear();

            // Adiciona as colunas (ajuste os nomes conforme sua ListView)
            listView1.Columns.Add("Descrição", 150);
            listView1.Columns.Add("Valor (R$)", 100);
            listView1.Columns.Add("Tipo", 100);
            listView1.Columns.Add("Data", 100);

            // Exemplo de dados iniciais (opcional)
            AdicionarItemFinanceiro("Salário", 3500.00m, "Salário", DateTime.Now);
            AdicionarItemFinanceiro("Dividendos", 450.50m, "Investimento", DateTime.Now);
        }

        private void AdicionarItemFinanceiro(string descricao, decimal valor, string tipo, DateTime data)
        {
            string[] row = {
            descricao,
            valor.ToString("C2"),
            tipo,
            data.ToShortDateString()
        };

            var listViewItem = new ListViewItem(row);
            listView1.Items.Add(listViewItem);
        }
    }

}

