using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Alta_Comprador : System.Web.UI.Page
    {
        Rematadora dominio = Rematadora.Instancia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["tipo"] == 0) //Valido que el usuario se haya logueado y no se saltee la autentificación
            {
                Response.Redirect("Login.aspx"); //si no se logueó, lo redirijo a Login
            }
        }

        protected void radParticular_CheckedChanged(object sender, EventArgs e)
        {
            panEmpresa.Visible = false;
            panParticular.Visible = true;
            lblErrorDocPart.Visible = false;
            lblErrorTelPart.Visible = false;
            lblOk.Visible = false;
            limpiarCampos(Page.Controls);
        }

        protected void radEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            panEmpresa.Visible = true;
            panParticular.Visible = false;
            lblErrorRutEmp.Visible = false;
            lblErrorTelEmp.Visible = false;
            lblOk.Visible = false;
            limpiarCampos(Page.Controls);
        }

        protected void btnCrearComprador_Click(object sender, EventArgs e)
        {
            if (radParticular.Checked == true) {
                if (dominio.stringEsSoloNumeros(txtTelPart.Text) && dominio.stringEsSoloNumeros(txtDocPart.Text)) {
                    lblErrorDocPart.Visible = false;
                    string unNomUsuPart = txtNomUsuPart.Text;
                    string unaClavePart = txtClavePart.Text;
                    string unaDirPart = txtDirPart.Text;
                    string unTelPart = txtTelPart.Text;
                    string unNomPart = txtNomPart.Text;
                    string unApePart = txtApePart.Text;
                    string unDocPart = txtDocPart.Text;
                    if (!dominio.nombreusuarioYaExiste(unNomUsuPart)) {
                        dominio.crearUsuarioCompradorParticular(unNomUsuPart, unaClavePart, unaDirPart, unTelPart, unNomPart, unApePart, unDocPart);
                        lblErrorNomUsuPart.Visible = false;
                        lblErrorTelPart.Visible = false;
                        lblOk.Visible = true;
                        lblOk.Text = "El comprador se creó exitosamente";
                        limpiarCampos(Page.Controls);
                    }
                    else
                    {
                        lblErrorNomUsuPart.Text = "El nombre de usuario ya ha sido utilizado";
                    }
                }
                else if (!dominio.stringEsSoloNumeros(txtTelPart.Text)) { 
                    lblErrorTelPart.Visible = true;
                    lblErrorTelPart.Text = "(*) Ingrese un Teléfono válido";
                    }
                else if (!dominio.stringEsSoloNumeros(txtDocPart.Text)){
                    lblErrorTelPart.Visible = false;
                    lblErrorDocPart.Visible = true;
                    lblErrorDocPart.Text = "(*) Ingrese un documento válido";
                }
            }
            else if (radEmpresa.Checked == true){
                if (dominio.stringEsSoloNumeros(txtTelEmp.Text) && dominio.stringEsSoloNumeros(txtRutEmp.Text))
                {
                    lblErrorRutEmp.Visible = false;
                    string unNomUsuEmp = txtNomUsuEmp.Text;
                    string unaClaveEmp = txtClaveEmp.Text;
                    string unaDirEmp = txtDirEmp.Text;
                    string unTelEmp = txtTelEmp.Text;
                    string unaPersConEmpr = txtContactEmp.Text;
                    string unaRazSocEmp = txtRazonSocEmp.Text;
                    string unRutEmp = txtRutEmp.Text;
                    if (!dominio.nombreusuarioYaExiste(unNomUsuEmp)){
                        dominio.crearUsuarioCompradorEmpresa(unNomUsuEmp, unaClaveEmp, unaDirEmp, unTelEmp, unaPersConEmpr, unaRazSocEmp, unRutEmp);
                        lblErrorNomUsuEmp.Visible = false;
                        lblErrorRutEmp.Visible = false;
                        lblErrorTelEmp.Visible = false;
                        lblOk.Visible = true;
                        lblOk.Text = "El comprador se creó exitosamente";
                        limpiarCampos(Page.Controls);
                }
                else
                {
                    lblErrorNomUsuEmp.Text = "El nombre de usuario ya ha sido utilizado";
                }
                }
                else if (!dominio.stringEsSoloNumeros(txtTelEmp.Text))
                {
                    lblErrorRutEmp.Visible = false;
                    lblErrorTelEmp.Visible = true;
                    lblErrorTelEmp.Text = "(*) Ingrese un Teléfono válido";
                }
                else if(!dominio.stringEsSoloNumeros(txtRutEmp.Text)){
                    lblErrorTelEmp.Visible = false;
                    lblErrorRutEmp.Visible = true;
                    lblErrorRutEmp.Text = "(*) Ingrese un RUT válido";
                }
                
            }
        }

        protected void limpiarCampos(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox) ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList) ((DropDownList)ctrl).ClearSelection();
                else if (ctrl is Calendar) ((Calendar)ctrl).SelectedDates.Clear();
                else if (ctrl is ListBox) ((ListBox)ctrl).ClearSelection();
                limpiarCampos(ctrl.Controls);
            }
        }
    }
}