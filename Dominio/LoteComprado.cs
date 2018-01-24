using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class LoteComprado
    {
        //ATRIBUTOS
        public Remate Remate { set; get; }
        public List<Lote> listaLotesCompradosEnRemate { set; get; }

        public LoteComprado(Remate unRemate)
        {
            this.Remate = unRemate;
            this.listaLotesCompradosEnRemate = new List<Lote>();
        }

        public double calcularComisionAPagar()
        {
            double comisionAPagar = 0;
            foreach(Lote L in listaLotesCompradosEnRemate)
            {
                comisionAPagar += L.PrecioCompraLote;
            }
            comisionAPagar = (comisionAPagar * 0.1) * 1.22; //0.10 (seña) + 1.22 (agrego IVA)
            return comisionAPagar;
        }
    }
}
