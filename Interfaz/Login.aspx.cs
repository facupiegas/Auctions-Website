using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Login : System.Web.UI.Page
    {
        Rematadora dominio = Rematadora.Instancia;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            int tipo = dominio.validarUsuario(Login1.UserName, Login1.Password);//con los datos obtenidos del login, voy a buscar si el objeto usuario existe, y de ser asi obtengo su tipo (int)

            if (0 < tipo && tipo < 4) //valido que el usuario sea 1-Admin 2-Rematador 3-Comprador
            {
                Session["usuario"] = Login1.UserName;
                if (tipo == 1)
                {
                    Session["tipo"] = 1;

                }
                if (tipo == 2)
                {

                    Session["tipo"] = 2;

                }
                if (tipo == 3)
                {

                    Session["tipo"] = 3;

                }
                e.Authenticated = true;
                

            }
            else //si es distinto de 1/2/3 no loguea
            {
                e.Authenticated = false;
            }


        }
    }
}
