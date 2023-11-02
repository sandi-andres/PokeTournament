using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Pokemon
    {
        public string nombre { get; set; }
        public string tipo { get; set; }
        public int salud { get; set; }
        public int velocidad { get; set; }
        public int ataque { get; set; }
        public int defensa { get; set; }


        //encapsular
        public List<Movimiento> movimientos = new List<Movimiento>();

        public Pokemon(string nombre, string tipo1, int salud, int ataque, int defensa, int velocidad, List<Movimiento> movimientos)
        {
            this.nombre = nombre;
            this.tipo = tipo1;
            this.salud = salud;
            this.velocidad = velocidad;
            this.movimientos = movimientos;
            this.ataque = ataque;
            this.defensa = defensa;
        }

        public int hacerDanno(int potencia, int defensa) //, int bonusTipo, int bonusArena
        {
            Random random = new Random();

            return ((((((2 / 5 + 2) * this.ataque * potencia) / defensa) / 50) + 2) * /* bonusTipo * bonusArena * */ random.Next(217, 256)) / 100; 
        }

        public string recibirDanno(int danio)
        {
           this.salud -= danio;

            return this.nombre + " recibe " + danio.ToString() + " puntos de daño.";
        }

    }
}
