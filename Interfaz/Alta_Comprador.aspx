<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Alta_Comprador.aspx.cs" Inherits="Interfaz.Alta_Comprador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:RadioButton ID="radParticular" runat="server" AutoPostBack="True" Checked="True" GroupName="tipoUsuario" OnCheckedChanged="radParticular_CheckedChanged" Text="Particular" />
&nbsp;<asp:RadioButton ID="radEmpresa" runat="server" AutoPostBack="True" GroupName="tipoUsuario" OnCheckedChanged="radEmpresa_CheckedChanged" Text="Empresa" />
    <br />
    <asp:Panel ID="panParticular" runat="server">
        Nombre de Usuario
        <asp:TextBox ID="txtNomUsuPart" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="valPart1" runat="server" ControlToValidate="txtNomUsuPart" ErrorMessage="RequiredFieldValidator" ForeColor="Red" Display="Dynamic">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        <asp:Label ID="lblErrorNomUsuPart" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Clave&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtClavePart" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valPart2" runat="server" ControlToValidate="txtClavePart" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
&nbsp;<br /> Dirección&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtDirPart" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valPart6" runat="server" ControlToValidate="txtDirPart" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
&nbsp;<br /> Teléfono&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTelPart" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valPart7" runat="server" ControlToValidate="txtTelPart" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        <asp:Label ID="lblErrorTelPart" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Nombre&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNomPart" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valPart3" runat="server" ControlToValidate="txtNomPart" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        &nbsp;<br /> Apellido&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtApePart" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valPart4" runat="server" ControlToValidate="txtApePart" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        &nbsp;<br /> Documento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtDocPart" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valPart5" runat="server" ControlToValidate="txtDocPart" ErrorMessage="RequiredFieldValidator" ForeColor="Red" Display="Dynamic">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        &nbsp;<asp:Label ID="lblErrorDocPart" runat="server" ForeColor="Red"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="panEmpresa" runat="server" Visible="False">
        Nombre de Usuario&nbsp;&nbsp;
        <asp:TextBox ID="txtNomUsuEmp" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="valEmp1" runat="server" ControlToValidate="txtNomUsuEmp" ErrorMessage="RequiredFieldValidator" ForeColor="Red" Display="Dynamic">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        <asp:Label ID="lblErrorNomUsuEmp" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Clave&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtClaveEmp" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="valEmp2" runat="server" ControlToValidate="txtClaveEmp" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
&nbsp;<br /> Dirección&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtDirEmp" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valEmp6" runat="server" ControlToValidate="txtDirEmp" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        <br />
        Teléfono&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTelEmp" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valEmp7" runat="server" ControlToValidate="txtTelEmp" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
        &nbsp;<asp:Label ID="lblErrorTelEmp" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Persona de contacto&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtContactEmp" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="valEmp3" runat="server" ControlToValidate="txtContactEmp" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
&nbsp;<br /> Razon Social&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtRazonSocEmp" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="valEmp4" runat="server" ControlToValidate="txtRazonSocEmp" ErrorMessage="RequiredFieldValidator" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
&nbsp;<br /> RUT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtRutEmp" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="valEmp5" runat="server" ControlToValidate="txtRutEmp" ErrorMessage="RequiredFieldValidator" ForeColor="Red" Display="Dynamic">(*) Campo Obligatorio</asp:RequiredFieldValidator>
&nbsp;<asp:Label ID="lblErrorRutEmp" runat="server" ForeColor="Red"></asp:Label>
    </asp:Panel>
    <br />
    <asp:Button ID="btnCrearComprador" runat="server" Text="Crear Comprador" OnClick="btnCrearComprador_Click" />
    <br />
    <br />
    <asp:Label ID="lblOk" runat="server" ForeColor="Green" Visible="False"></asp:Label>
</asp:Content>
