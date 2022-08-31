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

<form id="form1" runat="server" enableviewstate="True" contenteditable="false">
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 32px; top: 135px; position: absolute" Text="Buscar"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" style="z-index: 1; top: 136px; position: absolute; left: 204px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" class="btn btn-outline-secondary" OnClick="Consultar" Text="Consultar" style="z-index: 1; left: 443px; top: 84px; position: absolute" BackColor="#3333FF" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" ForeColor="White" />
        &nbsp;<asp:Button ID="Button5" runat="server" class="btn btn-success" OnClick="Exportar_Excel" Text="Exportar excel" style="z-index: 1; left: 443px; top: 31px; position: absolute; height: 31px;" />
        <asp:DropDownList ID="DDLObjeto"  OnSelectedIndexChanged="DDLObjeto_SelectedIndexChanged" AutoPostBack="true" runat="server" class="btn btn-secondary dropdown-toggle" style="z-index: 1; left: 204px; top: 48px; position: absolute"></asp:DropDownList>
        
        <div>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3333CC" BorderStyle="Double" BorderWidth="5px" CaptionAlign="Bottom" ForeColor="Black" style="z-index: 1; left: 33px; top: 186px; position: relative; height: 79px; width: 279px; margin-top: 19px" Width="279px" CellPadding="2" CellSpacing="2" GridLines="None" Height="300px" HorizontalAlign="Justify" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <HeaderStyle BackColor="#3333FF" BorderColor="White" BorderStyle="Solid" BorderWidth="2px" ForeColor="White" HorizontalAlign="Left" Wrap="True" />
            <RowStyle BorderStyle="Solid" Wrap="False" />
            <SelectedRowStyle BorderStyle="Solid" />
        </asp:GridView>
        </div>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 35px; top: 52px; position: absolute" Text="Seleccione el Objeto"></asp:Label>
        <asp:DropDownList ID="DDLFiltro"  runat="server" class="btn btn-secondary dropdown-toggle" style="z-index: 1; left: 204px; top: 87px; position: absolute"></asp:DropDownList>
        
        <br />
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 32px; top: 89px; position: absolute" Text="Criterio de Búsqueda"></asp:Label>
        <br />
    </form>
</body>




</html>
