using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Ver_Remates_Rematador : System.Web.UI.Page
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
                actualizarGridView();
            }
        }

        protected void grdRematesCerrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomUsuario = (string)Session["usuario"];
            Rematador unRematador = dominio.buscarRematadorPorNombreUsuario(nomUsuario);
            int idRemate = Convert.ToInt32((grdRematesCerrados.SelectedRow.Cells[1].Text));
            Remate unRemate = dominio.buscarRemate(idRemate);
            double comisionRematador =unRemate.calcularComisionAPagarRematador();
            lblComision.Visible = true;
            lblComision.Text = "Comisión Recibida - $" + comisionRematador;
        }

        protected void actualizarGridView()
        {
            grdRematesCerrados.SelectedIndex = -1;
            lblComision.Visible = false;
            string nomUsuario = (string)Session["usuario"];
            Rematador unRematador = dominio.buscarRematadorPorNombreUsuario(nomUsuario);
            List<Remate> listaRematesCerradosRematador = dominio.devolverListaRematesCerradosPorRematador(unRematador.IdRematador);
            if (listaRematesCerradosRematador.Count > 0)
            {
                grdRematesCerrados.DataSource = listaRematesCerradosRematador;
                grdRematesCerrados.DataBind();
            }
            else
            {
                lblErrorResumRemate.Visible = true;
                lblErrorResumRemate.Text = "(!) Usted no ha participado de ningun remate en el año (!)";
            }
        }
    }
}