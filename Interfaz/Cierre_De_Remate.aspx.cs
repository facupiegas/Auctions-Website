using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Cierre_De_Remate : System.Web.UI.Page
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
                actualizarGridView();
            }
        }

        protected void btnCerrarRemate_Click(object sender, EventArgs e)
        {
            lblErrorCierreRemate.Visible = false;
            if(grdRemates.SelectedRow != null && dominio.devolverRematesDisponibles().Count > 0) { 
                int idRemate = Convert.ToInt32((grdRemates.SelectedRow.Cells[1].Text));
                Remate unRemate = dominio.buscarRemate(idRemate);
                dominio.cerrarRemate(idRemate);
                lblComision.Text = "Comisión a Pagar - $ " + dominio.devolverComisionRematador(idRemate).ToString();
                lblRematador.Text = "Rematador - " + unRemate.Rematador.NombreApellido;
                lblOkCierreRemate.Visible = true;
                lblOkCierreRemate.Text = "El remate fue cerrado exitosamente";
                List<Comprador> listaCompradoresQueParticiparonDeRemate = dominio.devolverListaCompradoresQueParticiparonDeRemate(idRemate);


                foreach (Comprador C in listaCompradoresQueParticiparonDeRemate)
                {
                    C.devolverComisionAPagar(idRemate);
                    
                }
                
            






                grdCompradores.Visible = true;
                grdCompradores.DataSource = listaCompradoresQueParticiparonDeRemate;
                grdCompradores.DataBind();

                actualizarGridView();
                grdRemates.SelectedIndex = -1;
            }
            else if(dominio.devolverRematesDisponibles().Count == 0){
                lblOkCierreRemate.Visible = false;
                lblErrorCierreRemate.Visible = true;
                lblErrorCierreRemate.Text = "(!) No Existen Remates Disponibles (!)";
                actualizarGridView();
            }
            else{
                lblOkCierreRemate.Visible = false;
                lblErrorCierreRemate.Visible = true;
                lblErrorCierreRemate.Text = "(*) Seleccione un remate";
                actualizarGridView();
            }

        }

        protected void actualizarGridView()
        {
            List<Remate> listaRematesDosponibles = dominio.devolverRematesDisponibles();
            if(listaRematesDosponibles.Count > 0)
            { 
            grdRemates.DataSource = listaRematesDosponibles;
            grdRemates.DataBind();
            }
            else
            {
                grdRemates.Visible = false;
                lblOkCierreRemate.Visible = false;
                lblErrorCierreRemate.Visible = true;
                lblErrorCierreRemate.Text = "(!) No Existen Remates Disponibles (!)";
            }
        }
    }
}