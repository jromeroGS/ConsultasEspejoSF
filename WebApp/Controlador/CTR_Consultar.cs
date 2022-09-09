using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApp.Modelo;

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

            switch (Lista1)
            {
                case "Tercero":
                    nombreObjeto = "Party__c Ter";
                    //nombrefiltro = "PartyId__c";
                    cadenaSeleccion = "Ter.PartyId__c Código, Ter.Name Nombre, FullName__c Razón_Social, PartyType__c Tipo_Persona, PartyIdentificacionType__c TipoIdent, PartyIdentification__c Identificación, VerificationDigit__c DígVer, PaomiCompanyId__c CódPaomi, IsActive__c EstadoTer, CIIU__c CódCIIU, ACT.Name Act_Económica, BillingAddress__c Dirección, BillingPhone__c Teléfono, BillingCelphone__c Celular, BillingMail__c Correo, Pais.name País, Ciudad.name Ciudad_Factura, Ter.ID ID";

                    switch (Lista2)
                    {
                        case "Identificación":
                            nombrefiltro = "Ter.PartyIdentification__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Ter.Name";
                            query2 = " like '%" + Texto1 + "%' ";
                            break;
                        case "Código":
                            nombrefiltro = "Ter.PartyId__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                    }
                    query = conexion.getFiltroTercero(cadenaSeleccion, nombreObjeto, nombrefiltro, query2);
                    break;
                case "Cuenta":
                    nombreObjeto = "ACCOUNT Cuenta";
                    //nombrefiltro = "Account_ID__c";
                    cadenaSeleccion = "Name Nombre_Cuenta, Tipo_de_identificacion__c TipoIdent, PartyType__c TipoCuenta, Account_ID__c  Número_Cuenta, Party_Id__c Cliente_Único,  Identificacion__c Identificación, CommercialAddressP__c Dirección_Comercial, CountryParty__c País, Valor_Total_Mensual__c Valor_Mensual, Customer_Type__c Tipo_Cliente, ID ID";

                    switch (Lista2)
                    {
                        case "Identificación":
                            nombrefiltro = "Cuenta.Identificacion__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Cuenta.Name";
                            query2 = " like '%" + Texto1 + "%' ";
                            break;
                        case "Código":
                            nombrefiltro = "Cuenta.Account_ID__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                    }
                    query = conexion.getFiltroCuenta(cadenaSeleccion, nombreObjeto, nombrefiltro, query2);
                    break;
                case "Oportunidad":
                    nombreObjeto = "OPPORTUNITY Opor";
                    //nombrefiltro = "Opor.contract_code__c";
                    cadenaSeleccion = "Ter.Name Razón_Social, Ter.PartyIdentification__c Identificación, Opor.Contract_code__c Contrato, Opor.StageName Etapa, Opor.Type_of_contract__c TipoCont, Opor.CustomerType__c TipoCliente,  Opor.NetValue__c ValorVenta, Opor.TotalDiscount__c	Descuento, Opor.Amount ValorNeto, Opor.TotalIVA__c TotalImpuesto, Opor.GrandTotal__c ValorTotal, CampaignName__c Campaña, Fecha_cerrada_Ganada__c Fecha_CerradaGanada, LiveOpportu__c OporViva, Opor.CommercialAddressP__c DirecciónComercial, Opor.CommercialPhoneP__c Telf, Opor.Principal_Commercial_Email2__c Email, Opor.Equipo_de_ventas__c EquipoVentas, Contact.Name Autorizante, Usu.NAME Propietario, Canal_structure__c CanalEstructura, LegalvalidationDate__c ValidaciónJurídica, Opor.ID ID";
                    switch (Lista2)
                    {
                        case "Identificación":
                            nombrefiltro = "Ter.PartyIdentification__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Ter.Name";
                            query2 = " like '%" + Texto1 + "%' ";
                            break;
                        case "Código":
                            nombrefiltro = "Opor.contract_code__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                        default:
                            nombrefiltro = "Opor.contract_code__c";
                            break;
                    }
                    query = conexion.getFiltroOportunidad(cadenaSeleccion, nombreObjeto, nombrefiltro, query2);
                    break;
                case "Datos de Facturación":
                    nombreObjeto = "BILLINGDATA__c DatosF";
                    //nombrefiltro = "Main_Contract__c";
                    cadenaSeleccion = "BusinessName__c Razón_Social, DatosF.PartyNumber__c Cliente_Único, Collection_Agent__c.Name Medio_de_Pago, Identification_Type__c TipoId, IdentityTxt__c Identificación, DatosF.Main_Contract__c ContratoPrin, Salesforce_Contract__c Contrato, DatosF.Billing_Credential__c CódigoMedioPago, DatosF.ExternalId_PayU__c CódigoPAYU, FirstQuoteDate__c FechaPrimeraCuota, Direccion_facturacion__c Dirección, Telefono_Facturacion__c Teléfono, Email_Facturacion__c Email, Celular_Facturacion__c Celular, SalesDocument__c ContratoFactura, Sales_amount__c Valordeventa, DiscountAmount__c Valordedescuento, AmountWithTaxes__c ValorNeto, IVAAmount__c ValorImpuesto, Ciudad.name CiudadOperador,Operator_Phone__c TeléfonoOperador, DatosF.ID ID";
                    switch (Lista2)
                    {
                        case "Identificación":
                            nombrefiltro = "Ter.PartyIdentification__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Ter.Name";
                            query2 = " like '%" + Texto1 + "%' ";
                            break;
                        case "Código":
                            nombrefiltro = "Opor.contract_code__c";
                            query2 = "= '" + Texto1 + "'";
                            break;

                    }
                    query = conexion.getFitroDatosFacturacion(cadenaSeleccion, nombreObjeto, nombrefiltro, query2);
                    break;
                case "Productos X Cotización":
                    nombreObjeto = "QUOTELINEITEM ProXCot";
                    //nombrefiltro = "OPPORTUNITY.contract_code__c";
                    cadenaSeleccion = "ProXCot.LINENUMBER IdProdXCot, ProXCot.ReferenceId__c Referencia, ProXCot.IdPurchase2__c IdAviso, ProXCot.InsertionType__c TipoReferencia, Prod.name Producto, FinancialCodeTxt__c CódigoFinanciero, ProXCot.UnitPrice PrecioUnitario, ProXCot.UnitPrice PrecioVenta, ProXCot.Value_Discount__c Descuento, ProXCot.TotalPrice PrecioTotal, Act.NAME Activo, ProXCot.ID ID";
                    switch (Lista2)
                    {
                        case "Identificación":
                            nombrefiltro = "Ter.PartyIdentification__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Ter.Name";
                            query2 = " like '%" + Texto1 + "%' ";
                            break;
                        case "Código":
                            nombrefiltro = "Ter.PartyId__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                    }
                    query = conexion.getProductosXCotizacion(cadenaSeleccion, nombreObjeto, nombrefiltro, query2);
                    break;

                case "Activos":
                    nombreObjeto = "ASSET Act";
                    //nombrefiltro = "OPPORTUNITY.contract_code__c";
                    cadenaSeleccion = "Act.NAME NombreActivo, Act.STATUS EstadoActivo, Act.Url_Modificaciones__c UrlModificaciones, Act.Price Precio, Prod.name NombreProducto, Act.Date_Nextbilling__c FechaProxFacturación, Act.SubscripType__c TipoSuscripción, Act.Monthly_value__c ValorMensual, Act.InstallDate FechaInicialUso, Act.UsageEndDate FechaFinalUso, Act.Desactivation_Date__c FechaDesactivacion, Act.IdPurchase2__c IdAviso, Act.PurchaseDate FechaCompra, Act.ID ID";
                    switch (Lista2)
                    {
                        case "Identificación":
                            nombrefiltro = "Ter.PartyIdentification__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Ter.Name";
                            query2 = " like '%" + Texto1 + "%' ";
                            break;
                        case "Código":
                            nombrefiltro = "Ter.PartyId__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                    }
                    query = conexion.getActivos(cadenaSeleccion, nombreObjeto, nombrefiltro, query2);
                    break;

                case "Consolidado de Ventas":
                    nombreObjeto = "ConsolidatedSales__c Cons";
                    //nombrefiltro = "OPPORTUNITY.contract_code__c";
                    cadenaSeleccion = "Cons.name Consolidado, Cons.Contract_Code__c Contrato, Cons.SalesDocument__c ContratoFactura, Cuen.Name NombreCuenta, Cons.PartyNumber__c Cliente_Único, Cons.BusinessName__c Razón_Social, Cons.Identification_Type__c TipoIdentificación, Cons.Direccion_facturacion__c DirecciónFacturación, Ciudad.Name CiudadOperador,Cons.Operator_Phone__c Telf_Operador, Cons.Email_Facturacion__c Email, Collection_Agent__c.name AgenteRecaudo, Cons.TotalPaymentValue__c ValorConsolidado, Cons.DiscountAmount__c ValorDescuento, Cons.AmountWithTaxes__c ValorNeto, Cons.Tax1Value__c ValorImpuesto, TotalBilling__c ValorTotalFacturar, Cons.Date_First_Installment__c FechaPrimeraCuota, Cons.ID ID";
                    switch (Lista2)
                    {
                        case "Identificación":
                            nombrefiltro = "Ter.PartyIdentification__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Ter.Name";
                            query2 = " like '%" + Texto1 + "%' ";
                            break;
                        case "Código":
                            nombrefiltro = "Opor.contract_code__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                        default:
                            nombrefiltro = "Opor.contract_code__c";
                            break;


                    }
                    query = conexion.getConsolidadoVentas(cadenaSeleccion, nombreObjeto, nombrefiltro, query2);
                    break;

                case "Casos":
                    nombreObjeto = "[Case] Caso";
                    //nombrefiltro = "CaseNumber";
                    cadenaSeleccion = "Caso.CaseNumber Número_de_Caso,Caso.Status Estado,Caso.Subject Asunto,"
                        + " Caso.Description Descripción, Caso.Country_Claim__c PaisReclamacion, Caso.Tipo_de_soluci_n__c Tipo_Solución,"
                        + " Caso.Priority Prioridad, Caso.CreatedDate__c FechaDeApertura, Caso.ClosedDate__c FechaDeCierre,"
                        + " Caso.FreelanceName__c NombreFreelance, Tipificacion.Name DetalleTipoSolicitud,"
                        + " Caso.old_case__c Antiguedad_Dias, Caso.Origin OrigenDelCaso, Caso.Correo_electronico_del_contacto__c CorreoElectronicoDelContacto,"
                        + " Cuenta.Name NombreDeLaCuenta, TipoRegistro.Name TipoDeRegistroDelCaso, CasoRelacionado.CaseNumber CasoPrincipal,"
                        + " Caso.RecurrentCaseByEmail2__c CasoReincidentePorCorreo, Caso.Solution_Detail__c Detalle_de_la_Solución,"
                        + " ISNULL(UsuarioCreadoPor.name,ColaCreadoPor.name ) CreadoPor,"
                        + " ISNULL(UsuarioPropietario.name,ColaPropietario.name) Propietario, Caso.ID ID";
                    switch (Lista2)
                    {
                        case "Identificación":
                            nombrefiltro = "Cuenta.Identificacion__c";
                            query2 = "= '" + Texto1 + "'";
                            break;
                        case "Razón Social":
                            nombrefiltro = "Cuenta.Name";
                            query2 = " like '%" + Texto1 + "%' ";
                            break;
                        case "Número Caso":
                            nombrefiltro = "Caso.CaseNumber";
                            query2 = "= '" + Texto1 + "'";
                            break;
                        case "Email":
                            nombrefiltro = "Caso.SuppliedEmail";
                            query2 = "= '" + Texto1 + "'";
                            break;
                    }
                    query = conexion.getCasos(cadenaSeleccion, nombreObjeto, nombrefiltro, query2);
                    break;
                case "Productos":
                    nombreObjeto = "PRODUCT2 Prod";
                    cadenaSeleccion = "Prod.Name NombreProducto, Prod.IsActive Activo, Prod.Linea_de_negocio_c__c LineaNogocio, Prod.ProductCode Código_de_Producto," +
                        "Prod.Vigencia__c Vigencia, Prod.Family FamiliaProducto, Prod.ReferenceDescription__c Descripción_Referencia, Prod.ProductionType__c Tipo_Producción," +
                        "Prod.Model_Sale__c ModeloVenta, Prod.Financial_Preftxt__c Código_Financiero, ParProdXProd.Name ParteProdXProd, Prod.Id Id";

                    switch (Lista2)
                    {
                        case "Nombre":
                            nombrefiltro = "Prod.Name";
                            break;
                    }

                    query = conexion.getProductos(cadenaSeleccion, nombreObjeto, nombrefiltro, Texto1);
                    break;
            }

            return query;

        }

    }
}
