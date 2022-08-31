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
        

        protected void LlenarDDLObjeto()
        {
            SqlConnection conexion = conect.Conection();
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "spObjetoConsultaSF";

            DropDownList1.DataSource = comando.ExecuteReader();
            DropDownList1.DataTextField = "Objeto";
            DropDownList1.DataValueField = "Id_Objeto";
            DropDownList1.DataBind();
           // DropDownList1.Items.Insert(0, new ListItem("Seleccione el Objeto"));

            conexion.Close();

        }
        protected void LlenarDDLFiltro()
        {
            SqlConnection conexion = conect.Conection();
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "spObjetoConsultaSF";

            DropDownList1.DataSource = comando.ExecuteReader();
            DropDownList1.DataTextField = "Objeto";
            DropDownList1.DataValueField = "ValorObjeto";
            DropDownList1.DataBind();
            // DropDownList1.Items.Insert(0, new ListItem("Seleccione el Objeto"));

            conexion.Close();

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDDLObjeto();
            }
        }

        protected void Consultar(object sender, EventArgs e)
        {

            SqlConnection conexion = conect.Conection();
            conexion.Open();

            String Lista1 = DropDownList1.SelectedItem.ToString();
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
