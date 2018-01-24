using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Maestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int tipo = (int)Session["tipo"];

            lblUsuario.Text = (string)Session["usuario"];
            lnkSalir.Visible = false;
            if (tipo != 0)
            {
                lblBienvenida.Visible = true;
                lnkSalir.Visible = true;
                if (tipo == 1)
                {
                    menuAdmin.Visible = true;
                    menuRematador.Visible = false;
                    menuComprador.Visible = false;
                }
                if (tipo == 2)
                {
                    menuAdmin.Visible = false;
                    menuRematador.Visible = true;
                    menuComprador.Visible = false;
                }
                if (tipo == 3)
                {
                    menuAdmin.Visible = false;
                    menuRematador.Visible = false;
                    menuComprador.Visible = true;
                }
            }
            else
            {
                menuAdmin.Visible = false;
                menuRematador.Visible = false;
                menuComprador.Visible = false;
            }
        }

        protected void lnkSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
    }
}