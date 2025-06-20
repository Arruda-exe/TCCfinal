﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace TCCfinal
{
    public partial class Form1 : Form
    {
        private const int raio = 15;
        string connectionString = "server=localhost;user=root;database=controle_financeiro;port=3306;password=;";
        public Form1()
        {
            InitializeComponent();
            pnlCadastro.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            txtSenhaLogin.UseSystemPasswordChar = true; // Senha já começa oculta (pontilhada)
            btnVerSenha.Text = "VER SENHA";

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
      


        private void CentralizarPainel()
        {
          

            pnlLogin.Left = (this.ClientSize.Width - pnlLogin.Width) / 2;
            pnlLogin.Top = (this.ClientSize.Height - pnlLogin.Height) / 2;

            
            pnlCadastro.Left = (this.ClientSize.Width - pnlCadastro.Width) / 2;
            pnlCadastro.Top = (this.ClientSize.Height - pnlCadastro.Height) / 2;
        }

        public static class UIArredondamento
        {
            // Método usando API Windows (mais performático)
            [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
            private static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
                int nWidthEllipse, int nHeightEllipse);

            
            public static void ArredondarControle(Control controle, int raio)
            {
                try
                {
                    // Verifica se o controle é válido e visível
                    if (controle == null || !controle.Visible) return;

                    
                    if (controle is TextBox)
                    {
                        
                        controle.Padding = new Padding(10, 3, 10, 3);
                    }

                    
                    if (controle is Button)
                    {
                        var btn = (Button)controle;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                    }

                   
                    controle.Region = Region.FromHrgn(CreateRoundRectRgn(
                        0, 0, controle.Width, controle.Height, raio, raio));

                    // Adiciona handler para redimensionamento
                    controle.SizeChanged += (sender, e) =>
                    {
                        controle.Region = Region.FromHrgn(CreateRoundRectRgn(
                            0, 0, controle.Width, controle.Height, raio, raio));
                    };
                }
                catch
                {
                    // Fallback para controles que não suportam Region
                    controle.Paint += (sender, e) =>
                    {
                        using (var path = CriarPathArredondado(controle, raio))
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            e.Graphics.FillPath(new SolidBrush(controle.BackColor), path);

                            if (controle is Button)
                                e.Graphics.DrawPath(new Pen(Color.LightGray, 1), path);
                        }
                    };
                }
            }

            // Método alternativo usando GraphicsPath (para controles mais complexos)
            private static GraphicsPath CriarPathArredondado(Control controle, int raio)
            {
                var path = new GraphicsPath();

                path.AddArc(0, 0, raio, raio, 180, 90); // Canto superior esquerdo
                path.AddArc(controle.Width - raio, 0, raio, raio, 270, 90); // Superior direito
                path.AddArc(controle.Width - raio, controle.Height - raio, raio, raio, 0, 90); // Inferior direito
                path.AddArc(0, controle.Height - raio, raio, raio, 90, 90); // Inferior esquerdo
                path.CloseFigure();

                return path;
            }
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
                    command.Parameters.AddWithValue("@senha", senha); 
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
        
        private void btnContinuar_Click_1(object sender, EventArgs e)
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
                    command.Parameters.AddWithValue("@senha", senha); 

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idUsuario = reader.GetInt32("id");
                            string nomeUsuario = reader.GetString("nome_completo");

                            // Atualizar último login
                            AtualizarUltimoLogin(idUsuario);

                            MessageBox.Show($"Bem-vindo, {nomeUsuario}!", "Login Bem-sucedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            
                            Inicio formInicio = new Inicio();
                            formInicio.Show();
                            this.Hide();
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

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            CentralizarPainel();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Arredondar botões
            UIArredondamento.ArredondarControle(btnContinuar, 15);
            UIArredondamento.ArredondarControle(btnCadastrar, 15);

            // Arredondar painéis
            UIArredondamento.ArredondarControle(pnlLogin, 20);
            UIArredondamento.ArredondarControle(pnlCadastro, 20);

            // Arredondar textboxes
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    UIArredondamento.ArredondarControle(ctrl, 10);
                }
            }
        }

        private void btnVerSenha_Click(object sender, EventArgs e)
        {
            // Altere para o nome do seu TextBox de senha
            if (txtSenhaLogin.UseSystemPasswordChar)
            {
                txtSenhaLogin.UseSystemPasswordChar = false;
                btnVerSenha.Text = "OCULTAR";
            }
            else
            {

                txtSenhaLogin.UseSystemPasswordChar = true;
                btnVerSenha.Text = "EXIBIR SENHA";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string email = Microsoft.VisualBasic.Interaction.InputBox(
                "Digite seu e-mail cadastrado para recuperar a senha:",
                "Recuperação de Senha", "");

            if (string.IsNullOrEmpty(email))
                return;

            // Verifica se o email existe no banco
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM usuarios WHERE email = @email";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    // Gera nova senha temporária (exemplo simples)
                    string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);

                    // Atualiza a senha no banco
                    string updateQuery = "UPDATE usuarios SET senha = @senha WHERE email = @email";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@senha", novaSenha);
                    updateCmd.Parameters.AddWithValue("@email", email);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show(
                        $"Sua nova senha temporária é: {novaSenha}\nFaça login e altere sua senha.",
                        "Recuperação de Senha",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("E-mail não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}

    


