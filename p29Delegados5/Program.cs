// Ejemplo de delegado como parametro
// Karla Margarita Ponce Garcia
// 01 de Octrubre de 2020
// Feliz Octubre :3
using System;

namespace p29Delegados5
{
    public delegate void MiDelegado(string msj);
    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado d1,d2,d3;//,d4;
            d1=ClaseA.MetodoA;
            d1("Tradicional A");
            Invocar (d1);
            d2= ClaseB.MetodoB;
            d2("Tradicional A");
            Invocar (d2);

            d3 = (string msj) => Console.Write($"Llamando metodo con expresion lambada: {msj}");
            d3("Tradicional lambada\n");
            Invocar(d3);    
/*
            //¿se puede?
            //Invocar(d3("A veeer"));
            //no se puede porque no esta construido de eesa forma, el parametro de del es vacio 
            d4= (string msj) => Console.Write($"\nA fuerzas se debe usar minimo expresion lambada: {msj}");;
            OtroInvocador(d4, "en teoria esto deberia ser considerado delegado con parametro, pero quien sabe");
*/        }
        static void Invocar (MiDelegado del){
            del("Hola desde el invocador.");
        }
        /*static void OtroInvocador(MiDelegado del, string msj){
            del($"\nEl invocador convoca: {msj}"); //¿esto se podra? ¿seguira siendo delegado?
            //¿sera metodo tradicional o delegado como parametro? solo es hacernos bolas, el metodo de arriba es una forma simple
            //este ya es complicarse las cosas
        }*/
    }
    public class ClaseA{
        public static void MetodoA(string msj) => Console.WriteLine($"Llamando al MetodoA de la Clase A {msj}");
    }
    public class ClaseB{
        public static void MetodoB(string msj) => Console.WriteLine($"Llamando al MetodoB de la Clase A {msj}");
    }
}
