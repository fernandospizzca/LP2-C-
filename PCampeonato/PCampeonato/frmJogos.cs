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
    public partial class frmJogos : Form
    {
        private BindingSource bnJogo = new BindingSource();
         private bool bInclusao = false;
        private DataSet dsJogo = new DataSet();
        private DataSet dsTime1 = new DataSet();
        private DataSet dsTime2 = new DataSet();
        private DataSet dsEstadio = new DataSet();
        public frmJogos()
        {
            InitializeComponent();
        }

        private void frmJogos_Load(object sender, EventArgs e)
        {
            try
            {

                Jogo jogo = new Jogo();
                dsJogo.Tables.Add(jogo.Listar());
                bnJogo.DataSource = dsJogo.Tables["JOGO"];
                dgvJogos.DataSource = bnJogo;
                bindingNavigator1.BindingSource = bnJogo;


                Time time1 = new Time();
                dsTime1.Tables.Add(time1.Listar());
                Time time2 = new Time();
                dsTime2.Tables.Add(time2.Listar());

                cbTime1.DataSource = dsTime1.Tables["TIME"];

                cbTime2.DataSource = dsTime2.Tables["TIME"];

                cbTime1.DisplayMember = "nome_TIME";
                cbTime2.DisplayMember = "nome_TIME";
                cbTime1.ValueMember = "id_TIME";
                cbTime2.ValueMember = "id_TIME";
               


                Estadio estadio = new Estadio();
                dsEstadio.Tables.Add(estadio.Listar());

                cbEstadio.DataSource = dsEstadio.Tables["ESTADIO"];
                cbEstadio.DisplayMember = "nome_ESTADIO";
                cbEstadio.ValueMember = "id_ESTADIO";



                txtIdJogo.DataBindings.Add("TEXT", bnJogo, "id_jogo");
                cbTime1.DataBindings.Add("SelectedValue", bnJogo, "TIME_ID_TIME1");
                cbTime2.DataBindings.Add("SelectedValue", bnJogo, "TIME_ID_TIME2");
                cbEstadio.DataBindings.Add("SelectedValue", bnJogo, "ESTADIO_ID_ESTADIO");
                txtGrupo.DataBindings.Add("TEXT", bnJogo, "GRUPO_JOGO");
                txtObs.DataBindings.Add("TEXT", bnJogo, "OBS_JOGO");
                dtpData.DataBindings.Add("TEXT", bnJogo,"DTHR_JOGO");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            if (TabControl1.SelectedIndex == 0)
            {
                TabControl1.SelectTab(1);
            }

            bnJogo.AddNew();
            cbTime1.Enabled = true;
            cbTime2.Enabled = true;
            cbEstadio.Enabled = true;
            txtGrupo.Enabled = true;
            txtObs.Enabled = true;
            dtpData.Enabled = true;
            cbTime1.Focus();
            cbTime2.Focus();
            txtIdJogo.Focus();
            txtGrupo.Focus();
            txtObs.Focus();
            cbEstadio.Focus();

            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovoRegistro.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;

            bInclusao = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (TabControl1.SelectedIndex == 0)
            {
                TabControl1.SelectTab(1);
            }


            if (MessageBox.Show("Confirma exclusão?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Jogo RegJogo = new Jogo();

                RegJogo.IdJogo = Convert.ToInt16(txtIdJogo.Text);
         
                if (RegJogo.Excluir() > 0)
                {
                    MessageBox.Show("Jogo excluído com sucesso!");
                    Jogo R = new Jogo();
                    dsJogo.Tables.Clear();
                    dsJogo.Tables.Add(R.Listar());
                    bnJogo.DataSource = dsJogo.Tables["JOGO"];

                }
                else
                {
                    MessageBox.Show("Erro ao excluir Jogo!");
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbTime1.SelectedValue) == Convert.ToInt32(cbTime2.SelectedValue))
            {
                MessageBox.Show("Jogo inválido! Selecione Times Diferentes");

            }
            else
            {



                Jogo RegJogo = new Jogo();

                RegJogo.IdJogo = Convert.ToInt16(txtIdJogo.Text);
                RegJogo.IdTime1 = Convert.ToInt16(cbTime1.SelectedValue);
                RegJogo.Idtime2 = Convert.ToInt16(cbTime2.SelectedValue);
                RegJogo.EstadioId = Convert.ToInt16(cbEstadio.SelectedValue);
                RegJogo.DthrJogo = Convert.ToDateTime(dtpData.Value);
                RegJogo.Grupo = Convert.ToChar(txtGrupo.Text);
                RegJogo.Obs = txtObs.Text;


                if (bInclusao)
                {
                    if (RegJogo.Salvar() > 0)
                    {
                        MessageBox.Show("Time adicionado com sucesso!");

                        btnSalvar.Enabled = false;
                        cbTime1.Enabled = false;
                        cbTime2.Enabled = false;
                        cbEstadio.Enabled = false;
                        txtIdJogo.Enabled = false;
                        txtGrupo.Enabled = false;
                        txtObs.Enabled = false;
                        dtpData.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovoRegistro.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;

                        bInclusao = false;

                        // recarrega o grid
                        dsJogo.Tables.Clear();
                        dsJogo.Tables.Add(RegJogo.Listar());
                        bnJogo.DataSource = dsJogo.Tables["JOGO"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar Jogo!");
                    }
                }
                else
                {
                    if (RegJogo.Alterar() > 0)
                    {
                        MessageBox.Show("Jogo alterado com sucesso!");

                        dsJogo.Tables.Clear();
                        dsJogo.Tables.Add(RegJogo.Listar());
                        cbTime1.Enabled = false;
                        cbTime2.Enabled = false;
                        cbEstadio.Enabled = false;
                        btnSalvar.Enabled = false;
                        txtIdJogo.Enabled = false;
                        txtGrupo.Enabled = false;
                        txtObs.Enabled = false;
                        dtpData.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovoRegistro.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar Jogo!");
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

            cbTime1.Enabled = true;
            cbTime1.Focus();
            cbTime2.Enabled = true;
            cbTime2.Focus();
            cbEstadio.Enabled = true;
            cbEstadio.Focus();
            txtGrupo.Enabled = true;
            txtObs.Enabled = true;
            dtpData.Enabled = true;
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovoRegistro.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bnJogo.CancelEdit();

            btnSalvar.Enabled = false;
            cbTime1.Enabled = false;
            cbTime2.Enabled = false;
            cbEstadio.Enabled = false;
            txtGrupo.Enabled = false;
            txtObs.Enabled = false;
            dtpData.Enabled = false;
            btnAlterar.Enabled = true;
            btnNovoRegistro.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
