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
    public partial class Form1 : Form
    {

        private string connectionString = "server=localhost;database=bancodedados;uid=root;pwd=;";
        public Form1()
        {
            InitializeComponent();
            pnlCadastro.Visible = false;
           
            this.StartPosition = FormStartPosition.CenterScreen;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            CentralizarPainel(pnlLogin);
            CentralizarPainel(pnlCadastro);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            CentralizarPainel(pnlLogin);
            CentralizarPainel(pnlCadastro);
        }

        public void CentralizarPainel(Control painel)
        {
            if (painel == null || !painel.Visible) return;

            painel.SuspendLayout();

            // Centralizar horizontal e verticalmente no cliente do formulário
            painel.Left = (this.ClientSize.Width - painel.Width) / 2;
            painel.Top = (this.ClientSize.Height - painel.Height) / 2;

            painel.ResumeLayout();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            pnlCadastro.Visible = true;
            pnlLogin.Visible = false;

        }

        private void PossuiConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            pnlLogin.Visible = true;
            pnlCadastro.Visible = false;

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string email = txtEmailCadastro.Text.Trim();
            string senha = txtSenhaCadastro.Text;
            string confirmarSenha = txtConfirmarSenha.Text;
            string cpf = txtCPF.Text.Trim();
            string telefone = txtTelefone.Text.Trim();
            DateTime dataNascimento = dtpDataNascimento.Value;

            // Validações básicas
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha) ||
                string.IsNullOrEmpty(confirmarSenha) || string.IsNullOrEmpty(cpf))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (senha != confirmarSenha)
            {
                MessageBox.Show("As senhas não coincidem.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarEmail(email))
            {
                MessageBox.Show("Por favor, insira um e-mail válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar se email já existe
            if (VerificarEmailExistente(email))
            {
                MessageBox.Show("Este e-mail já está cadastrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO usuarios 
                                    (nome_completo, email, senha, cpf, data_nascimento, telefone, data_criacao) 
                                    VALUES 
                                    (@nome, @email, @senha, @cpf, @dataNascimento, @telefone, NOW())";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@senha", senha); // Senha sem criptografia
                    command.Parameters.AddWithValue("@cpf", cpf);
                    command.Parameters.AddWithValue("@dataNascimento", dataNascimento);
                    command.Parameters.AddWithValue("@telefone", telefone);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCamposCadastro();
                        pnlLogin.Visible = true;
                        pnlCadastro.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Falha ao cadastrar usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            string email = txtEmailLogin.Text.Trim();
            string senha = txtSenhaLogin.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT id, nome_completo, senha 
                                    FROM usuarios 
                                    WHERE email = @email AND senha = @senha";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@senha", senha); // Comparação direta sem criptografia

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idUsuario = reader.GetInt32("id");
                            string nomeUsuario = reader.GetString("nome_completo");

                            // Atualizar último login
                            AtualizarUltimoLogin(idUsuario);

                            MessageBox.Show($"Bem-vindo, {nomeUsuario}!", "Login Bem-sucedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Aqui você pode abrir o formulário principal
                            // Ex: new FormPrincipal().Show();
                            // this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("E-mail ou senha incorretos.", "Login Falhou", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar login: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Métodos auxiliares
        private bool VerificarEmailExistente(string email)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM usuarios WHERE email = @email";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        private void AtualizarUltimoLogin(int idUsuario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE usuarios SET ultimo_login = NOW() WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", idUsuario);
                command.ExecuteNonQuery();
            }
        }

        private void LimparCamposCadastro()
        {
            txtNome.Text = "";
            txtEmailCadastro.Text = "";
            txtSenhaCadastro.Text = "";
            txtConfirmarSenha.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            dtpDataNascimento.Value = DateTime.Now;
        }

        // Validação de e-mail
        private bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        

        

    }
}
    


