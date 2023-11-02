using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Pokemon
    {
        public int IdPokemon { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public int Salud { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public int Velocidad { get; set; }
        public byte[] Imagen { get; set; }

        public List<Movimiento> movimientos = new List<Movimiento>();

        public Pokemon(int id, string nombre, byte[] img, string tipo)
        {
            IdPokemon = id;
            Nombre = nombre;
            Imagen= img;
            Descripcion = tipo;
        }
        public Pokemon(string nombre, string tipo1, int salud, int ataque, int defensa, int velocidad, List<Movimiento> movimientos)
        {
            this.Nombre = nombre;
            this.Tipo = tipo1;
            this.Salud = salud;
            this.Velocidad = velocidad;
            this.movimientos = movimientos;
            this.Ataque = ataque;
            this.Defensa = defensa;
        }

        public int hacerDanno(int potencia, int defensa) //, int bonusTipo, int bonusArena
        {
            Random random = new Random();

            return ((((((2 / 5 + 2) * this.Ataque * potencia) / defensa) / 50) + 2) * /* bonusTipo * bonusArena * */ random.Next(217, 256)) / 100;
        }

        public string recibirDanno(int danio)
        {
            this.Salud -= danio;

            return this.Nombre + " recibe " + danio.ToString() + " puntos de daño.";
        }
    }
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Potencia { get; set; }

        public Movimiento(int id, string nombre, string tipo, int potencia)
        {
            this.IdMovimiento = id;
            this.Nombre = nombre;
            this.Tipo = tipo;   
            this.Potencia = potencia;

        }
        public Movimiento(string nombre, string tipo, int potencia)
        {
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Potencia = potencia;
        }
    }

}
