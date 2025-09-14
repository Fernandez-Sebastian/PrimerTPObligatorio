using System.Globalization;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mostrar la descripción del ejercicio y los integrantes.
            MostrarDescripcion();

            // Creamos una instancia de la clase Biblioteca que contendrá los lectores y libros.
            Biblioteca biblioteca = new();

            // ---- CREAR LECTORES ----
            // Bucle para crear Lectores
            Console.WriteLine("---- Crear Lectores ----");
            while (true)
            {
                // El método string.IsNullOrWhiteSpace(nombre) devuelve true si la cadena ingresada es vacía, contiene solo espacios en blanco o es null.
                Console.Write("Ingrese nombre del lector (ENTER para terminar): ");
                string nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre)) break;

                Console.WriteLine();

                // Agregar validación para que el valor ingresado sea un número con al menos 7 / 8 dígitos.
                Console.Write("Ingrese DNI del lector: ");
                string dni = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(dni))
                {
                    Console.WriteLine("DNI no puede estar vacío. Intente de nuevo.");
                    continue;
                }

                Console.WriteLine();

                // Agregar validación para que el valor ingresado sea un número con al menos 7 / 8 dígitos.
                Console.Write("Ingrese direccion: ");
                string direccion = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(dni))
                {
                    Console.WriteLine("Direccion no puede estar vacío. Intente de nuevo.");
                    continue;
                }
                Console.WriteLine();
                // Una vez ingresado el Nombre y el DNI, doy de alta el Lector. 
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
                    Console.Write("Ingrese fecha de lanzamiento: ");
                    if (DateTime.TryParse(Console.ReadLine(), CultureInfo.CurrentCulture, DateTimeStyles.None, out fechaLanzamiento))
                        break;
                    else
                        Console.WriteLine("Formato inválido. Intente de nuevo.");
                }

                // Una vez se validaron todos los campos, se crea el nuevo libro y se agrega al listado de libros disponibles de la biblioteca.
                // Mostramos cartel de que se agrego con éxito.
                Libro nuevoLibro = new(titulo, genero, fechaLanzamiento, autor);
                biblioteca.LibrosDisponibles.Add(nuevoLibro);
                Console.WriteLine($"Libro '{titulo}' agregado correctamente.\n");
            }

            // ---- PRESTAR LIBROS ----
            // Bucle para prestar libros a un Lector
            while (true)
            {
                Console.Write("¿Desea prestar un libro? (s/n): ");
                string resp = Console.ReadLine().ToLower();
                if (resp != "s") break;

                // Se muestra los libros disponibles
                biblioteca.MostrarLibros();
                Console.WriteLine();

                //se muestran los lectores registrados
                biblioteca.MostrarLectores();
                Console.WriteLine();

                // Se pueden agregar validaciones al leer el titulo que no sea vacío.
                Console.Write("Ingrese título del libro a prestar: ");
                string tituloPrestamo = Console.ReadLine();
                Console.WriteLine();

                // Se puede agregar validaciones para que se ingrese números de DNI correctos.
                Console.Write("Ingrese DNI del lector: ");
                string dniLector = Console.ReadLine();
                Console.WriteLine();

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