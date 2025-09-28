```mermaid
classDiagram
direction LR

class Biblioteca {
  + Biblioteca()
  - buscarLibro(titulo: string)Libro
  + agregarLibro(titulo: string, autor: string, editorial: string) bool
  + eliminarLibro(titulo: string) bool
  + listarLibros() void
}

class Libro {
  - titulo: string
  - autor: string
  - editorial: string
  + Libro(titulo: string, autor: string, editorial: string)
}

Biblioteca --> "0..n" Libro : libros
