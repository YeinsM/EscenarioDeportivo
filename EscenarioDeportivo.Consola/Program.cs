using System;

/*
Hace falta crear el menú para el CRUD por Consola y ponerlo en el Main
*/

namespace EscenarioDeportivo.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            menuPrincipal();
        }
        private static void menuPrincipal()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("===== MENU PRINCIPAL ====");
                Console.WriteLine("1. CRUD Patrocinador");
                Console.WriteLine("2. CRUD Municipio");
                Console.WriteLine("3. CRUD Deportista");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Elegir una opción:");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CRUDPatrocinador.menuCrudPatrocinador();
                        break;
                    case 2:
                        CRUDMunicipio.menuCrudMunicipio();
                        break;
                    case 3:
                        CRUDDeportista.menuCrudDeportista();
                        break;
                    case 4:
                        Console.WriteLine("Salimos de la Aplicación. Hasta luego!!");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Elefir una de las opciones!!");
                        break;
                }
            }
        }
    }
}
