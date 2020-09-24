using System;
using System.Collections.Generic;

namespace p23examen1
{
    class Red{
        private string empresa;
        private string propietario;
        private string domicilio;
        private List<Nodo> nodos;
        public Red(string empresa,string propietario, string domicilio){
            this.empresa=empresa;
            this.propietario=propietario;
            this.domicilio=domicilio;
            nodos=new List<Nodo>();
        }
        public string Empresa{get {return empresa;} set{empresa=value;}}
        public string Propietario{get {return propietario;} set{propietario=value;}}
        public string Domicilio{get {return domicilio;} set{domicilio=value;}}

        public List<Nodo> Nodos{
            get{return nodos;}
        }
        
        public void AddNodo(Nodo nod){
            nodos.Add(nod);
        }
        
        public override string ToString() =>
            $"Empresa\t\t:\t{empresa}\nPropietario\t:\t{propietario}\nDomicilio\t:\t{domicilio}\n";
        
        //Calcular vulnerabilidades y nodos
        public int numVulnes(Nodo nod){
            return nod.Vulnes.Count;
        }
        public int Mayor(List<Nodo> nod)
        {
            int m=-1;
            foreach(Nodo n in nod){
                if(n.Saltos>m){
                    m=n.Saltos;
                }
            }
            return m;
        }

        public int Menor(List<Nodo> nod)
        {
            int m=1000;
            foreach(Nodo n in nod){
                if(n.Saltos<m){
                    m=n.Saltos;
                }
            }
            return m;
        }
    }
}