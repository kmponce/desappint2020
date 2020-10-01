// Ejemplo de delegado generico
// Karla Margarita Ponce Garcia
// 01 de Octubre de 2020
// Feliz Octubre :3
using System;

namespace p28Delegados4
{
    //funciona cuando son del mismo tipo
    public delegate T Suma<T>(T p1, T p2);
    class Program
    {
        static void Main(string[] args)
        {
            Suma<int> d1 = Sumar;
            Suma<string> d2 = Concatenar;
            // Suma <string> d3 = NoSePuede; //<-- Esto no se puede porque tienen diferentes tipos de parametros
            Console.WriteLine($"La suma es {d1(20,30)}");
            Console.WriteLine($"La concatenacion es {d2("No pos","aqui andamos")}");
            Console.WriteLine($"Diferentes tipos de parametros {NoSePuede("parametro a",100)}");

            // este es un calis para ver si funciona si el tipo de retorno es diferente al tipo de los parametros
            // Suma<int> d3=Multiplicar;
            // tampoco se puede, i.e. los tipos de valores (parametros y retorno) deben ser iguales
            Console.WriteLine($"Tipo retorno diferente, parametros iguales {Multiplicar(3,8)}");


        }
        public static int Sumar(int a, int b)=> a+b;
        public static string Concatenar(string a, string b)=> a+b;
        public static string NoSePuede(string a, int b) => $"{a} - {b.ToString()}";
        //¿se puede si el tipo de retorno es diferente al de los parametros?
        public static string Multiplicar(int a, int b) => $"{(a*b).ToString()}";
    }
}
