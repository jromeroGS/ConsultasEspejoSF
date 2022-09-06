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
    <asp:Image ID="Image1" runat="server" src="./logo.png" style="margin-left:200px; margin-top:10px; z-index: 1; left: 550px; top: 5px; position: absolute; width: 120px; height: 80px;"/>
        <asp:Button ID="Button1" runat="server" class="btn btn-outline-secondary" OnClick="Consultar" Text="Consultar" style="z-index: 1; left: 400px; top: 59px; position: absolute; height: 31px;" BackColor="#3333FF" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" ForeColor="White" />
        &nbsp;<asp:DropDownList ID="DDLObjeto"  OnSelectedIndexChanged="DDLObjeto_SelectedIndexChanged" AutoPostBack="true" runat="server" class="btn btn-secondary dropdown-toggle" style="z-index: 1; left: 163px; top: 11px; position: absolute"></asp:DropDownList>
        
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 13px; top: 17px; position: absolute" Text="Seleccione el Objeto"></asp:Label>
        <asp:DropDownList ID="DDLFiltro"  runat="server" class="btn btn-secondary dropdown-toggle" style="z-index: 1; left: 163px; top: 53px; position: absolute"></asp:DropDownList>
        

            


        
        <br />
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 14px; top: 56px; position: absolute" Text="Criterio de Búsqueda"></asp:Label>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 403px; top: 23px; position: absolute" Text="Buscar"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" style="z-index: 1; top: 19px; position: absolute; left: 461px; width: 244px;"></asp:TextBox>
        <br />
        
            <div style="width: 1106px; height: 194px; overflow:auto; z-index: 1; left: 20px; top: 110px; position: absolute;">
                <asp:GridView ID="GridView1" ShowHeaderWhenEmpty="true" runat="server" CaptionAlign="Bottom" ForeColor="#333333" style="z-index: 2; left: 2px; top: 0px; position: relative; height: 198px; width: 773px; margin-top: 0px" CellPadding="4" GridLines="None" HorizontalAlign="Justify" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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

                    <Columns>
                    <asp:TemplateField HeaderText="Detalle">
                    <itemTemplate><asp:LinkButton ID="LnkDet" Text="VerDetalle" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="LnkDet_Click"/></itemTemplate></asp:TemplateField>
                    </Columns>
                    <Columns>
                    <asp:TemplateField HeaderText="Nro">
                    <ItemTemplate>
                    <%# Container.DataItemIndex + 1%>                                                             
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                   
        </asp:GridView>
            </div>
        
        <asp:Panel ID="Panel1" runat="server" style="z-index: 1; left: 24px; top: 314px; position: absolute; height: 144px; width: 527px; text-align: left;" ScrollBars ="Auto">
            <asp:Label ID="Label4" runat="server" Text="Label" ForeColor="White"></asp:Label>
            <asp:GridView ID="GridView2" runat="server" ShowHeaderWhenEmpty="True" CellPadding="4" Height="16px" Width="511px" ForeColor="#333333" GridLines="None">
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
        
        <asp:Panel ID="Panel2" runat="server" style="z-index: 1; left: -570px; top: 474px; position: absolute; height: 116px; width: 524px; margin-left: 596px" ScrollBars ="Auto">
            <asp:Label ID="Label5" runat="server" Text="Label" ForeColor="White"></asp:Label>
            <asp:GridView ID="GridView3" runat="server" ShowHeaderWhenEmpty="True" CellPadding="4" Height="16px" Width="509px" ForeColor="#333333" GridLines="None">
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
        
        <asp:Panel ID="Panel3" runat="server" style="z-index: 1; left: 28px; top: 599px; position: absolute; height: 149px; width: 521px" ScrollBars ="Auto">
            <asp:Label ID="Label6" runat="server" Text="Label" ForeColor="White"></asp:Label>
            <asp:GridView ID="GridView4" runat="server" ShowHeaderWhenEmpty="True" CellPadding="4" Width="504px" Height="109px" ForeColor="#333333" GridLines="None">
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
        
        <asp:Panel ID="Panel4" runat="server" style="z-index: 1; left: -643px; top: 750px; position: absolute; height: 190px; width: 515px; margin-left: 672px">
            <asp:Label ID="Label7" runat="server" ForeColor="White" Text="Label"></asp:Label>
            <asp:GridView ID="GridView5" runat="server" ShowHeaderWhenEmpty="True" CellPadding="4" Width="501px" ForeColor="#333333" GridLines="None" Height="126px">
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
        
        <asp:Button ID="Button5" runat="server" class="btn btn-secondary" OnClick="Exportar_Excel" Text="Exportar excel" style="z-index: 1; left: 548px; top: 57px; position: absolute; height: 31px;" />
        
    </form>
</body>




</html>
