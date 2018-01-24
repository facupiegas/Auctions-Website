using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Alta_Rematador : System.Web.UI.Page
    {
        Rematadora dominio = Rematadora.Instancia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["tipo"] == 0) //Valido que el usuario se haya logueado y no se saltee la autentificación
            {
                Response.Redirect("Login.aspx"); //si no se logueó, lo redirijo a Login
            }
        }

        protected void btnAltaRem_Click(object sender, EventArgs e){

            //convierto los datos obtenidos de las cajas de texto validados con los validadores
            string unNombreUsuario = Convert.ToString(txtAltaRemUser.Text);
            string unaContrasena = Convert.ToString(txtAltaRemPass.Text);
            string unNomRem = Convert.ToString(txtAltaNomRem.Text);
            string unApeRem = Convert.ToString(txtAltaApeRem.Text);
            string unTelRem = txtAltaTelRem.Text;
            if (dominio.stringEsSoloNumeros(unTelRem)){ 
                if(!dominio.nombreusuarioYaExiste(unNombreUsuario)){//si el nombre de usuario aun no ha sido utlilzado, creo el objeto
                    dominio.crearRematador(unNombreUsuario, unaContrasena, unNomRem, unApeRem, unTelRem);//llamo al constructor y creo el objeto
                    lblErrorAltaRem.Visible = false;
                    lblErrorTelRem.Visible = false;
                    lblOkAltaRem.Visible = true;
                    lblOkAltaRem.Text = "Rematador creado con éxito";
                    limpiarCampos(Page.Controls);
                }
                else//si ya fue utilizado, le pido que seleccione otro
                {
                    lblErrorAltaRem.Visible = true;
                    lblOkAltaRem.Visible = false;
                    lblErrorTelRem.Visible = false;
                    lblErrorAltaRem.Text = "El nombre de usuario ya ha sido utilizado";
                }
            }
            else
            {
                lblErrorTelRem.Text = "(*) Ingrese un Número de Teléfono Válido";
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