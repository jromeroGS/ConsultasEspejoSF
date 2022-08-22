<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous"/>
    <style type="text/css">
        #form1 {
            height: 317px;
            width: 582px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 24px; top: 84px; position: absolute" Text="Criterio de Búsqueda"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" style="z-index: 1; top: 85px; position: absolute; left: 171px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" class="btn btn-outline-secondary" OnClick="Button1_Click" Text="Consultar" style="z-index: 1; left: 378px; top: 83px; position: absolute" />
        <asp:DropDownList ID="DropDownList1" runat="server" class="btn btn-secondary dropdown-toggle" style="z-index: 1; left: 175px; top: 48px; position: absolute">
            <asp:ListItem>Tercero</asp:ListItem>
            <asp:ListItem>Cuenta</asp:ListItem>
            <asp:ListItem>Oportunidad</asp:ListItem>
            <asp:ListItem>Productos X Cotización</asp:ListItem>
            <asp:ListItem>Activos</asp:ListItem>
            <asp:ListItem>Datos de Facturación</asp:ListItem>
            <asp:ListItem>Consolidado de Ventas</asp:ListItem>
            <asp:ListItem>Casos</asp:ListItem>
            <asp:ListItem>Productos</asp:ListItem>
            <asp:ListItem>Referencias</asp:ListItem>
        </asp:DropDownList>
        <asp:GridView ID="GridView1" runat="server" Height="55px" BackColor="White" BorderColor="#3333CC" BorderStyle="Solid" BorderWidth="5px" CaptionAlign="Bottom" ForeColor="Black" style="z-index: 1; left: 11px; top: 122px; position: relative; height: 141px; width: 279px; margin-top: 19px" Width="279px">
        </asp:GridView>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 26px; top: 53px; position: absolute" Text="Seleccione el Objeto"></asp:Label>
    </form>
</body>




</html>
