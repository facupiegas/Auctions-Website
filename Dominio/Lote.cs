using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Lote
    {
        #region Atributos y Properties

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string _idLote;
        public string IdLote
        {
            get { return _idLote; }
            set { _idLote = value; }
        }


        private string _descripcionLote;
        public string DescripcionLote
        {
            get { return _descripcionLote; }
            set { _descripcionLote = value; }
        }


        private double _precioBaseLote;
        public double PrecioBaseLote
        {
            get { return _precioBaseLote; }
            set { _precioBaseLote = value; }
        }


        private int _cantidadUnidadesLote;
        public int CantidadUnidadesLote
        {
            get { return _cantidadUnidadesLote; }
            set { _cantidadUnidadesLote = value; }
        }

        private bool _fueAsignado;
        public bool FueAsignado
        {
            get { return _fueAsignado; }
            set { _fueAsignado = value; }
        }

        private bool _fueComprado;
        public bool FueComprado
        {
            get { return _fueComprado; }
            set { _fueComprado = value; }
        }

        private double _precioCompraLote;
        public double PrecioCompraLote
        {
            get { return _precioCompraLote; }
            set { _precioCompraLote = value; }
        }

        public string Foto { set; get; }

        public string DescripcionListaLote
        {
            get { return "Descripción:" + "  " + this.DescripcionLote + " - " + "  " + "Precio base:" + "  " + this.PrecioBaseLote; }
        }
        #endregion

        #region Constructores

        public Lote(string unaDescripcionLote, double unPrecioBaseLote, int unaCantidadUnidadesLote, string unaFoto)
        {
            this.IdLote = Lote.RandomString(5);
            this.DescripcionLote = unaDescripcionLote;
            this.PrecioBaseLote = unPrecioBaseLote;
            this.PrecioCompraLote = 0;
            this.CantidadUnidadesLote = unaCantidadUnidadesLote;
            this.FueAsignado = false;
            this.FueComprado = false;
            this.Foto = unaFoto;
        }
        #endregion

        #region Metodos sobreescritos / heredados
        public override string ToString()
        {
            return "ID: " + this.IdLote + "\n" + "Descripción: " + this.DescripcionLote + "\n" + "Cantidad de Unidades: " + this.CantidadUnidadesLote + "\n" + "\n";
        }

        #endregion

        #region Otros metodos


        #endregion
    }
}