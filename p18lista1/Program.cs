using System;
using System.Collections.Generic;
//Uso de listas 
//Karla Margarita Ponce Garcia
//17 de Sep de 2020
namespace p18lista1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definir la lista con algunos valores iniciales
            List<string> mats= new List<string>(){
                "Calculo I",
                "Redacción Avanzada",
                "Introduccion a la Ingenieria"
            };

            // Agregar elementos a la lista
            mats.Add("Matematicas discretas");
            mats.Add("Compiladores e interpretadores");
            imprime(mats);

            //Agregar un rango de materias
            string[] mopt = {
                "Seguridad en redes y sitemas (op)",
                "Topicos selectos de redes (op)",
                "Criptografia Avanzada (op)"
            };
            mats.AddRange(mopt);
            imprime(mats);


            //Ordenar la lista
            mats.Sort();
            imprime(mats);

            // Invertir los elementos de la lista
            mats.Reverse();
            imprime(mats);

            // Buscar un elemento en la lista, en base a una condicion
            Console.WriteLine("Materias que tengan la palabra dicretas");
            string mat = mats.Find(x=>x.Contains("discretas"));

            // Buscar todas las materias en la lista, que son optativa
            Console.WriteLine("\nMaterias Optativas");
            var ms = mats.FindAll(x=>x.Contains("(op)"));
            imprime(ms);
        }
        static void imprime(List<string> lista){
            //foreach(string m in lista){ Console.WriteLine(m); }
            //version reducida
            lista.ForEach(m=>Console.WriteLine(m));
            Console.WriteLine();
        }
    }
}
