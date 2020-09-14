    using System;

namespace p15cuentabancariav1
{
    class CuentaBancaria{
        private double saldo;
        // Constructor
        public CuentaBancaria(double saldo){
            this.saldo = saldo;
        }

        public double Saldo{
            get { return saldo;}
        }

        public void Deposita(double cant){
            saldo+=cant;
        }

        public bool Retira(double cant){
            if(saldo >= cant){
                saldo-=cant;
                return true;
            }
            else return false;
        }
    }
}