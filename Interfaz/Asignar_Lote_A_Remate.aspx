<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Asignar_Lote_A_Remate.aspx.cs" Inherits="Interfaz.Asiganr_Lote_A_Remate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
ASIGNACIÓN DE LOTE A REMATE<br />
<br />
Seleccione un remate:<br />
&nbsp;&nbsp;&nbsp;
<br />
<asp:ListBox ID="lstRematesDisponibles" runat="server" OnSelectedIndexChanged="Page_Load"></asp:ListBox>
<br />
<asp:RequiredFieldValidator ID="valSelecRem" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="lstRematesDisponibles">(*) Seleccione un remate</asp:RequiredFieldValidator>
<br />
<br />
Seleccione lote:<br />
<br />
<asp:ListBox ID="lstLotesDisponibles" runat="server"></asp:ListBox>
<br />
<asp:RequiredFieldValidator ID="valSelecLote" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="lstLotesDisponibles">(*) Seleccione un lote</asp:RequiredFieldValidator>
<br />
<br />
<asp:Label ID="lblAsignadoOK" runat="server" ForeColor="Green" Visible="False"></asp:Label>
<br />
<asp:Button ID="btnAsignarLoteARemate" runat="server" OnClick="btnAsignarLoteARemate_Click" Text="Asignar" />
</asp:Content>
