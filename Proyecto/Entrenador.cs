using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Entrenador
    {
        public string nombre { get; set; }
        public bool status { get; set; }

        //encapsular
        internal List<Pokemon> equipo = new List<Pokemon>();

        public virtual void ElegirEquipo()
        {

        }
    }
}
