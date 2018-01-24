using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Listado_Remates : System.Web.UI.Page
    {
        Rematadora dominio = Rematadora.Instancia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["tipo"] == 0) //Valido que el usuario se haya logueado y no se saltee la autentificación
            {
                Response.Redirect("Login.aspx"); //si no se logueó, lo redirijo a Login
            }
            //Solo cargamos la lista si es la primera vez. 
            //Si quisieramos poder "refrescar" la lista se deberia usar el mismo codigo que se muestra a continuación en un boton de la página
            if (!IsPostBack)
            {
                actualizarGridViewRemates();
            }
        }

        protected void grdRemates_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idRemateGrid = Convert.ToInt32((grdRemates.SelectedRow.Cells[1].Text));
            grdLotesRemate.Visible = true;
            Remate unRemate = dominio.buscarRemate(idRemateGrid);
            LotesDisponiblesDeRemate(unRemate);
        }

        protected void actualizarGridViewRemates()
        {
            grdRemates.SelectedIndex = -1;
            List<Remate> listaRemates = dominio.devolverListaRemates();
            if (listaRemates.Count > 0)
            {
                grdRemates.DataSource = listaRemates;
                grdRemates.DataBind();
            }
            else
            {
                grdRemates.Visible = false;
                lblErrorGrdRemates.Visible = true;
                lblErrorGrdRemates.Text = "(!) No se encontraron Remates";
            }


        }

        protected void LotesDisponiblesDeRemate(Remate unRemate)
        {
            lblHeaderLotes.Visible = true;
            lblHeaderLotes.Text = "LOTES REMATADOS";
            grdLotesRemate.Visible = true;
            List<Lote> listaDeLotesDelRemate = unRemate.devolverListaLotesRemate();
            if(listaDeLotesDelRemate.Count != 0)
            {
                lblErrorGrdRemates.Visible = false;
                grdLotesRemate.DataSource = listaDeLotesDelRemate;
                grdLotesRemate.DataBind();
            }
            else
            {
                lblHeaderLotes.Visible = false;
                lblErrorGrdRemates.Visible = true;
                lblErrorGrdRemates.Text = "(!) Aun no se han adjudicado lotes al remate";
            }
           
        }
    }
}