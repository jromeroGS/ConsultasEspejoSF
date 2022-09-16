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
            query = "SELECT TOP (2000) " + cadenaSeleccion + " FROM " + nombreObjeto + " LEFT JOIN SectionTreeItem__c ACT ON Ter.SectionTreeItemID__c = Act.id INNER JOIN Location__c Pais ON Ter.PartyCountryId__c = Pais.id INNER JOIN Location__c Ciudad ON Ter.BillingCity__c = Ciudad.id where " + nombrefiltro + query2;
            return query;
        }
        public String getFiltroCuenta(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query = "SELECT TOP (2000) " + cadenaSeleccion + " FROM " + nombreObjeto + " LEFT JOIN [User] Usu ON Cuenta.OwnerId = Usu.Id LEFT JOIN [User] UsuMod ON Cuenta.LastModifiedById = UsuMod.Id WHERE " + nombrefiltro + query2;
            return query;
        }
        public String getFiltroOportunidad(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query = "SELECT TOP (2000) " + cadenaSeleccion + " FROM " + nombreObjeto + " INNER JOIN ACCOUNT Cuenta ON Opor.AccountId = Cuenta.id INNER JOIN Party__c Ter ON Cuenta.Tercero__c = Ter.id INNER JOIN Contact ON Contact.id = Opor.Authorizer__c INNER JOIN [USER] Usu ON Usu.id = Opor.OwnerId where " + nombrefiltro + query2;
            return query;
        }
        public String getFitroDatosFacturacion(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query = "SELECT TOP (2000) " + cadenaSeleccion + " FROM " + nombreObjeto + " INNER JOIN Collection_Agent__c ON DatosF.Collection_Agent__c = Collection_Agent__c.ID LEFT JOIN Location__c ciudad ON DatosF.City_Operator_Phone__c = Ciudad.Id LEFT JOIN Opportunity Opor ON Opor.id = DatosF.Opportunityid__c LEFT JOIN Account Cuenta ON DatosF.BillingAccountId__c = cuenta.id LEFT JOIN party__c Ter ON Cuenta.Tercero__c = Ter.id where " + nombrefiltro + query2;
            return query;
        }
        public String getProductosXCotizacion(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query = "SELECT TOP (2000) " + cadenaSeleccion + " FROM PARTY__C Ter INNER JOIN ACCOUNT Cuenta ON Ter.id = Cuenta.Tercero__c INNER JOIN OPPORTUNITY opor ON Opor.AccountId = Cuenta.id INNER JOIN QUOTE Cot ON Cot.OpportunityId = Opor.ID INNER JOIN QUOTELINEITEM ProXCot ON ProXCot.QuoteId = Cot.ID INNER JOIN PRODUCT2 Prod ON ProXCot.Product2Id = Prod.Id INNER JOIN ASSET Act ON ProXCot.Activo_producido__c = Act.ID where " + nombrefiltro + query2;
            return query;
        }
        public String getActivos(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query = "SELECT TOP (2000) " + cadenaSeleccion + " FROM PARTY__C Ter INNER JOIN ACCOUNT Cuenta ON Cuenta.Tercero__c = Ter.Id INNER JOIN OPPORTUNITY Opor ON Opor.accountid = Cuenta.id INNER JOIN QUOTE Cot ON Cot.OpportunityId = Opor.ID INNER JOIN QUOTELINEITEM ProXCot ON ProXCot.QuoteId = Cot.ID INNER JOIN PRODUCT2 prod ON ProXCot.Product2Id = prod.Id INNER JOIN ASSET Act ON ProXCot.Activo_producido__c = Act.ID LEFT JOIN [User] Usu ON Act.LastModifiedById = Usu.Id where " + nombrefiltro + query2;
            return query;
        }
        public String getConsolidadoVentas(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query = "SELECT TOP (2000) " + cadenaSeleccion + " FROM PARTY__C Ter INNER JOIN ACCOUNT Cuen ON Cuen.Tercero__c = Ter.id INNER JOIN OPPORTUNITY Opor ON Opor.accountid = Cuen.id INNER JOIN QUOTE ON QUOTE.OpportunityId = Opor.ID INNER JOIN ConsolidatedSales__c Cons ON Cons.Contract_Code__c = Opor.Contract_code__c INNER JOIN Collection_Agent__c ON Cons.Collection_Agent__c = Collection_Agent__c.ID LEFT JOIN LOCATION__C Ciudad ON Ciudad.id = Cons.City_Operator_Phone__c where " + nombrefiltro + query2 + " ORDER BY Cons.name";
            return query;
        }
        public String getCasos(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query = "SELECT TOP (2000) " + cadenaSeleccion + " FROM " + nombreObjeto
                    + " LEFT JOIN ACCOUNT Cuenta ON Caso.AccountId = Cuenta.Id"
                    + " LEFT JOIN [Case] CasoRelacionado ON Caso.ParentId = CasoRelacionado.Id"
                    + " LEFT JOIN Tipificacion__c Tipificacion ON Caso.Detalle_tipo_de_solicitud__c = Tipificacion.Id"
                    + " LEFT JOIN RecordType TipoRegistro ON Caso.RecordTypeId = TipoRegistro.Id"
                    + " LEFT JOIN [GROUP] ColaPropietario ON ColaPropietario.ID = Caso.OwnerId LEFT JOIN [user] UsuarioPropietario ON UsuarioPropietario.id=Caso.OwnerId"
                    + " LEFT JOIN [GROUP] ColaCreadoPor ON ColaCreadoPor.ID = Caso.CreatedById LEFT JOIN [user] UsuarioCreadoPor ON UsuarioCreadoPor.id=Caso.CreatedById"
                    + " LEFT JOIN [user] UsuarioCerrado ON UsuarioCerrado.Id = Caso.ClosedBy__c"
                    + " WHERE " + nombrefiltro + query2;
            return query;

        }
        public String getProductos(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query = "SELECT " + cadenaSeleccion + " FROM " + nombreObjeto
                + " INNER JOIN ProductPartsByProduct__c ParProdXProd ON Prod.ProductPartsByProduct__c= ParProdXProd.Id"
                + " where " + nombrefiltro + " like '%" + query2 + "%' ";
            return query;
        }
        public String getMovProduccion(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query = "SELECT TOP (2000) " + cadenaSeleccion + " FROM Movimiento_produccion__c Mov LEFT JOIN [User] Usu ON Mov.Usuario_Responsable__c = Usu.Id " +
                " INNER JOIN ACCOUNT Cuenta ON Mov.Cuenta__c = Cuenta.Id " +
                " INNER JOIN OPPORTUNITY Opor ON Mov.Opportunity__c = Opor.Id " +
                " INNER JOIN ASSET Act On Mov.Activo__c = Act.Id " +
                " INNER JOIN RECORDTYPE Rec On Mov.RecordTypeId = Rec.Id " +
                " LEFT JOIN [User] UsuGes ON UsuGes.Id = Mov.Responsible_Organized_Content__c " +
                " LEFT JOIN Reference__c Ref ON Ref.Id = Mov.Reference__c " +
                
                " WHERE " + nombrefiltro + query2 + " AND Mov.createdDate > 2019-01-01  ORDER BY Mov.name";
            return query;
        }
        public String getRegFidelizacion(String cadenaSeleccion, String nombreObjeto, String nombrefiltro, String query2)
        {
            query = "SELECT " + cadenaSeleccion + " FROM Loyalty_Registry__c Reg LEFT JOIN [User] Usu ON Reg.OwnerId = Usu.Id " +
                " INNER JOIN ACCOUNT Cuenta ON Reg.Account__c = Cuenta.Id " +
                " LEFT JOIN RECORDTYPE Rec On Reg.RecordTypeId = Rec.Id " +

                " WHERE " + nombrefiltro + query2 + " ORDER BY Reg.name";
            return query;
        }


    }

}