using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PCampeonato
{
    public partial class frmPrincipal : Form
    {
        public static SqlConnection conexao;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           try
            {
                conexao = new SqlConnection("Data Source=DESKTOP-HCGU6HU\\MSSQLSERVER01;Initial Catalog=LP2;Integrated Security=True");
                conexao.Open();
            }

            catch(SqlException ex)
            {
                MessageBox.Show("Erro de Banco de Dados =/" + ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Outros Erros =/" + ex.Message);

            }

        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void timesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTime form2 = new frmTime();

            form2.MdiParent = this;

            form2.WindowState = FormWindowState.Maximized;

            form2.Show();
        }

        private void estádiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadio form3 = new frmEstadio();

            form3.MdiParent = this;

            form3.WindowState = FormWindowState.Maximized;

            form3.Show();

        }

        private void jogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJogos form4 = new frmJogos();

            form4.MdiParent = this;

            form4.WindowState = FormWindowState.Maximized;

            form4.Show();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSobre form5 = new FormSobre();

            form5.MdiParent = this;

            form5.WindowState = FormWindowState.Maximized;

            form5.Show();

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
