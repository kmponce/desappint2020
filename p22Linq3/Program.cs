// Ejemplo de uso de Linq
// Karla Margarita Ponce Garcia
// 22 de Sep de 2020
using System;
using System.Collections.Generic;
using System.Linq;
namespace p22Linq3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Estudiante> estudiantes = new List<Estudiante>() {
                new Estudiante {Matricula=111, Nombre="Juan Perez", Domicilio="Principal 123",Ciudad="Zacatecas",
                Califs = new List<float>{97,92,81,60}},
            
                new Estudiante {Matricula=222, Nombre="Maria Lopez", Domicilio="Principal 126",Ciudad=" Fresnillo",
                Califs = new List<float>{75,84,91,39}},
            
                new Estudiante {Matricula=333, Nombre="Rodrigo Mata", Domicilio="Luis Moya 31",Ciudad=" Rio Grande",
                Califs = new List<float>{88,94,65,91}},
            
                new Estudiante {Matricula=444, Nombre="Miguel Mejia", Domicilio="Juan de Tolosa 22",Ciudad="Rio Grande",
                Califs = new List<float>{70,90,60,40}}
            };

            estudiantes.Add(new Estudiante {Matricula=555, Nombre="Karla Ponce", Domicilio="Lomita 310",Ciudad="Zacatecas",
                Califs = new List<float>{75,95,65,70}});

            //Todos los registros sin consulta ni filtro
            Console.WriteLine("\nTodos los estudiantes: {0}",estudiantes.Count());
            estudiantes.ForEach(est=>Console.WriteLine(est.ToString()));

            //filtrar lo estudiantes que son de la calle principal
            var estzac = (from est in estudiantes where est.Domicilio.Contains("Principal") select est).ToList();
            Console.WriteLine("\nLos estudiantes que viven en calles principales: {0}",estzac.Count());
            estzac.ForEach(est=>Console.WriteLine(est.ToString()));

            //filtrar  estudiantes con promedio de 7 ,y mostrarlos ordenados por nombre descendente
            var otros = (from est in estudiantes
                where est.Califs.Average()>=70
                orderby est.Nombre descending
                select est).ToList();
            Console.WriteLine("\nLos estudiantes con promedio de 8 en orden descendente por nombre: {0}",otros.Count());
            otros.ForEach(est=>Console.WriteLine(est.ToString()));

            //consulta con datos agrupados
            var gpoest = from est in estudiantes
                where est.Califs.Average()>=70
                group est by est.Ciudad;
            Console.WriteLine("\nLos estudiantes agrupados por ciudad: {0}",gpoest.Count());
            foreach(var gpo in gpoest){
                Console.WriteLine(gpo.Key);
                foreach(Estudiante est in gpo)
                    Console.WriteLine(est.ToString());
            }

            //Estudiantes y sus promedios
            var proms = (from est in estudiantes
                select $"Nombre = {est.Nombre}\tprom= {est.Califs.Average()}").ToList();
            Console.WriteLine("\nLista de alumnos y sus promedios");
            proms.ForEach(p=>Console.WriteLine(p));
        }
    }
}
