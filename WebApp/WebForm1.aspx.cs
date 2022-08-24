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
            /*DropDownList2.Items.Add("Nit");
            DropDownList2.Items.Add("Razón Social");
            DropDownList2.Items.Add("Código");*/
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
            String query2 = "";

            switch (DropDownList1.Text)
            {
                case "Tercero":
                    nombreObjeto = "Party__c Ter";
                    //nombrefiltro = "PartyId__c";
                    cadenaSeleccion = "Ter.PartyId__c Código, Ter.ID ID, Ter.Name Nombre, FullName__c RazónSocial, PartyType__c TipoPers, PartyIdentificacionType__c TipoIdent, PartyIdentification__c Ident, VerificationDigit__c DígVer, PaomiCompanyId__c CódPaomi, IsActive__c EstadoTer, CIIU__c CódCIIU, ACT.Name ActEcon, BillingAddress__c Dirección, BillingPhone__c Teléf, BillingCelphone__c Celular, BillingMail__c Correo, Pais.name País, Ciudad.name CiuFactura";
                    switch (DropDownList2.Text)
                    {
                        case "Nit":
                            nombrefiltro = "Ter.PartyIdentification__c";
                            query2 = "= '" + TextBox1.Text + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Ter.Name";
                            query2 = " like '%" + TextBox1.Text + "%' ";
                            break;
                        case "Código":
                            nombrefiltro = "Ter.PartyId__c";
                            query2 = "= '" + TextBox1.Text + "'";
                            break;
                        default:
                            nombrefiltro = "PartyId__c";
                            break;


                    }

                    query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " INNER JOIN SectionTreeItem__c ACT ON Ter.SectionTreeItemID__c = Act.id INNER JOIN Location__c Pais ON Ter.PartyCountryId__c = Pais.id INNER JOIN Location__c Ciudad ON Ter.BillingCity__c = Ciudad.id where " + nombrefiltro + query2;
                    
                    break;
                case "Cuenta":
                    nombreObjeto = "ACCOUNT Cuenta";
                    //nombrefiltro = "Account_ID__c";
                    cadenaSeleccion = "ID ID, Name NombreCuenta, Tipo_de_identificacion__c TipoIdent, PartyType__c TipoCuenta, Account_ID__c  NúmeroCuenta, Party_Id__c ClienteÚnico,  Identificacion__c Identificación, CommercialAddressP__c DireccionComercial, CountryParty__c País, Valor_Total_Mensual__c ValorMensual, CommercialAddressP__c DirecciónCom, CountryParty__c País, Customer_Type__c TipoCliente";
                    //DropDownList2.inner.html =
                    switch (DropDownList2.Text)
                    {
                        case "Nit":
                            nombrefiltro = "Cuenta.Identificacion__c";
                            query2 = "= '" + TextBox1.Text + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Cuenta.Name";
                            query2 = " like '%" + TextBox1.Text + "%' ";
                            break;
                        case "Código":
                            nombrefiltro = "Cuenta.Account_ID__c";
                            query2 = "= '" + TextBox1.Text + "'";
                            break;
                        default:
                            nombrefiltro = "Account_ID__c";
                            break;


                    } 
                    query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " where " + nombrefiltro + query2;
                    break;
                case "Oportunidad":
                    nombreObjeto = "OPPORTUNITY Opor";
                    //nombrefiltro = "Opor.contract_code__c";
                    cadenaSeleccion = "Opor.ID ID, Ter.Name RazónSocial, Ter.PartyIdentification__c Identificación, Opor.Contract_code__c Contrato, Opor.StageName Etapa, Opor.Type_of_contract__c TipoCont, Opor.CustomerType__c TipoCliente,  Opor.NetValue__c ValorVenta, Opor.TotalDiscount__c	Descuento, Opor.Amount ValorNeto, Opor.TotalIVA__c TotalIva, Opor.GrandTotal__c ValorTotal, CampaignName__c Campaña, Fecha_cerrada_Ganada__c Fecha_CerradaGanada, LiveOpportu__c OporViva, Opor.CommercialAddressP__c DirecciónComercial, Opor.CommercialPhoneP__c Telf, Opor.Principal_Commercial_Email2__c Email, Opor.Equipo_de_ventas__c EquipoVentas, Contact.Name Autorizante, Usu.NAME Propietario, Canal_structure__c CanalEstructura, LegalvalidationDate__c ValidaciónJurídica";

                    switch (DropDownList2.Text)
                    {
                        case "Nit":
                            nombrefiltro = "Ter.PartyIdentification__c";
                            query2 = "= '" + TextBox1.Text + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Ter.Name";
                            query2 = " like '%" + TextBox1.Text + "%' ";
                            break;
                        case "Código":
                            nombrefiltro = "Opor.contract_code__c";
                            query2 = "= '" + TextBox1.Text + "'";
                            break;
                        default:
                            nombrefiltro = "Opor.contract_code__c";
                            break;


                    }
                    query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " INNER JOIN ACCOUNT Cuenta ON Opor.AccountId = Cuenta.id INNER JOIN Party__c Ter ON Cuenta.Tercero__c = Ter.id INNER JOIN Contact ON Contact.id = Opor.Authorizer__c INNER JOIN [USER] Usu ON Usu.id = Opor.OwnerId where " + nombrefiltro + query2;
                    break;
                    
                case "Datos de Facturación":        
                    nombreObjeto = "BILLINGDATA__c DatosF";
                    //nombrefiltro = "Main_Contract__c";

                    switch (DropDownList2.Text)
                    {
                        case "Nit":
                            nombrefiltro = "Ter.PartyIdentification__c";
                            query2 = "= '" + TextBox1.Text + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Ter.Name";
                            query2 = " like '%" + TextBox1.Text + "%' ";
                            break;
                        case "Código":
                            nombrefiltro = "Opor.contract_code__c";
                            query2 = "= '" + TextBox1.Text + "'";
                            break;
                        default:
                            nombrefiltro = "Opor.contract_code__c";
                            break;


                    }
                    cadenaSeleccion = "DatosF.ID ID, BusinessName__c RazónSocial, DatosF.PartyNumber__c ClienteUnico, Collection_Agent__c.Name AgenteRecaudo, Identification_Type__c TipoId, IdentityTxt__c Identificación, DatosF.Main_Contract__c ContratoPrin, Salesforce_Contract__c Contrato, DatosF.Billing_Credential__c CódigoMedioPago, DatosF.ExternalId_PayU__c CódigoPAYU, FirstQuoteDate__c FechaPrimeraCuota, Direccion_facturacion__c Dirección, Telefono_Facturacion__c Teléfono, Email_Facturacion__c Email, Celular_Facturacion__c Celular, SalesDocument__c ContratoFactura, Sales_amount__c Valordeventa, DiscountAmount__c Valordedescuento, AmountWithTaxes__c ValorNeto, IVAAmount__c ValorImpuesto, Ciudad.name CiudadOperador,Operator_Phone__c TeléfonoOperador ";
                    query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " INNER JOIN Collection_Agent__c ON DatosF.Collection_Agent__c = Collection_Agent__c.ID INNER JOIN Location__c ciudad ON DatosF.City_Operator_Phone__c = Ciudad.Id LEFT JOIN Opportunity Opor ON Opor.id = DatosF.Opportunityid__c LEFT JOIN Account Cuenta ON DatosF.BillingAccountId__c = cuenta.id LEFT JOIN party__c Ter ON Cuenta.Tercero__c = Ter.id where " + nombrefiltro + query2;
                    break;
                case "Productos X Cotización":
                    nombreObjeto = "QUOTELINEITEM";
                    nombrefiltro = "OPPORTUNITY.contract_code__c";
                    cadenaSeleccion = "QUOTELINEITEM.ID ID, QUOTELINEITEM.LINENUMBER IdProdXCot, QUOTELINEITEM.ReferenceId__c Referencia, QUOTELINEITEM.IdPurchase2__c IdAviso, QUOTELINEITEM.InsertionType__c TipoReferencia, PRODUCT2.name Producto, FinancialCodeTxt__c CódigoFinanciero, QUOTELINEITEM.UnitPrice PrecioUnitario, QUOTELINEITEM.UnitPrice PrecioVenta, QUOTELINEITEM.Value_Discount__c Descuento, QUOTELINEITEM.TotalPrice PrecioTotal, ASSET.NAME Activo";
                    query = "SELECT " + cadenaSeleccion + " FROM OPPORTUNITY INNER JOIN QUOTE ON QUOTE.OpportunityId = OPPORTUNITY.ID INNER JOIN QUOTELINEITEM ON QUOTELINEITEM.QuoteId = QUOTE.ID INNER JOIN PRODUCT2 ON QUOTELINEITEM.Product2Id = PRODUCT2.Id INNER JOIN ASSET ON QUOTELINEITEM.Activo_producido__c = ASSET.ID where " + nombrefiltro + "= '" + TextBox1.Text + "'";
                    break;
                case "Activos":
                    nombreObjeto = "ASSET";
                    nombrefiltro = "OPPORTUNITY.contract_code__c";
                    cadenaSeleccion = "ASSET.ID ID, ASSET.NAME NombreActivo, ASSET.STATUS EstadoActivo, ASSET.Url_Modificaciones__c UrlModificaciones, ASSET.Price Precio, PRODUCT2.name NombreProducto, ASSET.Date_Nextbilling__c FechaProxFacturación, ASSET.SubscripType__c TipoSuscripción, ASSET.Monthly_value__c ValorMensual, ASSET.InstallDate FechaInicialUso, ASSET.UsageEndDate FechaFinalUso, ASSET.Desactivation_Date__c FechaDesactivacion, ASSET.IdPurchase2__c IdAviso, ASSET.PurchaseDate FechaCompra";
                    query = "SELECT " + cadenaSeleccion + " FROM ACCOUNT INNER JOIN OPPORTUNITY ON OPPORTUNITY.accountid = ACCOUNT.id INNER JOIN QUOTE ON QUOTE.OpportunityId = OPPORTUNITY.ID INNER JOIN QUOTELINEITEM ON QUOTELINEITEM.QuoteId = QUOTE.ID INNER JOIN PRODUCT2 ON QUOTELINEITEM.Product2Id = PRODUCT2.Id INNER JOIN ASSET ON QUOTELINEITEM.Activo_producido__c = ASSET.ID where " + nombrefiltro + "= '" + TextBox1.Text + "'";
                    break;
                case "Consolidado de Ventas":
                        nombreObjeto = "ConsolidatedSales__c Cons";
                        //nombrefiltro = "OPPORTUNITY.contract_code__c";

                    switch (DropDownList2.Text)
                    {
                        case "Nit":
                            nombrefiltro = "Ter.PartyIdentification__c";
                            query2 = "= '" + TextBox1.Text + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Ter.Name";
                            query2 = " like '%" + TextBox1.Text + "%' ";
                            break;
                        case "Código":
                            nombrefiltro = "Opor.contract_code__c";
                            query2 = "= '" + TextBox1.Text + "'";
                            break;
                        default:
                            nombrefiltro = "Opor.contract_code__c";
                            break;


                    }
                    cadenaSeleccion = "Cons.ID IDConsolidado, Cons.name Consolidado, Cons.Contract_Code__c Contrato, Cons.SalesDocument__c ContratoFactura, Cuen.Name NombreCuenta, Cons.PartyNumber__c ClienteUnico, Cons.BusinessName__c Razón_Social, Cons.Identification_Type__c TipoIdentificación, Cons.Direccion_facturacion__c DirecciónFacturación, Ciudad.Name CiudadOperador,Cons.Operator_Phone__c Telf_Operador, Cons.Email_Facturacion__c Email, Collection_Agent__c.name AgenteRecaudo, Cons.TotalPaymentValue__c ValorConsolidado, Cons.DiscountAmount__c ValorDescuento, Cons.AmountWithTaxes__c ValorNeto, Cons.Tax1Value__c ValorImpuesto, TotalBilling__c ValorTotalFacturar, Cons.Date_First_Installment__c FechaPrimeraCuota";
                        query = "SELECT " + cadenaSeleccion + " FROM PARTY__C Ter INNER JOIN ACCOUNT Cuen ON Cuen.Tercero__c = Ter.id INNER JOIN OPPORTUNITY Opor ON Opor.accountid = Cuen.id INNER JOIN QUOTE ON QUOTE.OpportunityId = Opor.ID INNER JOIN ConsolidatedSales__c Cons ON Cons.Contract_Code__c = Opor.Contract_code__c INNER JOIN Collection_Agent__c ON Cons.Collection_Agent__c = Collection_Agent__c.ID INNER JOIN LOCATION__C Ciudad ON Ciudad.id = Cons.City_Operator_Phone__c where " + nombrefiltro + query2 + " ORDER BY Cons.name";
                    break;

                case "Casos":
                    //Pruebas casos Juan
                    nombreObjeto = "[Case]";
                    nombrefiltro = "CaseNumber";
                        cadenaSeleccion = "CaseNumber NumeroCaso,Status Estado,Subject Asunto, Description Descripcion, Country_Claim__c PaisReclamacion, Tipo_de_soluci_n__c TipoSolucion, ISNULL([user].name,[GROUP].name) Propietario";
                        query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto
                        + " LEFT JOIN [GROUP] ON [GROUP].ID = [Case].OwnerId LEFT JOIN [user] ON [user].id=[Case].OwnerId"
                        + " WHERE " + nombrefiltro + "= '" + TextBox1.Text + "'";

                    break;
                case "Productos":
                        nombreObjeto = "PRODUCT2";
                        nombrefiltro = "name";
                        cadenaSeleccion = "ID ID, name NombreProducto ";
                        query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " where " + nombrefiltro + " like '%" + TextBox1.Text + "%' ";
                    break;

                default:
                    query = "";
                    break;
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
    }
}
