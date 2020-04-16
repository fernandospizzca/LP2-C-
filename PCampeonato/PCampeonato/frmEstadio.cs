using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCampeonato
{
    public partial class frmEstadio : Form
    {
        private BindingSource bnEstadio = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsEstadio = new DataSet();
        public frmEstadio()
        {
            InitializeComponent();
        }

            
        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            // validar os dados
            if (txtNomeEstadio.Text == "")
            {
                MessageBox.Show("Estadio inválido!");
            }
            else
            {
                Estadio RegEstadio = new Estadio();

                RegEstadio.IdEstadio = Convert.ToInt16(txtIdEstadio.Text);
                RegEstadio.NomeEstadio = txtNomeEstadio.Text;

                if (bInclusao)
                {
                    if (RegEstadio.Salvar() > 0)
                    {
                        MessageBox.Show("Estadio adicionado com sucesso!");

                        btnSalvar.Enabled = false;
                        txtIdEstadio.Enabled = false;
                        txtNomeEstadio.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovoRegistro.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;

                        bInclusao = false;

                        // recarrega o grid
                        dsEstadio.Tables.Clear();
                        dsEstadio.Tables.Add(RegEstadio.Listar());
                        bnEstadio.DataSource = dsEstadio.Tables["ESTADIO"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar Estadio!");
                    }
                }
                else
                {
                    if (RegEstadio.Alterar() > 0)
                    {
                        MessageBox.Show("Estadio alterado com sucesso!");

                        dsEstadio.Tables.Clear();
                        dsEstadio.Tables.Add(RegEstadio.Listar());
                        txtIdEstadio.Enabled = false;
                        txtNomeEstadio.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovoRegistro.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar Estadio!");
                    }

                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (TabControl1.SelectedIndex == 0)
            {
                TabControl1.SelectTab(1);
            }

            txtNomeEstadio.Enabled = true;
            txtNomeEstadio.Focus();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovoRegistro.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bnEstadio.CancelEdit();

            btnSalvar.Enabled = false;
            txtNomeEstadio.Enabled = false;
            btnAlterar.Enabled = true;
            btnNovoRegistro.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                Estadio estadio = new Estadio();
                dsEstadio.Tables.Add(estadio.Listar());
                bnEstadio.DataSource = dsEstadio.Tables["ESTADIO"];
                dgvEstadio.DataSource = bnEstadio;
                bnEstadios.BindingSource = bnEstadio;

                txtIdEstadio.DataBindings.Add("TEXT", bnEstadio, "id_ESTADIO");
                txtNomeEstadio.DataBindings.Add("TEXT", bnEstadio, "NOME_ESTADIO");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovoRegistro_Click_1(object sender, EventArgs e)
        {
            if (TabControl1.SelectedIndex == 0)
            {
                TabControl1.SelectTab(1);
            }

            bnEstadio.AddNew();
            txtNomeEstadio.Enabled = true;
            txtNomeEstadio.Focus();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovoRegistro.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;

            bInclusao = true;
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            if (TabControl1.SelectedIndex == 0)
            {
                TabControl1.SelectTab(1);
            }


            if (MessageBox.Show("Confirma exclusão?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Estadio RegEstadio = new Estadio();

                RegEstadio.IdEstadio = Convert.ToInt16(txtIdEstadio.Text);
                RegEstadio.NomeEstadio = txtNomeEstadio.Text;

                if (RegEstadio.Excluir() > 0)
                {
                    MessageBox.Show("Estadio excluído com sucesso!");
                    Estadio R = new Estadio();
                    dsEstadio.Tables.Clear();
                    dsEstadio.Tables.Add(R.Listar());
                    bnEstadio.DataSource = dsEstadio.Tables["ESTADIO"];
                }
                else
                {
                    MessageBox.Show("Erro ao excluir Estadio!");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
