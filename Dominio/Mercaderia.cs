using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mercaderia : Remate
    {
        #region Atributos y Properties
        private double _porcentajeAdicionalPorLote;
        public double PorcentajeAdicionalPorLote
        {
            get { return _porcentajeAdicionalPorLote; }
            set { _porcentajeAdicionalPorLote = value; }
        }
        #endregion

        #region Constructores
        public Mercaderia(string unaDescripcion, double unPorcentajeBaseRematador, DateTime unaFecha, Lugar unLugar, Rematador unRematador, double unPorcentajeAdicionalPorLote) : base(unaDescripcion, unPorcentajeBaseRematador, unaFecha, unLugar, unRematador)
        {
            this.PorcentajeAdicionalPorLote = unPorcentajeAdicionalPorLote;
        }
        #endregion

        #region Metodos sobreescritos / heredados
        public override double calcularComisionAPagarRematador()
        {
            double gananciaTotalLotesVendidos = calcularMontoVentasRemate();
            double comisionRematador = this.PorcentajeBaseRematador;
            int lotesVendidos = devolverCantidadLotesVendidos();
            comisionRematador += (PorcentajeAdicionalPorLote * lotesVendidos);
            comisionRematador = (comisionRematador / 100) * gananciaTotalLotesVendidos;
            return comisionRematador;
        }
        #endregion

        #region Otros metodos


        #endregion
    }
}
