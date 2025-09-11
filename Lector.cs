using System.Collections.Generic;

namespace Biblioteca
{
    public class Lector
    {
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public List<Libro> LibrosPrestados { get; set; }

        public Lector(string nombre, string dni)
        {
            Nombre = nombre;
            Dni = dni;
            LibrosPrestados = new List<Libro>();
        }
    }
}