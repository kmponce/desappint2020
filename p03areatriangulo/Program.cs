using System;
//Programa que calcula el area de un triangulo dando la base y altura
//Karla Margarita Ponce Garcia
namespace p03areatriangulo
{
    class Program
    {
        static void Main(string[] args)
        {
           float a,b; //a = altura, b = base
           float area;

           Console.WriteLine("Dame la base"); b = float.Parse( Console.ReadLine() );
           Console.WriteLine("Dame la altura"); a = float.Parse( Console.ReadLine() );

           area = b * a / 2;

           Console.WriteLine($"Un trinagulo de base {b} y altura {a} tiene un area de {area}");
        }
    }
}
