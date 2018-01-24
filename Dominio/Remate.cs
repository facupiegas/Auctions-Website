using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Remate
    {
        private List<Lote> listaLotesDeRemate;

        #region Atributos y Properties
        //Atributos de Clase
        // Autonumerado
        private static int _UltimoNro = 0;

        public static int UltimoNumero
        {
            get { return _UltimoNro; }
        }

        // Atributos de Instancia

        private int _idRemate;
        public int IdRemate
        {
            get { return _idRemate; }
            set { _idRemate = value; }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private double _porcentajeBaseRematador;
        public double PorcentajeBaseRematador
        {
            get { return _porcentajeBaseRematador; }
            set { _porcentajeBaseRematador = value; }
        }

        private DateTime _fecha;
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private Lugar _lugar;
        public Lugar Lugar
        {
            get { return _lugar; }
            set { _lugar = value; }
        }

        private Rematador _rematador;
        public Rematador Rematador
        {
            get { return _rematador; }
            set { _rematador = value; }
        }

        private bool _cerrado;
        public bool Cerrado
        {
            get { return _cerrado; }
            set { _cerrado = value; }
        }

        private double _comisionRematador;
        public double ComisionRematador
        {
            get { return _comisionRematador; }
            set { _comisionRematador = value; }
        }

        #endregion

        #region Constructores
        public Remate(string unaDescripcion, double unPorcentajeBaseRematador, DateTime unaFecha, Lugar unLugar, Rematador unRematador)
        {
            _UltimoNro++;
            listaLotesDeRemate = new List<Lote>();
            this.IdRemate = Remate._UltimoNro;
            this.Descripcion = unaDescripcion;
            this.PorcentajeBaseRematador = unPorcentajeBaseRematador;
            this.Fecha = unaFecha;
            this.Lugar = unLugar;
            this.Rematador = unRematador;
            this.Cerrado = false;
        }
        #endregion

        #region Metodos sobreescritos / heredados
        public override string ToString()
        {
            return "Fecha: " + this.Fecha.ToString() + "\n" + "Lugar: " + this.Lugar.NombreLugar + "\n" + "Rematador: " + this.Rematador.NombreRematador + "\n" + "\n";
        }

        // Si ya se que este metodo es polimórfico y tiene codigo debo indicarlo agregando la palabra virtual 
        public abstract double calcularComisionAPagarRematador();

        public virtual double calcularMontoVentasRemate()
        {
            double montoVentasRemate = 0;
            List<Lote> listaLotesRemate = devolverListaLotesRemate();
            foreach(Lote L in listaLotesDeRemate){
                if (L.FueComprado == true){
                    montoVentasRemate += L.PrecioCompraLote;
                }
            }
            return montoVentasRemate;
        }//devuelve el monto total cobrado por los lotes vendidos
        #endregion

        #region Otros metodos
        public void agregarLoteALista(Lote unLote)
        {
            unLote.FueAsignado = true;//cambio el estado del lote
            listaLotesDeRemate.Add(unLote);
        }//metodo que agrega un objeto lote a la lista de lotes del remate

        public List<Lote> devolverListaLotesRemate()
        {
            return listaLotesDeRemate;
        }

        public List<Lote> devolverListaLotesNoVendidosRemate()
        {
            List<Lote> listaLotesNoVendidos = new List<Lote>();
            foreach(Lote L in listaLotesDeRemate){
                if(L.FueComprado == false){
                    listaLotesNoVendidos.Add(L);
                }
            }
            return listaLotesNoVendidos;
        }

        public void liberarLotesNoVendidos()
        {
            foreach(Lote L in listaLotesDeRemate)
            {
                if (L.FueComprado == false)
                {
                    L.FueAsignado = false;
                }
            }
        }

        public int devolverCantidadLotesVendidos()
        {
            int cantidadLotesVendidos = 0;
            List<Lote> listaLotesRemate = devolverListaLotesRemate();
            foreach (Lote L in listaLotesRemate)
            {
                if (L.FueComprado == true)
                {
                    cantidadLotesVendidos++;
                }
            }
            return cantidadLotesVendidos;
        }//devuelve la cantidad de lotes que fueron vendidos para calcular la comision adicional

        #endregion
    }
}
