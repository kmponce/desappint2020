using System;

namespace p19lista2
{
    class Pieza{
        public Pieza(int id, string nombre) =>(Id, Nombre) = (id,nombre);
        public int Id { get; set; }
        public string Nombre { get; set; }

        //Sobre cargagamos metodo ToSring()
        public override string ToString() => $"{Id} - {Nombre}";
    }
}