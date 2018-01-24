using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ganado : Remate
    {
        #region Atributos y Properties
        private static double _porcentajeAdicionalRematador = 3;
        public static double PorcentajeAdicionalRematador
        {
            get { return _porcentajeAdicionalRematador; }
            set { _porcentajeAdicionalRematador = value; }
        }
        #endregion

        #region Constructores
        public Ganado(string unaDescripcion, double unPorcentajeBaseRematador, DateTime unaFecha, Lugar unLugar, Rematador unRematador) : base(unaDescripcion, unPorcentajeBaseRematador, unaFecha, unLugar, unRematador)
        {
            // Nada para hacer
            // Solo se invoca al contructor de la clase base
        }
        #endregion

        #region Metodos sobreescritos / heredados
        public override double calcularComisionAPagarRematador()
        {
            double gananciaTotalLotesVendidos = calcularMontoVentasRemate();
            double comisionRematador = this.PorcentajeBaseRematador;
            int totalLotes = devolverListaLotesRemate().Count;
            int lotesVendidos = devolverCantidadLotesVendidos();
            if(lotesVendidos > (totalLotes / 2)){
                comisionRematador += _porcentajeAdicionalRematador;
                comisionRematador = (comisionRematador / 100) * gananciaTotalLotesVendidos;
            }
            else{
                comisionRematador = (comisionRematador / 100) * gananciaTotalLotesVendidos;
            }

            return comisionRematador;
        }
        #endregion

        #region Otros metodos


        #endregion

    }
}