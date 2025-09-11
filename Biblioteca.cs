using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    public class Biblioteca
    {
        // lectores es una lista que almacena todos los lectores registrados en la biblioteca.
        // libros es una lista que almacena todos los libros disponibles para préstamo.
        // LibrosDisponibles es una variable de solo lectura que devuelve la lista de libros disponibles.

        private List<Lector> lectores = new List<Lector>();
        private List<Libro> libros = new List<Libro>();
        public List<Libro> LibrosDisponibles => libros;

        public Biblioteca()
        {
            //  cuando se crea una biblioteca, por defecto creo estos 14 libros.
            libros.Add(new Libro("Harry Potter 1", "Fantasía", new DateTime(1997, 6, 26), "J. K. Rowling"));
            libros.Add(new Libro("El Quijote", "Novela", new DateTime(1605, 1, 16), "Miguel de Cervantes"));
            libros.Add(new Libro("Cien Años de Soledad", "Realismo mágico", new DateTime(1967, 5, 30), "Gabriel García Márquez"));
            libros.Add(new Libro("Rayuela", "Novela", new DateTime(2000, 6, 28), "Julio Cortázar"));
            libros.Add(new Libro("La Iliada", "Épica", new DateTime(1980, 1, 1), "Homero"));
            libros.Add(new Libro("La Odisea", "Épica", new DateTime(1930, 1, 1), "Homero"));
            libros.Add(new Libro("Don Juan Tenorio", "Drama", new DateTime(1844, 1, 1), "José Zorrilla"));
            libros.Add(new Libro("El Principito", "Fantasía", new DateTime(1943, 4, 6), "Antoine de Saint-Exupéry"));
            libros.Add(new Libro("Hamlet", "Drama", new DateTime(1600, 1, 1), "William Shakespeare"));
            libros.Add(new Libro("Macbeth", "Drama", new DateTime(1606, 1, 1), "William Shakespeare"));
            libros.Add(new Libro("1984", "Distopía", new DateTime(1949, 6, 8), "George Orwell"));
            libros.Add(new Libro("Fahrenheit 451", "Distopía", new DateTime(1953, 10, 19), "Ray Bradbury"));
            libros.Add(new Libro("El Hobbit", "Fantasía", new DateTime(1937, 9, 21), "J.R.R. Tolkien"));
            libros.Add(new Libro("El Señor de los Anillos", "Fantasía", new DateTime(1954, 7, 29), "J.R.R. Tolkien"));
        }

        public void AltaLector(string nombre, string dni)
        {
            // Any devuelve true si algún lector tiene el mismo DNI.
            // Si existe un lector con el mismo DNI, devuelve un mensaje indicando que el lector con el DNI ingresado, ya existe.
            // Sino creo el nuevo lector con los valores pasados por parámetro y lo agrego a la lista de lectores.
            if (lectores.Any(lectorexistente => lectorexistente.Dni == dni))
            {
                Console.WriteLine($"El lector con DNI {dni} ya existe.");
                return;
            }
            lectores.Add(new Lector(nombre, dni));
            Console.WriteLine($"Lector {nombre} dado de alta correctamente.");
        }

        public string PrestarLibro(string titulo, string dni)
        {
            // En primera instancia me fijo que ponderación es mas alta a la hora de prestar un libro.
            // Sin importar el libro que elija, si no existe el lector es lo primero que tengo que tener en cuenta (ponderación mas alta).
            // Para ello busco el DNI en el listado de Lectores.
            // Con el return, corto la ejecución del método y no valido lo que sigue por debajo.
            // Si no existe, corto la ejecución y devuelvo "LECTOR INEXISTENTE".
            var lector = lectores.FirstOrDefault(lectorExistente => lectorExistente.Dni == dni);
            if (lector == null) return "LECTOR INEXISTENTE";

            // La segunda ponderación es si el Lector ya tiene al menos 3 libros prestados.
            // lector.LibrosPrestados.Count cuenta la cantidad de elementos (libros prestados) que tiene el Lector.
            // Recordamos que LibrosPrestados esta dentro de la clase Lector.
            // Si tiene 3 o más, devuelvo "TOPE DE PRESTAMO ALCANZADO"
            if (lector.LibrosPrestados.Count >= 3) return "TOPE DE PRESTAMO ALCANZADO";

            // La tercera ponderacion es buscar que el libro que exista.
            // Primero el método FirstOrDefault busca la primera coincidencia en el listado de Libros.
            // buscarLibro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase) esta acción, compara el titulo pasado por parametro
            // en el listado de Libros y además no diferencia mayúsculas de minúsculas.
            // Si no hay coincidencia devuelve el mensaje "LIBRO INEXISTENTE".

            var libro = libros.FirstOrDefault(buscarLibro => buscarLibro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (libro == null) return "LIBRO INEXISTENTE";

            // En caso que de que pasó las validaciones anteriores, queire decir que el libro está listo para ser prestado.
            // Agrego el libro a los libros prestados del lector y lo quito del listado de libros disponibles.
            // Tambien devuelvo el mensaje "PRESTAMO EXITOSO".
            lector.LibrosPrestados.Add(libro);
            libros.Remove(libro);
            return "PRESTAMO EXITOSO";
        }

        public void MostrarLibros()
        {
            // Muestra por consola el listado de libros disponibles.
            // En caso de no tener libros disponibles, se muestra "No hay libros disponibles.".
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros disponibles.");
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("Libros disponibles:");
            Console.WriteLine("");
            // Recorro el listado de Libros y por cada objeto muestro los atributos que tienen (Titulo, Autor, Genero,FechaLanzamiento).
            // El método ToShortDateString transforma una fecha en una cadena y la formatea dependiendo el uso horario configurado en la PC.
            foreach (var libro in libros)
            {
                Console.WriteLine($"- {libro.Titulo} | {libro.Autor} | {libro.Genero} | {libro.FechaLanzamiento.ToShortDateString()}");
            }
        }

        public bool ExisteLibro(string titulo)
        {
            // Método para buscar si existe un Libro dentro del listado de libros buscándolo por el título.
            // Busca coincidencia del título del listado de libros con el título pasado por parámetro sin 
            // diferenciar entre mayúsculas de minúsculas.
            return libros.Any(libroExiste => libroExiste.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
        }
    }
}