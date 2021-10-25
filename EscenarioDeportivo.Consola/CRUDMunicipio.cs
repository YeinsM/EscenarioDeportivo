using System;
using System.Collections.Generic;
using EscenarioDeportivo.Persistencia;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Consola
{
    public class CRUDMunicipio
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio(new EscenarioDeportivo.Persistencia.AppContext());
        public static void menuCrudMunicipio()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("===== MENU CRUD MUNICIPIO ====");
                Console.WriteLine("1. Crear Municipio");
                Console.WriteLine("2. Buscar Municipio");
                Console.WriteLine("3. Listar Municipios");
                Console.WriteLine("4. Actualizar Municipio");
                Console.WriteLine("5. Eliminar Municipio");
                Console.WriteLine("6. Salir");
                Console.WriteLine("Elegir una opción:");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        bool ejecutado = crearMunicipio();
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
                        buscarMunicipio();
                        break;
                    case 3:
                        listarMunicipios();
                        break;
                    case 4:
                        bool actualizado = actualizarMunicipio();
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
                        bool elmininado = eliminarMunicipio();
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
                        Console.WriteLine("Elefir una de las opciones!!");
                        break;
                }
            }
        }
        #region [MUNICIPIO]
        private static bool crearMunicipio()
        {
            Console.WriteLine("Digite el nombre del Municipio: ");
            String _nombre = Console.ReadLine();
            var municipio = new Municipio
            {
                Nombre = _nombre
            };
            bool validaEjecucion = _repoMunicipio.CrearMunicipio(municipio);
            return validaEjecucion;
        }
        private static void listarMunicipios()
        {
            IEnumerable<Municipio> municipios = _repoMunicipio.ListarMunicipios();
            if (municipios != null)
            {
                if (municipios.Count() > 0)
                {
                    foreach (var mun in municipios)
                    {
                        Console.WriteLine(mun.Id + " - " + mun.Nombre);
                    }
                }
                else
                {
                    Console.WriteLine("No hay Muncipios inscritos.");
                }
            }
            else
            {
                Console.WriteLine("No hay Muncipios inscritos.");
            }
        }
        private static bool eliminarMunicipio()
        {
            Console.WriteLine("Digite el Id de Municipio a eliminar:");
            int _id = Convert.ToInt32(Console.ReadLine());
            bool eliminado = _repoMunicipio.EliminarMunicipio(_id);
            return eliminado;
        }
        private static bool actualizarMunicipio()
        {
            bool actualizado = false;
            int _id = 0;
            Console.WriteLine("Digite el ID del Municipio a modificar:");
            bool _idNum = int.TryParse(Console.ReadLine(), out _id);
            if (_idNum)
            {
                Console.WriteLine("Digite el nuevo nombre del Municipio:");
                String _nombre = Console.ReadLine();
                var municipio = new Municipio
                {
                    Id = _id,
                    Nombre = _nombre
                };
                actualizado = _repoMunicipio.ActualizarMunicipio(municipio);
            }
            else
            {
                Console.WriteLine("Digite únicamente número.");
            }
            return actualizado;
        }
        private static void buscarMunicipio()
        {
            Console.WriteLine("Por favor digite el ID del Municipio:");
            int _id = Convert.ToInt32(Console.ReadLine());
            var munBuscar = _repoMunicipio.BuscarMunicipio(_id);
            if (munBuscar != null)
            {
                Console.WriteLine("Se encontró " + munBuscar.Nombre + " del Id = " + munBuscar.Id);
            }
            else
            {
                Console.WriteLine("No se encontró el Id = " + munBuscar.Id);
            }
        }
        #endregion

    }
}