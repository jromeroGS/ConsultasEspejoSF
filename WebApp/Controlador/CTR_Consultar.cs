using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApp.Modelo;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace WebApp.Controlador
{
    public class CTR_Consultar
    {
        public String cadenaSeleccion = "";
        public String nombreObjeto = "";
        public String nombrefiltro = "";
        public String query = "";
        public String query2 = "";
        WebApp.Modelo.MOD_Conexion conexion = new WebApp.Modelo.MOD_Conexion();
        public String Filtros(String Lista1, String Lista2, String Texto1)
        {
            return query;

        }

    }
}
