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
    class Time
    {
        private int idTime;
        private string nomeTime;

        public int IdTime
        {
            get
            {
                return idTime;
            }
            set
            {
                idTime = value;
            }
        }
        public string NomeTime
        {
            get
            {
                return nomeTime;
            }
            set
            {
                nomeTime = value;

            }
        }
        public DataTable Listar()
        {
            SqlDataAdapter daTime;

            DataTable dtTime = new DataTable();
            try
            {
                daTime = new SqlDataAdapter("select * from TIME", frmPrincipal.conexao);
                daTime.Fill(dtTime);
                daTime.FillSchema(dtTime, SchemaType.Source);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtTime;
        }
        public int Salvar()
        {
            int retorno = 0;
            try
            {
                SqlCommand mycommand;
                int nReg;

                mycommand = new SqlCommand("INSERT INTO TIME VALUES (@nome_time)", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@nome_time", SqlDbType.VarChar));

                mycommand.Parameters["@nome_time"].Value = nomeTime;
              
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
                mycommand = new SqlCommand("UPDATE Time Set nome_time=@nome_time where id_time = @id_time", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@id_time", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@nome_time", SqlDbType.VarChar));

                mycommand.Parameters["@id_time"].Value = idTime;
                mycommand.Parameters["@nome_time"].Value = nomeTime;

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

                mycommand = new SqlCommand("DELETE FROM Time WHERE id_time = @id_time", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@id_time", SqlDbType.Int));

                mycommand.Parameters["@id_time"].Value = idTime;

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
