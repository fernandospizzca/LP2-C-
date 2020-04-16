using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace PCampeonato
{
    class Estadio
    {
        private int idEstadio;
        private string nomeEstadio;

        public int IdEstadio
        {
            get
            {
                return idEstadio;
            }
            set
            {
                idEstadio = value;
            }
        }
        public string NomeEstadio
        {
            get
            {
                return nomeEstadio;
            }
            set
            {
                nomeEstadio = value;

            }
        }
        public DataTable Listar()
        {
            SqlDataAdapter daEstadio;

            DataTable dtEstadio = new DataTable();
            try
            {
                daEstadio = new SqlDataAdapter("SELECT * FROM Estadio", frmPrincipal.conexao);
                daEstadio.Fill(dtEstadio);
                daEstadio.FillSchema(dtEstadio, SchemaType.Source);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtEstadio;
        }
        public int Salvar()
        {
            int retorno = 0;
            try
            {
                SqlCommand mycommand;
                int nReg;

                mycommand = new SqlCommand("INSERT INTO ESTADIO VALUES (@nome_estadio)", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@nome_estadio", SqlDbType.VarChar));

                mycommand.Parameters["@nome_estadio"].Value = nomeEstadio;

                nReg = mycommand.ExecuteNonQuery();

                if (nReg > 0)
                {
                    retorno = nReg;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;

        }
        public int Alterar()
        {
            int retorno = 0;
            try
            {
                SqlCommand mycommand;
                int nReg = 0;
                mycommand = new SqlCommand("UPDATE Estadio Set nome_estadio=@nome_estadio where id_estadio = @id_estadio", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@id_estadio", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@nome_estadio", SqlDbType.VarChar));

                mycommand.Parameters["@id_estadio"].Value = idEstadio;
                mycommand.Parameters["@nome_estadio"].Value = nomeEstadio;

                nReg = mycommand.ExecuteNonQuery();
                if (nReg > 0)
                {
                    retorno = nReg;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
        public int Excluir()
        {
            int nReg = 0;
            try
            {
                SqlCommand mycommand;

                mycommand = new SqlCommand("DELETE FROM Estadio WHERE id_estadio = @id_estadio", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@id_estadio", SqlDbType.Int));

                mycommand.Parameters["@id_estadio"].Value = idEstadio;

                nReg = mycommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nReg;
        }

    }
}
    

