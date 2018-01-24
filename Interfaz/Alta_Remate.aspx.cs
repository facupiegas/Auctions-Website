using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Alta_Remate : System.Web.UI.Page
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
                LblPorcentajeAdicionalPorLoteAdjudicado.Visible = false;
                txtPorcentajeAdicComLoteAdjudicado.Visible = false;

                lstLugar.DataSource = dominio.devolverListaLugares();
                lstLugar.DataTextField = "NombreLugar";
                lstLugar.DataValueField = "IdLugar";
                lstLugar.DataBind();

                lstRematador.DataSource = dominio.devolverListaRematadores();
                lstRematador.DataTextField = "NombreRematador";
                lstRematador.DataValueField = "IdRematador";
                lstRematador.DataBind();
            }
        }

        protected void rbGanado_CheckedChanged(object sender, EventArgs e)
        {
            panGanado.Visible = true;
            panRemMerc.Visible = false;
            LblPorcentajeAdicionalPorLoteAdjudicado.Visible = false;
            txtPorcentajeAdicComLoteAdjudicado.Visible = false;
        }

        protected void rbMercaderia_CheckedChanged(object sender, EventArgs e)
        {
            panGanado.Visible = false;
            panRemMerc.Visible = true;
            LblPorcentajeAdicionalPorLoteAdjudicado.Visible = true;
            txtPorcentajeAdicComLoteAdjudicado.Visible = true;
        }

        protected void btnCrearRemate_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            double porcentajeBaseRematador = Convert.ToDouble(TxtPorcentajeBaseRematador.Text);
            int idLugar = Convert.ToInt32(lstLugar.SelectedValue);
            Lugar unLugar = dominio.buscarLugar(idLugar);
            int idRematador = Convert.ToInt32(lstRematador.SelectedValue);
            Rematador unRematador = dominio.buscarRematador(idRematador);
            DateTime fecha = CalFechaRemate.SelectedDate;
                if (fecha >= DateTime.Today){
                    if (dominio.validoLugarFecha(fecha, idLugar)){
                        if (rbGanado.Checked){
                            dominio.crearRemateGanado(descripcion, porcentajeBaseRematador, fecha, unLugar, unRematador);
                            lblAltaRemateOk.Text = "Remate creado con éxito";
                            lblAltaRemateOk.Visible = true;
                            limpiarCampos(Page.Controls);
                            lblMensajeCal.Visible = false;
                            lblAltaRemateError.Visible = false;
                        }
                    if (rbMercaderia.Checked){
                            double porcentajeAdicionalPorLote = Convert.ToDouble(txtPorcentajeAdicComLoteAdjudicado.Text);
                            dominio.crearRemateMercaderia(descripcion, porcentajeBaseRematador, fecha, unLugar, unRematador, porcentajeAdicionalPorLote);
                            lblAltaRemateOk.Text = "Remate creado con éxito";
                            lblAltaRemateOk.Visible = true;
                            limpiarCampos(Page.Controls);
                            lblMensajeCal.Visible = false;
                            lblAltaRemateError.Visible = false;
                        }
                    }
                    else{
                        lblAltaRemateError.Text = "Ya existe un remate con misma fecha en el mismo lugar";
                        lblAltaRemateError.Visible = true;
                        lblAltaRemateOk.Visible = false;

                    }
                }
                else{
                    lblMensajeCal.Visible = true;
                    lblMensajeCal.Text = "(*) Seleccione una fecha válida";
                    lblAltaRemateError.Visible = false;
                    lblAltaRemateOk.Visible = false;
                }
        }

        protected void limpiarCampos(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox) ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList) ((DropDownList)ctrl).ClearSelection();
                else if (ctrl is Calendar) ((Calendar)ctrl).SelectedDates.Clear();
                else if (ctrl is ListBox) ((ListBox)ctrl).ClearSelection();
                limpiarCampos(ctrl.Controls);
            }
        }
    }
}