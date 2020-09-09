// Genera dos vectores aleatorios y los suma
// Karla Margarita Ponce Garcia
// 8 de Sep de 2020
using System;

namespace p09vectoraleatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[15];
            int[] B = new int[15];
            int[] C = new int[15];

            Random rnd = new Random();

            for(int i=0; i < A.Length; i++){
                A[i]= rnd.Next(1,100);
                B[i]= rnd.Next(1,100);
                C[i]= A[i]+B[i];
            }
            Console.WriteLine("\nElementos de A"); imprime(A);
            Console.WriteLine("\nElementos de B"); imprime(B);
            Console.WriteLine("\nElementos de C"); imprime(C);
        }

        static void imprime(int[] v){
            for(int i=0; i < v.Length; i++)
                Console.Write($"{v[i]} ");
        }
    }
}
