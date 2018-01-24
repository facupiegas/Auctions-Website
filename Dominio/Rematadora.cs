using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Rematadora
    {
        #region Atributos y Properties
        private static Rematadora instancia;

        public static Rematadora Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Rematadora();
                    instancia.cargaObjetosPrueba();
                }
                return instancia;
            }
        }
        #endregion

        #region Constructores
        private List<Remate> listaRemates;
        private List<Rematador> listaRematadores;
        private List<Lugar> listaLugares;
        private List<Lote> listaLotes;
        private List<Usuario> listaUsuarios;
        private List<Comprador> listaCompradores;
        private Rematadora()
        {
            listaRemates = new List<Remate>();
            listaRematadores = new List<Rematador>();
            listaLugares = new List<Lugar>();
            listaLotes = new List<Lote>();
            listaUsuarios = new List<Usuario>();
            listaCompradores = new List<Comprador>();
        }
        #endregion

        #region Metodos
        public void cargaObjetosPrueba()
        {
            //precargo datos del lote de pueba
            crearLote("Lote de Prueba 1", 15000, 1, "imagenes\\ad.jpg");
            crearLote("Lote de Prueba 2", 16000, 2, "imagenes\\ad.jpg");
            crearLote("Lote de Prueba 3", 17000, 3, "imagenes\\ad.jpg");
            crearLote("Lote de Prueba 4", 18000, 4, "imagenes\\ad.jpg");
            crearLote("Lote de Prueba 5", 19000, 5, "imagenes\\ad.jpg");
            //precargo usuarios
            crearUsuarioAdministrador("1", "1");
            crearRematador("rem1", "rem1", "Carlos1", "Bueno", "099868407");
            crearRematador("rem2", "rem2", "Carlos2", "Bueno", "099868407");
            crearRematador("rem3", "rem3", "Carlos3", "Bueno", "099868407");
            crearRematador("rem4", "rem4", "Carlos4", "Bueno", "099868407");
            crearUsuarioCompradorParticular("part1", "part1", "Guayaqui 3342", "099868877", "Susaana", "Horia", "45867946");
            crearUsuarioCompradorEmpresa("emp1", "emp1", "Cuareim 3322", "47327844", "Ese COntacto", "Razon de Ser SRL", "111111");
            //precargo datos del lugar de prueba
            crearLugar("Casona del Lago", "Calle de Lugar", "564654", "Montevideo");
            crearLugar("Galpon", "Calle de Galpon", "78744", "Montevideo");
            crearLugar("Hotel", "Calle del Hotel", "98745", "Montevideo");
            crearLugar("Campo", "Calle del Campo", "25773", "Montevideo");
            //precargo un remate
            crearRemateGanado("remate1", 2, DateTime.Now, listaLugares[0], listaRematadores[0]);
            crearRemateGanado("remate2", 2, DateTime.Now, listaLugares[1], listaRematadores[1]);
            crearRemateGanado("remate3", 2, DateTime.Now, listaLugares[2], listaRematadores[2]);
            //asigno lotes a los remates
            listaRemates[0].agregarLoteALista(listaLotes[0]);
            listaRemates[0].agregarLoteALista(listaLotes[1]);
           listaRemates[0].agregarLoteALista(listaLotes[2]);
        }  //Objetos de Prueba

        #region ALTAS DE OBJETOS
        public void crearRematador(string unNombreUsuario, string unaClave, string unNombreRematador, string unApellidoRematador, string unTelefonoRematador)
        {
            Rematador unRematador = new Rematador(unNombreUsuario, unaClave, unNombreRematador, unApellidoRematador, unTelefonoRematador);
            listaRematadores.Add(unRematador);
            listaUsuarios.Add(unRematador);
        }

        public void crearLugar(string unNombreLugar, string unaCalleLugar, string unNumeroPuertaLugar, string unaCiudadLugar)
        {
            Lugar unLugar = new Lugar(unNombreLugar, unaCalleLugar, unNumeroPuertaLugar, unaCiudadLugar);
            listaLugares.Add(unLugar);
        }

        public void crearLote(string unaDescripcionLote, double unPrecioBaseLote, int unaCantidadUnidadesLote, string unaFoto)
        {
            Lote unLote = new Lote(unaDescripcionLote, unPrecioBaseLote, unaCantidadUnidadesLote, unaFoto);
            listaLotes.Add(unLote);
        }

        public LoteComprado crearLoteComprado(Remate unRemate)
        {
            LoteComprado unLoteComprado = new LoteComprado(unRemate);
            return unLoteComprado;
        }

        public void crearRemateGanado(string unaDescripcion, double unPorcentajeBaseRematador, DateTime unaFecha, Lugar unLugar, Rematador unRematador)
        {
            //Creo el remate y lo agrego a la lista
            Ganado unRemateGanado = new Ganado(unaDescripcion, unPorcentajeBaseRematador, unaFecha, unLugar, unRematador);
            listaRemates.Add(unRemateGanado);
        }

        public void crearRemateMercaderia(string unaDescripcion, double unPorcentajeBaseRematador, DateTime unaFecha, Lugar unLugar, Rematador unRematador, double unPorcentajeAdicionalPorLote)
        {
            //Creo el remate y lo agrego a la lista
            Mercaderia unRemateMercaderia = new Mercaderia(unaDescripcion, unPorcentajeBaseRematador, unaFecha, unLugar, unRematador, unPorcentajeAdicionalPorLote);
            listaRemates.Add(unRemateMercaderia);
        }

        public void crearUsuarioAdministrador(string unNombreUsuario, string unaClave)
        {
            Administrador unAdministrador = new Administrador(unNombreUsuario, unaClave);
            listaUsuarios.Add(unAdministrador);
        }

        public void crearUsuarioCompradorParticular(string unNombreUsuario, string unaClave, string unaDireccion, string unTelefono, string unNombreParticular, string unApellidoParticular, string unDocumentoParticular)
        {
            Particular unParticular = new Particular(unNombreUsuario, unaClave, unaDireccion, unTelefono, unNombreParticular, unApellidoParticular, unDocumentoParticular);
            listaUsuarios.Add(unParticular);
            listaCompradores.Add(unParticular);
        }

        public void crearUsuarioCompradorEmpresa(string unNombreUsuario, string unaClave, string unaDireccion, string unTelefono, string unaPersonaContacto, string unaRazonSocial, string unRut)
        {
            Empresa unaEmpresa = new Empresa(unNombreUsuario, unaClave, unaDireccion, unTelefono, unaPersonaContacto, unaRazonSocial, unRut);
            listaUsuarios.Add(unaEmpresa);
            listaCompradores.Add(unaEmpresa);
        }
        #endregion

        #region METODOS CON LISTAS
        public List<Lugar> devolverListaLugares()
        { //metodo que devuleve la lista de lugares
            return listaLugares;
        }

        public List<Rematador> devolverListaRematadores()
        { //metodo que devuelve la lista de rematadores
            return listaRematadores;
        }

        public List<Rematador> devolverListaRematadoresActivosEnElAño()
        { //metodo que devuelve la lista de rematadores que participaron de uno o mas remates en el año
            List<Rematador> listaRematadoresActivosEnElAño = new List<Rematador>();
            foreach (Remate R in listaRemates)
            {
                double comTmp;
                if (R.Cerrado ==true && R.Fecha.Year == DateTime.Today.Year)
                {
                    if (listaRematadoresActivosEnElAño.Count != 0)
                    {
                        foreach (Rematador tmp in listaRematadoresActivosEnElAño)
                        {
                            foreach (Rematador tmp2 in listaRematadoresActivosEnElAño)
                            {
                                if (tmp.IdRematador == tmp2.IdRematador)//si ya existe solo lke agrego comision
                                {
                                    comTmp = Convert.ToDouble(R.Rematador.ComisionRematador);//obtengo el valor que ya tenia convirtiendolo 
                                    R.Rematador.ComisionRematador = ((comTmp + devolverComisionRematador(R.IdRemate)).ToString());//le agrego el nuevo y lo substituyo
                                }
                                else
                                {// si termine de recorrer y no lo encontre, lo creo como objeto
                                    R.Rematador.ComisionRematador = ((comTmp = devolverComisionRematador(R.IdRemate)).ToString());
                                    listaRematadoresActivosEnElAño.Add(R.Rematador);
                                }
                            }
                        }
                    }
                    else // lo creo porque la lista esta vacia, solo entra aca una y solo una vez
                    {
                        R.Rematador.ComisionRematador = ((comTmp = devolverComisionRematador(R.IdRemate)).ToString());
                        listaRematadoresActivosEnElAño.Add(R.Rematador);
                    }  
                } 
            }
            return listaRematadoresActivosEnElAño;
        }
            
        public List<Lote> devolverListaLotesDisponibles()
        {
            List<Lote> listaLotesDiponibles = new List<Lote>();
            foreach (Lote tmpLote in listaLotes)
            {
                if (tmpLote.FueAsignado == false)
                {
                    listaLotesDiponibles.Add(tmpLote);
                }
            }
            return listaLotesDiponibles;
        } //metodo que devuleve la lista de lotes disponibles para ser asignados a un nuevo remate

        public List<Remate> devolverListaRemates()
        {
            return listaRemates;

        } //metodo qeu develve la lista de remates

        public List<Remate> devolverListaRematesCerradosPorRematador(int unIdRem)
        {
            List<Remate> listaRematesCerradosRematador = new List<Remate>();
            foreach (Remate tmpRemate in listaRemates)
            {
                if (tmpRemate.Cerrado == true && tmpRemate.Rematador.IdRematador == unIdRem)
                {
                    listaRematesCerradosRematador.Add(tmpRemate);
                }
            }
            return listaRematesCerradosRematador;

        } //metodo qeu develve la lista de remates cerrados de un rematador

        public List<Remate> devolverRematesPorFecha(DateTime unaFechaDesde, DateTime unaFechaHasta)
        {
            List<Remate> listaRematesPorFecha = new List<Remate>();
            foreach (Remate tmpRemate in listaRemates)
            {
                if (tmpRemate.Fecha >= unaFechaDesde && tmpRemate.Fecha <= unaFechaHasta)
                {
                    listaRematesPorFecha.Add(tmpRemate);
                }
            }
            return listaRematesPorFecha;
        } //metodo que devuleve la lista de remates disponibles validando un intervalo de fechas

        public List<Remate> devolverRematesDisponibles()
        {
            List<Remate> listaRematesDisponibles = new List<Remate>();
            foreach (Remate tmpRemate in listaRemates)
            {
                if (tmpRemate.Cerrado == false)
                {
                    listaRematesDisponibles.Add(tmpRemate);
                }
            }
            return listaRematesDisponibles;
        } //metodo que devuleve la lista de remates disponibles para utilizar en asignar lotes a remate.

        public void darBajaRematador(Rematador unRematador)
        {
            listaRematadores.Remove(unRematador);
        }//metodo que elimina un objeto rematador de la lista de rematadores validando que no tenga remates en el futuro (metodo 'tieneRematesAsignados')

        public List<Usuario> devolverListaUsuarios()
        {
            return listaUsuarios;

        } //metodo que develve la lista de usuarios

        public List<Comprador> devolverListaCompradores()
        {
            return listaCompradores;

        } //metodo que develve la lista de compradores

        public List<Comprador> devolverListaCompradoresQueParticiparonDeRemate(int unIdRemate)//metodo que recibe un idRemate como parametro y retorna una lista de compradores que participaron del mismo
        {
            List<Comprador> listaCompradoresQueParticiparonDeRemate = new List<Comprador>();

            foreach(Comprador C in listaCompradores)
            {
                if (C.participoDeRemate(unIdRemate))
                {
                    listaCompradoresQueParticiparonDeRemate.Add(C);
                }
            }

            return listaCompradoresQueParticiparonDeRemate;

        } //metodo qeu develve la lista de compradores

        #endregion

        #region VALIDACIONES
        public bool validoLugarFecha(DateTime unaFecha, int unIdLugar)
        { //metodo que valida la disponibilidad de la combinacion fecha/lugar
            bool retorno = true;
            foreach (Remate r in listaRemates)
            {
                if (r.Lugar.IdLugar == unIdLugar && r.Fecha == unaFecha)
                {
                    retorno = false;
                }
            }
            return retorno;
        }

        public int validarUsuario(string unNombre, string unaClave)
        {
            Usuario u = new Usuario();
            int retorno = 0;
            u.NombreUsuario = unNombre;
            u.Clave = unaClave;
            int indice = listaUsuarios.IndexOf(u);
            if (indice != -1)
            {

                u = listaUsuarios[indice]; //traigo todo el objeto usuario
                if (u.Clave.Equals(unaClave))
                {
                    retorno = u.devolverTipo();
                }
            }
            return retorno;
        }//metodo que valida usuario y devuelve su tipo

        public bool tieneRematesAsignados(int unIdRematador)
        {
            bool retonro = false;
            bool loEncontre = false;
            foreach (Remate r in listaRemates)
            {
                if (r.Cerrado == false && r.Rematador.IdRematador == unIdRematador && !loEncontre)
                {
                    retonro = true;
                    loEncontre = true;
                }
            }
            return retonro;
        }//valida que el rematador a ser dado de baja no tenga remates a relaizar em el furuto

        public bool nombreusuarioYaExiste(string unNombreUsuario){
            bool loEncontre = false;
            int pos = 0;
            List<Usuario> listaUsuarios = devolverListaUsuarios();
            while (pos < listaUsuarios.Count && !loEncontre)
            {
                // Recorro hasta que lo encuentre
                if (listaUsuarios[pos].NombreUsuario == unNombreUsuario)
                {
                    loEncontre = true;
                }
                pos++;
            }
            return loEncontre;
        }//metodo que valida que el nombre de usuario ya no haya sido usado

        public bool stringEsSoloNumeros(string unString) { 
            foreach (char c in unString){
                if (c < '0' || c > '9') { 
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region METODOS DE BUSQUEDA
        public Lugar buscarLugar(int unIdLugar)
        {
            Lugar retorno = null;
            bool loEncontre = false;
            int pos = 0;
            List<Lugar> listaDisponibles = devolverListaLugares();
            while (pos < listaDisponibles.Count && !loEncontre)
            {
                // Recorro hasta que lo encuentre
                if (listaDisponibles[pos].IdLugar == unIdLugar)
                {
                    retorno = listaDisponibles[pos];
                    loEncontre = true;
                }
                pos++;
            }
            return retorno;
        }

        public Rematador buscarRematador(int unIdRematador)
        {
            Rematador retorno = null;
            bool loEncontre = false;
            int pos = 0;
            while (pos < listaRematadores.Count && !loEncontre)
            {
                // Recorro hasta que lo encuentre
                if (listaRematadores[pos].IdRematador == unIdRematador)
                {
                    retorno = listaRematadores[pos];
                    loEncontre = true;
                }
                pos++;
            }
            return retorno;
        } //método que devuelve un objeto rematador, recibiendo su id como parámetro 

        public Comprador buscarComprador(string unNomUsuarioComprador){
            Comprador retorno = null;
            bool loEncontre = false;
            int pos = 0;
            while (pos < listaCompradores.Count && !loEncontre)
            {
                // Recorro hasta que lo encuentre
                if (listaCompradores[pos].NombreUsuario == unNomUsuarioComprador)
                {
                    retorno = listaCompradores[pos];
                    loEncontre = true;
                }
                pos++;
            }
            return retorno;
        } //método que devuelve un objeto comprador, recibiendo su nombre de usuario como parámetro

        public Rematador buscarRematadorPorNombreUsuario(string unNomUsuarioRematador)
        {
            Rematador retorno = null;
            bool loEncontre = false;
            int pos = 0;
            while (pos < listaRematadores.Count && !loEncontre)
            {
                // Recorro hasta que lo encuentre
                if (listaRematadores[pos].NombreUsuario == unNomUsuarioRematador)
                {
                    retorno = listaRematadores[pos];
                    loEncontre = true;
                }
                pos++;
            }
            return retorno;
        } //método que devuelve un objeto rematador, recibiendo su nombre de usuario como parámetro 

        public Lote buscarLoteDisponible(string unIdLote)
        {
            Lote retorno = null;
            bool loEncontre = false;
            int pos = 0;
            List<Lote> listaDisponibles = devolverListaLotesDisponibles();
            while (pos < listaDisponibles.Count && !loEncontre)
            {
                // Recorro hasta que lo encuentre
                if (listaDisponibles[pos].IdLote == unIdLote)
                {
                    retorno = listaDisponibles[pos];
                    loEncontre = true;
                }
                pos++;
            }
            return retorno;
        } //método que devuelve un objeto lote DISPONIBLE, recibiendo su id como parámetro

        public Lote buscarLote (string unIdLote)
        {
            Lote retorno = null;
            bool loEncontre = false;
            int pos = 0;
            while (pos < listaLotes.Count && !loEncontre)
            {
                // Recorro hasta que lo encuentre
                if (listaLotes[pos].IdLote == unIdLote)
                {
                    retorno = listaLotes[pos];
                    loEncontre = true;
                }
                pos++;
            }
            return retorno;
        } //método que devuelve un objeto lote, recibiendo su id como parámetro

        public Remate buscarRemate(int unIdRemate)
        {
            Remate retorno = null;
            bool loEncontre = false;
            int pos = 0;
            while (pos < listaRemates.Count && !loEncontre)
            {
                // Recorro hasta que lo encuentre
                if (listaRemates[pos].IdRemate == unIdRemate)
                {
                    retorno = listaRemates[pos];
                    loEncontre = true;
                }
                pos++;
            }
            return retorno;
        } //método que devuelve un objeto remate, recibiendo su id como 
        #endregion

        public void modificarDatosRematador(int unIdRematador, string unNombre, string unApellido, string unTelefono){
            Rematador unRematador = buscarRematador(unIdRematador);
            unRematador.NombreRematador = unNombre;
            unRematador.ApellidoRematador = unApellido;
            unRematador.TelefonoRematador = unTelefono;
        }

        public void cerrarRemate(int unIdRemate)
        {
            Remate unRemate = buscarRemate(unIdRemate);
            unRemate.Cerrado = true;
            unRemate.liberarLotesNoVendidos();
        }

        public double devolverComisionRematador(int unIdRemate)
        {
            Remate unRemate = buscarRemate(unIdRemate);
            double comisionRematador = unRemate.calcularComisionAPagarRematador();
            return comisionRematador;
        }
        #endregion
    }
}
