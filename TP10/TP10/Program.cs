using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TP10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Propiedad> Lista = new List<Propiedad>();
            
            string carpetaPrueba = Directory.GetCurrentDirectory()+"\\Prueba\\";
            string readfile = carpetaPrueba + "readfile.csv";
            if (!Directory.Exists(carpetaPrueba))
            {
                Directory.CreateDirectory(carpetaPrueba);
            }
            using (FileStream fs1 = File.Open(readfile, FileMode.Open))
            {
                StreamReader sr = new StreamReader(fs1);
                while (!sr.EndOfStream)
                {
                    Propiedad casa = new Propiedad();
                    string linea = sr.ReadLine();
                    string[] arreglo = linea.Split(";");
                    casa.Domicilio = arreglo[0];
                    casa.TipoDePropiedad = arreglo[1];
                    Lista.Add(casa);
                }
                
            }

            using (FileStream fs = new FileStream(carpetaPrueba + "prueba.csv",FileMode.Open))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (Propiedad p in Lista)
                {
                    string linea = p.Domicilio + ";NUEVO" + p.TipoDePropiedad;
                    Console.WriteLine(linea);
                    sw.WriteLine(linea);
                }
            }
            
                
            
            
        }
    }
}
