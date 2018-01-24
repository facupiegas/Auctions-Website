using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Rematador : Usuario
    {
        #region Atributos y Properties
        // Autonumerado
        private static int _UltimoNro = 0;

        public static int UltimoNumero
        {
            get { return _UltimoNro; }
        }

        // Atributos de Instancia
        private int _idRematador;
        public int IdRematador
        {
            get { return _idRematador; }
            set { _idRematador = value; }
        }

        private string _nombreRematador;
        public string NombreRematador
        {
            get { return _nombreRematador; }
            set { _nombreRematador = value; }
        }

        private string _apellidoRematador;
        public string ApellidoRematador
        {
            get { return _apellidoRematador; }
            set { _apellidoRematador = value; }
        }

        private string _telefonoRematador;
        public string TelefonoRematador
        {
            get { return _telefonoRematador; }
            set { _telefonoRematador = value; }
        }

        public string NombreApellido{
            get
            {
                return this.NombreRematador + "  " + this.ApellidoRematador;
            }
        }
        public string ComisionRematador { set; get; }

        #endregion

        #region Constructores
        public Rematador(string unNombreUsuario, string unaClave, string unNombreRematador, string unApellidoRematador, string unTelefonoRematador) : base(unNombreUsuario, unaClave)
        {
            _UltimoNro++;
            this.IdRematador = Rematador._UltimoNro;
            this.Clave = unaClave;
            this.NombreRematador = unNombreRematador;
            this.ApellidoRematador = unApellidoRematador;
            this.TelefonoRematador = unTelefonoRematador;
        }
        #endregion

        #region Metodos sobreescritos / heredados
        public override string ToString()
        {
            return "ID: " + this.IdRematador + "\n" + "Nombre: " + this.NombreRematador + "\n" + "Apellido: " + this.ApellidoRematador + "\n" + "\n";
        }

        public override int devolverTipo()
        {
            return 2;
        }

        public override bool Equals(object obj)
        {
            Usuario otro = obj as Usuario;
            return this.NombreUsuario.Equals(otro.NombreUsuario);
        }

        public int CompareTo(Usuario other)
        {
            int res;
            if (this.NombreUsuario.CompareTo(other.NombreUsuario) < 0) // alias de this esta antes qu el alias de other
            {
                res = -1;
            }
            else
            {
                if (this.NombreUsuario.CompareTo(other.NombreUsuario) > 0)
                {
                    res = 1;
                }
                else
                {
                    res = 0;
                }
            }

            return res;
        }
        #endregion

        #region Otros metodos


        #endregion
    }
}
