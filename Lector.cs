namespace Biblioteca
{
    public class Lector
    {
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public List<Libro> LibrosPrestados { get; set; }

        public Lector(string nombre, string dni, string direccion)
        {
            Nombre = nombre;
            Dni = dni;
            Direccion = direccion;
            LibrosPrestados = new List<Libro>();
        }
    }
}