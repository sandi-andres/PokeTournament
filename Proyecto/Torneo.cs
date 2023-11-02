using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Proyecto
{
    internal class Torneo
    {
        public Arena arena { get; set; }
        public List<Movimiento> movSeleccionados = new List<Movimiento>() { null, null };
        //encapsular

        public List<Jugador> contrincantes = new List<Jugador>();

        public List<List<Entrenador>> llavesTorneo = new List<List<Entrenador>>()
        {
            new List<Entrenador>(),
            new List<Entrenador>()
        };

        public Torneo(int tamanioTorneo, int cantidadJugadores, List<string> nombres)
        {
            List<Entrenador> listaEntrenadores = new List<Entrenador>();

            

            for (int i = 0; i < cantidadJugadores; i++)
                listaEntrenadores.Add(new Jugador(nombres[i]));

            int cantidadBots = tamanioTorneo - listaEntrenadores.Count;

            for (int i = 0; i < cantidadBots; i++)
                listaEntrenadores.Add(new Bot("Bot" + (i+1)));

            Random random = new Random();

            int n = listaEntrenadores.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Entrenador entrenador = listaEntrenadores[k];
                listaEntrenadores[k] = listaEntrenadores[n];
                listaEntrenadores[n] = entrenador;
            }

            Console.WriteLine("tamaño lista" + listaEntrenadores.Count);

            for (int i = 0; i < listaEntrenadores.Count; i++)
            {
                if(i < listaEntrenadores.Count / 2)
                    llavesTorneo[0].Add(listaEntrenadores[i]);
                else if (i > listaEntrenadores.Count / 2 - 1)
                    llavesTorneo[1].Add(listaEntrenadores[i]);
            }

            Console.WriteLine("Llave 1\n");

            foreach (Entrenador e in llavesTorneo[0])
            {                
                Console.WriteLine(e.nombre.ToString());
            }

            Console.WriteLine("\n\nLlave 2\n");

            foreach (Entrenador e in llavesTorneo[1])
            {

                Console.WriteLine(e.nombre.ToString());
            }


        }

        public Torneo()
        {
            arena = new Arena();

            contrincantes.Add(new Jugador("Jugador 1"));
            contrincantes.Add(new Jugador("Jugador 2"));

            //contrincantes[0].ElegirEquipo('F');
            //contrincantes[1].ElegirEquipo('C');

        }

        public string Batalla()
        {
            string resultado = "";

            Pokemon pokemonJugador1 = contrincantes[0].equipo[0];
            Pokemon pokemonJugador2 = contrincantes[1].equipo[0];

            Movimiento movJugador1 = movSeleccionados[0];
            Movimiento movJugador2 = movSeleccionados[1];

            if (pokemonJugador1.velocidad > pokemonJugador2.velocidad)
            {
                resultado += pokemonJugador1.nombre + " utiliza " + movJugador1.nombre + ". ";

                resultado += pokemonJugador2.recibirDanno(pokemonJugador1.hacerDanno(movJugador1.potencia, pokemonJugador2.defensa));

                if (pokemonJugador2.salud > 0)
                {
                    resultado += "\n" + pokemonJugador2.nombre + " utiliza " + movJugador2.nombre + ". ";

                    resultado += pokemonJugador1.recibirDanno(pokemonJugador2.hacerDanno(movJugador2.potencia, pokemonJugador1.defensa));
                }
                    
            }
            else if (pokemonJugador1.velocidad < pokemonJugador2.velocidad)
            {
                resultado += pokemonJugador2.nombre + " utiliza " + movJugador2.nombre + ". ";

                resultado = pokemonJugador1.recibirDanno(pokemonJugador2.hacerDanno(movJugador2.potencia, pokemonJugador2.defensa));

                if (pokemonJugador1.salud > 0)
                {
                    resultado += "\n" + pokemonJugador1.nombre + " utiliza " + movJugador1.nombre + ". ";

                    resultado += pokemonJugador2.recibirDanno(pokemonJugador1.hacerDanno(movJugador1.potencia, pokemonJugador1.defensa));
                }
                    
            }
            else
            {
                Random random = new Random();
                int primero = random.Next(0, 2);

                if (primero == 0)
                {
                    resultado = pokemonJugador2.recibirDanno(pokemonJugador1.hacerDanno(movJugador1.potencia, pokemonJugador2.defensa));

                    if (pokemonJugador2.salud > 0)
                        resultado += "\n" + pokemonJugador1.recibirDanno(pokemonJugador2.hacerDanno(movJugador2.potencia, pokemonJugador1.defensa));
                }
                else if (primero == 1)
                {
                    resultado = pokemonJugador1.recibirDanno(pokemonJugador2.hacerDanno(movJugador2.potencia, pokemonJugador2.defensa));

                    if (pokemonJugador1.salud > 0)
                        resultado += pokemonJugador2.recibirDanno(pokemonJugador1.hacerDanno(movJugador1.potencia, pokemonJugador1.defensa));
                }

            }

            movSeleccionados[0] = null; movSeleccionados[1] = null;

            return resultado;
        }

    }
}
