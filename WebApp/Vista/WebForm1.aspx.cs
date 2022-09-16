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

                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Visible = false;
                Label7.Visible = false;
                Label8.Visible = false;
                Label9.Visible = false;


                String Lista1 = DDLObjeto.SelectedItem.ToString();
                String Lista2 = DDLFiltro.SelectedItem.ToString();
                String Texto1 = TextBox1.Text;
                String query = filtros.Filtros(Lista1, Lista2, Texto1);

                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataAdapter data = new SqlDataAdapter(comando);

                DataTable tabla = new DataTable();
                data.Fill(tabla);
                GridView1.DataSource = tabla;
                //GridView1.Visible = true;
                GridView1.DataBind();
                conexion.Close();
            }
            catch(FormatException ex)
            {
                string error = ex.Message;
                MessageBox.Show("Revise el valor ingresado y el filtro"+ error, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            GridView1 = null;
            GridView2 = null;
            GridView3 = null;
            GridView4 = null;
            GridView5 = null;
            GridView6 = null;
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
            String queryDet2 = "";
            String queryDet3 = "";
            String queryDet4 = "";
            String queryDet5 = "";
            String queryDet6 = "";
            String queryDet7 = "";

            Label4.Text = "";
            Label5.Text = "";
            Label6.Text = "";
            Label7.Text = "";
            Label8.Text = "";
            Label9.Text = "";


            SqlConnection conexion = conect.Conection();
            conexion.Open();

            idSeleccion = Convert.ToString((sender as LinkButton).CommandArgument);

            String Lista1 = DDLObjeto.SelectedItem.ToString();

            /*SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            //comando.CommandText = "spConsCuentaOp";
            comando.Parameters.Add("@ValObjeto", SqlDbType.VarChar).Value = idSeleccion;*/

            
            switch (Lista1)
            {
                case "Oportunidad":
                    queryDet2 = "SELECT tipoDeDocumento__c TipoDocumento,Name Nombre,DateTimeCreated__c Fecha_Creación, CreatedById Creado_Por, Download__c Cloud, sequence__c Secuencia, PreviewDownload__c AS URL, Ver__c Ver FROM DragDropToCloudCloudDocuments__c WHERE OportunityID__c = '" + idSeleccion + "' ORDER BY sequence__c";
                    Label4.Text = "CLOUD DOCUMENTS";
                    queryDet3 = "SELECT Cons.Name Consolidado, Cons.Contract_Code__c Número_de_Contrato, Cons.SalesDocument__c Contrato_Factura, Cons.TotalPaymentValue__c  ValorBruto, Cons.DiscountAmount__c Descuento, Cons.AmountWithTaxes__c ValorNeto, Cons.Tax1Value__c Impuesto, Cons.Date_First_Installment__c FechaAFacturar, Medio.Name Medio_Pago, PartyNumber__c ClienteUnico, BusinessName__c Razón_Social, Email_Facturacion__c Email, IdentityTxt__c Identificación, Direccion_facturacion__c Dirección_Facturación, Ciu.Name Ciudad, Pais.Name País FROM ConsolidatedSales__c Cons INNER JOIN Consolidated_by_Opportunity__c ConsXO ON Cons.Id = ConsXO.Consolidated_Sales__c LEFT JOIN Collection_Agent__c Medio ON Cons.Collection_Agent__c = Medio.Id LEFT JOIN Location__c Ciu ON Ciu.Id= Cons.City_Operator_Phone__c LEFT JOIN Location__c Pais on Pais.Id=Cons.Country__c WHERE ConsXO.Opportunity__c = '" + idSeleccion + "' ORDER BY Cons.Id";
                    Label5.Text = "CONSOLIDADO DE VENTAS";
                    queryDet4 = "SELECT Act.Name Activo, Act.Status Estado, Pro.Name Nombre_Producto, IdPurchase2__c Aviso, Estado_suscripcion__c EstadoSuscripción, Monthly_value__c ValorMensual, Date_Nextbilling__c FechaPróxFact, InstallDate FechaInicialUso,  UsageEndDate FechaFinalUso, PurchaseDate FechaDeCompra, Activate_date__c FechaActivación, Desactivation_Date__c FechaDesactivación, AnualPayment__c PagoAnual, FigurationNameTxtAndIdPurchase2__c NombreFiguración FROM Asset Act INNER JOIN Product2 Pro ON Act.Product2Id = Pro.Id WHERE Act.Oportunidad_relacionada__c = '" + idSeleccion + "' ORDER BY Act.Id";
                    Label6.Text = "ACTIVOS";
                    /*queryDet3 = "SELECT  FROM ConsolidateSales__C WHERE OportunityID__c = '" + idSeleccion + "' ORDER BY sequence__c";
                    Label5.Text = "DATOS DE FACTURACION";*/
                    break;
                case "Tercero":
                    queryDet2 = "SELECT pais.name País, MarcaB.Name Consecutivo, Marca.Name Marca, BRAND_ID__c Código_de_Marca, CLASIFICATION__c Clasificación FROM PartyByBrand__c MarcaB LEFT JOIN BRAND__c Marca ON MarcaB.BrandId__c = Marca.Id LEFT JOIN LOCATION__C pais ON Marca.CountryId__c = pais.id WHERE PartyId__c = '" + idSeleccion + "' ORDER BY Marca.Name";
                    Label4.Text = "TERCEROS Y/O MARCAS RELACIONADAS";
                    queryDet3 = "SELECT pais.name País, LocationCityName__c Ciudad, Suc.Name Dirección, AddressName__c Dirección FROM PartyAddress__c Suc LEFT JOIN LOCATION__C pais ON Suc.CountryId__c = pais.id WHERE PartyId__c = '" + idSeleccion + "' ORDER BY Suc.Name";
                    Label5.Text = "SUCURSALES DE TERCEROS";
                    queryDet4 = "SELECT Name Consecutivo, ContactType__c Tipo_de_Contacto, ContactPointValue__c Punto_de_Contacto FROM PartyContactPoint__c WHERE PartyId__c = '" + idSeleccion + "' ORDER BY Name";
                    Label6.Text = "PUNTOS DE CONTACTO";

                    //queryDet4 = "SELECT pais.name País, MarcaB.Name Consecutivo, Marca.Name, BRAND_ID__c Código_de_Marca, CLASIFICATION__c Clasificación FROM PartyByBrand__c MarcaB LEFT JOIN BRAND__c Marca ON MarcaB.BrandId__c = Marca.Id LEFT JOIN LOCATION__C pais ON Marca.CountryId__c = pais.id WHERE PartyId__c = '" + idSeleccion + "' ORDER BY Marca.Name";
                    break;
                case "Cuenta":
                    queryDet2 = "SELECT CaseNumber NúmeroCaso, SolutionGD__c Solución, Solution_Detail__c Detalle, Tipi.Name Detalle_Tipo_Solicitud,Status Estado, Caso.CreatedDate FechaApertura, Caso.ClosedDate FechaCierre, Usuario.Name Propietario FROM [Case] Caso INNER JOIN ACCOUNT cuenta ON Caso.AccountId=Cuenta.id INNER JOIN [User] Usuario ON Caso.OwnerId = Usuario.id LEFT JOIN Tipificacion__c Tipi ON Caso.Detalle_tipo_de_solicitud__c = Tipi.ID WHERE Caso.AccountId = '" + idSeleccion + "' ORDER BY Caso.CaseNumber";
                    Label4.Text = "CASOS";
                    queryDet3 = "SELECT Opor.NAME NombreOportunidad, Ter.NAME NombreTercero, StageName Etapa, FirstDateReportSales__c Fecha_de_Cierre, Contract_code__c Número_de_Contrato, LiveOpportu__c OportViva, Amount Valor_Neto, Type_of_contract__c Tipo_de_Contrato, Fecha_cerrada_Ganada__c Fecha_CerradaGanada, LegalvalidationDate__c Fecha_ValidaciónJur FROM OPPORTUNITY as Opor INNER JOIN Territorio__c as Ter on opor.Territory__c = Ter.Id WHERE Opor.AccountId = '" + idSeleccion + "' ORDER BY Opor.Id";
                    Label5.Text = "OPORTUNIDADES";
                    queryDet4 = "SELECT Act.Name NombreActivo, Act.Status Estado,Act.Price Precio,Act.Renovado__c Renovado, FigurationNameTxtAndIdPurchase2__c RazónFigur_IdAvis_Pdto_PartPdto_Ciud_Sec, Opor.Contract_code__c Contrato, Activate_date__c FechaActivación, Desactivation_Date__c FechaDesactivación, Act.AnualPayment__c PagoAnual FROM ASSET as Act INNER JOIN Opportunity Opor ON Act.Oportunidad_relacionada__c = Opor.Id WHERE Act.AccountId = '" + idSeleccion + "' ORDER BY Act.Id";
                    Label6.Text = "ACTIVOS";
                    queryDet5 = "SELECT Name Consolidado, Contract_Code__c Número_de_Contrato, SalesDocument__c Contrato_Factura, TotalPaymentValue__c ValorBruto, DiscountAmount__c Descuento, AmountWithTaxes__c ValorNeto, Tax1Value__c Impuesto, Date_First_Installment__c FechaAFacturar FROM ConsolidatedSales__c as Cons WHERE Cons.account__c = '" + idSeleccion + "' ORDER BY Cons.name";
                    Label7.Text = "CONSOLIDADOS DE VENTAS";

                    queryDet6 = "SELECT Name Nombre_RF, Status__c Estado, Flow__c Flujo, Satisfaction_Level__c Nivel_de_Satisfacción, CallCounter__c Cant_Llamadas,  CloseDate__c Fecha_Cierre FROM Loyalty_Registry__c as Reg WHERE Reg.Account__c = '" + idSeleccion + "' ORDER BY Reg.Id";
                    Label8.Text = "REGISTROS DE FIDELIZACION";

                    queryDet7 = "SELECT Name Nombre, Authorization_Level__c Rol, Identification_type__c TipoIdent, Identification_number__c Identificación, Email Correo, Address_1__c Dirección, Phone Teléfono, MobilePhone Celular FROM Contact as Cont  WHERE Cont.AccountId = '" + idSeleccion + "' ORDER BY Cont.name";
                    Label9.Text = "CONTACTOS";

                    break;
                case "Casos":
                    queryDet2 = "SELECT Cloud.Name NombreCloud, Cloud.DragDropToCloudFolderId__c Carpeta, Cloud.Download__c Descargar, Cloud.tipoDeDocumento__c Tipo_Documento FROM DragDropToCloudCloudDocuments__c Cloud INNER JOIN [Case] Caso ON Cloud.Caso__c = Caso.id WHERE Caso.id = '" + idSeleccion + "'";
                    Label4.Text = "CLOUD DOCUMENTS";
                    queryDet3 = "SELECT CommentBody Comentario, IsPublished Publicado FROM CaseComment Comen INNER JOIN [Case] Caso ON Comen.ParentId=Caso.Id WHERE Caso.Id = '" + idSeleccion + "'";
                    Label5.Text = "COMENTARIOS DEL CASO";
                    queryDet4 = "SELECT ToAddress DirecciónPara, Subject Asunto, TextBody Texto, Status Estado, CreatedDate FechaCreación FROM [EmailMessage] WHERE ParentId = '" + idSeleccion + "'";
                    Label6.Text = "CORREOS ELECTRONICOS";
                    queryDet5 = "SELECT Status Estado, Subject Asunto, Description Descripción, ActivityDate Fecha_Vencimiento, Priority Prioridad, RecordTypeId TipoRegistro FROM [Task] WHERE WhatId = '" + idSeleccion + "'";
                    Label7.Text = "ACTIVIDADES";
                    break;
                case "Consolidado de Ventas":
                    queryDet2 = "SELECT Name CuotaConsolidado,PaymentValue__c ValorBruto, DiscountAmount__c Descuento, AmountWithTaxes__c ValorNeto,Tax1Value__c Impuesto, TotalBilling__c ValorTotal, PositionSAP__c PosiciónSap, PaymentNumber__c Posicion, BillingDate__c Fecha_de_Facturación, Billing_Date__c Fecha_de_Cuota, FinancialCode__c CódigoFinanciero, Number_of_Initial_Contract__c ContratoInicial, SAP_Synchronization__c SincronizaciónSAP, ReferenceName__c Referencia, Business_line__c Línea_Negocio FROM PaymentByConsolidatedSales__c WHERE ConsolidatedSalesId__c = '" + idSeleccion + "' ORDER BY Name";
                    Label4.Text = "CUOTAS DEL CONSOLIDADO";

                    break;
                case "Datos de Facturación":
                    queryDet2 = "SELECT Name CuotaDato, ReferenceName__c Referencia,PaymentNumber__c ConsCuota,PaymentValue__c ValorBruto, DiscountAmount__c Descuento,AmountWithTaxes__c ValorNeto, Tax1Value__c Impuesto, TotalBilling__c TotalFacturar, BillingDate__c FechaFactura, Billing_Date__c FechaCuota, FinancialCode__c CódigoFinanciero FROM BillingDataByReferenceByPayment__c WHERE BillingDataId__c = '" + idSeleccion + "' ORDER BY Name";
                    Label4.Text = "CUOTAS DEL DATO DE FACTURACION";
                    break;

            }


            if (queryDet2 != "")
            {
                Label4.Visible = true;
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
                Label5.Visible = true;
                SqlCommand comando = new SqlCommand(queryDet3, conexion);
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                GridView3.DataSource = tabla;
                GridView3.Visible = true;
                GridView3.DataBind();

                /*Label5.Visible = true;
                SqlCommand comando3 = new SqlCommand();
                comando3.Connection = conexion;
                comando3.CommandType = CommandType.StoredProcedure;
                comando3.CommandText = "spConsCuentaOp";
                comando3.Parameters.Add("@ValObjeto", SqlDbType.VarChar).Value = idSeleccion;
                //conexion.Open();
                GridView3.DataSource = comando3.ExecuteReader();
                GridView3.Visible = true;
                GridView3.DataBind();*/
            }

            if (queryDet4 != "")
            {
                Label6.Visible = true;
                SqlCommand comando = new SqlCommand(queryDet4, conexion);
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                GridView4.DataSource = tabla;
                GridView4.Visible = true;
                GridView4.DataBind();
            }
            if (queryDet5 != "")
            {
                Label7.Visible = true;
                SqlCommand comando = new SqlCommand(queryDet5, conexion);
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                GridView5.DataSource = tabla;
                GridView5.Visible = true;
                GridView5.DataBind();
            }
            if (queryDet6 != "")
            {
                Label8.Visible = true;
                SqlCommand comando = new SqlCommand(queryDet6, conexion);
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                GridView6.DataSource = tabla;
                GridView6.Visible = true;
                GridView6.DataBind();
            }

            if (queryDet7 != "")
            {
                Label9.Visible = true;
                SqlCommand comando = new SqlCommand(queryDet7, conexion);
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                GridView7.DataSource = tabla;
                GridView7.Visible = true;
                GridView7.DataBind();
            }

            conexion.Close();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*Label9.Text = GridView1.SelectedRow.Cells[1].Text;
           
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        
                    
                }
            }*/

           /* GridViewRow row = GridView1.SelectedRow;

            //
            // Obtengo el id de la entidad que se esta editando
            // en este caso de la entidad Person
            //
            int idselec = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);*/


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            /*if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                //
                // Obtengo el id de la entidad que se esta editando
                // en este caso de la entidad Person
                //
                int id = Convert.ToInt32(GridView1.DataKeys[index].Value);
            }*/
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
               /* if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HyperLink link = new HyperLink();
                    link.Text = "NUEVOLINK";
                    link.NavigateUrl = "Navegar a: " + e.Row.DataItem;
                    e.Row.Cells[ColumnIndex].Controls.Add(link);
            }*/
            
        }
    }
}

