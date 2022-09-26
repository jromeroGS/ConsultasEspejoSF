using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/* Pendientes
Pasar a store Procedure todos los queries y llamarlos desde .net
Ver link de listas para objetos relacionados al objeto principal

 */
namespace WebApp.Modelo
{
    public class MOD_Conexion
    {
        String query;
        public SqlConnection Conection()
        {
            String cadenaConexion = "Server=192.168.233.9;Database=Salesforce2.0;User Id=pubevldb;Password=Evolucion.09";
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            return conexion;
        }
        


    }

}