<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Rematadores_Activos_En_El_Año.aspx.cs" Inherits="Interfaz.Rematadores_Activos_En_El_Año" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <br />
    REMATADORES ACTIVOS EN EL AÑO</p>
<asp:GridView ID="grdRemActivos" runat="server" style="margin-right: 0px; text-align: center;" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="NombreApellido" HeaderText="Nombre Rematador" />
        <asp:BoundField DataField="ComisionRematador" HeaderText="Comision Anual" />
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
    <asp:Label ID="lblErrorRem" runat="server" ForeColor="Red" Text="Label"></asp:Label>
</asp:Content>
