<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Baja_Rematador.aspx.cs" Inherits="Interfaz.Baja_Rematador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
BAJA REMATADOR<br __designer:mapid="fc" />
<br __designer:mapid="fd" />
<asp:ListBox ID="lstBajaRem" runat="server"></asp:ListBox>
<br __designer:mapid="ff" />
<br __designer:mapid="100" />
<asp:Label ID="lblOkBajaRem" runat="server" ForeColor="#33CC33" Text="Label" Visible="False"></asp:Label>
<asp:Label ID="lblErrorBajaRem" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
<br __designer:mapid="103" />
<br __designer:mapid="104" />
<asp:Button ID="btnBajaRem" runat="server" Text="Eliminar" OnClick="btnBajaRem_Click" />
</asp:Content>
