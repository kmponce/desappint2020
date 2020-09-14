//Ejemplo de funcionamiento de clases en C#
// Karla Margarita Ponce Garcia
//  de Sep de 2020
using System;

namespace p15cuentabancariav1
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco mibanco =new Banco("El pochinito", "Karla Ponce");

            mibanco.AgregarCliente(new Cliente("Pancho Barraza"));
            mibanco.AgregarCliente(new Cliente("Monica Tonica"));
            mibanco.AgregarCliente(new Cliente("Toña la Negra"));
            mibanco.AgregarCliente(new Cliente("Bienvenido Granda"));

            mibanco.Clientes[0].Cuenta= new CuentaBancaria(100);
            mibanco.Clientes[1].Cuenta= new CuentaBancaria(200);
            mibanco.Clientes[2].Cuenta= new CuentaBancaria(300);
            mibanco.Clientes[3].Cuenta= new CuentaBancaria(0);
            mibanco.Clientes[2].Cuenta.Retira(100);
            mibanco.Clientes[3].Cuenta.Deposita(50);

            Console.WriteLine("Reporte General \n");
            Console.WriteLine($"Banco {mibanco.Nombre} propiedad de {mibanco.Propietario}");

            foreach(Cliente cte in mibanco.Clientes){
                 Console.WriteLine($"El cliente con nombre {cte.Nombre}");
                 Console.WriteLine($"Tiene una cuenta con un saldo de {cte.Cuenta.Saldo}");
            }
        }
    }
}
