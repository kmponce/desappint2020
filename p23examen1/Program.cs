// Solucion al examen parcial uno
// Karla Margarita Ponce Garcia
// 24 de Sep de 2020
using System;
using System.Collections.Generic;
using System.Linq;

namespace p23examen1
{
    class Program
    {
        static void Main(string[] args)
        {
            Red mired = new Red("Red Patito, S.A. de C.V.","Mr Pato McPato","Av. Siempre Viva 214, Springfield");
            
            mired.AddNodo(new Nodo("192.168.0.10","servidor",5,10,"linux"));
            mired.AddNodo(new Nodo("192.168.0.12","equipoactivo",2,12,"ios"));
            mired.AddNodo(new Nodo("192.168.0.20","computadora",8,5,"windows"));
            mired.AddNodo(new Nodo("192.168.0.15","servidor",10,22,"linux"));
            
            mired.Nodos[0].AddVulnes(
                new Vulnerabilidad("CVE-2015-1635",
                    "microsoft",
                    "HTTP.sys permite a atacantes remotos ejecutar codigo arbitrarios",
                    "remota",
                    new DateTime(2015,04,14))); //YY,MM,DD
            mired.Nodos[0].AddVulnes(
                new Vulnerabilidad("CVE-2017-0004",
                    "microsoft",
                    "El servicio LSASS permite causar una denegacion de servicio",
                    "local",
                    new DateTime(2017,01,10)));
            mired.Nodos[1].AddVulnes(
                new Vulnerabilidad("CVE-2017-3847",
                    "cisco",
                    "Cisco Firepower Management Center XSS",
                    "remota",
                    new DateTime(2017,02,21)));
            mired.Nodos[2].AddVulnes(
                new Vulnerabilidad("CVE-2009-2504",
                    "microsoft",
                    "Multiples desbordamientos de enteros en APIs Microsoft .NET 1.1",
                    "local",
                    new DateTime(2009,11,13)));
            mired.Nodos[2].AddVulnes(
                new Vulnerabilidad("CVE-2016-7271",
                    "microsoft",
                    "Elevacion de provolegios Kernel Segura en Windows 10 Gold",
                    "local",
                    new DateTime(2016,12,20)));
            mired.Nodos[2].AddVulnes(
                new Vulnerabilidad("CVE-2017-2996",
                    "adobe",
                    "Adobe Flash Player 24.0.0.194 corrupcion de memoria explotable",
                    "remota",
                    new DateTime(2017,02,15)));


            Console.WriteLine(">> Datos generales de la red:\n");
            Console.WriteLine($"{mired.ToString()}");

            Console.WriteLine($"Total de nodos: {mired.Nodos.Count}");
            int tot=0;
            foreach(Nodo nod in mired.Nodos){
                tot+= mired.numVulnes(nod);
            }
        
            Console.WriteLine($"Total de vulnerabilidades: {(tot).ToString()}\n");

            Console.WriteLine(">> Datos generales de los nodos:\n");
            //foreach(Nodo nod in mired.Nodos){
            //    Console.WriteLine($"{nod.ToString()}");
            //}
            mired.Nodos.ForEach(nod =>Console.WriteLine($"{nod.ToString()}"));

            Console.WriteLine($"\nMayor numero de saltos: {mired.Mayor(mired.Nodos)}");
            Console.WriteLine($"Menor numero de saltos: {mired.Menor(mired.Nodos)}");

            Console.WriteLine("\n>> Vulnerabilidades por nodo:");
            foreach(var nod in mired.Nodos){
                Console.WriteLine($"\n> Ip: {nod.IP}, Tipo: {nod.Tipo}");
                if(nod.Vulnes.Count!=0) {
                    Console.WriteLine("\nVulnerabilidades:");
                    foreach(var vul in nod.Vulnes)
                        Console.WriteLine($"{(vul).ToString()}");}
                else Console.WriteLine("\nNo tiene vulnerabilidades ..");
            }


        }
        
    }
}
