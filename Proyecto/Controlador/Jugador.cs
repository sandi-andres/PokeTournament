using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Jugador : Entrenador
    {

        public Jugador(string nombre)
        {
            this.nombre = nombre;
            this.status = true;
        }

        public override void ElegirEquipo()
        {

        }
    }
}
