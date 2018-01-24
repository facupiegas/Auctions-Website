using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Comprador : Usuario
    {
        #region Atributos y Properties
        public string Direccion { set; get; }
        public string Telefono { set; get; }
        public string SenaAPagar { set; get; }
        public string NomLista { set; get; }

        public List<LoteComprado> listaLotesComprados { set; get; }

        #endregion

        #region Constructores
        public Comprador(string NombreUsuario, string unaClave, string unaDireccion, string unTelefono) : base(NombreUsuario, unaClave)
        {
            this.Direccion = unaDireccion;
            this.Telefono = unTelefono;
            this.listaLotesComprados = new List<LoteComprado>();

        }
        public override int devolverTipo()
        {
            return 3;
        }

        public double devolverComisionAPagar(int unIdRemate)
        {
            double comision=0;
            foreach(LoteComprado R in listaLotesComprados)
            {
                if(R.Remate.IdRemate == unIdRemate)
                {
                    comision = R.calcularComisionAPagar();
                }
            }
            this.SenaAPagar = "$ " + comision.ToString();
            return comision;
        }

        public bool participoDeRemate(int unIdRemate)
        {
            bool participoDeRemate = false;
            foreach(LoteComprado L in listaLotesComprados)
            {
                if(L.Remate.IdRemate == unIdRemate)
                {
                    participoDeRemate = true;
                }
            }
            return participoDeRemate;
        }
        #endregion
    }
}
