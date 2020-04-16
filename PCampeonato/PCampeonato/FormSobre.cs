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
    public partial class FormSobre : Form
    {
        public FormSobre()
        {
            InitializeComponent();
        }

        private void FormSobre_Load(object sender, EventArgs e)
        {
            labelDescricao.Text = "\nDaniel Luciano de Oliveira - RA 0030481823015\n\nFernando Henrique Spizzca - RA 0030481823011\n\nLeonardo Henrique Pinheiro Rodrigues - RA 0030481823038\n\nGuilherme de Lima Helaehil - RA 0030481823021\n\n\nFatec Sorocaba ADS - 2º Semestre Noite";
        }
    }
}
