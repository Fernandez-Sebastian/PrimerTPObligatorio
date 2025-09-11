using System;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();

            // ---- CREAR LECTORES ----
            Console.WriteLine("---- Crear Lectores ----");
            while (true)
            {
                Console.Write("Ingrese nombre del lector (ENTER para terminar): ");
                string nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre)) break;

                Console.Write("Ingrese DNI del lector: ");
                string dni = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(dni))
                {
                    Console.WriteLine("DNI no puede estar vacío. Intente de nuevo.");
                    continue;
                }

                biblioteca.AltaLector(nombre, dni);
            }

            // ---- CREAR LIBROS ----
            Console.WriteLine("\n---- Crear Libros ----");
            while (true)
            {
                Console.Write("Ingrese título del libro (ENTER para terminar): ");
                string titulo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(titulo)) break;

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
                    Console.Write("Ingrese fecha de lanzamiento (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out fechaLanzamiento))
                        break;
                    else
                        Console.WriteLine("Formato inválido. Intente de nuevo.");
                }

                var nuevoLibro = new Libro(titulo, genero, fechaLanzamiento, autor);
                biblioteca.LibrosDisponibles.Add(nuevoLibro);
                Console.WriteLine($"Libro '{titulo}' agregado correctamente.\n");
            }

            // ---- PRESTAR LIBROS ----
            while (true)
            {
                Console.Write("¿Desea prestar un libro? (s/n): ");
                string resp = Console.ReadLine().ToLower();
                if (resp != "s") break;

                biblioteca.MostrarLibros();

                Console.Write("Ingrese título del libro a prestar: ");
                string tituloPrestamo = Console.ReadLine();

                Console.Write("Ingrese DNI del lector: ");
                string dniLector = Console.ReadLine();

                string resultado = biblioteca.PrestarLibro(tituloPrestamo, dniLector);
                Console.WriteLine(resultado + "\n");
            }

            Console.WriteLine("¡Gracias por usar la biblioteca!");
        }
    }
}