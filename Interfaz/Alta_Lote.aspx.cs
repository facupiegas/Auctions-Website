using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace Interfaz
{
    public partial class Alta_Lote : System.Web.UI.Page
    {
        Rematadora dominio = Rematadora.Instancia;
        protected void Page_Load(object sender, EventArgs e){
            if ((int)Session["tipo"] == 0) //Valido que el usuario se haya logueado y no se saltee la autentificación
            {
                Response.Redirect("Login.aspx"); //si no se logueó, lo redirijo a Login
            }
            if (!IsPostBack)
            {
                lblOkAltaLote.Visible = false;
            }
        }

        protected void btnUpload_Click(object sender, ImageClickEventArgs e){
            if (extensionArchivoOK(upFotoLote.FileName))
            {
                string path = Server.MapPath("imagenes");
                string archivo = path + "\\" + upFotoLote.FileName;
                upFotoLote.SaveAs(archivo);
                imgFoto.ImageUrl = "imagenes\\" + upFotoLote.FileName;
                lblErrorFoto.Visible = false;
            }
            else{
                lblErrorFoto.Visible = true;
                lblErrorFoto.Text = "Formato de imagen admitido .gif/.png/.jpeg/.jpg";
                imgFoto.ImageUrl = null;
            }
        }

        private bool extensionArchivoOK(string nombreArchivo){
            bool ok = false;
            string fileExtension =
                    System.IO.Path.GetExtension(nombreArchivo).ToLower();
            string[] allowedExtensions =
                {".gif", ".png", ".jpeg", ".jpg"};
            for (int i = 0; i < allowedExtensions.Length; i++){
                if (fileExtension == allowedExtensions[i]){
                    ok = true;
                }
            }
            return ok;
        }//verifica extension de la imagen

        protected void BtnAltaLote_Click(object sender, EventArgs e){
            if (imgFoto.ImageUrl != ""){
                string descripcion = TxtDescripcion.Text;
                double precioBase = Convert.ToDouble(txtPrecioBase.Text);
                int unidades = Convert.ToInt32(txtUnidades.Text);
                dominio.crearLote(descripcion, precioBase, unidades, imgFoto.ImageUrl);
                lblOkAltaLote.Visible = true;
                lblErrorFoto.Visible = false;
                lblOkAltaLote.Text = "Lote creado con éxito";
                imgFoto.ImageUrl = null;
                limpiarCampos(Page.Controls);
            }
            else{
                lblErrorFoto.Visible = true;
                lblErrorFoto.Text = "(*) Ingrese una imagen para crear el lote";
            }
        
        }

        protected void limpiarCampos(ControlCollection ctrls){
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