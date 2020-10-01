// Ejemplo de delegado simple
// Karla Margarita Ponce Garcia
// 01 de Octubre de 2020
// Feliz octubre :3
using System;

namespace p25Delegados1
{
    public delegate void MiDelegado(string msj);
    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado del;
            del = Mensaje.Mensaje1;
            del("chino");
            del = Mensaje.Mensaje2;
            del("el gordo");
        }
    }
    public class Mensaje{
        public static void Mensaje1 (string msj) => Console.WriteLine($"{msj} - lleva el pastel");
        public static void Mensaje2(string msj) => Console.WriteLine($"{msj} - fue el culpable, xe cancela la fiesta");
    }
}
