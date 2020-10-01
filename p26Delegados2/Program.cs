//Ejemplo de delegado multicast(un delegado que invoca a varios metodos al mismo tiempo)
// Karla Margarita Ponce Garcia
// 01 de Octubre de 2020
// Feliz Octubre :3
using System;

namespace p26Delegados2
{
    class Program
    {
        public delegate void Midelegado(string msj);
        static void Main(string[] args)
        {
            Midelegado d1, d2, d3, d;

            d1 = Mensajes.Mensaje1;
            d2 = Mensajes.Mensaje2;
            d = d1 + d2;
            d("El primi");
            d3 = (string msj) => Console.WriteLine($"{msj} - paga todo que no pare la fiesta");
            d += d3;
            d("Porfirio");
            d -= d2;
            d("Pancho Villa");
            d -= d1;
            d("Maxi bebe");
        }
    }
}
