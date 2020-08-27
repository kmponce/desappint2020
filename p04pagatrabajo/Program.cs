using System;
//Programaque calcula la pagade un trabajador, dando nombre, horas, paga y tasa de impuesto
//Karla Margarita Ponce Garcia
namespace p04pagatrabajo
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            int horas;
            float paga, tasa=0.10f;
            float impuesto, pagabruta, paganeta;
            
            Console.WriteLine("Calculando la paga de un trabajador");
            Console.WriteLine("Dame el nombre"); nombre = Console.ReadLine();
            Console.WriteLine("Dame las horas"); horas = int.Parse( Console.ReadLine());
            Console.WriteLine("Dame las paga "); paga = float.Parse( Console.ReadLine());

            pagabruta = horas * paga;
            impuesto = pagabruta * tasa;
            paganeta = pagabruta - impuesto;

            Console.WriteLine($"El trabajado de nombre {nombre}");
            Console.WriteLine($"Trabajo  {horas} horas");
            Console.WriteLine($"Con una paga de {paga} pesos");
            Console.WriteLine($"Por lo cual recibe una paga bruta de  {pagabruta} pesos");
            Console.WriteLine($"Esto genera un impusto de {impuesto} pesos");
            Console.WriteLine($"Al final llega a su casa con la miserabe cantidad de {paganeta} pesos");
        }
    }
}
