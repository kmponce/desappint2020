using System;
using System.Collections.Generic;

namespace p22Linq3
{
    class Estudiante {
        public int Matricula{get; set;}
        public string Nombre {get;set;}
        public string Domicilio{get;set;}
        public string Ciudad{get;set;}
        public List<float> Califs;
        public override string ToString() =>
        $"Matricula: {Matricula}, Nombre: {Nombre}, Domicilio: {Domicilio}, {Ciudad}, Califs: {string.Join(",",Califs)}";
    }
}