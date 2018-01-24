using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Ver_Remates_En_Los_Que_Compro_Usuario : System.Web.UI.Page
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
            lblErrorGrdRemates.Visible = false;
            string nomUsuario = (string)Session["usuario"];
            Comprador unComprador = dominio.buscarComprador(nomUsuario);
            int idRemateGrid = Convert.ToInt32((grdRemates.SelectedRow.Cells[1].Text));
            List<LoteComprado> listaLoteComprado = unComprador.listaLotesComprados;
            List<Lote> listaLotesCompradosComprador = new List<Lote>();
            {
                foreach (LoteComprado R in listaLoteComprado)
                {
                    if(R.Remate.IdRemate == idRemateGrid)
                    {
                        listaLotesCompradosComprador = R.listaLotesCompradosEnRemate;
                    }
                }
                grdLotesDisponiblesDeRemate.Visible = true;
                grdLotesDisponiblesDeRemate.DataSource = listaLotesCompradosComprador;
                grdLotesDisponiblesDeRemate.DataBind();
            }
        }

        protected void actualizarGridViewRemates()
        {
            grdRemates.SelectedIndex = -1;
            string nomUsuario = (string)Session["usuario"];
            Comprador unComprador = dominio.buscarComprador(nomUsuario);
            List<LoteComprado> listaLoteComprado = unComprador.listaLotesComprados;
            List<Remate> listaRematesRematesComprador = new List<Remate>();
            if (listaLoteComprado.Count > 0)
            {
                foreach(LoteComprado R in listaLoteComprado)
                {
                    listaRematesRematesComprador.Add(R.Remate);
                }
                grdRemates.DataSource = listaRematesRematesComprador;
                grdRemates.DataBind();
            }
            else
            {
                grdRemates.Visible = false;
                lblErrorGrdRemates.Visible = true;
                lblErrorGrdRemates.Text = "Usted aun no ha comprado lotes";
            }


        }

        protected void LotesDisponiblesDeRemate(Remate unRemate)
        {
            lblHeaderLotes.Visible = true;
            lblHeaderLotes.Text = "Seleccione Lote/s";
            grdLotesDisponiblesDeRemate.Visible = true;
            List<Lote> listaLotesDosponibles = unRemate.devolverListaLotesNoVendidosRemate();
            grdLotesDisponiblesDeRemate.DataSource = listaLotesDosponibles;
            grdLotesDisponiblesDeRemate.DataBind();
        }

    }
}