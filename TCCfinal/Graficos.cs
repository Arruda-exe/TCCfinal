using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TCCfinal
{
    public partial class Graficos : UserControl
    {
        // Variáveis de instância aqui!
        private string connectionString = "server=localhost;database=controle_financeiro;";

        public Graficos()
        {
            InitializeComponent();
            this.Load += Graficos_Load;
            btnVerGrafico.Click += btnVerGrafico_Click;
        }

        private void Graficos_Load(object sender, EventArgs e)
        {
            comboBoxTipoGrafico.Items.Clear();
            comboBoxTipoGrafico.Items.Add("Pizza - Despesas por categoria");
            comboBoxTipoGrafico.Items.Add("Barra - Receitas x Despesas por mês");
            comboBoxTipoGrafico.Items.Add("Linha - Saldo ao longo do tempo");
            comboBoxTipoGrafico.SelectedIndex = 0;
        }

        private DataTable ObterLancamentos()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT id, data, tipo, categoria, descricao, valor FROM lancamentos";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        private void btnVerGrafico_Click(object sender, EventArgs e)
        {
            // Pega o tipo do gráfico selecionado
            string tipoSelecionado = comboBoxTipoGrafico.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tipoSelecionado))
            {
                MessageBox.Show("Selecione o tipo de gráfico.");
                return;
            }

            DataTable dt = ObterLancamentos();
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum lançamento encontrado no banco de dados.");
                return;
            }

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 0;

            if (tipoSelecionado.StartsWith("Pizza"))
            {
                chart1.Series.Add("Despesas");
                chart1.Series["Despesas"].ChartType = SeriesChartType.Pie;
                chart1.Series["Despesas"].IsValueShownAsLabel = true;

                var despesasPorCategoria = dt.AsEnumerable()
                    .Where(r => r.Field<string>("tipo") == "despesa")
                    .GroupBy(r => r.Field<string>("categoria"))
                    .Select(g => new { Categoria = g.Key, Total = g.Sum(x => Convert.ToDecimal(x.Field<object>("valor"))) });

                foreach (var item in despesasPorCategoria)
                    chart1.Series["Despesas"].Points.AddXY(item.Categoria, item.Total);

                chart1.Titles.Add("Despesas por Categoria");
            }
            else if (tipoSelecionado.StartsWith("Barra"))
            {
                chart1.Series.Add("Receitas");
                chart1.Series.Add("Despesas");
                chart1.Series["Receitas"].ChartType = SeriesChartType.Column;
                chart1.Series["Despesas"].ChartType = SeriesChartType.Column;
                chart1.Series["Receitas"].Color = Color.Green;
                chart1.Series["Despesas"].Color = Color.Red;

                var receitasPorMes = dt.AsEnumerable()
                    .Where(r => r.Field<string>("tipo") == "receita")
                    .GroupBy(r => r.Field<DateTime>("data").ToString("MM/yyyy"))
                    .Select(g => new { Mes = g.Key, Total = g.Sum(x => Convert.ToDecimal(x.Field<object>("valor"))) });

                var despesasPorMes = dt.AsEnumerable()
                    .Where(r => r.Field<string>("tipo") == "despesa")
                    .GroupBy(r => r.Field<DateTime>("data").ToString("MM/yyyy"))
                    .Select(g => new { Mes = g.Key, Total = g.Sum(x => Convert.ToDecimal(x.Field<object>("valor"))) });

                var todosOsMeses = receitasPorMes.Select(x => x.Mes).Union(despesasPorMes.Select(x => x.Mes)).Distinct().OrderBy(x => x);

                foreach (var mes in todosOsMeses)
                {
                    var receita = receitasPorMes.FirstOrDefault(x => x.Mes == mes)?.Total ?? 0;
                    var despesa = despesasPorMes.FirstOrDefault(x => x.Mes == mes)?.Total ?? 0;
                    chart1.Series["Receitas"].Points.AddXY(mes, receita);
                    chart1.Series["Despesas"].Points.AddXY(mes, despesa);
                }

                chart1.Titles.Add("Receitas x Despesas por Mês");
            }
            else if (tipoSelecionado.StartsWith("Linha"))
            {
                chart1.Series.Add("Saldo");
                chart1.Series["Saldo"].ChartType = SeriesChartType.Line;
                chart1.Series["Saldo"].Color = Color.Blue;
                chart1.Series["Saldo"].BorderWidth = 3;

                var dadosOrdenados = dt.AsEnumerable()
                    .OrderBy(r => r.Field<DateTime>("data"))
                    .Select(r => new
                    {
                        Data = r.Field<DateTime>("data"),
                        Tipo = r.Field<string>("tipo"),
                        Valor = Convert.ToDecimal(r.Field<object>("valor"))
                    });

                decimal saldoAcumulado = 0;
                foreach (var item in dadosOrdenados)
                {
                    if (item.Tipo == "receita")
                        saldoAcumulado += item.Valor;
                    else if (item.Tipo == "despesa")
                        saldoAcumulado -= item.Valor;

                    chart1.Series["Saldo"].Points.AddXY(item.Data.ToString("dd/MM/yyyy"), saldoAcumulado);
                }

                chart1.Titles.Add("Evolução do Saldo");
            }
        }
    }

}
