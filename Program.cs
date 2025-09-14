using System;
using System.Net;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mostrar la descripción del ejercicio y los integrantes.
            MostrarDescripcion();

            // Creamos una instancia de la clase Biblioteca que contendrá los lectores y libros.
            Biblioteca biblioteca = new Biblioteca();

            int dniNumero;

            // ---- CREAR LECTORES ----
            // Bucle para crear Lectores
            Console.WriteLine("---- Crear Lectores ----");
            while (true)
            {
                // El método string.IsNullOrWhiteSpace(nombre) devuelve true si la cadena ingresada es vacía, contiene solo espacios en blanco o es null.
                Console.Write("Ingrese nombre del lector (ENTER para terminar): ");
                string nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre)) break;
                
                string dni;
                string direccion;
                while (true) { 
                    Console.Write("Ingrese DNI del lector: ");
                    dni = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(dni))
                    {
                        Console.WriteLine("DNI no puede estar vacío. Intente de nuevo.");
                        continue;
                    }
                    else if (!int.TryParse(dni, out dniNumero))
                    {
                        Console.WriteLine("El DNI debe contener solo números. Intente de nuevo.");
                        continue;
                    }
                    else if (dni.Length < 7 || dni.Length > 8)
                    {
                        Console.WriteLine("El DNI debe tener 7 u 8 dígitos. Intente de nuevo.");
                        continue;
                    }
                    break;
                }

                while (true) { 
                    Console.Write("Ingrese dirección: ");
                    direccion = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(direccion))
                    {
                        Console.WriteLine("Dirección no puede estar vacío. Intente de nuevo.");
                        continue;
                    }
                    break;
                }
                // Una vez ingresado el Nombre, el DNI y la dirección doy de alta el Lector. 
                biblioteca.AltaLector(nombre, dni, direccion);
            }

            // ---- CREAR LIBROS ----
            // Bucle para crear Libros
            Console.WriteLine("\n---- Crear Libros ----");
            while (true)
            {
                Console.Write("Ingrese título del libro (ENTER para terminar): ");
                string titulo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(titulo)) break;

                // Se busca que el título ingresado exista en el listado de libros cargados.
                // Si existe pedimos que ingrese otro título, para evitar registrar libros duplicados.
                if (biblioteca.ExisteLibro(titulo))
                {
                    Console.WriteLine("El libro ya existe en la biblioteca. Intente con otro título.");
                    continue;
                }

                Console.Write("Ingrese género del libro: ");
                string genero = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(genero))
                {
                    Console.WriteLine("El género no puede estar vacío.");
                    genero = Console.ReadLine();
                }

                Console.Write("Ingrese autor del libro: ");
                string autor = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(autor))
                {
                    Console.WriteLine("El autor no puede estar vacío.");
                    autor = Console.ReadLine();
                }

                DateTime fechaLanzamiento;
                while (true)
                {
                    // DateTime.TryParse(string, out DateTime) Éste método intenta convertir la cadena en un valor de tipo DateTime (fecha y hora).
                    // Primer parámetro es la cadena que queremos convertir.
                    // El segundo parámetro es out fechaLanzamiento: si la conversión es exitosa, el valor convertido se guarda en esta variable.
                    // TryParse devuelve true si el usuario ingreso una fecha válida, de lo contrario pide ingresar una nueva fecha.
                    Console.Write("Ingrese fecha de lanzamiento (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out fechaLanzamiento))
                        break;
                    else
                        Console.WriteLine("Formato inválido. Intente de nuevo.");
                }

                // Una vez se validaron todos los campos, se crea el nuevo libro y se agrega al listado de libros disponibles de la biblioteca.
                // Mostramos cartel de que se agrego con éxito.
                var nuevoLibro = new Libro(titulo, genero, fechaLanzamiento, autor);
                biblioteca.LibrosDisponibles.Add(nuevoLibro);
                Console.WriteLine($"Libro '{titulo}' agregado correctamente.\n");
            }

            // ---- PRESTAR LIBROS ----
            // Bucle para prestar libros a un Lector
            string tituloPrestamo;
            while (true)
            {
                Console.Write("¿Desea prestar un libro? (s/n): ");
                string resp = Console.ReadLine().ToLower();
                if (resp != "s") break;

                // Se muestra los libros disponibles
                biblioteca.MostrarLibros();

                while (true) { 
                    Console.Write("Ingrese título del libro a prestar: ");
                    tituloPrestamo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(tituloPrestamo))
                    {
                        Console.WriteLine("Título no puede estar vacío. Intente de nuevo.");
                        continue;
                    }
                    break;
                }
                string dniLector;
                while (true) { 
                    Console.Write("Ingrese DNI del lector: ");
                    dniLector = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(dniLector))
                    {
                        Console.WriteLine("DNI no puede estar vacío. Intente de nuevo.");
                        continue;
                    }
                    else if (!int.TryParse(dniLector, out dniNumero))
                    {
                        Console.WriteLine("El DNI debe contener solo números. Intente de nuevo.");
                        continue;
                    }
                    else if (dniLector.Length < 7 || dniLector.Length > 8)
                    {
                        Console.WriteLine("El DNI debe tener 7 u 8 dígitos. Intente de nuevo.");
                        continue;
                    }
                    break;
                }
                string resultado = biblioteca.PrestarLibro(tituloPrestamo, dniLector);
                Console.WriteLine(resultado + "\n");
            }

            Console.WriteLine("¡Gracias por usar la biblioteca!");
        }

        // Método que muestra una descripción antes de cargar el programa.
        static void MostrarDescripcion()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("Ejercicio: agregar enunciado del ejercicio ");
            Console.WriteLine("Descripción: agregar una descripción");
            Console.WriteLine("Integrantes: agregar listado de integrantes");
            Console.WriteLine("==================================================\n");
        }
    }
}