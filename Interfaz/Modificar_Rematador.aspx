<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Modificar_Rematador.aspx.cs" Inherits="Interfaz.Modificar_Rematador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    MODIFICAR DATOS REMATADOR<br __designer:mapid="e7" />
    <br __designer:mapid="e8" />Rematador
<asp:DropDownList ID="comboRematadores" runat="server" OnSelectedIndexChanged="comboRematadores_SelectedIndexChanged" AutoPostBack="True">
</asp:DropDownList>
    <asp:RequiredFieldValidator ID="valDDB" runat="server" ControlToValidate="comboRematadores" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Seleccione un Rematador</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblErrorModifRem" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    <br __designer:mapid="ed" />
    <br />
    <asp:Panel ID="panDatosRem" runat="server" Visible="False">
        Nombre:
        <asp:TextBox ID="txtModifNomRem" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vaVacioNomModif" runat="server" ControlToValidate="txtModifNomRem" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        <br />
        Apellido:
        <asp:TextBox ID="txtModifApeRem" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valVacioApeModf" runat="server" ControlToValidate="txtModifApeRem" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        <br />
        Teléfono:
        <asp:TextBox ID="txtModifTelRem" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valVacioTelModif" runat="server" ControlToValidate="txtModifTelRem" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        <asp:Label ID="lblErrorModifTelRem" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </asp:Panel>
    <br __designer:mapid="f6" />
    <asp:Label ID="lblOkModfiRem" runat="server" ForeColor="#33CC33" Text="Label" Visible="False"></asp:Label>
    <br __designer:mapid="f8" />
    <br __designer:mapid="f9" />
    <asp:Button ID="btnModifRem" runat="server" Text="Guardar" OnClick="btnModifRem_Click" />
</asp:Content>
