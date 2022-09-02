<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous"/>
    <style type="text/css">
        #form1 {
            height: 435px;
            width: 910px;
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
        
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 35px; top: 52px; position: absolute" Text="Seleccione el Objeto"></asp:Label>
        <asp:DropDownList ID="DDLFiltro"  runat="server" class="btn btn-secondary dropdown-toggle" style="z-index: 1; left: 204px; top: 87px; position: absolute"></asp:DropDownList>
        

            


        
        <br />
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 32px; top: 89px; position: absolute" Text="Criterio de Búsqueda"></asp:Label>
        <br />
        
            <div style="width: 602px; height: 219px; overflow:auto; z-index: 1; left: 29px; top: 191px; position: absolute;">
                <asp:GridView ID="GridView1" runat="server" CaptionAlign="Bottom" ForeColor="#333333" style="z-index: 2; left: -3px; top: 0px; position: relative; height: 206px; width: 365px; margin-top: 0px" CellPadding="4" GridLines="None" HorizontalAlign="Justify" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" BorderColor="White" BorderStyle="Solid" BorderWidth="2px" ForeColor="White" HorizontalAlign="Left" Wrap="True" Font-Bold="True" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BorderStyle="Solid" Wrap="False" BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BorderStyle="Solid" BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

        </asp:GridView>
            </div>
        
        <asp:Panel ID="Panel1" runat="server" style="z-index: 1; left: 643px; top: 193px; position: absolute; height: 213px; width: 258px" ScrollBars ="Auto">
            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </asp:Panel>
        
    </form>
</body>




</html>
