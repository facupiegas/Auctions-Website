using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        #region Atributos y Properties
        // Atributos de Instancia
        public string NombreUsuario { set; get; }
        public string Clave { set; get; }
        #endregion

        #region Constructores
        public Usuario(string unNombreUsuario, string unaClave)
        {
            this.NombreUsuario = unNombreUsuario;
            this.Clave = unaClave;
        }

        public Usuario()
        {
        }

        #endregion

        #region Otros Metodos
        public virtual int devolverTipo() {
           return 0 ;
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
