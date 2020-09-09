// Leer dos vectores A y B de tamaño n y multiplicar el primer elemento de A con el ultimo de B
// Karla Margarita Ponce Garcia
// 8 de Sep de 2020
using System;

namespace p13vectormultiplica
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX = 3;
            double[] A = new double[MAX];
            double[] B = new double[MAX];
            double[] C = new double[MAX];

            Console.WriteLine("\nDame los elementos de A"); leer(A);
            Console.WriteLine("\nDame los elementos de B"); leer(B);
            for(int i = 0; i<MAX;i++)
                C[i]=A[i]*B[(MAX-1)-i];
            
            Console.WriteLine("\nLos 3 vectores son");
            imprime(A);
            imprime(B);
            imprime(C);
        }

        static void leer(double[] v){
            for(int i = 0; i<v.Length; i++){
                Console.Write($"Elemento {i}");
                v[i] = double.Parse(Console.ReadLine());
            }
        }

        static void imprime(double[] v){
            for(int i = 0; i<v.Length; i++)
                Console.Write($"{v[i]} ");
            Console.WriteLine();
        }
    }
}
