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
        public string getFiltroTercero(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query="SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " INNER JOIN SectionTreeItem__c ACT ON Ter.SectionTreeItemID__c = Act.id INNER JOIN Location__c Pais ON Ter.PartyCountryId__c = Pais.id INNER JOIN Location__c Ciudad ON Ter.BillingCity__c = Ciudad.id where " + nombrefiltro + query2;
            return query;
        }
        public String getFiltroCuenta(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query="SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " where " + nombrefiltro + query2;
            return query;
        }
        public String getFiltroOportunidad(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query= "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " INNER JOIN ACCOUNT Cuenta ON Opor.AccountId = Cuenta.id INNER JOIN Party__c Ter ON Cuenta.Tercero__c = Ter.id INNER JOIN Contact ON Contact.id = Opor.Authorizer__c INNER JOIN [USER] Usu ON Usu.id = Opor.OwnerId where " + nombrefiltro + query2;
            return query;
        }
        public String getFitroDatosFacturacion(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query= "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " INNER JOIN Collection_Agent__c ON DatosF.Collection_Agent__c = Collection_Agent__c.ID INNER JOIN Location__c ciudad ON DatosF.City_Operator_Phone__c = Ciudad.Id LEFT JOIN Opportunity Opor ON Opor.id = DatosF.Opportunityid__c LEFT JOIN Account Cuenta ON DatosF.BillingAccountId__c = cuenta.id LEFT JOIN party__c Ter ON Cuenta.Tercero__c = Ter.id where " + nombrefiltro + query2;
            return query;
        }
        public String getProductosXCotizacion(String cadenaSeleccion, String nombrefiltro, String Texto1)
        {
            query = "SELECT " + cadenaSeleccion + " FROM OPPORTUNITY INNER JOIN QUOTE ON QUOTE.OpportunityId = OPPORTUNITY.ID INNER JOIN QUOTELINEITEM ON QUOTELINEITEM.QuoteId = QUOTE.ID INNER JOIN PRODUCT2 ON QUOTELINEITEM.Product2Id = PRODUCT2.Id INNER JOIN ASSET ON QUOTELINEITEM.Activo_producido__c = ASSET.ID where " + nombrefiltro + "= '" + Texto1 + "'";
            return query;
        }
        public String getActivos(String cadenaSeleccion, String nombrefiltro, String Texto1)
        {
            query = "SELECT " + cadenaSeleccion + " FROM ACCOUNT INNER JOIN OPPORTUNITY ON OPPORTUNITY.accountid = ACCOUNT.id INNER JOIN QUOTE ON QUOTE.OpportunityId = OPPORTUNITY.ID INNER JOIN QUOTELINEITEM ON QUOTELINEITEM.QuoteId = QUOTE.ID INNER JOIN PRODUCT2 ON QUOTELINEITEM.Product2Id = PRODUCT2.Id INNER JOIN ASSET ON QUOTELINEITEM.Activo_producido__c = ASSET.ID where " + nombrefiltro + "= '" + Texto1 + "'";
            return query;
        }
        public String getConsolidadoVentas(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query = "SELECT " + cadenaSeleccion + " FROM PARTY__C Ter INNER JOIN ACCOUNT Cuen ON Cuen.Tercero__c = Ter.id INNER JOIN OPPORTUNITY Opor ON Opor.accountid = Cuen.id INNER JOIN QUOTE ON QUOTE.OpportunityId = Opor.ID INNER JOIN ConsolidatedSales__c Cons ON Cons.Contract_Code__c = Opor.Contract_code__c INNER JOIN Collection_Agent__c ON Cons.Collection_Agent__c = Collection_Agent__c.ID INNER JOIN LOCATION__C Ciudad ON Ciudad.id = Cons.City_Operator_Phone__c where " + nombrefiltro + query2 + " ORDER BY Cons.name";
            return query;
        }
        public String getCasos(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String Texto1)
        {
            query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto
                    + " LEFT JOIN [GROUP] ON [GROUP].ID = [Case].OwnerId LEFT JOIN [user] ON [user].id=[Case].OwnerId"
                    + " WHERE " + nombrefiltro + "= '" + Texto1 + "'";
            return query;

        }
        public String getProductos(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String Texto1)
        {
            query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto + " where " + nombrefiltro + " like '%" + Texto1 + "%' ";
            return query;
        }


    }
    
}