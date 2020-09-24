using System;
using System.Collections.Generic;

namespace p23examen1
{
    class Vulnerabilidad{
        private string clave;
        private string vendedor;
        private string descripcion;
        private string tipo;
        private DateTime fecha;
        public Vulnerabilidad(string clv, string vdr, string des,string tp, DateTime f){
            clave=clv;
            vendedor=vdr;
            descripcion=des;
            tipo=tp;
            fecha=f;
        }
        public string Clave{get{return clave;} set{clave=value;}}
        public string Vendedor{get{return vendedor;} set{vendedor=value;}}
        public string Descripcion{get{return descripcion;} set{descripcion=value;}}
        public string Tipo{get{return tipo;} set{tipo=value;}}
        public DateTime Fecha{get{return fecha;} set{fecha=value;}}
        //Calcular la antiguedad

        public int Antiguedad(DateTime f){
            //TimeSpan ant = DateTime.Today - f;
            //DateTime total= new DateTime(ant.Ticks);
            //return total;
            return DateTime.Today.AddTicks(-f.Ticks).Year - 1;
        }
        public override string ToString() =>
            $"\nClave: {clave}, Vendedor: {vendedor}, Descripcion: {descripcion}, Tipo: {tipo}, Fecha: {String.Format("{0:dd/MM/yy}",fecha)}, Antigüedad: {Antiguedad(fecha)}";//{String.Format("{0:y}", Antiguedad(fecha))}";
    }
}