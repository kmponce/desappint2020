// Ejemplo de uso de diccionario
// Karla Margarita Ponce Garcia
// 17 de Sep de 2020
using System;
using System.Collections.Generic;
namespace p17diccionario
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definicion del diccionario, y reerva de espacio en memoria
            Dictionary<string, string> midic = new Dictionary<string, string>(); 
            //SortedDictionary<string,string> midic = new SortedDictionary<string, string>();

            //Agregar elementos al diccionario
            midic.Add("txt", "Archivo de texto");
            midic.Add("jpg","Archivo de imagen");
            midic.Add("mp3","Archivo de sonido");
            midic.Add("html","Archivo de texto html");
            midic.Add("exe","Archivo ejecutable");
            midic.Add("lll","Archivo de tipo desconocido");

            // Acceder elemento a traves de la llave
            Console.WriteLine(midic["html"]);

            // Verificar si una llave existe, si no agregarla
            if(midic.ContainsKey("elf"))
                Console.WriteLine("La llave ya existe en el diccionario");
            else
                midic.Add("elf","Archivo ejecutable en linux");
            
            //Borrar una entrada al diccionario en base a la llave
            if(midic.ContainsKey("lll"))
                midic.Remove("lll");
            
            //Recorrer el diccionario e imprimir la llave y su valor 
            foreach(KeyValuePair<string,string> val in midic){
                Console.WriteLine($"{val.Key} - {val.Value}");
            }

            //Imprimir solo las llaves del diccionario
            foreach(string key in midic.Keys){
                Console.WriteLine($"{key}");
            }

            //Imprimir solo las entradas del diccionario
            foreach(string val in midic.Values){
                Console.WriteLine($"{val}");
            }
            //Borrar todas las entradas al diccionario
            midic.Clear();
        }
    }
}
