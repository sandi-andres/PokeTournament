using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Bot : Entrenador
    {
        public Bot(string nombre)
        {
            this.nombre = nombre;
            this.status = true;
        }

        public override void ElegirEquipo()
        {

        }

    }


}
