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




namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public String query = "";
        WebApp.Modelo.MOD_Conexion conect = new WebApp.Modelo.MOD_Conexion();
        WebApp.Controlador.CTR_Consultar  filtros= new WebApp.Controlador.CTR_Consultar();

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
            DDLObjeto.Items.Insert(0, new ListItem("Seleccione el Objeto","0"));

            //GridView1.Columns.Clear();

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

            SqlConnection conexion = conect.Conection();
            conexion.Open();

            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView4.Visible = false;

            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;


            String Lista1 = DDLObjeto.SelectedItem.ToString();
            String Lista2 = DDLFiltro.SelectedItem.ToString();
            String Texto1 = TextBox1.Text;
            String query=filtros.Filtros(Lista1,Lista2,Texto1);

            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataAdapter data = new SqlDataAdapter(comando);

            DataTable tabla = new DataTable();
            data.Fill(tabla);
            GridView1.DataSource = tabla;
            //GridView1.Visible = true;
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

                String Lista1 = DDLObjeto.SelectedItem.ToString();
                String Lista2 = DDLFiltro.SelectedItem.ToString();
                String Texto1 = TextBox1.Text;
                String query = filtros.Filtros(Lista1, Lista2, Texto1);

                SqlCommand Sqlcmd = new SqlCommand(query, conexion);
                SqlDataAdapter data = new SqlDataAdapter(Sqlcmd);

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
        protected void DDLObjeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLFiltro.ClearSelection();
           
            LlenarDDLFiltro(DDLObjeto.SelectedValue);

        }

        protected void LnkDet_Click(object sender, EventArgs e)
        {
            string idSeleccion;
            String queryDet2 = "";
            String queryDet3 = "";
            String queryDet4 = "";
            SqlConnection conexion = conect.Conection();
            conexion.Open();

            idSeleccion = Convert.ToString((sender as LinkButton).CommandArgument);

            String Lista1 = DDLObjeto.SelectedItem.ToString();

            switch (Lista1)
            {
                case "Oportunidad":
                    queryDet2 = "SELECT tipoDeDocumento__c TipoDocumento,Name Nombre,DateTimeCreated__c FechaCreación, CreatedById CreadoPor, Download__c Cloud, sequence__c Secuencia, PreviewDownload__c Ver FROM DragDropToCloudCloudDocuments__c WHERE OportunityID__c = '" + idSeleccion + "' ORDER BY sequence__c";
                    break;
                case "Tercero":
                    queryDet2 = "SELECT pais.name País, LocationCityName__c Ciudad, Suc.Name Dirección, AddressName__c FROM PartyAddress__c Suc LEFT JOIN LOCATION__C pais ON Suc.CountryId__c = pais.id WHERE PartyId__c = '" + idSeleccion + "' ORDER BY Suc.Name";
                    queryDet3 = "SELECT pais.name País, MarcaB.Name Consecutivo, Marca.Name, BRAND_ID__c Código_de_Marca, CLASIFICATION__c Clasificación FROM PartyByBrand__c MarcaB LEFT JOIN BRAND__c Marca ON MarcaB.BrandId__c = Marca.Id LEFT JOIN LOCATION__C pais ON Marca.CountryId__c = pais.id WHERE PartyId__c = '" + idSeleccion + "' ORDER BY Marca.Name";
                    //queryDet4 = "SELECT pais.name País, MarcaB.Name Consecutivo, Marca.Name, BRAND_ID__c Código_de_Marca, CLASIFICATION__c Clasificación FROM PartyByBrand__c MarcaB LEFT JOIN BRAND__c Marca ON MarcaB.BrandId__c = Marca.Id LEFT JOIN LOCATION__C pais ON Marca.CountryId__c = pais.id WHERE PartyId__c = '" + idSeleccion + "' ORDER BY Marca.Name";
                    break;
                case "Cuenta":
                    queryDet2 = "SELECT CaseNumber NúmeroCaso, SolutionGD__c Solución, Solution_Detail__c Detalle, Caso.RecordTypeId TipoRegistroCaso,Status Estado, Caso.CreatedDate FechaApertura, Caso.ClosedDate FechaCierre FROM [Case] Caso INNER JOIN ACCOUNT cuenta ON Caso.AccountId=Cuenta.id WHERE AccountId = '" + idSeleccion + "' ORDER BY Caso.CaseNumber";
                    break;
                case "Casos":
                    queryDet2 = "SELECT Cloud.Name, Cloud.DragDropToCloudFolderId__c, Cloud.Download__c Descargar, Cloud.tipoDeDocumento__c TipoDocumento FROM DragDropToCloudCloudDocuments__c Cloud INNER JOIN [Case] Caso ON Cloud.Caso__c = Caso.id WHERE Caso.id = '" + idSeleccion + "'";
                    Label4.Text = "CLOUD DOCUMENTS";
                    queryDet3 = "SELECT CommentBody Comentario, IsPublished Publicado FROM CaseComment Comen INNER JOIN [Case] Caso ON Comen.ParentId=Caso.Id WHERE Caso.Id = '" + idSeleccion + "'";
                    Label5.Text = "COMENTARIOS DEL CASO";
                    queryDet4 = "SELECT ToAddress DirecciónPara, Subject Asunto, TextBody, Status Estado FROM [EmailMessage] WHERE ParentId = '" + idSeleccion + "'";
                    Label6.Text = "CORREOS ELECTRONICOS";
                    break;
                case "Consolidado de Ventas":
                    queryDet2 = "SELECT Id Id,Name CuotaConsolidado,PaymentValue__c ValorBruto, DiscountAmount__c Descuento, AmountWithTaxes__c ValorNeto,Tax1Value__c Impuesto, TotalBilling__c ValorTotal, PositionSAP__c PosiciónSap, PaymentNumber__c Posicion, BillingDate__c FechaFacturación, Billing_Date__c FechaCuota, FinancialCode__c CódigoFinanciero, Number_of_Initial_Contract__c ContratoInicial, SAP_Synchronization__c SincronizaciónSAP, ReferenceName__c Referencia, Business_line__c LíneaNegocio FROM PaymentByConsolidatedSales__c WHERE ConsolidatedSalesId__c = '" + idSeleccion + "' ORDER BY Name";
                   
                    break;
                case "Datos de Facturación":
                    queryDet2 = "SELECT Name CuotaDato, ReferenceName__c,PaymentNumber__c ConsCuota,PaymentValue__c ValorBruto, DiscountAmount__c Descuento,AmountWithTaxes__c ValorNeto, Tax1Value__c Impuesto, TotalBilling__c TotalFacturar, BillingDate__c FechaFactura, Billing_Date__c FechaCuota, FinancialCode__c CódigoFinanciero FROM BillingDataByReferenceByPayment__c WHERE BillingDataId__c = '" + idSeleccion + "' ORDER BY Name";
                    break;

            }


            if (queryDet2 != "")
            {
                
                SqlCommand comando = new SqlCommand(queryDet2, conexion);
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                GridView2.DataSource = tabla;
                GridView2.Visible = true;
                GridView2.DataBind();
            }

            if (queryDet3 != "")
            {

                SqlCommand comando3 = new SqlCommand(queryDet3, conexion);
                SqlDataAdapter data3 = new SqlDataAdapter(comando3);
                DataTable tabla3 = new DataTable();
                data3.Fill(tabla3);
                GridView3.DataSource = tabla3;
                GridView3.Visible = true;
                GridView3.DataBind();
            }

            if (queryDet4 != "")
            {
                SqlCommand comando4 = new SqlCommand(queryDet4, conexion);
                SqlDataAdapter data4 = new SqlDataAdapter(comando4);
                DataTable tabla4 = new DataTable();
                data4.Fill(tabla4);
                GridView4.DataSource = tabla4;
                GridView4.Visible = true;
                GridView4.DataBind();
            }

                conexion.Close();

        }
    }
}

