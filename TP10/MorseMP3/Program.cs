using System;
using Helpers;

namespace MorseMP3
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = "agustin asdsad";
            string morse = ConversorDeMorse.TextoAMorse(texto);
            ConversorDeMorse.MorseAMP3(morse);
        }
    }
}
