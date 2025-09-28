# TP 1 - Proyecto Biblioteca


## Descripci�n
Este proyecto corresponde al Trabajo Pr�ctico de **Desarrollo de Sistemas Orientado a Objetos**.  
La aplicaci�n permite registrar lectores, agregar libros y realizar pr�stamos con un m�ximo de Libros 3 por Lector.



## Integrantes
- Ignacio Grosman
- Sebasti�n Fern�ndez 
- Glaucia Ferreira
- Andrea Maslucan


 
## UML � Diagrama de Clases

```mermaid

classDiagram
direction LR

    class Biblioteca {
      - lectores: List
      - libros: List
      + librosDisponibles: List
      + Biblioteca()
      + ExisteLibro (titulo:string) bool
      + MostrarLibro() void
      + PrestarLibro (titulo: string, dni: string) string
      + AltaLector(nombre: string, dni: string, direccion: string) void
      + MostrarLectores() void
    }

    class Libro {
      + titulo: string
      + genero: string
      + fechaLanzamiento: DateTime
      + autor: string
      + editorial: string
      + Libro(string,string,DateTime, string, string) void
    }

    class Lector {
      + nombre: string
      + dni: string
      + direccion: string
      + librosPrestados: List
      + Lector(string, string, string, List) void
    }

    class Program {
      + Main(args: string[]) void
      - MostrarDescripcion() void
    }
       
    Biblioteca --> "0..n        " Lector : registra
    Biblioteca --> "0..n        " Libro : posee
    Lector  --> "0..3        " Libro : presta
    Program ..> Biblioteca: usa