<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous"/>
    <style type="text/css">
        #form1 {
            height: 973px;
            width: 1133px;
            margin-right: 27px;
        }
    </style>
</head>
<body style="background-color:#77acd2">


<form id="form1" runat="server" enableviewstate="True" contenteditable="false">
   <asp:Image ID="Image1" runat="server" src="./logo.png" style="margin-left:200px; margin-top:10px; z-index: 1; left: 618px; top: -3px; position: absolute; width: 219px; height: 98px;" BackColor="White" BorderColor="Blue" BorderStyle="Solid"/>
        <asp:Button ID="Button1" runat="server" class="btn btn-outline-secondary" OnClick="Consultar" Text="Consultar" style="z-index: 1; left: 510px; top: 68px; position: absolute; height: 31px; width: 131px;" BackColor="#3333FF" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" ForeColor="White" Font-Italic="True" />
        &nbsp;<asp:DropDownList ID="DDLObjeto"  OnSelectedIndexChanged="DDLObjeto_SelectedIndexChanged" AutoPostBack="true" runat="server" class="btn btn-secondary dropdown-toggle" style="z-index: 1; left: 217px; top: 25px; position: absolute"></asp:DropDownList>
        
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 22px; top: 31px; position: absolute; width: 180px;" Text="Seleccione el Objeto" Font-Bold="True" Font-Italic="True" Font-Size="Small" Font-Strikeout="False" ForeColor="White" Font-Names="Verdana"></asp:Label>
        <asp:DropDownList ID="DDLFiltro"  runat="server" class="btn btn-secondary dropdown-toggle" style="z-index: 1; left: 217px; top: 72px; position: absolute"></asp:DropDownList>
       
        
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 439px; top: 25px; position: absolute; width: 58px; height: 21px;" Text="Buscar" Font-Bold="True" Font-Italic="True" ForeColor="White"></asp:Label>
  
        <br />
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" style="z-index: 1; top: 24px; position: absolute; left: 506px; width: 287px;"></asp:TextBox>
        <br />
        
            <div style="width: 1231px; height: 176px; overflow:auto; z-index: 1; left: 20px; top: 135px; position: absolute;">
                <asp:GridView ID="GridView1" ShowHeaderWhenEmpty="true" runat="server" CaptionAlign="Bottom" ForeColor="#333333" style="z-index: 2; left: 2px; top: 0px; position: relative; height: 198px; width: 1213px; margin-top: 0px" CellPadding="2" GridLines="None" HorizontalAlign="Justify" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" EmptyDataText="No hay Datos" Font-Names="Verdana" Font-Size="Small">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" BorderColor="White" BorderStyle="Solid" BorderWidth="2px" ForeColor="White" HorizontalAlign="Left" Wrap="True" Font-Bold="True" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BorderStyle="Solid" Wrap="False" BackColor="#F7F6F3" ForeColor="#333333" />
            
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                    <Columns>
                    <asp:TemplateField HeaderText="Detalle">
                    <itemTemplate><asp:LinkButton ID="LnkDet" Text="Ver Listas" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="LnkDet_Click"/></itemTemplate></asp:TemplateField>
<asp:TemplateField HeaderText="Nro"><ItemTemplate>
                    <%# Container.DataItemIndex + 1%>                                                             
                    
</ItemTemplate>
</asp:TemplateField>
                    </Columns>
                   
                   <selectedrowstyle backcolor="RED"
         forecolor="DarkBlue"
         font-bold="true"/> 
        </asp:GridView>
            </div>
        
        <asp:Panel ID="Panel1" runat="server" style="z-index: 1; left: 24px; top: 314px; position: absolute; height: 144px; width: 1223px; text-align: left;" ScrollBars ="Auto">
            <asp:Label ID="Label4" runat="server" Text="Label" ForeColor="White" Font-Bold="True"></asp:Label>
            <asp:GridView ID="GridView2" runat="server" ShowHeaderWhenEmpty="True" CellPadding="4" Height="17px" Width="1208px" ForeColor="#333333" GridLines="None" EmptyDataText="No hay Datos" Font-Names="Verdana" Font-Size="Small">
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
 
            </asp:GridView>
        </asp:Panel>
        
        <asp:Panel ID="Panel2" runat="server" style="z-index: 1; left: -570px; top: 474px; position: absolute; height: 116px; width: 1222px; margin-left: 596px" ScrollBars ="Auto">
            <asp:Label ID="Label5" runat="server" Text="Label" ForeColor="White" Font-Bold="True"></asp:Label>
            <asp:GridView ID="GridView3" runat="server" ShowHeaderWhenEmpty="True" CellPadding="4" Height="16px" Width="1202px" ForeColor="#333333" GridLines="None" EmptyDataText="No hay Datos" Font-Names="Verdana" Font-Size="Small">
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
        
        <asp:Panel ID="Panel3" runat="server" style="z-index: 1; left: 28px; top: 599px; position: absolute; height: 149px; width: 1218px" ScrollBars ="Auto">
            <asp:Label ID="Label6" runat="server" Text="Label" ForeColor="White" Font-Bold="True"></asp:Label>
            <asp:GridView ID="GridView4" runat="server" ShowHeaderWhenEmpty="True" CellPadding="4" Width="1196px" Height="109px" ForeColor="#333333" GridLines="None" EmptyDataText="No hay Datos" Font-Names="verdana" Font-Size="Small">
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
        </asp:Panel>
        
        <asp:Panel ID="Panel4" runat="server" style="z-index: 1; left: -643px; top: 750px; position: absolute; height: 190px; width: 1216px; margin-left: 672px" ScrollBars ="Auto">
            <asp:Label ID="Label7" runat="server" ForeColor="White" Text="Label" Font-Bold="True"></asp:Label>
            <asp:GridView ID="GridView5" runat="server" ShowHeaderWhenEmpty="True" CellPadding="4" Width="1194px" ForeColor="#333333" GridLines="None" Height="126px" EmptyDataText="No hay Datos" Font-Names="Verdana" Font-Size="Small">
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
        </asp:Panel>
        
        <asp:Panel ID="Panel5" runat="server" style="z-index: 1; left: -649px; top: 949px; position: absolute; height: 182px; width: 1214px; margin-left: 679px">
            <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="White" Text="Label"></asp:Label>
            <asp:GridView ID="GridView6" runat="server" CellPadding="4" Font-Names="verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" Width="1193px" EmptyDataText="No hay Datos" ShowHeaderWhenEmpty="True">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
    </asp:Panel>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 20px; top: 79px; position: absolute; height: 16px; width: 184px;" Text="Criterio de Búsqueda" Font-Italic="True" ForeColor="White" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"></asp:Label>
        
        <asp:Button ID="Button5" runat="server" class="btn btn-secondary" OnClick="Exportar_Excel" Text="Exportar excel" style="z-index: 1; left: 646px; top: 68px; position: absolute; height: 31px; width: 151px;" BackColor="#3333FF" Font-Bold="True" Font-Italic="True" Font-Names="Verdana" Font-Size="Small" ForeColor="White" />

        
    </form>
</body>




</html>
