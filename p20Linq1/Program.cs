//Ejemplo de uso de Linq
//Karla Margarita Ponce Garcia
//22 de Sep de 2020
using System;
using System.Collections.Generic;
using System.Linq;

namespace p20Linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            // fuente de datos
            int[] numeros = new int[] {10,25,-1,10,0,320,22,65,800,-4,20,20,1000,2000,-233};

            // crear la consulta pares
            IEnumerable<int> qrypares =
                from num in numeros
                where (num%2) ==0
                select num;
            
            //Ejecutar consulta pares
            Console.WriteLine($"\nNumeros pares {qrypares.Count()}");
            foreach(int n in qrypares)
                Console.Write($"{n} ");

            // crear consulta impares
            var qryimpares = (from num in numeros where (num%2)!=0 select num).ToArray();
            Console.WriteLine($"\nNumeros impares {qryimpares.Count()}");
            for(int i=0;i<qryimpares.Count();i++)
                Console.Write($"{qryimpares[i]}");     

            // crear consulta para sacar los numeros mayores a 100 y ponerlos en una lista
            var mayores = (from num in numeros where num >=100 select num).ToList();

            Console.WriteLine($"\nNumeros mayores que 100 {mayores.Count()}");
            mayores.ForEach(n=>Console.Write($"{n} "));

        }
    }
}
