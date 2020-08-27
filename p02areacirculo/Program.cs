using System;
//Este programa calcula el area de un circulo a partir del radio
//Karla Margarita Ponce Garcia
namespace p02areacirculo
{
    class Program
    {
        static void Main(string[] args)
        {
            float radio = 0;
            double area = 0;

            Console.Clear();
            Console.WriteLine("Dame el radio del circulo");
            radio = float.Parse( Console.ReadLine() );
            area = Math.PI * Math.pow(radio,2);

            Console.WriteLine($"El area es {area}");
        }
    }
}
