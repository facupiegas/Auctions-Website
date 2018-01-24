<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Alta_Rematador.aspx.cs" Inherits="Interfaz.Alta_Rematador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br __designer:mapid="d6" />ALTA REMATADOR<br __designer:mapid="d7" />
    <br __designer:mapid="d8" />Nombre Usuario
<asp:TextBox ID="txtAltaRemUser" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="valNomUsuarioAltaRem" runat="server" ControlToValidate="txtAltaRemUser" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
<br />
Clave&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtAltaRemPass" runat="server" style="text-align: left"></asp:TextBox>
<asp:RequiredFieldValidator ID="valClaveAltaRem" runat="server" ControlToValidate="txtAltaRemPass" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
<br />
Nombre &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAltaNomRem" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="valNomAltaRem" runat="server" ControlToValidate="txtAltaNomRem" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
    <br __designer:mapid="da" />Apellido&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="txtAltaApeRem" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="valApellidoAltaRem" runat="server" ControlToValidate="txtAltaApeRem" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
    <br __designer:mapid="dc" />Teléfono&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAltaTelRem" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="valTelAltaRem" runat="server" ControlToValidate="txtAltaTelRem" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
    <asp:Label ID="lblErrorTelRem" runat="server" ForeColor="Red"></asp:Label>
    <br __designer:mapid="de" />
    <br __designer:mapid="df" />
    <asp:Label ID="lblOkAltaRem" runat="server" ForeColor="#33CC33" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="lblErrorAltaRem" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    <br __designer:mapid="e2" />
    <br __designer:mapid="e3" />
    <asp:Button ID="btnAltaRem" runat="server" Text="Guardar" OnClick="btnAltaRem_Click" />
</asp:Content>
