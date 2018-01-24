<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Cierre_De_Remate.aspx.cs" Inherits="Interfaz.Cierre_De_Remate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
CIERRE DE REMATE<br />
<br />
Seleccione un Remate<br />
<br />
<asp:GridView ID="grdRemates" runat="server" AutoGenerateSelectButton="True" style="text-align: center; margin-right: 0px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="50%">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="IdRemate" HeaderText="Id Remate" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
    </Columns>
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
<br />
<asp:Label ID="lblErrorCierreRemate" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    <asp:Label ID="lblOkCierreRemate" runat="server" ForeColor="Green" Visible="False"></asp:Label>
<br />
    <br />
<asp:Button ID="btnCerrarRemate" runat="server" OnClick="btnCerrarRemate_Click" Text="Cerrar Remate" Width="136px" />
    <br />
<br />
<asp:Label ID="lblComision" runat="server"></asp:Label>
<br />
<asp:Label ID="lblRematador" runat="server"></asp:Label>
    <br />
<br />
<asp:GridView ID="grdCompradores" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" style="text-align: center" Visible="False" Width="372px">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField HeaderText="Nombre Comprador" DataField="NomLista" />
        <asp:BoundField HeaderText="Seña" DataField="SenaAPagar" />
    </Columns>
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
    <br />
</asp:Content>
