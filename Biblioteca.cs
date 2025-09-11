using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    public class Biblioteca
    {
        private List<Lector> lectores = new List<Lector>();
        private List<Libro> libros = new List<Libro>();

        public List<Libro> LibrosDisponibles => libros;

        public Biblioteca()
        {
            // 3 libros iniciales
            libros.Add(new Libro("El Quijote", "Novela", new DateTime(1605, 1, 16), "Miguel de Cervantes"));
            libros.Add(new Libro("Cien Años de Soledad", "Realismo mágico", new DateTime(1967, 5, 30), "Gabriel García Márquez"));
            libros.Add(new Libro("Rayuela", "Novela", new DateTime(2000, 6, 28), "Julio Cortázar"));

            // 10 libros adicionales por defecto
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
            if (lectores.Any(l => l.Dni == dni))
            {
                Console.WriteLine($"El lector con DNI {dni} ya existe.");
                return;
            }
            lectores.Add(new Lector(nombre, dni));
            Console.WriteLine($"Lector {nombre} dado de alta correctamente.");
        }

        public string PrestarLibro(string titulo, string dni)
        {
            var lector = lectores.FirstOrDefault(l => l.Dni == dni);
            if (lector == null) return "LECTOR INEXISTENTE";

            if (lector.LibrosPrestados.Count >= 3) return "TOPE DE PRESTAMO ALCANZADO";

            var libro = libros.FirstOrDefault(b => b.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (libro == null) return "LIBRO INEXISTENTE";

            lector.LibrosPrestados.Add(libro);
            libros.Remove(libro);
            return "PRESTAMO EXITOSO";
        }

        public void MostrarLibros()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros disponibles.");
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("Libros disponibles:");
            Console.WriteLine("");
            foreach (var libro in libros)
            {
                Console.WriteLine($"- {libro.Titulo} | {libro.Autor} | {libro.Genero} | {libro.FechaLanzamiento.ToShortDateString()}");
            }
        }

        public bool ExisteLibro(string titulo)
        {
            return libros.Any(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
        }
    }
}