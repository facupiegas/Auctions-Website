using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Asiganr_Lote_A_Remate : System.Web.UI.Page
    {
        Rematadora dominio = Rematadora.Instancia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["tipo"] == 0) //Valido que el usuario se haya logueado y no se saltee la autentificación
            {
                Response.Redirect("Login.aspx"); //si no se logueó, lo redirijo a Login
            }
            if (!IsPostBack)
            {
                lstRematesDisponibles.DataSource = dominio.devolverRematesDisponibles();
                lstRematesDisponibles.DataTextField = "Descripcion";
                lstRematesDisponibles.DataValueField = "IdRemate";
                lstRematesDisponibles.DataBind();

                lstLotesDisponibles.DataSource = dominio.devolverListaLotesDisponibles();
                lstLotesDisponibles.DataTextField = "DescripcionListaLote";
                lstLotesDisponibles.DataValueField = "IdLote";
                lstLotesDisponibles.DataBind();
            }

        }

        protected void btnAsignarLoteARemate_Click(object sender, EventArgs e)
        {

            int idRemate = Convert.ToInt32(lstRematesDisponibles.SelectedValue);
            string idLote = lstLotesDisponibles.SelectedValue;
            Remate unRemate = dominio.buscarRemate(idRemate);
            Lote unLote = dominio.buscarLote(idLote);
            unRemate.agregarLoteALista(unLote); //hago el add a la lista de lotes del remate
            lblAsignadoOK.Text = "El lote fue asignado con éxito";//doy aviso al usuario
            lblAsignadoOK.Visible = true;
            lstLotesDisponibles.DataSource = dominio.devolverListaLotesDisponibles();
            lstLotesDisponibles.DataBind();//vuelvo a cargar las list boxes
            limpiarCampos(Page.Controls);
        }

        protected void limpiarCampos(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls){
                if (ctrl is TextBox) ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList) ((DropDownList)ctrl).ClearSelection();
                else if (ctrl is Calendar) ((Calendar)ctrl).SelectedDates.Clear();
                else if (ctrl is ListBox) ((ListBox)ctrl).ClearSelection();
                limpiarCampos(ctrl.Controls);
            }
        }
    }
}