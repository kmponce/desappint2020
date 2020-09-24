using System;
using System.Collections.Generic;

namespace p23examen1
{
    class Nodo{
        private string ip;
        private string tipo;
        private int puertos;
        private int saltos;
        private string so;
        private List<Vulnerabilidad> vulnes;
        public Nodo(string ip, string tipo, int puertos, int saltos, string so){
            this.ip=ip;
            this.tipo=tipo;
            this.puertos=puertos;
            this.saltos=saltos;
            this.so=so;
            vulnes = new List<Vulnerabilidad>();
        }
        public string IP{ get{return ip;} set{ip=value;}}
        public string Tipo{get{return tipo;} set{tipo=value;}}
        public int Puertos{get{return puertos;} set{puertos=value;}}
        public int Saltos{get{return saltos;} set{saltos=value;}}
        public string SO{get{return so;} set{so=value;}}
        public List<Vulnerabilidad> Vulnes{
            get {return vulnes;}
        }

        public void AddVulnes(Vulnerabilidad vul){
            vulnes.Add(vul);
        }

        public override string ToString() =>
            $"IP: {IP}, Tipo: {Tipo},\tPuertos: {Puertos},\tSaltos: {Saltos},\tSO: {SO},\tTotVul: {Vulnes.Count}";
        //Calcular Vulnerabilidades
        
    }
}