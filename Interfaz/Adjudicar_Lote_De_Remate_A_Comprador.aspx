<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Adjudicar_Lote_De_Remate_A_Comprador.aspx.cs" Inherits="Interfaz.Adjudicar_Lore_De_Remate_A_Comprador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
ADJUDICACION DE LOTES A COMPRADORES<br />
<br />
Seleccione un Comprador<br />
    <br />
<asp:GridView ID="grdCompradores" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" style="text-align: center" AutoGenerateSelectButton="True">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField HeaderText="Nombre Comprador" DataField="NomLista" />
        <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
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
    <br />
    Usuario no Encontrado ?&nbsp;&nbsp;
    <asp:LinkButton ID="lnkAltaComprador" runat="server" PostBackUrl="~/Alta_Comprador.aspx">Crear Comprador</asp:LinkButton>
    <br />
    <br />
    <asp:Label ID="lblErrorComp" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    <br />
<br />
    <asp:Label ID="lblHeaderRemates" runat="server" Text="Seleccione un Remate"></asp:Label>
    <br />
    <br />
<asp:GridView ID="grdRemates" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdRemates_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" style="text-align: center" Width="622px">
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
    <asp:Label ID="lblErrorGrdRemates" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    <br />
<br />
    <asp:Label ID="lblHeaderLotes" runat="server" Visible="False"></asp:Label>
    <br />
    <br />
<asp:GridView ID="grdLotesDisponiblesDeRemate" runat="server" Visible="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdLotesDisponiblesDeRemate_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="191px" style="text-align: center" Width="478px">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="IdLote" HeaderText="Id Lote" />
        <asp:BoundField DataField="PrecioBaseLote" HeaderText="Precio Base" />
        <asp:BoundField DataField="DescripcionLote" HeaderText="Descripción" />
        <asp:ImageField DataImageUrlField="Foto" HeaderText="Imagen">
            <ControlStyle Height="50px" Width="50px" />
        </asp:ImageField>
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
    <asp:Panel ID="panelPrecioVta" runat="server" Visible="False">
        Ingrese el Precio de Venta del Lote
        <asp:TextBox ID="txtPrecioVta" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrecioVta" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPrecioVta" Display="Dynamic" ErrorMessage="RangeValidator" ForeColor="Red" MaximumValue="2000000" MinimumValue="1" Type="Double">(*) Seleccione un Precio Válido</asp:RangeValidator>
    </asp:Panel>
    <br />
    <br />
    <asp:Label ID="lblErrorAdj" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    <asp:Label ID="lblOkAdj" runat="server" ForeColor="Green" Visible="False"></asp:Label>
    <br />
<br />
<asp:Button ID="btnAsignar" runat="server" Text="Asignar" OnClick="btnAsignar_Click" />
<br />
</asp:Content>
