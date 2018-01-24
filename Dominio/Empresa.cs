using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empresa : Comprador
    {
        #region Atributos y Properties
        public string PersonaContacto { set; get; }
        public string RazonSocial { set; get; }
        public string Rut { set; get; }
        #endregion

        #region Constructores
        public Empresa(string unNombreUsuario, string unaClave, string unaDireccion, string unTelefono, string unaPersonaContacto, string unaRazonSocial, string unRut) : base(unNombreUsuario, unaClave, unaDireccion, unTelefono)
        {
            this.NomLista = unaRazonSocial;
            this.PersonaContacto = unaPersonaContacto;
            this.RazonSocial = unaRazonSocial;
            this.Rut = unRut;
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