using System;
using System.IO;

namespace DragonBall
{
    class Program
    {
        static void Main(string[] args)
        {
            string cabecera = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>";
            FileStream file;
            try
            {
                file = File.Create("c:\\Programacion\\DragonBALL.xml");
            }
            catch (UnauthorizedAccessException e)
            {
                System.Diagnostics.Trace.TraceError(e.Message);
                Console.WriteLine("El programa no puede escribir en la ruta"); 
                #if debug
                Console.WriteLine(e);
                #endif 
                return;

            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.TraceError(e.Message);
                Console.WriteLine("Se produjo un problema");
                return;
            }

               //file.Write(Byte[]);
                 
            Heroe heroe = new Heroe();
            heroe.Name = "Goku";
            heroe.Ki = 100000;
            Villano villano = new Villano();
            villano.Name = "Cell";
            villano.Ki = 100000;

            Console.WriteLine("Hello World!");
        }

    }

    interface IToXml
    {
        string ToXml();
    }


    public class Heroe : IToXml
    {
        public string Name { get; set; }
        public int Ki { get; set; }
        public Caracter Caracter { get; set; }
        public Fase Fase { get; set; }
        public Heroe Amigo { get; set; }
        public Villano Enemigo { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public string ToXml()
        {
            return $"<heroe><name>{Name}</name><ki>{Ki}</ki><caracter>{Caracter}</caracter>" +
            $"{Enemigo.ToXml()}</heroe>";
        }


    }

    public class Fase : IToXml
    {
        public string Name { get; set; }

        public string ToXml()
        {
            return $"<fase><name>{Name}</name></fase>";
        }

    }


    public enum Caracter
    {
        Jovial,
        Enojado,
        Violento
    }

    public class Ubicacion : IToXml
    {
        public int PosicionX { get; set; }
        public int PoscionY { get; set; }
        public int PoscionZ { get; set; }
        public DateTime PosicionTiempo { get; set; }

        public string ToXml()
        {
            return $"<ubicacion><posicionx>{PosicionX}</posicionx></ubicacion";
        }



    }

    public class Villano : IToXml
    {
        public string Name { get; set; }
        public int Ki { get; set; }
        public string ToXml()
        {
            return $"<villano><name>{Name}</name><ki>{Ki}</ki></villano>";
        }

    }

}
