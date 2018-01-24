using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Interfaz
{
    public partial class Adjudicar_Lore_De_Remate_A_Comprador : System.Web.UI.Page
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
                actualizarGridViewCompradores();
                actualizarGridViewRemates();
            }
        }

        protected void grdRemates_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOkAdj.Visible = false;
            lblErrorAdj.Visible = false;
            lblErrorGrdRemates.Visible = false;
            int idRemate = Convert.ToInt32((grdRemates.SelectedRow.Cells[1].Text));
            Remate unRemate = dominio.buscarRemate(idRemate);
            LotesDisponiblesDeRemate(unRemate);
        }

        protected void grdCompradores_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOkAdj.Visible = false;
            lblErrorComp.Visible = false;
            lblErrorAdj.Visible = false;
        }

        protected void grdLotesDisponiblesDeRemate_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOkAdj.Visible = false;
            lblErrorAdj.Visible = false;
            panelPrecioVta.Visible = true;
        }

        protected void actualizarGridViewCompradores()
        {
            List<Comprador> ListaCompradores = dominio.devolverListaCompradores();
            if (ListaCompradores.Count > 0)
            {
                grdCompradores.DataSource = ListaCompradores;
                grdCompradores.DataBind();
            }
            else
            {
                grdRemates.Visible = false;
                lblOkAdj.Visible = false;
                lblErrorComp.Visible = true;
                lblErrorComp.Text = "(!) No Existen Compradores Disponibles (!)";
            }
        }

        protected void actualizarGridViewRemates()
        {
            List<Remate> listaRematesDosponibles = dominio.devolverRematesDisponibles();
            if (listaRematesDosponibles.Count > 0)
            {
                grdRemates.DataSource = listaRematesDosponibles;
                grdRemates.DataBind();
            }
            else
            {
                grdRemates.Visible = false;
                //lblOkCierreRemate.Visible = false;
                lblHeaderRemates.Visible=false;
                lblErrorComp.Visible = true;
                lblErrorComp.Text = "(!) No Existen Remates Disponibles (!)";
            }
        }

        protected void LotesDisponiblesDeRemate(Remate unRemate)
        {
            lblHeaderLotes.Visible = true;
            lblHeaderLotes.Text = "Seleccione Lote/s";
            grdLotesDisponiblesDeRemate.Visible = true;
            List<Lote> listaLotesDosponibles = unRemate.devolverListaLotesNoVendidosRemate();
            if (listaLotesDosponibles.Count > 0){
                grdLotesDisponiblesDeRemate.DataSource = listaLotesDosponibles;
                grdLotesDisponiblesDeRemate.DataBind();
            }
            else{
                grdLotesDisponiblesDeRemate.Visible = false;
                lblHeaderLotes.Visible = false;
                lblErrorGrdRemates.Visible = true;
                lblErrorGrdRemates.Text = "(!) El remate no posee lotes para ser adjudicados";
            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            lblErrorComp.Visible = false;
            lblErrorGrdRemates.Visible = false;
            lblErrorAdj.Visible = false;
            if (grdCompradores.SelectedRow != null)
            {
                if (grdRemates.SelectedRow != null)
                {
                    int idRemate = Convert.ToInt32((grdRemates.SelectedRow.Cells[1].Text));
                    Remate unRemate = dominio.buscarRemate(idRemate);
                    if (unRemate.devolverListaLotesNoVendidosRemate().Count != 0)
                    { 
                        if (grdLotesDisponiblesDeRemate.SelectedRow != null)
                        {
                            string idLote = (grdLotesDisponiblesDeRemate.SelectedRow.Cells[1].Text);
                            Lote unLote = dominio.buscarLote(idLote);
                            double precioVenta = Convert.ToDouble(txtPrecioVta.Text);
                            if (precioVenta >= unLote.PrecioBaseLote)
                            {
                                lblOkAdj.Visible = true;
                                lblOkAdj.Text = "El lote fue asignado existosamente";
                                limpiarCampos(Page.Controls);
                                unLote.PrecioCompraLote = precioVenta;
                                unLote.FueComprado = true;
                                string nomUsuarioComprador = grdCompradores.SelectedRow.Cells[2].Text;
                                Comprador unComprador = dominio.buscarComprador(nomUsuarioComprador);
                                if (unComprador.listaLotesComprados.Count != 0)
                                {
                                    bool loEncontre = false;
                                    foreach (LoteComprado L in unComprador.listaLotesComprados.ToList())//recorro la lista buscando que ya haya un lote comprado con el id remate que tengo
                                    {
                                        if (L.Remate.IdRemate == unRemate.IdRemate)//si el lote comprado ya existe, solamente le hago un add a la lista de lotes
                                        {
                                            L.listaLotesCompradosEnRemate.Add(unLote);
                                            loEncontre = true;
                                        }
                                    }
                                    if (loEncontre == false)//si no encontre ningun remate como el que estoy buscando, creo uno nuevo el la lista LoteComprado del Comprador
                                    {
                                        LoteComprado loteCompradotmp = dominio.crearLoteComprado(unRemate);
                                        loteCompradotmp.listaLotesCompradosEnRemate.Add(unLote);
                                        unComprador.listaLotesComprados.Add(loteCompradotmp);
                                    }
                                }
                                else { //si la lista de LotesComprados del Comprador esta vacia, crea un objeto nuevo. Solo entrará en este else UNA vez y solamente UNA
                                    LoteComprado loteCompradotmp = dominio.crearLoteComprado(unRemate);
                                    loteCompradotmp.listaLotesCompradosEnRemate.Add(unLote);
                                    unComprador.listaLotesComprados.Add(loteCompradotmp);
                                }
                                LotesDisponiblesDeRemate(unRemate);
                                panelPrecioVta.Visible = false;
                                grdCompradores.SelectedIndex = -1;
                                grdLotesDisponiblesDeRemate.SelectedIndex = -1;
                                grdRemates.SelectedIndex = -1;
                            }
                            else
                            {
                                lblErrorAdj.Visible = true;
                                lblErrorAdj.Text = "El comprador no puede abonar un monto menor al precio base del lote ($" + unLote.PrecioBaseLote + ")";
                            }
                        }
                        else
                        {
                            lblErrorAdj.Visible = true;
                            lblErrorAdj.Text = "(*) Seleccione uno o mas Lotes";
                        }
                    }
                    else
                    {
                        lblErrorAdj.Visible = false;
                        lblErrorGrdRemates.Visible = true;
                        lblErrorGrdRemates.Text = "(!) El remate no posee lotes para ser adjudicados";
                    }
                }
                else
                {
                    lblErrorGrdRemates.Visible = true;
                    lblErrorGrdRemates.Text = "(*) Seleccione un Remate";
                }
            }
            else
            {
                lblErrorComp.Visible = true;
                lblErrorComp.Text = "(*) Seleccione un Comprador";
            }
        }

        protected void limpiarCampos(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox) ((TextBox)ctrl).Text = string.Empty;
               // else if (ctrl is DropDownList) ((DropDownList)ctrl).ClearSelection();
               // else if (ctrl is Calendar) ((Calendar)ctrl).SelectedDates.Clear();
               // else if (ctrl is ListBox) ((ListBox)ctrl).ClearSelection();
                limpiarCampos(ctrl.Controls);
            }
        }
    }
}