<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous" type="text/css" />
    <link href="https://cdn.datatables.net/1.12.1/css/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />   
    <link href="../Estilos/Estilos.css" rel="stylesheet" type="text/css" />
    

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>

    <script type="text/javascript">
        $(document).ready( function () {
            $('#GridView1').DataTable();
            $('#GridView2').DataTable();
            $('#GVSinCloudDocuments').DataTable();
            $('#GridView3').DataTable();
            $('#GridView4').DataTable();
            $('#GridView5').DataTable();
            $('#GridView6').DataTable();
            $('#GridView7').DataTable();
        } );
    </script>

</head>
<body>

    <form id="form1" runat="server" enableviewstate="True" contenteditable="false">

    <h1 class="Titulo">Consultas Salesforce </h1>

        <asp:Button ID="Button1" runat="server" class="btn btn-outline-secondary" OnClick="Consultar" Text="Consultar" />
        &nbsp;<asp:DropDownList ID="DDLObjeto" OnSelectedIndexChanged="DDLObjeto_SelectedIndexChanged" AutoPostBack="true" runat="server" class="btn btn-secondary dropdown-toggle"></asp:DropDownList>

        <asp:Label ID="Label2" runat="server" Text="Seleccione el Objeto"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Buscar"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Criterio de Búsqueda"></asp:Label>
        <asp:Button ID="Button5" runat="server" class="btn btn-secondary" OnClick="Exportar_Excel" Text="Exportar excel"/>

        <asp:DropDownList ID="DDLFiltro" runat="server" class="btn btn-secondary dropdown-toggle"></asp:DropDownList>


        <br />
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" class="btn btn-secondary dropdown-toggle"></asp:TextBox>
        <br />
        <asp:Panel ID="Panel7" runat="server">
            <asp:Image ID="Image1" runat="server" src="./logo.png" />
        </asp:Panel>
        <div id="ImagenSales">
            <asp:Image ID="Image2" runat="server" src="./salesforce.png"  />
        </div>

        <div id="contenedor">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No hay Datos" CssClass="table table-light table-hover" ShowHeaderWhenEmpty="true">

                <RowStyle CssClass="rowStyle"/>

                <Columns>
                    <asp:TemplateField HeaderText="Detalle">
                        <ItemTemplate>
                            <asp:LinkButton ID="LnkDet" Text="Ver Listas" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="LnkDet_Click" /></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle CssClass="itemStyle"/>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>

        <div id="contenedorCuotas">
            <asp:Label ID="Label4" runat="server"></asp:Label>
             <asp:GridView ID="GridView2" runat="server" EmptyDataText="No hay Datos" CssClass="table table-light table-hover" ShowHeaderWhenEmpty="true">

                <RowStyle CssClass="rowStyle" />

                <Columns>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField
                        DataTextField="Descargar"
                        DataNavigateUrlFields="Descargar"
                        Target="_blank"
                        HeaderText="UrlDocument" />
                </Columns>

            </asp:GridView>
            <asp:GridView ID="GVSinCloudDocuments" runat="server" EmptyDataText="No hay Datos" CssClass="table table-light table-hover" ShowHeaderWhenEmpty="true">

                <RowStyle CssClass="rowStyle" />

                <Columns>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div id="contenedorOportunidades">
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <asp:GridView ID="GridView3" runat="server" EmptyDataText="No hay Datos" CssClass="table table-light table-hover" ShowHeaderWhenEmpty="true">

                <RowStyle CssClass="rowStyle"/>

                <Columns>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div id="contenedorActivos">            
            <asp:Label ID="Label6" runat="server"></asp:Label>
            <asp:GridView ID="GridView4" runat="server" EmptyDataText="No hay Datos" CssClass="table table-light table-hover" ShowHeaderWhenEmpty="true">

                <RowStyle CssClass="rowStyle"/>

                <Columns>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
        </div>

        <div id="contenedorConsolidados">
            <asp:Label ID="Label7" runat="server"></asp:Label>
            <asp:GridView ID="GridView5" runat="server" EmptyDataText="No hay Datos" CssClass="table table-light table-hover" ShowHeaderWhenEmpty="true">
                <RowStyle CssClass="rowStyle"/>
                <Columns>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
        </div>

        <div id="contenedorRegfid">
            
            <asp:Label ID="Label8" runat="server"></asp:Label>
            <asp:GridView ID="GridView6" runat="server" EmptyDataText="No hay Datos" CssClass="table table-light table-hover" ShowHeaderWhenEmpty="true">
                <RowStyle CssClass="rowStyle"/>
                <Columns>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div id="contenedorContactos">
            <asp:Label ID="Label9" runat="server" ></asp:Label>
            <asp:GridView ID="GridView7" runat="server" EmptyDataText="No hay Datos" CssClass="table table-light table-hover" ShowHeaderWhenEmpty="true">
                <RowStyle CssClass="rowStyle"/>
                <Columns>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
        </div>        
    </form>
</body>
</html>
