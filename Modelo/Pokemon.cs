using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPorgramacionIV.Modelo
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
    }
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Potencia { get; set; }

    }

}
