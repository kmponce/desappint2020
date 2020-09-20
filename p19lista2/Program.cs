using System;
using System.Collections.Generic;
namespace p19lista2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una lista con elementos tipo Pieza
            List<Pieza> mp= new List<Pieza>();

            // Agregar piezas a la lista
            mp.Add(new Pieza(1234,"tuerca de rosca interior"));
            mp.Add(new Pieza(5678,"tornillo de cabeza grande"));
            mp.Add(new Pieza(9345,"martillo de chiva"));

            // Agregar un rango de piezas
            var proveedor= new List<Pieza>(){
                new Pieza(8888, "tornillo de cabeza pequeña"),
                new Pieza(9999, "cables para pasar corriente"),
                new Pieza(6666, "taquetes dobles de madera")
            };

            mp.AddRange(proveedor);
            // Usar el metodo foreach integrado en la lista para imprimir su contenido
            mp.ForEach(p19lista2=>Console.WriteLine(p19lista2.ToString()));

            //Eliminar el ultimo elemento de la lista
            mp.RemoveAt(mp.Count-1);

            //Insertar un elemento en la segunda posicion
            Console.WriteLine("\nInsertar un elemento en la posicion 2:");
            mp.Insert(1, new Pieza(2222,"caja de 8 velocidades"));
            mp.ForEach(p19lista2=>Console.WriteLine(p19lista2.ToString()));

            //Buscar todas las ocurrencias de la palabra tornillo
            Console.WriteLine("\nPiezas que contienen la palabra tornillo");
            var pzas= mp.FindAll(p=>p.Nombre.Contains("tornillo"));
            pzas.ForEach(p19lista2=>Console.WriteLine(p19lista2.ToString()));

            //Buscar las piezas cuyo Id es menor que 5000
            Console.WriteLine("\nPiezas cuyo Id < 5000");
            var pzas2= mp.FindAll(p=>p.Id<5000);
            pzas2.ForEach(p19lista2=>Console.WriteLine(p19lista2.ToString()));
        }
    }
}
