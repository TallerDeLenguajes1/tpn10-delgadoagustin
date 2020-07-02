using System;
using System.Collections.Generic;
using System.Text;

namespace TP10
{
    enum Operacion
    {
        Venta,
        Alquiler
    }
    enum Tipo
    {
        Departamento,
        Casa,
        Duplex,
        Penthhouse,
        Terreno
    }

    class Propiedad
    {
        int id, banios, habitaciones;
        string tipoDePropiedad, tipoDeOperacion, domicilio;
        float tamanio, precio;
        bool estado;

        public int Id { get => id; set => id = value; }
        public int Banios { get => banios; set => banios = value; }
        public int Habitaciones { get => habitaciones; set => habitaciones = value; }
        public string TipoDePropiedad { get => tipoDePropiedad; set => tipoDePropiedad = value; }
        public string TipoDeOperacion { get => tipoDeOperacion; set => tipoDeOperacion = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public float Tamanio { get => tamanio; set => tamanio = value; }
        public float Precio { get => precio; set => precio = value; }
        public bool Estado { get => estado; set => estado = value; }

        public float ValorDelInmueble()
        {
            float valor;
            if (TipoDeOperacion == Convert.ToString((Operacion)1)) 
            {
                valor = Precio * (float)(1.21+0.10)+10000;
            }
            else
            {
                valor = Precio * (float)(0.02 + 0.005);
            }
            return valor;
        }
    }
}
