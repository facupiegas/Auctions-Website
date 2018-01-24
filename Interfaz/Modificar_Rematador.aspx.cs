using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    
    public partial class Modificar_Rematador : System.Web.UI.Page
    {
        Rematadora dominio = Rematadora.Instancia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["tipo"] == 0) //Valido que el usuario se haya logueado y no se saltee la autentificación
            {
                Response.Redirect("Login.aspx"); //si no se logueó, lo redirijo a Login
            }
            if (!IsPostBack) { 
                comboRematadores.DataSource = dominio.devolverListaRematadores();
                comboRematadores.DataTextField = "NombreApellido";
                comboRematadores.DataValueField = "IdRematador";
                comboRematadores.DataBind();
                comboRematadores.Items.Insert(0, new ListItem("--Seleccione un Rematador--", string.Empty));
                comboRematadores.SelectedIndex = 0;
            }
        }

        protected void comboRematadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorModifTelRem.Visible = false;
            if(comboRematadores.SelectedValue != "") {
                panDatosRem.Visible = true;
                int unIdRem = Convert.ToInt32(comboRematadores.SelectedValue);
                Rematador unRematador = dominio.buscarRematador(unIdRem);
                txtModifNomRem.Text = unRematador.NombreRematador;
                txtModifApeRem.Text = unRematador.ApellidoRematador;
                txtModifTelRem.Text = Convert.ToString(unRematador.TelefonoRematador);
                lblErrorModifRem.Visible = false;
            }
            else{
                panDatosRem.Visible = false;
                lblErrorModifRem.Visible = true;
                lblErrorModifRem.Text = "Seleccione un rematador de la lista";
            }

        }

        protected void btnModifRem_Click(object sender, EventArgs e)
        {
            int unIdRem = Convert.ToInt32(comboRematadores.SelectedValue);
            string unNuevoNombreRematador = txtModifNomRem.Text;
            string unNuevoApellidoRematador = txtModifApeRem.Text;
            string unNuevoTelRematador = txtModifTelRem.Text;
            if (dominio.stringEsSoloNumeros(unNuevoTelRematador)) { 
                dominio.modificarDatosRematador(unIdRem, unNuevoNombreRematador, unNuevoApellidoRematador, unNuevoTelRematador);
                lblOkModfiRem.Visible = true;
                lblErrorModifTelRem.Visible = false;
                lblOkModfiRem.Text = "Los datos del Rematador fueron modificados con éxito";
                comboRematadores.DataSource = dominio.devolverListaRematadores();
                comboRematadores.DataBind();
                comboRematadores.Items.Insert(0, new ListItem("--Seleccione un Rematador--", string.Empty));
                comboRematadores.SelectedIndex = 0;
                limpiarCampos(Page.Controls);
            }
            else
            {
                lblErrorModifTelRem.Visible = true;
                lblErrorModifTelRem.Text = "(*) Ingrese un Teléfono Válido";
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