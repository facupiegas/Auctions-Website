<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Alta_Remate.aspx.cs" Inherits="Interfaz.Alta_Remate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
ALTA REMATE<br />
<br />
Descripción:&nbsp;&nbsp;
<asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescripcion" Display="Dynamic" ForeColor="#FF5050">(*) Campo Obligatorio</asp:RequiredFieldValidator>
<br />
<br />
Porcentaje base rematador:&nbsp;
<asp:TextBox ID="TxtPorcentajeBaseRematador" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPorcentajeBaseRematador" Display="Dynamic" ForeColor="#FF5050">(*) Ingrese datos</asp:RequiredFieldValidator>
<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TxtPorcentajeBaseRematador" Display="Dynamic" ForeColor="#FF5050" MaximumValue="10" MinimumValue="1" Type="Double">(*) Ingrese un porcentaje entre 1 y 10</asp:RangeValidator>
<br />
<br />
Asignar fecha :<br />
<asp:Calendar ID="CalFechaRemate" runat="server"></asp:Calendar>
<asp:Label ID="lblMensajeCal" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    <br />
<br />
Lugar:<br />
<asp:ListBox ID="lstLugar" runat="server" OnSelectedIndexChanged="Page_Load"></asp:ListBox>
<br />
<asp:RequiredFieldValidator ID="valLugar" runat="server" ControlToValidate="lstLugar" Display="Dynamic" ForeColor="Red">(*) Seleccione un Lugar</asp:RequiredFieldValidator>
    <br />
<br />
Rematador:<br />
<asp:ListBox ID="lstRematador" runat="server" OnSelectedIndexChanged="Page_Load"></asp:ListBox>
<br />
<asp:RequiredFieldValidator ID="valRematador" runat="server" ControlToValidate="lstRematador" Display="Dynamic" ForeColor="Red">(*) Seleccione un rematador</asp:RequiredFieldValidator>
<br />
<br />
<asp:RadioButton ID="rbGanado" runat="server" AutoPostBack="True" Checked="True" GroupName="tipoRemate" OnCheckedChanged="rbGanado_CheckedChanged" Text="Ganado" />
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:RadioButton ID="rbMercaderia" runat="server" AutoPostBack="True" GroupName="tipoRemate" OnCheckedChanged="rbMercaderia_CheckedChanged" Text="Mercaderia" />
    <br />
    <br />
    <asp:Panel ID="panGanado" runat="server" Height="24px" Width="272px">
        <asp:Label ID="lblComAdicGan" runat="server" Text="Porcentaje adicional de comisión = 3 %"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="panRemMerc" runat="server" Height="30px" style="margin-top: 0px" Visible="False" Width="840px">
        <asp:Label ID="LblPorcentajeAdicionalPorLoteAdjudicado" runat="server" Text="Porcentaje adicional de comisión por lote adjudicado"></asp:Label>
        &nbsp;<asp:TextBox ID="txtPorcentajeAdicComLoteAdjudicado" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtPorcentajeAdicComLoteAdjudicado" Display="Dynamic" ForeColor="#FF5050" MaximumValue="3" MinimumValue="1" Type="Double" ValidateRequestMode="Enabled">(*) Ingrese un porcentaje entre 1 y 3</asp:RangeValidator>
        <asp:RequiredFieldValidator ID="valPorAdicMerc" runat="server" ControlToValidate="txtPorcentajeAdicComLoteAdjudicado" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        &nbsp;</asp:Panel>
<br />
<asp:Button ID="btnCrearRemate" runat="server" OnClick="btnCrearRemate_Click" style="margin-left: 0px" Text="Crear Remate" />
<br />
<br />
<asp:Label ID="lblAltaRemateOk" runat="server" BackColor="White" ForeColor="#009933" Visible="False"></asp:Label>
    <asp:Label ID="lblAltaRemateError" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
</asp:Content>
