using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Arena
    {
        public string nombre { get; set; }
        public string tipo { get; set; }

        public Dictionary<string, string> tipos = new Dictionary<string, string>()
        {
            { "acero", "acero" }, {"agua","agua"}, { "bicho", "bicho" }, { "dragón", "dragón" }, { "eléctico", "eléctico" }, { "fantasma", "fantasma" },
            { "fuego", "fuego" }, { "hada", "hada" }, { "hielo", "hielo" }, { "lucha", "lucha" }, { "normal", "normal" }, { "planta", "planta"},
            { "psíquico", "psíquico" }, { "roca", "roca" }, { "siniestro", "siniestro" }, { "tierra", "tierra"}, { "veneno", "veneno" }, { "volador" , "volador"},
        };

        public Arena()
        {
            Random random = new Random();

            int index = random.Next(tipos.Count);
            nombre = tipos.Keys.ElementAt(index);
            tipo = tipos[nombre];
        }
    }
}
