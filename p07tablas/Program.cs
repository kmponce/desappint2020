using System;
//programa que imprime las tablas de multiplicar
//Karla Margarita Ponce Garcia
// 01/Sep/2020
namespace p07tablas
{
    class Program
    {
        static int Main(string[] args)
        {
            int op;  //opcion
            int num; //tabla
            int inf; //cota inferior
            int sup; //cota superior

            if(args.Length==0){Menu(); return 1;}

            op=int.Parse(args[0]);
            num=int.Parse(args[1]);
            inf=int.Parse(args[2]);
            sup=int.Parse(args[3]);

            switch(op){
                case 1:
                    for(int i= inf; i<=sup; i++){
                        Console.WriteLine($"{num} x {i} = {num*i}");
                    }
                break;
                case 2:
                    for(int t=1; t<=num; t++){
                        for(int i= inf; i<=sup; i++){
                            Console.WriteLine($"{t} x {i} = {t*i}");
                        }
                        Console.WriteLine("\n");
                    }
                break;
            }

            return 0;
        }

        static void Menu(){
            Console.Clear();
            Console.WriteLine("[1] Imprimir una tabla de multiplicar específica hasta cierto número (ej. la tabla del 5 , del 1 al 10) [5 1 10]");
            Console.WriteLine("[2] Imprimir las tablas deseadas hasta el número deseado. (ej. hasta la table del 4, del 1 al 11) [4 1 10]");
        }
    }
}
