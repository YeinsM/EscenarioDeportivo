using System;
using System.Collections.Generic;
using EscenarioDeportivo.Persistencia;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Consola
{
    public class CRUDDeportista
    {
        private static IRepositorioDeportista _repoDeportista = new RepositorioDeportista(new EscenarioDeportivo.Persistencia.AppContext());
        public static void menuCrudDeportista()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("===== MENU CRUD DEPORTISTA ====");
                Console.WriteLine("1. Crear Deportista");
                Console.WriteLine("2. Buscar Deportista");
                Console.WriteLine("3. Listar Deportista");
                Console.WriteLine("4. Actualizar Deportista");
                Console.WriteLine("5. Eliminar Deportista");
                Console.WriteLine("6. Salir");
                Console.WriteLine("Elegir una opción:");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        bool ejecutado = crearDeportista();
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
                        buscarDeportista();
                        break;
                    case 3:
                        listarDeportistas();
                        break;
                    case 4:
                        bool actualizado = actualizarDeportista();
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
                        bool elmininado = eliminarDeportista();
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
        #region [DEPORTISTA]
        private static bool crearDeportista()
        {
            Console.WriteLine("Digite el documento del Deportista: ");
            String _documento = Console.ReadLine();
            Console.WriteLine("Digite los nombres del Deportista: ");
            String _nombre = Console.ReadLine();
            Console.WriteLine("Digite los apellidos del Deportista: ");
            String _apellido = Console.ReadLine();
            String _genero = "otro";
            while (_genero.Equals("otro"))
            {
                Console.WriteLine("Digite:\nM -> Masculino\nF -> Femenino");
                _genero = Console.ReadLine();
                if (!_genero.Equals("M") && !_genero.Equals("F"))
                {
                    _genero = "otro";
                    Console.WriteLine("Digito errado!!");
                }
            }
            Console.WriteLine("Digite su Rh: ");
            String _rh = Console.ReadLine();
            Console.WriteLine("Digite su EPS: ");
            String _eps = Console.ReadLine();
            DateTime _dt;
            String _fecha = "01-01-2021";
            while (!DateTime.TryParseExact(_fecha, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _dt))
            {
                Console.WriteLine("Digite Fecha de nacimiento con formato 'Año-Mes-Día' (2021-12-31):");
                _fecha = Console.ReadLine();
            }
            Console.WriteLine("Digite su Disciplina: ");
            String _disciplina = Console.ReadLine();
            Console.WriteLine("Digite su Dirección: ");
            String _direccion = Console.ReadLine();
            var deportista = new Deportista
            {
                Documento = _documento
                ,
                Nombres = _nombre
                ,
                Apellidos = _apellido
                ,
                Genero = _genero
                ,
                Rh = _rh
                ,
                EPS = _eps
                ,
                FechaNacimiento = DateTime.Parse(_fecha)
                ,
                Disciplina = _disciplina
                ,
                Direccion = _direccion
            };
            bool validaEjecucion = _repoDeportista.CrearDeportista(deportista);
            return validaEjecucion;
        }
        private static void buscarDeportista()
        {
            Console.WriteLine("Digite el Documento del Deportista:");
            string _documento = Console.ReadLine();
            var depBuscar = _repoDeportista.BuscarDeportista(_documento);
            if (depBuscar != null)
            {
                Console.WriteLine("Se encontró a " + depBuscar.Nombres + " " + depBuscar.Apellidos + ", fecha de nacimiento = " + depBuscar.FechaNacimiento);
            }
            else
            {
                Console.WriteLine("No se encontró el documento = " + _documento);
            }
        }
        private static void listarDeportistas()
        {
            IEnumerable<Deportista> deportistas = _repoDeportista.ListarDeportistas();
            if (deportistas != null)
            {
                if (deportistas.Count() > 0)
                {
                    foreach (var dep in deportistas)
                    {
                        Console.WriteLine(dep.Documento + " - " + dep.Nombres + " - " + dep.FechaNacimiento);
                    }
                }
                else
                {
                    Console.WriteLine("No hay Deportistas inscritos.");
                }
            }
            else
            {
                Console.WriteLine("No hay Deportistas inscritos.");
            }
        }
        private static bool eliminarDeportista()
        {
            Console.WriteLine("Digite el Documento del Deportista a eliminar:");
            String _documento = Console.ReadLine();
            bool eliminado = _repoDeportista.EliminarDeportista(_documento);
            return eliminado;
        }
        private static bool actualizarDeportista()
        {
            bool actualizado = false;
            Console.WriteLine("Digite el Documento del Deportista a modificar:");
            String _documento = Console.ReadLine();
            var _deportista = _repoDeportista.BuscarDeportista(_documento);
            if (_deportista != null)
            {
                int _opc = 0;
                while (_opc < 1 && _opc > 8)
                {
                    Console.WriteLine("Escoja el dato a modificar:");
                    Console.WriteLine("1. Nombres:");
                    Console.WriteLine("2. Apellidos:");
                    Console.WriteLine("3. Genero:");
                    Console.WriteLine("4. Rh:");
                    Console.WriteLine("5. EPS:");
                    Console.WriteLine("6. Fecha de Nacimiento:");
                    Console.WriteLine("7. Disciplina:");
                    Console.WriteLine("8. Direccion:");
                    bool _idNum = int.TryParse(Console.ReadLine(), out _opc);
                    if (!_idNum)
                        _opc = 0;
                    switch (_opc)
                    {
                        case 1:
                            Console.WriteLine("Digite los nuevos Nombres del Deportista:");
                            _deportista.Nombres = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Digite los nuevos Apellidos del Deportista:");
                            _deportista.Apellidos = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Digite el nuevo Genero del Deportista:");
                            String _genero = "otro";
                            while (_genero.Equals("otro"))
                            {
                                Console.WriteLine("Digite:\nM -> Masculino\nF -> Femenino");
                                _genero = Console.ReadLine();
                                if (!_genero.Equals("M") || !_genero.Equals("F"))
                                {
                                    _genero = "otro";
                                    Console.WriteLine("Digito errado!!");
                                }
                            }
                            _deportista.Genero = _genero;
                            break;
                        case 4:
                            Console.WriteLine("Digite el nuevo Rh del Deportista:");
                            _deportista.Rh = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Digite la nueva EPS del Deportista:");
                            _deportista.EPS = Console.ReadLine();
                            break;
                        case 6:
                            DateTime _dt;
                            String _fecha = "01-01-2021";
                            while (!DateTime.TryParseExact(_fecha, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _dt))
                            {
                                Console.WriteLine("Digite la nueva Fecha de Nacimiento del Deportista con formato 'Año-Mes-Día' (2021-12-31):");
                                _fecha = Console.ReadLine();
                            }
                            _deportista.FechaNacimiento = DateTime.Parse(_fecha);
                            break;
                        case 7:
                            Console.WriteLine("Digite la nueva Disciplina del Deportista:");
                            _deportista.Disciplina = Console.ReadLine();
                            break;
                        case 8:
                            Console.WriteLine("Digite la nueva Dirección del Deportista:");
                            _deportista.Direccion = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Selección errada!!");
                            break;
                    }
                }
                actualizado = _repoDeportista.ActualizarDeportista(_deportista);
            }
            else
            {
                Console.WriteLine("El deportista no existe!!");
            }
            return actualizado;
        }
        #endregion
    }
}