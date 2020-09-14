//Ejemplo de funcionamiento de clases en C#
// Karla Margarita Ponce Garcia
// 10 de Sep de 2020
using System;

namespace p15cuentabancariav1
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco mibanco = new Banco("El pochinito","Karla Ponce");

            mibanco.AgregarCliente(new Cliente("Pancho Barraza"));
            mibanco.AgregarCliente(new Cliente("Monica Tonica"));
            mibanco.AgregarCliente(new Cliente("Toña la Negra"));
            mibanco.AgregarCliente(new Cliente("Bienvenido Granda"));

            mibanco.Clientes[0].AgregarCuenta (new CuentaDeAhorro(500,0.10));
            mibanco.Clientes[0].AgregarCuenta (new CuentaDeCheques(1500,300));
            mibanco.Clientes[1].AgregarCuenta (new CuentaDeCheques(1500,200));
            mibanco.Clientes[2].AgregarCuenta (new CuentaDeAhorro(2500,0.08));
            mibanco.Clientes[2].AgregarCuenta (new CuentaDeCheques(500,30));
            mibanco.Clientes[3].AgregarCuenta (new CuentaDeAhorro(1500,0.09));
            mibanco.Clientes[3].AgregarCuenta (mibanco.Clientes[2].Cuentas[1]);

            mibanco.CalcularIntereses();

            Console.WriteLine("Reporte Bancario\n");
            Console.WriteLine($"{mibanco.Nombre} - {mibanco.Propietario}\n");
            Console.WriteLine($"Total de Clientes {mibanco.Clientes.Count}\n");
            foreach(Cliente cte in mibanco.Clientes){
                Console.WriteLine($"Cliente: {cte.Nombre} tiene {cte.Cuentas.Count} cuentas que son: \n");
                foreach(CuentaBancaria cta in cte.Cuentas){
                    Console.Write((cta is CuentaDeAhorro)? "Cuenta de Ahorro:" : "Cuenta de Cheques:");
                    Console.WriteLine($"{cta.Saldo}");
                }
                Console.WriteLine();
            }
        }
    }
}
