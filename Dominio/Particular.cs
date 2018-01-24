using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Particular : Comprador
    {
        #region Atributos y Properties
        public string NombreParticular { set; get; }
        public string ApellidoParticular { set; get; }
        public string DocumentoParticular { set; get; }
        #endregion

        #region Constructores
        public Particular(string NombreUsuario, string unaClave, string unaDireccion, string unTelefono, string unNombreParticular, string unApellidoParticular, string unDocumentoParticular) : base(NombreUsuario, unaClave, unaDireccion, unTelefono)
        {
            this.NomLista = unNombreParticular + " " + unApellidoParticular;
            this.NombreParticular = unNombreParticular;
            this.ApellidoParticular = unApellidoParticular;
            this.DocumentoParticular = unDocumentoParticular;


        }
        #endregion

        #region Metodos Sobreescrios
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
    }
}
