using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Ver_Remates_Rematador_Por_Fecha : System.Web.UI.Page
    {
        Rematadora dominio = Rematadora.Instancia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["tipo"] == 0) //Valido que el usuario se haya logueado y no se saltee la autentificación
            {
                Response.Redirect("Login.aspx"); //si no se logueó, lo redirijo a Login
            }
            grdRematesFecha.SelectedIndex = -1;
        }

        protected void btnMostrarRemates_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = calDesde.SelectedDate;
            DateTime fechaHasta = calHasta.SelectedDate;
            if (calDesde.SelectedDate <= calHasta.SelectedDate)
            {
                lblErrorFecha.Visible = false;
                grdRematesFecha.Visible = true;
                string nomUsuario = (string)Session["usuario"];
                Rematador unRematador = dominio.buscarRematadorPorNombreUsuario(nomUsuario);
                List<Remate> listaRematesPorFecha = dominio.devolverRematesPorFecha(fechaDesde, fechaHasta);
                grdRematesFecha.DataSource = listaRematesPorFecha;
                grdRematesFecha.DataBind();
                if (listaRematesPorFecha.Count == 0)
                {
                    lblErrorFecha.Visible = true;
                    lblErrorFecha.Text = "No existen remates para el intervalo seleccionado";
                }
            }
            else
            {
                lblErrorFecha.Visible = true;
                lblErrorFecha.Text = "Seleccione un intervalo válido";
            }
        }
    }
}