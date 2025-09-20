# TP 1 - Proyecto Biblioteca

## Descripción
Este proyecto corresponde al Trabajo Práctico de **Desarrollo de Sistemas Orientado a Objetos**.  
La aplicación permite registrar lectores, agregar libros y realizar préstamos con un máximo de Libros 3 por Lector.



## Integrantes
- Ignacio Grosman
- Sebastián Fernández 
- Glaucia Ferreira
- Andrea Maslucan



- 
## UML – Diagrama de Clases

```mermaid
classDiagram
    class Biblioteca {
      - List<Lector> lectores
      - List<Libro> libros
      + List<Libro> LibrosDisponibles
      + AltaLector(nombre: string, dni: string, direccion: string): void
      + PrestarLibro(titulo: string, dni: string): string
      + MostrarLibros(): void
      + ExisteLibro(titulo: string): bool
      + MostrarLectores(): void
    }

    class Lector {
      + Nombre: string
      + Dni: string
      + Direccion: string
      + LibrosPrestados: List<Libro>
    }

    class Libro {
      + Titulo: string
      + Genero: string
      + FechaLanzamiento: DateTime
      + Autor: string
      + Editorial: string
    }

    class Program {
      + Main(args: string[]): void
      - MostrarDescripcion(): void
    }

    Biblioteca o-- "0..n" Lector : registra
    Biblioteca o-- "0..n" Libro  : posee
    Lector "0..n" o-- Libro : presta
