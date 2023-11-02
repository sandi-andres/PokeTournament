using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Movimiento
    {
        public string nombre { get; set; }
        public string tipo { get; set; }
        public int potencia { get; set; }

        public Movimiento(string nombre, string tipo, int potencia)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.potencia = potencia;
        }
    }
}
