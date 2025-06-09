using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TCCfinal
{
    public partial class Inicio : Form
    {
        string connStr = "server=localhost;user=root;database=controle_financeiro;port=3306;password=;";

        public Inicio()
        {
            InitializeComponent();
            CarregarLancamentos();    // Carrega os lançamentos no DataGridView ao abrir o formulário
            CarregarCategorias();     // Carrega as categorias no ComboBox ao abrir o formulário

        }
        // Carrega os lançamentos financeiros do banco de dados e exibe no DataGridView
        private void CarregarLancamentos()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open(); // Abre a conexão com o banco
                    string sql = "SELECT id, data, tipo, categoria, descricao, valor FROM lancamentos ORDER BY data DESC";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn); // Prepara o comando SQL
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
        // Carrega as categorias no ComboBox com base no tipo selecionado (entrada ou saída)
        private void CarregarCategorias()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Define o tipo de categoria de acordo com o RadioButton selecionado
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

                    // Define os parâmetros do comando SQL com os valores dos controles do formulário
                    string tipo = radioEntrada.Checked ? "receita" : "despesa";
                    cmd.Parameters.AddWithValue("@data", DateTime.Parse(txtData.Text));
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@categoria", comboDescricao.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@descricao", comboDescricao.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@valor", decimal.Parse(txtValor.Text.Replace(",", ".")));

                    cmd.ExecuteNonQuery(); // Executa o comando de inserção
                    MessageBox.Show("Lançamento cadastrado com sucesso!");
                    CarregarLancamentos(); // Atualiza o DataGridView com o novo lançamento
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
                        cmd.Parameters.AddWithValue("@data", DateTime.Parse(txtData.Text));
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
    }

}

