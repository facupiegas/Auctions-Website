<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Alta_Lote.aspx.cs" Inherits="Interfaz.Alta_Lote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
ALTA LOTE<br />
<br />
Descripcion:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TxtDescripcion" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDescripcion" Display="Dynamic" ErrorMessage="Ingrese datos" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
<br />
<br />
Precio Base :&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtPrecioBase" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrecioBase" Display="Dynamic" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPrecioBase" Display="Dynamic" ForeColor="Red" MaximumValue=" 2147483647" MinimumValue="1" Type="Double">(*) Ingrese un precio Base Válido</asp:RangeValidator>
<br />
<br />
Unidades :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
<asp:TextBox ID="txtUnidades" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUnidades" Display="Dynamic" ForeColor="Red">(*) Campo Obligatorio</asp:RequiredFieldValidator>
<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtUnidades" Display="Dynamic" ErrorMessage="Ingrese números" ForeColor="Red" MaximumValue=" 2147483647" MinimumValue="1" Type="Integer">(*) Ingrese una Cantidad de Unidades Válida</asp:RangeValidator>
<br />
<br />
<br />
&nbsp;<asp:Label ID="Label4" runat="server" Text="Foto"></asp:Label>
&nbsp;&nbsp;
<asp:FileUpload ID="upFotoLote" runat="server" />
&nbsp;&nbsp;
<asp:ImageButton ID="btnUpload" runat="server" Height="28px" ImageUrl="~/imagenes/upload.jpg" OnClick="btnUpload_Click" Width="34px" />
<br />
<br />
<asp:Label ID="lblErrorFoto" runat="server" ForeColor="Red"></asp:Label>
<br />
<br />
<asp:Image ID="imgFoto" runat="server" Height="100px" Width="100px" />
<br />
<br />
<asp:Button ID="BtnAltaLote" runat="server" OnClick="BtnAltaLote_Click" Text="Dar Alta" />
<br />
<br />
<asp:Label ID="lblOkAltaLote" runat="server" ForeColor="Green" Visible="False"></asp:Label>
</asp:Content>
