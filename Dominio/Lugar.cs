using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Lugar
    {
        #region Atributos y Properties
        // Autonumerado
        private static int _UltimoNro = 0;

        public static int UltimoNumero
        {
            get { return _UltimoNro; }

        }

        // Atributos de Instancia
        private string _nombreLugar;
        public string NombreLugar
        {
            get { return _nombreLugar; }
            set { _nombreLugar = value; }
        }

        private int _idLugar;
        public int IdLugar
        {
            get { return _idLugar; }
            set { _idLugar = value; }
        }

        private string _calleLugar;
        public string CalleLugar
        {
            get { return _calleLugar; }
            set { _calleLugar = value; }
        }

        private string _numeroPuertaLugar;
        public string NumeroPuertaLugar
        {
            get { return _numeroPuertaLugar; }
            set { _numeroPuertaLugar = value; }
        }

        private string _ciudadLugar;
        public string CiudadLugar
        {
            get { return _ciudadLugar; }
            set { _ciudadLugar = value; }
        }
        #endregion

        #region Constructores
        public Lugar(string unNombreLugar, string unaCalleLugar, string unNumeroPuertaLugar, string unaCiudadLugar)
        {
            _UltimoNro++;
            this.IdLugar = Lugar._UltimoNro;
            this.NombreLugar = unNombreLugar;
            this.CalleLugar = unaCalleLugar;
            this.NumeroPuertaLugar = unNumeroPuertaLugar;
            this.CiudadLugar = unaCiudadLugar;
        }
        #endregion

        #region Metodos sobreescritos / heredados
        public override string ToString()
        {
            return "ID: " + this.IdLugar + "\n" + "Nombre: " + this.NombreLugar + "\n" + "Calle: " + this.CalleLugar + "\n" + "Ciudad: " + this.CiudadLugar + "\n" + "\n";
        }
        #endregion

        #region Otros metodos


        #endregion
    }
}