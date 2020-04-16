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
    class Jogo
    {
        private int idJogo;
        private DateTime dthrJogo = new DateTime();
        private int estadioId;
        private int idTime1;
        private int idTime2;
        private char grupo;
        private string obs;
            
        public int IdJogo
        {
            get
            {
                return idJogo;
            }
            set
            {
                idJogo = value;
            }
        }
        public DateTime DthrJogo
        {
            get
            {
                return dthrJogo;
            }
            set
            {
                dthrJogo = value;

            }
        }
        public int EstadioId
        {
            get
            {
                return estadioId;
            }
            set
            {
                estadioId = value;
            }
        }
        public int IdTime1
        {
            get
            {
                return idTime1;
            }
            set
            {
                idTime1 = value;
            }
        }
        public int Idtime2
        {
            get
            {
                return idTime2;
            }
            set
            {
                idTime2 = value;
            }
        }

        public char Grupo
        {
            get
            {
                return grupo;
            }
            set
            {
                grupo = value;
            }
        }
        public string Obs
        {
            get
            {
                return obs;
            }
            set
            {
                obs = value;
            }
        }
        public DataTable Listar()
        {
            SqlDataAdapter daJogo;

            DataTable dtJogo = new DataTable();
            try
            {
                daJogo = new SqlDataAdapter("SELECT * FROM JOGO", frmPrincipal.conexao);
                daJogo.Fill(dtJogo);
                daJogo.FillSchema(dtJogo, SchemaType.Source);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtJogo;
        }
        public int Salvar()
        {
            int retorno = 0;
            try
            {
                SqlCommand mycommand;
                int nReg;

                mycommand = new SqlCommand("INSERT INTO Jogo VALUES (@dthrJogo,@EstadioId,@IdTime1,@IdTime2,@Grupo,@Obs)", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@dthrJogo", SqlDbType.DateTime));
                mycommand.Parameters.Add(new SqlParameter("@EstadioId", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@IdTime1", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@IdTime2", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@Grupo", SqlDbType.Char));
                mycommand.Parameters.Add(new SqlParameter("@Obs", SqlDbType.VarChar));
                mycommand.Parameters["@dthrJogo"].Value = dthrJogo;
                mycommand.Parameters["@EstadioId"].Value = estadioId;
                mycommand.Parameters["@IdTime1"].Value = idTime1;
                mycommand.Parameters["@IdTime2"].Value = idTime2;
                mycommand.Parameters["@Grupo"].Value = grupo;
                mycommand.Parameters["@Obs"].Value = obs;

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
                mycommand = new SqlCommand("UPDATE Jogo Set dthr_jogo = @dthrJogo, ESTADIO_ID_ESTADIO = @EstadioId," +
                    " TIME_ID_TIME1 = @IdTime1, TIME_ID_TIME2 = @IdTime2, GRUPO_JOGO = @Grupo, OBS_JOGO = @Obs" +
                    " where id_jogo = @id_jogo", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@id_jogo", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@dthrJogo", SqlDbType.DateTime));
                mycommand.Parameters.Add(new SqlParameter("@EstadioId", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@IdTime1", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@IdTime2", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@Grupo", SqlDbType.Char));
                mycommand.Parameters.Add(new SqlParameter("@Obs", SqlDbType.VarChar));

                mycommand.Parameters["@id_jogo"].Value = idJogo;
                mycommand.Parameters["@dthrJogo"].Value = dthrJogo;
                mycommand.Parameters["@EstadioId"].Value = estadioId;
                mycommand.Parameters["@IdTime1"].Value = idTime1;
                mycommand.Parameters["@IdTime2"].Value = idTime2;
                mycommand.Parameters["@Grupo"].Value = grupo;
                mycommand.Parameters["@Obs"].Value = obs;
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

                mycommand = new SqlCommand("DELETE FROM Jogo WHERE id_jogo = @id_jogo", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@id_jogo", SqlDbType.Int));

                mycommand.Parameters["@id_jogo"].Value = idJogo;

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
