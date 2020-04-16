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
    public partial class frmTime : Form
    {
        private BindingSource bnTime = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsTime = new DataSet();
        public frmTime()
        {
            InitializeComponent();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                Time time = new Time();
                dsTime.Tables.Add(time.Listar());
                bnTime.DataSource = dsTime.Tables["TIME"];
                dgvTimes.DataSource = bnTime;
                bindingNavigator1.BindingSource = bnTime;

                txtId.DataBindings.Add("TEXT", bnTime, "id_TIME");
                txtNomeTime.DataBindings.Add("TEXT", bnTime, "NOME_TIME");
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

            bnTime.AddNew();
            txtNomeTime.Enabled = true;
            txtNomeTime.Focus();
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
                Time RegTime = new Time();

                RegTime.IdTime = Convert.ToInt16(txtId.Text);
                RegTime.NomeTime = txtNomeTime.Text;

                if (RegTime.Excluir() > 0)
                {
                    MessageBox.Show("Time excluído com sucesso!");
                    Time R = new Time();
                    dsTime.Tables.Clear();
                    dsTime.Tables.Add(R.Listar());
                    bnTime.DataSource = dsTime.Tables["TIME"];
                }
                else
                {
                    MessageBox.Show("Erro ao excluir Time!");
                }
            }
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            // validar os dados
            if (txtNomeTime.Text == "")
            {
                MessageBox.Show("Time inválido!");
            }
            else
            {
                Time RegTime = new Time();

                RegTime.IdTime = Convert.ToInt16(txtId.Text);
                RegTime.NomeTime = txtNomeTime.Text;

                if (bInclusao)
                {
                    if (RegTime.Salvar() > 0)
                    {
                        MessageBox.Show("Time adicionado com sucesso!");

                        btnSalvar.Enabled = false;
                        txtId.Enabled = false;
                        txtNomeTime.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovoRegistro.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;

                        bInclusao = false;

                        // recarrega o grid
                        dsTime.Tables.Clear();
                        dsTime.Tables.Add(RegTime.Listar());
                        bnTime.DataSource = dsTime.Tables["TIME"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar Time!");
                    }
                }
                else
                {
                    if (RegTime.Alterar() > 0)
                    {
                        MessageBox.Show("Time alterado com sucesso!");

                        dsTime.Tables.Clear();
                        dsTime.Tables.Add(RegTime.Listar());
                        txtId.Enabled = false;
                        txtNomeTime.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovoRegistro.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar Time!");
                    }

                }
            }
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            if (TabControl1.SelectedIndex == 0)
            {
                TabControl1.SelectTab(1);
            }

            txtNomeTime.Enabled = true;
            txtNomeTime.Focus();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovoRegistro.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = false;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            bnTime.CancelEdit();

            btnSalvar.Enabled = false;
            txtNomeTime.Enabled = false;
            btnAlterar.Enabled = true;
            btnNovoRegistro.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

