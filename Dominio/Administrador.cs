using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario
    {
        #region Contructor
        public Administrador(string unNombreUsuario, string unaClave) : base(unNombreUsuario, unaClave)
        {
        }
        public override int devolverTipo()
        {
            return 1;
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
            if (this.NombreUsuario.CompareTo(other.NombreUsuario) < 0) // alias de this esta antes que el alias de other
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
