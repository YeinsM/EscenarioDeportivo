using System;
using System.Collections.Generic;
using EscenarioDeportivo.Persistencia;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Consola
{
    public class CRUDPatrocinador
    {
        private static IRepositorioPatrocinador _repoPatrocinador = new RepositorioPatrocinador(new EscenarioDeportivo.Persistencia.AppContext());
        public static void menuCrudPatrocinador()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("===== MENU CRUD PATROCINADOR ====");
                Console.WriteLine("1. Crear Patrocinador");
                Console.WriteLine("2. Buscar Patrocinador");
                Console.WriteLine("3. Listar Patrocinador");
                Console.WriteLine("4. Actualizar Patrocinador");
                Console.WriteLine("5. Eliminar Patrocinador");
                Console.WriteLine("6. Salir");
                Console.WriteLine("Elegir una opción:");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        bool ejecutado = crearPatrocinador();
                        if (ejecutado)
                        {
                            Console.WriteLine("Se adicionó con éxito");
                        }
                        else
                        {
                            Console.WriteLine("Se presentaron fallas");
                        }
                        break;
                    case 2:
                        buscarPatrocinador();
                        break;
                    case 3:
                        listarPatrocinadores();
                        break;
                    case 4:
                        bool actualizado = actualizarPatrocinador();
                        if (actualizado)
                        {
                            Console.WriteLine("Se actualizó con éxito");
                        }
                        else
                        {
                            Console.WriteLine("Se presentaron fallas");
                        }
                        break;
                    case 5:
                        bool elmininado = eliminarPatrocinador();
                        if (elmininado)
                        {
                            Console.WriteLine("Se eliminó con éxito");
                        }
                        else
                        {
                            Console.WriteLine("Se presentaron fallas");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Salimos de este Menú. Hasta luego!!");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Elegir una de las opciones!!");
                        break;
                }
            }
        }

        #region [PATROCINADOR]
        private static bool crearPatrocinador()
        {
            Console.WriteLine("Digite la identificación del Patrocinador: ");
            String _identificacion = Console.ReadLine();
            Console.WriteLine("Digite el nombre del Patrocinador: ");
            String _nombre = Console.ReadLine();
            String _tipoPersona = "otro";
            while (_tipoPersona.Equals("otro"))
            {
                Console.WriteLine("Digite:\nN -> Natural\nJ -> Jurídico");
                _tipoPersona = Console.ReadLine();
                if (!_tipoPersona.Equals("N") && !_tipoPersona.Equals("J"))
                {
                    _tipoPersona = "otro";
                    Console.WriteLine("Digito errado!!");
                }
            }
            Console.WriteLine("Digite su Dirección: ");
            String _direccion = Console.ReadLine();
            Console.WriteLine("Digite su número de Teléfono: ");
            String _telefono = Console.ReadLine();
            var patrocinador = new Patrocinador
            {
                Identificacion = _identificacion
                ,
                Nombre = _nombre
                ,
                TipoPersona = _tipoPersona
                ,
                Direccion = _direccion
                ,
                Telefono = _telefono
            };
            bool validaEjecucion = _repoPatrocinador.CrearPatrocinador(patrocinador);
            return validaEjecucion;
        }
        private static void buscarPatrocinador()
        {
            Console.WriteLine("Digite la identificación del Patrocinador:");
            string _identificacion = Console.ReadLine();
            var patBuscar = _repoPatrocinador.BuscarPatrocinador(_identificacion);
            if (patBuscar != null)
            {
                Console.WriteLine("Se encontró a " + patBuscar.Nombre + " - " + patBuscar.TipoPersona + ", Identificación = " + patBuscar.Identificacion);
            }
            else
            {
                Console.WriteLine("No se encontró el documento = " + _identificacion);
            }
        }
        private static void listarPatrocinadores()
        {
            IEnumerable<Patrocinador> patrocinadores = _repoPatrocinador.ListarPatrocinadores();
            if (patrocinadores != null)
            {
                if (patrocinadores.Count() > 0)
                {
                    foreach (var pat in patrocinadores)
                    {
                        Console.WriteLine(pat.Identificacion + " - " + pat.Nombre + " - " + pat.TipoPersona);
                    }
                }
                else
                {
                    Console.WriteLine("No hay Patrocinadores inscritos.");
                }
            }
            else
            {
                Console.WriteLine("No hay Patrocinadores inscritos.");
            }
        }
        private static bool actualizarPatrocinador()
        {
            bool actualizado = false;
            Console.WriteLine("Digite la identificación del Patrocinador:");
            string _identificacion = Console.ReadLine();
            var _patrocinador = _repoPatrocinador.BuscarPatrocinador(_identificacion);
            if (_patrocinador != null)
            {
                int _opc = 0;
                while (_opc < 1 && _opc > 4)
                {
                    Console.WriteLine("Escoja el dato a modificar:");
                    Console.WriteLine("1. Nombre:");
                    Console.WriteLine("2. TipoPersona:");
                    Console.WriteLine("3. Direccion:");
                    Console.WriteLine("4. Telefono:");
                    bool _idNum = int.TryParse(Console.ReadLine(), out _opc);
                    if (!_idNum)
                        _opc = 0;
                    switch (_opc)
                    {
                        case 1:
                            Console.WriteLine("Digite el nuevo Nombre del Patrocinador:");
                            _patrocinador.Nombre = Console.ReadLine();
                            break;
                        case 2:
                            String _tipoPersona = "otro";
                            while (_tipoPersona.Equals("otro"))
                            {
                                Console.WriteLine("Digite el nuevo Tipo del Patrocinador:");
                                Console.WriteLine("Digite:\nN -> Natural\nJ -> Jurídico");
                                _tipoPersona = Console.ReadLine();
                                if (!_tipoPersona.Equals("N") && !_tipoPersona.Equals("J"))
                                {
                                    _tipoPersona = "otro";
                                    Console.WriteLine("Digito errado!!");
                                }
                            }
                            _patrocinador.TipoPersona = _tipoPersona;
                            break;
                        case 3:
                            Console.WriteLine("Digite la nueva Dirección del Patrocinador:");
                            _patrocinador.Direccion = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Digite el nuevo Teléfono del Patrocinador:");
                            _patrocinador.Telefono = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Selección errada!!");
                            break;
                    }
                }
                actualizado = _repoPatrocinador.ActualizarPatrocinador(_patrocinador);
            }
            else
            {
                Console.WriteLine("El patrocinador no existe!!");
            }
            return actualizado;
        }
        private static bool eliminarPatrocinador()
        {
            Console.WriteLine("Digite la identificación del patrocinador a eliminar:");
            String _identificacion = Console.ReadLine();
            bool eliminado = _repoPatrocinador.EliminarPatrocinador(_identificacion);
            return eliminado;
        }
        #endregion
    }
}