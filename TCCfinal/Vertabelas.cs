﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TCCfinal
{
    public partial class Vertabelas : UserControl
    {
        string connStr = "server=localhost;user=root;database=controle_financeiro;port=3306;password=;";

        public Vertabelas()
        {
            InitializeComponent();
            CarregarLancamentos();
            CarregarCategorias();
            dtpData.Value = DateTime.Now;
        }

        private void CarregarLancamentos()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open(); 
                    string sql = "SELECT id, data, tipo, categoria, descricao, valor FROM lancamentos ORDER BY data DESC";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn); 
                    DataTable dt = new DataTable();
                    da.Fill(dt); // Preenche o DataTable com os dados do banco
                    dataGridView1.DataSource = dt; // Exibe os dados no DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar lançamentos: " + ex.Message);
                }
            }
        }
        
        private void CarregarCategorias()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    
                    string tipo = radioEntrada.Checked ? "receita" : "despesa";
                    string sql = "SELECT nome FROM categorias WHERE tipo = @tipo";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    comboDescricao.Items.Clear(); // Limpa as opções anteriores
                    while (dr.Read())
                    {
                        comboDescricao.Items.Add(dr.GetString("nome")); // Adiciona cada categoria ao ComboBox
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar categorias: " + ex.Message);
                }
            }
        }
        private void btnCadastra_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO lancamentos (data, tipo, categoria, descricao, valor) VALUES (@data, @tipo, @categoria, @descricao, @valor)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    
                    string tipo = radioEntrada.Checked ? "receita" : "despesa";
                    cmd.Parameters.AddWithValue("@data", DateTime.Parse(dtpData.Text));
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@categoria", comboDescricao.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@descricao", comboDescricao.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@valor", decimal.Parse(txtValor.Text.Replace(",", ".")));

                    cmd.ExecuteNonQuery(); // Executa o comando de inserção
                    MessageBox.Show("Lançamento cadastrado com sucesso!");
                    CarregarLancamentos(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar lançamento: " + ex.Message);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Pega o ID da linha selecionada
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este lançamento?", "Confirmação", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        try
                        {
                            conn.Open();
                            string sql = "DELETE FROM lancamentos WHERE id = @id";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Lançamento excluído!");
                            CarregarLancamentos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao excluir: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha para excluir.");
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Troque "dataGridView1" pelo nome do seu DataGridView, se for diferente
            // Ajuste os nomes das colunas se necessário!
            if (dataGridView1.Columns[e.ColumnIndex].Name == "valor")
            {
                var tipo = dataGridView1.Rows[e.RowIndex].Cells["tipo"].Value?.ToString();

                if (tipo == "receita")
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.SelectionForeColor = Color.Green;
                }
                else if (tipo == "despesa")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Pega o ID da linha selecionada
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        string sql = "UPDATE lancamentos SET data=@data, tipo=@tipo, categoria=@categoria, descricao=@descricao, valor=@valor WHERE id=@id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        string tipo = radioEntrada.Checked ? "receita" : "despesa";
                        cmd.Parameters.AddWithValue("@data", DateTime.Parse(dtpData.Text));
                        cmd.Parameters.AddWithValue("@tipo", tipo);
                        cmd.Parameters.AddWithValue("@categoria", comboDescricao.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@descricao", comboDescricao.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@valor", decimal.Parse(txtValor.Text.Replace(",", ".")));
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Lançamento atualizado!");
                        CarregarLancamentos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao atualizar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha para atualizar.");
            }
        }

        private void radioEntrada_CheckedChanged(object sender, EventArgs e)
        {
            CarregarCategorias(); // Carrega as categorias de receita
        }

        private void radioSaida_CheckedChanged(object sender, EventArgs e)
        {
            CarregarCategorias(); // Carrega as categorias de despesa
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal totalEntradas = 0, totalSaidas = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["tipo"].Value == null || row.Cells["valor"].Value == null)
                    continue;

                string tipo = row.Cells["tipo"].Value.ToString();
                decimal valor = 0;
                decimal.TryParse(row.Cells["valor"].Value.ToString(), out valor);

                if (tipo == "receita")
                    totalEntradas += valor;
                else if (tipo == "despesa")
                    totalSaidas += valor;
            }

            decimal saldo = totalEntradas - totalSaidas;
            lblSaldo.Text = $"Saldo atual: R$ {saldo:N2}";

            
            if (saldo >= 0)
                lblSaldo.ForeColor = Color.Green;
            else
                lblSaldo.ForeColor = Color.Red;
        }


        public void CarregarTela(UserControl tela)
        {

            pnlTabe.Controls.Clear();

            tela.Dock = DockStyle.Fill;
            pnlTabe.Controls.Add(tela);
        }

        private void radioEntrada_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioEntrada.Checked)
            {
                CarregarCategorias();
                //AtualizarCorTipo();
            }
        }

        private void radioSaida_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioSaida.Checked)
            {
                CarregarCategorias();
                //AtualizarCorTipo();
            }

        }

        
    }

}
