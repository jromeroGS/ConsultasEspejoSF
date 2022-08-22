using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Conexion
{
    public class Controller
    {
        private static string cadenaConexion;
        private static SqlCommand comando;
        private static SqlConnection conexion;


        static Controller()
        {
            //cadenaConexion = @"Server=192.168.233.9;Initial Catalog=Salesforce2.0;Integrated Security=True; User ID= 'pubevldb'; 'Evolucion.09'";
            cadenaConexion = @"Server = 192.168.233.9; Database =Salesforce2.0; User Id=pubevldb; Password=Evolucion.09";
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        public static Cliente LeerPorId(string codigoCliente)
        {

            Cliente unCliente = null;
            try
            {
                conexion.Open();
                comando.CommandText = @"SELECT NAME FROM [Salesforce2.0].[dbo].[OPPORTUNITY] where ID = {codigoCliente}";




                /*using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        unCliente = new Cliente((dataReader["ID"].ToString()), 
                                             dataReader["NAME"].ToString() );
                    }
                }*/

                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Console.WriteLine(lector.GetValue(0).ToString());
                }


                    return unCliente;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

    }
}
