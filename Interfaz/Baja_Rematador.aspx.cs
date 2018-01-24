using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace Interfaz
{
    public partial class Baja_Rematador : System.Web.UI.Page
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
                lstBajaRem.DataSource = dominio.devolverListaRematadores();
                lstBajaRem.DataTextField = "NombreApellido";
                lstBajaRem.DataValueField = "IdRematador";
                lstBajaRem.DataBind();
            }
        }

        protected void btnBajaRem_Click(object sender, EventArgs e)
        {
            if (lstBajaRem.SelectedValue != "")
            {//valido que se haya seleccionado algun elemento de la lista
                lblErrorBajaRem.Visible = false;
                int idRematador = Convert.ToInt32(lstBajaRem.SelectedValue);
                if (!dominio.tieneRematesAsignados(idRematador))
                { //valido que el rematador no tenga ningun remate en el futuro
                    lblOkBajaRem.Visible = true;
                    lblOkBajaRem.Text = "El rematador " + dominio.buscarRematador(idRematador).NombreApellido + " fue dado de baja con éxito"; //cargo el label antes de eliminarlo ya que sino el objeto no existiria en la lista de rematadores al buscarlos por id para traer su nombre y apellido
                    dominio.darBajaRematador(dominio.buscarRematador(idRematador));//invoco a lmetodo que realiza el remove del objeto de la lista de rematadores en la calse controladora
                    lstBajaRem.DataSource = dominio.devolverListaRematadores();
                    lstBajaRem.DataBind();

                }
                else
                {
                    lblOkBajaRem.Visible = false;
                    lblErrorBajaRem.Visible = true;
                    lblErrorBajaRem.Text = "El rematador no puede ser dado de baja por tener remates pendientes";
                }
            }
            else //si no se selecciono ningun elemento de la lista, doy aviso
            {
                lblOkBajaRem.Visible = false;
                lblErrorBajaRem.Visible = true;
                lblErrorBajaRem.Text = "Seleccione un Rematador";
            }
        }//metodo que da de baja a un rematador de la lista de rematadores






    }
}