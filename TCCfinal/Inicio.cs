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
            CarregarTela(new Vertabelas());

        }


     
        public void CarregarTela(UserControl tela)
        {
          
            pnlFundo.Controls.Clear();
          
            tela.Dock = DockStyle.Fill;
            pnlFundo.Controls.Add(tela);

        }
        private void btnUser_Click(object sender, EventArgs e)
        {
         
            CarregarTela(new User());

        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            CarregarTela(new Graficos());
        }

        private void btnTabela_Click(object sender, EventArgs e)
        {
            CarregarTela(new Vertabelas());
        }
    }

}

