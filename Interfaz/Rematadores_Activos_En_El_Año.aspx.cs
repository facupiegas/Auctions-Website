using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Rematadores_Activos_En_El_Año : System.Web.UI.Page
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
                if((dominio.devolverListaRematadoresActivosEnElAño().Count != 0)) {
                    lblErrorRem.Visible = false;
                    grdRemActivos.DataSource = dominio.devolverListaRematadoresActivosEnElAño();
                    DataBind();
                }
                else
                {
                    lblErrorRem.Text = "(*) No se encontraron Rematadores Activos en el año";
                }
            }
        }
    }
}