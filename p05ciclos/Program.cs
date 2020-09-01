using System;
// Programa que muestra ejemplos de uso de ciclos
// Karla Margarita Ponce Garcia
// 01/Sep/2020
namespace p05ciclos
{
    class Program
    {
        static int Main(string[] args)
        {
            int op, c=0, suma=0; //c es contador
            Console.Clear();
            if(args.Length == 0){ //verifica que se haya pasado argumento en la linea de comando
                Menu();
                return 1;
            }
            op = int.Parse(args[0]); // tomo el primer argumento de la linea de comando
            
            switch(op){
                case 1:{ //Numeros del 1 al 100 con while
                    c=1; suma=0;
                    while(c<=100){
                        Console.Write($"{c} ");
                        suma+=c;
                        c++;
                    }
                    Console.Write($"\n La suma es {suma}");
                }
                break;
                case 2:{ //numeros del 100 al 1 con do while
                    c=100; suma=0;
                    do{
                        Console.Write($"{c} ");
                        suma+=c;
                        c--;
                    }while(c>=1);
                    Console.Write($"\n La suma es {suma}");
                }
                break;
                case 3:{//numeros del 50 al 200 con for
                    suma=0;
                    for(int i=50; i<=200; i++){
                        Console.Write($"{i} ");
                        suma+=i;
                    }
                    Console.Write($"\n La suma es {suma}");
                }
                break;
                case 4:{//numeros pares del 2 al 100 con for
                    suma=0;
                    for(int i=2; i<=100; i+=2){
                        Console.Write($"{i} ");
                        suma+=i;
                    }
                    Console.Write($"\n La suma es {suma}");
                }
                break;
                case 5:{//numeros impares del 99 al 1 con for
                    suma=0;
                    for(int i=99; i>=1; i-=2){
                        Console.Write($"{i} ");
                        suma+=i;
                    }
                    Console.Write($"\n La suma es {suma}");
                }
                break;
                case 6:{ //numeros del 272 al 40 con decrementos de 4 con do while
                    c=272; suma=0;
                    while(c>=40){
                        Console.Write($"{c} ");
                        suma+=c;
                        c-=4;
                    }
                    Console.Write($"\n La suma es {suma}");
                }
                break;
                
            }

            return 0;
        }

        static void Menu() {
            Console.Clear();
            Console.WriteLine("==== Uso de ciclos en lenguaje c#");
            Console.WriteLine("[1] Números del 1 al 100 con ciclo while");
            Console.WriteLine("[2] Números del 100 al 1 con ciclo do .. while");
            Console.WriteLine("[3] Números del 50 al 200 con ciclo for");
            Console.WriteLine("[4] Números del 2 al 100 solo los pares con ciclo for");
            Console.WriteLine("[5] Números del 99 al 1 solo los impares con ciclo for");
            Console.WriteLine("[6] Números del 272 al 40 en decrementos de 4 con ciclo while");
        }
    }
}
