// Leer un vector A de tamaño n y calcula mayor, menor, media, varianza y desviacion estandar
// Karla Margarita Ponce Garcia
// 8 de Sep de 2020
using System;

namespace p14vestadisticas
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=0; double[] A;
            double lamedia=0;
            Console.WriteLine("Cuantos elementos ?"); n= int.Parse(Console.ReadLine());
            A = new double[n];
            
            Console.WriteLine("Dame los elementos del Arreglo\n"); leer(A);
            Console.WriteLine("\nEstadisticas:\n");
            Console.WriteLine($"\nMayor\t{may(A)}");
            Console.WriteLine($"\nMenor\t{men(A)}");
            Console.WriteLine($"\nMedia\t{lamedia = media(A)}");
            Console.WriteLine($"\nVarianza\t{varianza(A, lamedia)}");
            Console.WriteLine($"\nDesviacion\t{desviacion(A, lamedia)}");
        }
        static void leer(double[] v){
            for(int i=0; i<v.Length;i++){
                Console.Write($"Elemento {i} ");
                v[i]= double.Parse(Console.ReadLine());
            }
        }
        static double may(double[] v){
            double m=v[0];
            for(int i=0; i<v.Length; i++)
                if(v[i]>m) m=v[i];
            return m;
        }

        static double men(double[] v){
            double m=v[0];
            for(int i=0; i<v.Length; i++)
                if(v[i]<m) m=v[i];
            return m;
        }

        static double media(double[] v){
            double suma=v[0];
            for(int i=0; i<v.Length; i++)
                suma+=v[i];
            return suma/v.Length;
        }
        static double varianza(double[] v, double m){
            double suma=v[0];
            for(int i = 0; i<v.Length; i++)
                suma += Math.Pow( (v[i]-m),2 );
            return suma/v.Length;
        }

        static double desviacion(double[] v, double m){
            double suma=v[0];
            for(int i = 0; i<v.Length; i++)
                suma += Math.Pow( (v[i]-m),2 );
            suma/=v.Length;
            return Math.Sqrt(suma);
        }
    }
}
