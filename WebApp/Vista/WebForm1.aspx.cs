using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Drawing;
using ClosedXML.Excel;
using System.IO;
using WebApp.Modelo;
using WebApp.Controlador;



namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public String query = "";
        WebApp.Modelo.MOD_Conexion conect = new WebApp.Modelo.MOD_Conexion();
        WebApp.Controlador.CTR_Consultar  filtros= new WebApp.Controlador.CTR_Consultar();


        protected void Page_Load(object sender, EventArgs e)
        {
            /*DropDownList2.Items.Add("Nit");
            DropDownList2.Items.Add("Razón Social");
            DropDownList2.Items.Add("Código");*/
        }

        protected void Consultar(object sender, EventArgs e)
        {

            SqlConnection conexion = conect.Conection();
            conexion.Open();

            String Lista1 = DropDownList1.Text;
            String Lista2 = DropDownList2.Text;
            String Texto1 = TextBox1.Text;
            String query=filtros.Filtros(Lista1,Lista2,Texto1);

            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataAdapter data = new SqlDataAdapter(comando);

            DataTable tabla = new DataTable();
            data.Fill(tabla);
            GridView1.DataSource = tabla;
            GridView1.DataBind();
            conexion.Close();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*DropDownList2.Items.Clear();
            switch (DropDownList1.Text)
            {
                
                case "Tercero":
                    
                    DropDownList2.Items.Add("Nit");
                    DropDownList2.Items.Add("Razón Social");
                    DropDownList2.Items.Add("Código");
                    break;
                case "Cuenta":
                    
                    DropDownList2.Items.Add("Nit");
                    DropDownList2.Items.Add("Razón Social");
                    DropDownList2.Items.Add("Código");
                    break;
                case "Oportunidad":
                    
                    DropDownList2.Items.Add("Nit");
                    DropDownList2.Items.Add("Razón Social");
                    DropDownList2.Items.Add("Código");
                    break;
                case "Datos de Facturación":
                    
                    DropDownList2.Items.Add("Nit");
                    DropDownList2.Items.Add("Razón Social");
                    DropDownList2.Items.Add("Código");
                    break;
                case "Consolidados de Ventas":
                    
                    DropDownList2.Items.Add("Nit");
                    DropDownList2.Items.Add("Razón Social");
                    DropDownList2.Items.Add("Código");
                    break;
                case "Casos":
                    
                    DropDownList2.Items.Add("Caso");
                    break;

            }*/
            
        }
         protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Exportar_Excel(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = conect.Conection();
                conexion.Open();

                String Lista1 = DropDownList1.Text;
                String Lista2 = DropDownList2.Text;
                String Texto1 = TextBox1.Text;
                String query = filtros.Filtros(Lista1, Lista2, Texto1);

                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataAdapter data = new SqlDataAdapter(comando);

                DataTable tabla = new DataTable("DTConsultas");
                data.Fill(tabla);

                using (XLWorkbook libro = new XLWorkbook())
                {
                    var hoja = libro.Worksheets.Add(tabla);
                    hoja.ColumnsUsed().AdjustToContents();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Reporte.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        libro.SaveAs(MyMemoryStream);
                        Response.BinaryWrite(MyMemoryStream.ToArray());
                        Response.Flush();
                        Response.End();

                    }

                }
                conexion.Close();
            }
            catch
            {
                throw;
            }
        }
    }
}
