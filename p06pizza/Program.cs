using System;

//Progama que permite pedir una pizza en base a la eleccion del usuario
// Karla Margarita Ponce Garcia
// 01/Sep/2020
namespace p06pizza
{
    class Program
    {
        static int Main(string[] args)
        {
            //Variables para recibir los parametros
            char tam, cub, lug;
            string[] ings;   //arreglo de cadenas

            //Variables para guardar la eleccion del usuario
            string tamaño, ingredientes="", cubierta, lugar;

            Console.Clear();
            
            if(args.Length==0){ //Revisar que existan parametros
                Menu();
                return 1;
            }

            //Elegir tamaño
            tam=char.Parse(args[0].ToUpper()); //Tomar el primer parametro
            if(tam=='P') tamaño="Pequeña";
            else if(tam=='M') tamaño = "Mediana";
            else tamaño="Grande";

            // Elegir ingredientes
            ings=args[1].Split("+"); // Separa los ingredientes en base al signo +
            foreach(string i in ings){
                switch(char.Parse(i.ToUpper())){
                    case 'E' : ingredientes+="Extraqueso "; break;
                    case 'P' : ingredientes+="Piña "; break;
                    case 'C' : ingredientes+="Champiñones "; break;
                }
            }
            
            //Elegir cubierta
            cub=char.Parse(args[2].ToUpper());
            cubierta= cub=='D' ? "Delgada":  "Gruesa";
            
            //Elegir Lugar
            lug=char.Parse(args[3].ToUpper());
            lugar = lug=='A' ? "Aqui" : "Llevar";
            //Salida
            Console.WriteLine("\n La pizza que pediste es la siguiente ");
            Console.WriteLine($"Tamaño: {tamaño}");
            Console.WriteLine($"Ingredientes: {ingredientes}");
            Console.WriteLine($"Cortesa: {cubierta}");
            Console.WriteLine($"Para {lugar}");
            return 0;
        }
        static void Menu(){
            Console.Clear();
            Console.WriteLine("Elija las opciones segun desea su pizza");
            Console.WriteLine("Tamaño: (P)equeña (M)ediana (G)rande");
            Console.WriteLine("Ingredientes: (E)xtra queso, (C)hampiñones, (P)iña unidos por + <C+P>");
            Console.WriteLine("Cubierta: (D)elgada, (G)ruesa");
            Console.WriteLine("Para (A)qui o para (L)levar");
        }
    }
}
