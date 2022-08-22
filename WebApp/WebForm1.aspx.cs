using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;
using Conexion;

using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Drawing;



namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        static String cadenaConexion = "Server=192.168.233.9;Database=Salesforce2.0;User Id=pubevldb;Password=Evolucion.09";
        SqlConnection conexion = new SqlConnection(cadenaConexion);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conexion.Open();

            //string query = "SELECT Id ID, Name NombreOportunidad, Contract_code__c Contrato, StageName Etapa, CustomerType__c TipoCliente, Amount Valor, CampaignName__c Campaña, Fecha_cerrada_Ganada__c Fecha_CerradaGanada FROM OPPORTUNITY where contract_code__c = '" + TextBox1.Text + "'";
            //string query = "SELECT Id ID, PartyNumber__c ClienteUnico, Main_Contract__c Contrato, ExternalId_PayU__c IdentPAYU FROM BILLINGDATA__C where Main_Contract__c = '" + TextBox1.Text + "'";

            //string datos = DropDownList1.Text;

            String cadenaSeleccion = "";
            String nombreObjeto = "";
            String nombrefiltro = "";
            String query = "";

            if (DropDownList1.Text == "Tercero")
            {
                nombreObjeto = "Party__c";
                nombrefiltro = "PartyId__c";
                cadenaSeleccion = "ID ID, Name Nombre, FullName__c RazónSocial, PartyType__c TipoPersona, PartyIdentificacionType__c TipoIdentificación, PartyIdentification__c Identificación, VerificationDigit__c DígitoVerificación ";
                query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " where " + nombrefiltro + "= '" + TextBox1.Text + "'";
            }

            if (DropDownList1.Text == "Cuenta")
            {
                nombreObjeto = "ACCOUNT";
                nombrefiltro = "Account_ID__c";
                cadenaSeleccion = "ID ID, Name NombreCuenta, Tipo_de_identificacion__c TipoIdentificación, PartyType__c TipoCuenta, Account_ID__c  NúmeroCuenta, Party_Id__c ClienteÚnico,  Identificacion__c Identificación, CommercialAddressP__c DireccionComercial, CountryParty__c País";
                query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " where " + nombrefiltro + "= '" + TextBox1.Text + "'";
            }
            if ( DropDownList1.Text == "Oportunidad")
            {
                nombreObjeto = "OPPORTUNITY";
                nombrefiltro = "contract_code__c";
                cadenaSeleccion = "ID ID, Name NombreOportunidad, Contract_code__c Contrato, StageName Etapa, CustomerType__c TipoCliente, Amount Valor, CampaignName__c Campaña, Fecha_cerrada_Ganada__c Fecha_CerradaGanada ";
                query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " where " + nombrefiltro + "= '" + TextBox1.Text + "'";
            }

            
            if (DropDownList1.Text == "Datos de Facturación")
            {
                nombreObjeto = "BILLINGDATA__c";
                nombrefiltro = "Main_Contract__c";
                cadenaSeleccion = "BILLINGDATA__c.ID ID, Collection_Agent__c.Name, Identification_Type__c TipoId, IdentityTxt__c Identificación, Main_Contract__c Contrato, BILLINGDATA__c.Billing_Credential__c CódigoMedioPago, ExternalId_PayU__c CódigoPAYU, FirstQuoteDate__c FechaPrimeraCuota, Direccion_facturacion__c Dirección, Telefono_Facturacion__c Teléfono, Email_Facturacion__c Email, Celular_Facturacion__c Celular, SalesDocument__c ContratoFactura, Sales_amount__c Valordeventa, DiscountAmount__c Valordedescuento, AmountWithTaxes__c ValorNeto, IVAAmount__c ValorImpuesto ";
                query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " INNER JOIN Collection_Agent__c ON BILLINGDATA__c.Collection_Agent__c = Collection_Agent__c.ID where " + nombrefiltro + "= '" + TextBox1.Text + "'";
            }
            if (DropDownList1.Text == "Productos X Cotización")
            {
                nombreObjeto = "QUOTELINEITEM";
                nombrefiltro = "OPPORTUNITY.contract_code__c";
                cadenaSeleccion = "QUOTELINEITEM.ID ID, QUOTELINEITEM.LINENUMBER IdProdXCot, QUOTELINEITEM.ReferenceId__c Referencia, QUOTELINEITEM.IdPurchase2__c IdAviso, QUOTELINEITEM.InsertionType__c TipoReferencia, PRODUCT2.name Producto, FinancialCodeTxt__c CódigoFinanciero, QUOTELINEITEM.UnitPrice PrecioUnitario, QUOTELINEITEM.UnitPrice PrecioVenta, QUOTELINEITEM.Value_Discount__c Descuento, QUOTELINEITEM.TotalPrice PrecioTotal, ASSET.NAME Activo";
                query = "SELECT " + cadenaSeleccion + " FROM OPPORTUNITY INNER JOIN QUOTE ON QUOTE.OpportunityId = OPPORTUNITY.ID INNER JOIN QUOTELINEITEM ON QUOTELINEITEM.QuoteId = QUOTE.ID INNER JOIN PRODUCT2 ON QUOTELINEITEM.Product2Id = PRODUCT2.Id INNER JOIN ASSET ON QUOTELINEITEM.Activo_producido__c = ASSET.ID where " + nombrefiltro + "= '" + TextBox1.Text + "'";
            }

            if (DropDownList1.Text == "Activos")
            {
                nombreObjeto = "ASSET";
                nombrefiltro = "OPPORTUNITY.contract_code__c";
                cadenaSeleccion = "ASSET.ID ID, ASSET.NAME NombreActivo, ASSET.STATUS EstadoActivo, ASSET.Url_Modificaciones__c UrlModificaciones, ASSET.Price Precio, PRODUCT2.name NombreProducto, ASSET.Date_Nextbilling__c FechaProxFacturación, ASSET.SubscripType__c TipoSuscripción, ASSET.Monthly_value__c ValorMensual, ASSET.InstallDate FechaInicialUso, ASSET.UsageEndDate FechaFinalUso, ASSET.Desactivation_Date__c FechaDesactivacion, ASSET.IdPurchase2__c IdAviso, ASSET.PurchaseDate FechaCompra";
                query = "SELECT " + cadenaSeleccion + " FROM ACCOUNT INNER JOIN OPPORTUNITY ON OPPORTUNITY.accountid = ACCOUNT.id INNER JOIN QUOTE ON QUOTE.OpportunityId = OPPORTUNITY.ID INNER JOIN QUOTELINEITEM ON QUOTELINEITEM.QuoteId = QUOTE.ID INNER JOIN PRODUCT2 ON QUOTELINEITEM.Product2Id = PRODUCT2.Id INNER JOIN ASSET ON QUOTELINEITEM.Activo_producido__c = ASSET.ID where " + nombrefiltro + "= '" + TextBox1.Text + "'";
            }

            if (DropDownList1.Text == "Consolidado de Ventas")
            {
                nombreObjeto = "ConsolidatedSales__c";
                nombrefiltro = "OPPORTUNITY.contract_code__c";
                cadenaSeleccion = "ConsolidatedSales__c.ID IDConsolidado, ConsolidatedSales__c.name NommbreConsolidado, ConsolidatedSales__c.Contract_Code__c Contrato, ConsolidatedSales__c.SalesDocument__c ContratoFactura, ACCOUNT.Name NombreCuenta, ConsolidatedSales__c.PartyNumber__c ClienteUnico, ConsolidatedSales__c.BusinessName__c RazónSocial, ConsolidatedSales__c.Identification_Type__c TipoIdentificación, ConsolidatedSales__c.Direccion_facturacion__c DirecciónFacturación, ConsolidatedSales__c.Telefono_Facturacion__c Teléfono, ConsolidatedSales__c.Email_Facturacion__c Email, Collection_Agent__c.name AgenteRecaudo, ConsolidatedSales__c.TotalPaymentValue__c ValorConsolidado, ConsolidatedSales__c.DiscountAmount__c ValorDescuento, ConsolidatedSales__c.AmountWithTaxes__c ValorNeto, ConsolidatedSales__c.Tax1Value__c ValorImpuesto, TotalBilling__c ValorTotalFacturar, ConsolidatedSales__c.Date_First_Installment__c FechaPrimeraCuota";
                query = "SELECT " + cadenaSeleccion + " FROM ACCOUNT INNER JOIN OPPORTUNITY ON OPPORTUNITY.accountid = ACCOUNT.id INNER JOIN QUOTE ON QUOTE.OpportunityId = OPPORTUNITY.ID INNER JOIN ConsolidatedSales__c ON ConsolidatedSales__c.Contract_Code__c = OPPORTUNITY.Contract_code__c INNER JOIN Collection_Agent__c ON ConsolidatedSales__c.Collection_Agent__c = Collection_Agent__c.ID where " + nombrefiltro + "= '" + TextBox1.Text + "' ORDER BY ConsolidatedSales__c.name";
            }

            if (DropDownList1.Text == "Casos")
            {
                /*nombreObjeto = "Case";
                nombrefiltro = "CaseNumber";
                cadenaSeleccion = "CaseNumber NumeroCaso";
                query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " where " + nombrefiltro + "= '" + TextBox1.Text + "'";*/
            }

            if (DropDownList1.Text == "Productos")
            {
                nombreObjeto = "PRODUCT2";
                nombrefiltro = "name";
                cadenaSeleccion = "ID ID, name NombreProducto ";
                query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " where " + nombrefiltro + " like '%" + TextBox1.Text + "%' ";
            }



            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataAdapter data = new SqlDataAdapter(comando);

            DataTable tabla = new DataTable();
            data.Fill(tabla);
            GridView1.DataSource = tabla;
            GridView1.DataBind();
            conexion.Close();
            //Response.Write("Datos Cargados");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}