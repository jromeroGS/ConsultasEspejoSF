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
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public String query = "";
        WebApp.Modelo.MOD_Conexion conect = new WebApp.Modelo.MOD_Conexion();
        WebApp.Controlador.CTR_Consultar filtros = new WebApp.Controlador.CTR_Consultar();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDDLObjeto();
                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Visible = false;
            }
        }

        protected void LlenarDDLObjeto()
        {
            SqlConnection conexion = conect.Conection();
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "spObjetoConsultaSF";

            DDLObjeto.DataSource = comando.ExecuteReader();
            DDLObjeto.DataTextField = "Objeto";
            DDLObjeto.DataValueField = "Id_Objeto";
            DDLObjeto.DataBind();
            DDLObjeto.Items.Insert(0, new ListItem("Seleccione el Objeto", "0"));

            //GridView1.Columns.Clear();
            GridView1 = null;
            GridView2 = null;
            GridView3 = null;
            GridView4 = null;
            GridView5 = null;
            GridView6 = null;


            conexion.Close();

        }
        protected void LlenarDDLFiltro(String IdObjeto)
        {
            SqlConnection conexion = conect.Conection();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "spConsultaFiltroSF";
            comando.Parameters.Add("@ValObjeto", SqlDbType.VarChar).Value = IdObjeto;
            conexion.Open();
            DDLFiltro.DataSource = comando.ExecuteReader();
            DDLFiltro.DataTextField = "NombreFiltro";
            DDLFiltro.DataValueField = "Valor";
            DDLFiltro.DataBind();

            conexion.Close();

        }

        protected void Consultar(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = conect.Conection();
                conexion.Open();

                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                GridView5.Visible = false;
                GridView6.Visible = false;
                GridView7.Visible = false;
                GVSinCloudDocuments.Visible = false;

                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Visible = false;
                Label7.Visible = false;
                Label8.Visible = false;
                Label9.Visible = false;


                String Lista1 = DDLObjeto.SelectedItem.ToString();
                String Lista2 = DDLFiltro.SelectedItem.ToString();
                String Texto1 = TextBox1.Text;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "spConsSF";
                comando.Parameters.Add("@Objeto", SqlDbType.VarChar).Value = Lista1;
                comando.Parameters.Add("@CampoFiltro", SqlDbType.VarChar).Value = Lista2;
                comando.Parameters.Add("@ValorFiltro", SqlDbType.VarChar).Value = Texto1;

                if (TextBox1.Text.Length != 0)
                {
                    GridView1.DataSource = comando.ExecuteReader();
                    GridView1.Visible = true;
                    GridView1.DataBind();
                    conexion.Close();
                    GridView1.UseAccessibleHeader = true;
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
                else
                {
                    MessageBox.Show("Datos Incompletos", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (FormatException ex)
            {
                string error = ex.Message;
                MessageBox.Show("Revise el valor ingresado y el filtro" + error, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                MessageBox.Show(error, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        protected void Exportar_Excel(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = conect.Conection();
                conexion.Open();

                String Lista1 = DDLObjeto.SelectedItem.ToString();
                String Lista2 = DDLFiltro.SelectedItem.ToString();
                String Texto1 = TextBox1.Text;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "spConsSF";
                comando.Parameters.Add("@Objeto", SqlDbType.VarChar).Value = Lista1;
                comando.Parameters.Add("@CampoFiltro", SqlDbType.VarChar).Value = Lista2;
                comando.Parameters.Add("@ValorFiltro", SqlDbType.VarChar).Value = Texto1;


                SqlDataAdapter data = new SqlDataAdapter(comando);

                DataTable tabla = new DataTable("DTConsultas");
                data.Fill(tabla);


                using (XLWorkbook libro = new XLWorkbook())
                {
                    var hoja = libro.Worksheets.Add(tabla);
                    hoja.ColumnsUsed().AdjustToContents();
                    Response.Clear();
                    Response.Buffer = false;
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
        protected void DDLObjeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLFiltro.ClearSelection();
            GridView1 = null;
            GridView2 = null;
            GridView3 = null;
            GridView4 = null;
            GridView5 = null;
            GridView6 = null;
            GVSinCloudDocuments = null;
            Label4.Text = "";
            Label5.Text = "";
            Label6.Text = "";
            Label7.Text = "";
            Label8.Text = "";
            LlenarDDLFiltro(DDLObjeto.SelectedValue);

        }

        protected void LnkDet_Click(object sender, EventArgs e)
        {
            string idSeleccion;

            Label4.Text = "";
            Label5.Text = "";
            Label6.Text = "";
            Label7.Text = "";
            Label8.Text = "";
            Label9.Text = "";

            idSeleccion = Convert.ToString((sender as LinkButton).CommandArgument);

            String Lista1 = DDLObjeto.SelectedItem.ToString();



            switch (Lista1)
            {
                case "Oportunidad":
                    Label4.Text = "CLOUD DOCUMENTS";
                    Label5.Text = "CONSOLIDADO DE VENTAS";
                    Label6.Text = "ACTIVOS";
                    break;
                case "Tercero":                    
                    Label4.Text = "TERCEROS Y/O MARCAS RELACIONADAS";                    
                    Label5.Text = "SUCURSALES DE TERCEROS";                    
                    Label6.Text = "PUNTOS DE CONTACTO";
                    break;
                case "Cuenta":                    
                    Label4.Text = "CASOS";                    
                    Label5.Text = "OPORTUNIDADES";                    
                    Label6.Text = "ACTIVOS";                    
                    Label7.Text = "CONSOLIDADOS DE VENTAS";                    
                    Label8.Text = "REGISTROS DE FIDELIZACION";                    
                    Label9.Text = "CONTACTOS";
                    break;
                case "Casos":                    
                    Label4.Text = "CLOUD DOCUMENTS";                    
                    Label5.Text = "COMENTARIOS DEL CASO";                    
                    Label6.Text = "CORREOS ELECTRONICOS";                    
                    Label7.Text = "ACTIVIDADES";
                    break;
                case "Consolidado de Ventas":                    
                    Label4.Text = "CUOTAS DEL CONSOLIDADO";
                    break;
                case "Datos de Facturación":                    
                    Label4.Text = "CUOTAS DEL DATO DE FACTURACION";
                    break;

            }

            if (Label4.Text != "")
            {
                Label4.Visible = true;

                SqlConnection conexion = conect.Conection();
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "spConsSFDetalle";
                comando.Parameters.Add("@Objeto", SqlDbType.VarChar).Value = Lista1;
                comando.Parameters.Add("@ObjetoDetalle", SqlDbType.VarChar).Value = Label4.Text;
                comando.Parameters.Add("@ValorFiltro", SqlDbType.VarChar).Value = idSeleccion;

                if (Label4.Text == "CLOUD DOCUMENTS")
                {
                    GridView2.DataSource = comando.ExecuteReader();
                    GridView2.Visible = true;
                    GridView2.DataBind();
                    GridView2.UseAccessibleHeader = true;
                    GridView2.HeaderRow.TableSection = TableRowSection.TableHeader;
                    GridView1.UseAccessibleHeader = true;
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    GVSinCloudDocuments.DataSource = comando.ExecuteReader();
                    GVSinCloudDocuments.Visible = true;
                    GVSinCloudDocuments.DataBind();
                    GVSinCloudDocuments.UseAccessibleHeader = true;
                    GVSinCloudDocuments.HeaderRow.TableSection = TableRowSection.TableHeader;
                    GridView1.UseAccessibleHeader = true;
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                conexion.Close();

            }
            if (Label5.Text != "")
            {
                Label5.Visible = true;
                SqlConnection conexion = conect.Conection();
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "spConsSFDetalle";
                comando.Parameters.Add("@Objeto", SqlDbType.VarChar).Value = Lista1;
                comando.Parameters.Add("@ObjetoDetalle", SqlDbType.VarChar).Value = Label5.Text;
                comando.Parameters.Add("@ValorFiltro", SqlDbType.VarChar).Value = idSeleccion;
                GridView3.DataSource = comando.ExecuteReader();
                GridView3.Visible = true;
                GridView3.DataBind();
                GridView3.UseAccessibleHeader = true;
                GridView3.HeaderRow.TableSection = TableRowSection.TableHeader;
                conexion.Close();
            }
            if (Label6.Text != "")
            {
                Label6.Visible = true;
                SqlConnection conexion = conect.Conection();
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "spConsSFDetalle";
                comando.Parameters.Add("@Objeto", SqlDbType.VarChar).Value = Lista1;
                comando.Parameters.Add("@ObjetoDetalle", SqlDbType.VarChar).Value = Label6.Text;
                comando.Parameters.Add("@ValorFiltro", SqlDbType.VarChar).Value = idSeleccion;
                GridView4.DataSource = comando.ExecuteReader();
                GridView4.Visible = true;
                GridView4.DataBind();
                GridView4.UseAccessibleHeader = true;
                GridView4.HeaderRow.TableSection = TableRowSection.TableHeader;
                conexion.Close();
            }
            if (Label7.Text != "")
            {
                Label7.Visible = true;
                SqlConnection conexion = conect.Conection();
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "spConsSFDetalle";
                comando.Parameters.Add("@Objeto", SqlDbType.VarChar).Value = Lista1;
                comando.Parameters.Add("@ObjetoDetalle", SqlDbType.VarChar).Value = Label7.Text;
                comando.Parameters.Add("@ValorFiltro", SqlDbType.VarChar).Value = idSeleccion;
                GridView5.DataSource = comando.ExecuteReader();
                GridView5.Visible = true;
                GridView5.DataBind();
                GridView5.UseAccessibleHeader = true;
                GridView5.HeaderRow.TableSection = TableRowSection.TableHeader;
                conexion.Close();
            }
            if (Label8.Text != "")
            {
                Label8.Visible = true;
                SqlConnection conexion = conect.Conection();
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "spConsSFDetalle";
                comando.Parameters.Add("@Objeto", SqlDbType.VarChar).Value = Lista1;
                comando.Parameters.Add("@ObjetoDetalle", SqlDbType.VarChar).Value = Label8.Text;
                comando.Parameters.Add("@ValorFiltro", SqlDbType.VarChar).Value = idSeleccion;
                GridView6.DataSource = comando.ExecuteReader();
                GridView6.Visible = true;
                GridView6.DataBind();
                GridView6.UseAccessibleHeader = true;
                GridView6.HeaderRow.TableSection = TableRowSection.TableHeader;
                conexion.Close();
            }
            if (Label9.Text != "")
            {
                Label9.Visible = true;
                SqlConnection conexion = conect.Conection();
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "spConsSFDetalle";
                comando.Parameters.Add("@Objeto", SqlDbType.VarChar).Value = Lista1;
                comando.Parameters.Add("@ObjetoDetalle", SqlDbType.VarChar).Value = Label9.Text;
                comando.Parameters.Add("@ValorFiltro", SqlDbType.VarChar).Value = idSeleccion;
                GridView7.DataSource = comando.ExecuteReader();
                GridView7.Visible = true;
                GridView7.DataBind();
                GridView7.UseAccessibleHeader = true;
                GridView7.HeaderRow.TableSection = TableRowSection.TableHeader;
                conexion.Close();
            }          

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

           


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }
    }
}
