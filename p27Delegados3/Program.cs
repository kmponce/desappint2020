// Ejemplo de delegado multicast con parametros
// Karla Margarita Ponce Garcia
// 01 de Octubre de 2020
// Feliz Octubre :3
using System;

namespace p27Delegados3
{
    public delegate int MiDelegado(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado d1= A.MetodoA;
            MiDelegado d2= B.MetodoB;
            Console.WriteLine($"La suma en {d1(10,20)}");
            Console.WriteLine($"La multiplicacion es {d2(10,20)}");
            MiDelegado d = d1+d2;
            //Despues de la concatenacion el ultimo metodo "activo" es el de la multiplicacion
            Console.WriteLine($"El resultado es: {d(5,2)}");
        }
    }
    public class A{
        public static int MetodoA(int a, int b) => a+b;
    }
    public class B{
        public static int MetodoB(int a, int b) => a*b;
    }
}
