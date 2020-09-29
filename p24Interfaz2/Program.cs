// Segundo ejemplo de Interfaz
// Karla Margarita Poncec Garcia
// 29 de Sep de 2020
using System;

namespace p24Interfaz2
{
    public class Organismo{
        public void Respiracion() => Console.WriteLine("Respiracion");
        public void Movimiento() => Console.WriteLine("Movimiento");
        public void Crecimiento() => Console.WriteLine("Crecimiento");
    }
    public interface IAnimales{
        void Multicelular();
        void Sangrecaliente();
    }
    public interface ICanino:IAnimales{
        void Correr();
        void Cuatropatas();
    }
    public interface IPajaro:IAnimales{
        void Volar();
        void Dospatas();
    }
    public class Perro : Organismo, ICanino{
        public void Multicelular() => Console.WriteLine("El perro es multicelular");
        public void Sangrecaliente() => Console.WriteLine("El perro tiene sangre caliente");
        public void Correr() => Console.WriteLine("El perro puede correr");
        public void Cuatropatas()=>Console.WriteLine("El perro camina en cuatro patas");
    }
    
    public class Perico: Organismo, IPajaro{
        public void Multicelular() => Console.WriteLine("El perico es multicelular");
        public void Sangrecaliente() => Console.WriteLine("El perico tiene sangre caliente");
        public void Volar()=>Console.WriteLine("El perico puede volar");
        public void Dospatas() => Console.WriteLine("El perico camina en dos patas");
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSegundo ejemplo fe interfaces:\n");
            
            Perro miperro = new Perro();
            Console.WriteLine("\nCaracteristicas del Perro:");
            miperro.Respiracion();
            miperro.Movimiento();
            miperro.Crecimiento();
            miperro.Multicelular();
            miperro.Sangrecaliente();
            miperro.Correr();
            miperro.Cuatropatas();

            Perico miperico = new Perico();
            Console.WriteLine("\nCaracteristicas del Perico:");
            miperico.Respiracion();
            miperico.Movimiento();
            miperico.Crecimiento();
            miperico.Multicelular();
            miperico.Sangrecaliente();
            miperico.Volar();
            miperico.Dospatas();
        }
    }
}
