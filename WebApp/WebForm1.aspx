<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous"/>
    <style type="text/css">
        #form1 {
            height: 383px;
            width: 876px;
            margin-right: 27px;
        }
    </style>
</head>
<body style="background-color:gainsboro">

    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 32px; top: 135px; position: absolute" Text="Buscar"></asp:Label>
        <asp:TextBox ID="TextBox1" placeholder="Ingresa el dato..."  class="form-control-sm" runat="server" OnTextChanged="TextBox1_TextChanged" style="z-index: 1; top: 136px; position: absolute; left: 204px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" class="btn btn-outline-secondary" OnClick="Button1_Click" Text="Consultar" style="z-index: 1; left: 443px; top: 84px; position: absolute" />
        <asp:DropDownList ID="DropDownList1" runat="server" class="btn btn-secondary dropdown-toggle" style="z-index: 1; left: 204px; top: 48px; position: absolute" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
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
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3333CC" BorderStyle="Solid" BorderWidth="5px" CaptionAlign="Bottom" ForeColor="Black" style="z-index: 1; left: 37px; top: 185px; position: relative; height: 141px; width: 279px; margin-top: 19px" Width="279px">
        </asp:GridView>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 35px; top: 52px; position: absolute" Text="Seleccione el Objeto"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" class="btn btn-secondary dropdown-toggle" style="z-index: 1; left: 204px; top: 87px; position: absolute">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 32px; top: 89px; position: absolute" Text="Criterio de Búsqueda"></asp:Label>
        <br />
    </form>
</body>




</html>
