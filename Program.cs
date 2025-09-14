using System.Globalization;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaramos las variables que utilizaremos.
            int dniNumero;
            string dni;
            string direccion;
            string dniLector;
            string nombre;
            string titulo;
            string tituloPrestamo;
            string genero;
            string resp;

            // Mostrar la descripción del ejercicio y los integrantes.
            MostrarDescripcion();

            // Creamos una instancia de la clase Biblioteca que contendrá los lectores y libros.
            Biblioteca biblioteca = new();

            // ---- CREAR LECTORES ----
            // Bucle para crear Lectores
            Console.WriteLine("\nInicio del Sistema \n");
            Console.WriteLine("---- Crear Lectores ----");
            while (true)
            {
                // El método string.IsNullOrWhiteSpace(nombre) devuelve true si la cadena ingresada es vacía, contiene solo espacios en blanco o es null.
                Console.Write("Ingrese nombre del lector (ENTER para terminar): ");
                nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre)) break;
                
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

                Console.WriteLine();
                biblioteca.AltaLector(nombre, dni, direccion);
            }

            // ---- CREAR LIBROS ----
            // Bucle para crear Libros
            Console.WriteLine("\n---- Crear Libros ----");
            while (true)
            {
                Console.Write("Ingrese título del libro (ENTER para terminar): ");
                titulo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(titulo)) break;

                // Se busca que el título ingresado exista en el listado de libros cargados.
                // Si existe pedimos que ingrese otro título, para evitar registrar libros duplicados.
                if (biblioteca.ExisteLibro(titulo))
                {
                    Console.WriteLine("El libro ya existe en la biblioteca. Intente con otro título.");
                    continue;
                }

                Console.Write("Ingrese género del libro: ");
                genero = Console.ReadLine();
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
                Console.Write("\n ¿Desea prestar un libro? (s/n): ");
                resp = Console.ReadLine().ToLower();
                if (resp != "s") break;

                // Se muestra los libros disponibles
                biblioteca.MostrarLibros();
                Console.WriteLine();

                //se muestran los lectores registrados
                biblioteca.MostrarLectores();
                Console.WriteLine();

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
            Console.WriteLine("===================================================================================================================================================================================");
            Console.WriteLine("Desarrollo de Sistemas Orientado a Objetos \n");
            Console.WriteLine("Comisión B\n");
            Console.WriteLine("===================================================================================================================================================================================");
            Console.WriteLine("Enunciado TP: \n");
            Console.WriteLine("Usando el ejemplo de la biblioteca  visto durante la semana en la explicación, nos piden como requerimiento que la misma tenga una colección de lectores registrados. \r\n\r\nDe los lectores conocemos su nombre y dni.\r\n\r\nCada lector puede tener hasta un máximo de 3 prestamos vigentes. \r\n\r\nCuando se realiza un préstamo, se extrae de la biblioteca el libro para entregárselo al lector (si es que puede retirarlo).\r\n\r\nEs decir, se debe retirar el libro de la lista de libros que posee la biblioteca para asignársela a la lista de libros que posee el lector en préstamo.");
            Console.WriteLine("===================================================================================================================================================================================");
            Console.WriteLine("Integrantes: \n");
            Console.WriteLine("Ignacio, Grosman (33662091)");
            Console.WriteLine("Sebastián, Fernández (34741667)");
            Console.WriteLine("Glaucia, Ferreira (95858361)");
            Console.WriteLine("Andrea, Maslucan Moreno");
            Console.WriteLine("===================================================================================================================================================================================");
        }
    }
}