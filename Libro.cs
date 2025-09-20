namespace Biblioteca
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }

        public Libro(string titulo, string genero, DateTime fechaLanzamiento, string autor, string editorial)
        {
            Titulo = titulo;
            Genero = genero;
            FechaLanzamiento = fechaLanzamiento;
            Autor = autor;
            Editorial = editorial;
        }
    }
}