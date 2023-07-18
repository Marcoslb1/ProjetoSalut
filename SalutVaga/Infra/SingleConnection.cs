using Microsoft.Extensions.Configuration;
using PRO.Infraestructure;
using System;
using System.Data;
using System.Data.SqlClient;


namespace SalutVaga.Infra
{
    public class SingleConnection
    {
        private static SqlConnection? Con = null;

        public static SqlConnection GetConnection(string nomeConexao)
        {
            try
            {
                var configuration = ConfigurationHelper.LoadConfiguration();
                string ConnectionString = ConnectionString = configuration.GetConnectionString(nomeConexao);

                if (Con != null)
                {
                    if (Con.State != ConnectionState.Open)
                    {
                        Con = new SqlConnection(ConnectionString);
                        Con.Open();

                        return Con;
                    }

                    else return Con;
                }

                Con = new SqlConnection(ConnectionString);
                Con.Open();
                return Con;
            }
            catch (Exception)
            {
                return Con;
            }
        }

        public static void CloseConnection()
        {
            try
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }

            }
            catch (Exception)
            {

            }
        }
    }

}

