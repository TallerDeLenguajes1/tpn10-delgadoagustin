using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Helpers
{
    static class SoporteParaConfiguracion
    {
        static public void CrearArchivoDeConfiguracion(string path, string moveTo)
        {
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] data = new UTF8Encoding(true).GetBytes(moveTo);
                    fs.Write(data, 0, data.Length);
                }
                Console.WriteLine("Creado con Exito");
            }
            else
            {
                Console.WriteLine("Archivo Existente");
            }
        }
        static public string LeerConfiguracion(string path) 
        {
            using FileStream fs = File.OpenRead(path);
            using StreamReader sr = new StreamReader(fs);
            string dir;
            if((dir = sr.ReadLine()) != null)
            {
                return dir;
            }
            return "vacio";
        }
    }
    
    static class ConversorDeMorse
    {
        static Dictionary<char, string> Diccionario = new Dictionary<char, string>
        {
            {'a', ".-"},
            {'b', "-..."},
            {'c', "-.-."},
            {'d', "-.."},
            {'e', "."},
            {'f', "..-."},
            {'g', "--."},
            {'h', "...."},
            {'i', ".."},
            {'j', ".---"},
            {'k', "-.-"},
            {'l', ".-.."},
            {'m', "--"},
            {'n', "-."},
            {'o', "---"},
            {'p', ".--."},
            {'q', "--.-"},
            {'r', ".-."},
            {'s', "..."},
            {'t', "-"},
            {'u', "..-"},
            {'v', "...-"},
            {'w', ".--"},
            {'x', "-..-"},
            {'y', "-.--"},
            {'z', "--.."},
            {'0', "-----"},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},
            {' ', "\\" },
        };
        static public string MorseATexto(string Morse)
        {
            string Texto = "";
            string[] Arreglo = Morse.Split(" ");
            foreach(string s in Arreglo)
            {
                char key = Diccionario.FirstOrDefault(x => x.Value == s).Key;
                Texto = string.Concat(Texto, key);
            }
            return Texto;
        }
        static public string TextoAMorse(string Texto)
        {
            string Morse="";
            foreach(char letter in Texto)
            {
                Morse = String.Concat(Morse,Diccionario[letter]+' ');
            }
            return Morse;
        }
        
        static public void MorseAMP3(string morse)
        {
            string audios = Directory.GetCurrentDirectory()+"\\audio";
            string[] arreglo = morse.Split(" ");
            using (FileStream fs = File.Create(audios + "\\creado.mp3"))
            {
                byte[] punto = File.ReadAllBytes(Path.Combine(audios,"punto.mp3"));
                byte[] raya = File.ReadAllBytes(Path.Combine(audios, "raya.mp3"));
                //byte[] oneseg = File.ReadAllBytes(Path.Combine(audios, "1seg.mp3"));
                //byte[] twoseg = File.ReadAllBytes(Path.Combine(audios, "2seg.mp3"));
                foreach (string s in arreglo)
                {
                    foreach (char c in s)
                    {
                        switch (c)
                        {
                            case '.':
                                fs.Write(punto, 0, punto.Length);
                                //Console.WriteLine("Punto");
                                break;
                            case '-':
                                fs.Write(raya, 0, raya.Length);
                                //Console.WriteLine("Guion");
                                break;
                            case '\\':
                                //fs.Write(twoseg, 0, twoseg.Length);
                                //Console.WriteLine("Pausa2");
                                break;
                        }
                    }
                    //fs.Write(oneseg, 0, oneseg.Length);
                    //Console.WriteLine("Pausa1");
                }
            }
        }
    }
}
