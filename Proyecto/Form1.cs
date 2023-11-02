using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Form1 : Form
    {
        Torneo bt = new Torneo();

        public Form1()
        {
            InitializeComponent();
            Refrescar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Elegir movimientos.";
        }

        private void Refrescar()
        {
            /*listBox1.Items.Clear();

            listBox1.Items.Add("Jugador: " + bt.contrincantes[0].nombre);
            listBox1.Items.Add("Pokemon: " + bt.contrincantes[0].equipo[0].nombre);
            listBox1.Items.Add("Tipo: " + bt.contrincantes[0].equipo[0].tipo);
            listBox1.Items.Add("Salud: " + bt.contrincantes[0].equipo[0].salud);

            primerMovJugador1.Text = bt.contrincantes[0].equipo[0].movimientos[0].nombre;
            segundoMovJugador1.Text = bt.contrincantes[0].equipo[0].movimientos[1].nombre;
            tercerMovJugador1.Text = bt.contrincantes[0].equipo[0].movimientos[2].nombre;
            cuartoMovJugador1.Text = bt.contrincantes[0].equipo[0].movimientos[3].nombre;

            listBox2.Items.Clear();
            listBox2.Items.Add("Jugador: " + bt.contrincantes[1].nombre);
            listBox2.Items.Add("Pokemon: " + bt.contrincantes[1].equipo[0].nombre);
            listBox2.Items.Add("Tipo: " + bt.contrincantes[1].equipo[0].tipo);
            listBox2.Items.Add("Salud: " + bt.contrincantes[1].equipo[0].salud);

            primerMovJugador2.Text = bt.contrincantes[1].equipo[0].movimientos[0].nombre;
            segundoMovJugador2.Text = bt.contrincantes[1].equipo[0].movimientos[1].nombre;
            tercerMovJugador2.Text = bt.contrincantes[1].equipo[0].movimientos[2].nombre;
            cuartoMovJugador2.Text = bt.contrincantes[1].equipo[0].movimientos[3].nombre;

            if (bt.movSeleccionados[0] == null || bt.movSeleccionados[1] == null)
                buttonAvanzar.Enabled = false;*/
        }
        
        private void HabilitarAvanzar()
        {
            if (bt.movSeleccionados[0] != null && bt.movSeleccionados[1] != null)
                buttonAvanzar.Enabled = true;
        }

        private void DesHabilitarMovimientos(int jugador)
        {
            if(jugador == 1) 
            { 
                primerMovJugador1.Enabled = false; segundoMovJugador1.Enabled = false; tercerMovJugador1.Enabled = false; cuartoMovJugador1.Enabled = false;
            }

            else if (jugador == 2)
            {
                primerMovJugador2.Enabled = false; segundoMovJugador2.Enabled = false; tercerMovJugador2.Enabled = false; cuartoMovJugador2.Enabled = false;
            }
                
        }

        private void buttonAvanzar_Click(object sender, EventArgs e)
        {
            label1.Text = bt.Batalla();
            Refrescar();

            primerMovJugador1.Enabled = true; segundoMovJugador1.Enabled = true; tercerMovJugador1.Enabled = true; cuartoMovJugador1.Enabled = true;
            primerMovJugador2.Enabled = true; segundoMovJugador2.Enabled = true; tercerMovJugador2.Enabled = true; cuartoMovJugador2.Enabled = true;
            buttonAvanzar.Enabled = false;
        }

        private void primerMovJugador1_Click(object sender, EventArgs e)
        {
            bt.movSeleccionados[0] = bt.contrincantes[0].equipo[0].movimientos[0];

            label1.Text = bt.contrincantes[0].nombre + " ha elegido " + bt.contrincantes[0].equipo[0].movimientos[0].nombre;

            DesHabilitarMovimientos(1);

            HabilitarAvanzar();
        }

        private void segundoMovJugador1_Click(object sender, EventArgs e)
        {
            bt.movSeleccionados[0] = bt.contrincantes[0].equipo[0].movimientos[1];

            label1.Text = bt.contrincantes[0].nombre + " ha elegido " + bt.contrincantes[0].equipo[0].movimientos[1].nombre;

            DesHabilitarMovimientos(1);

            HabilitarAvanzar();
        }

        private void tercerMovJugador1_Click(object sender, EventArgs e)
        {
            bt.movSeleccionados[0] = bt.contrincantes[0].equipo[0].movimientos[2];

            label1.Text = bt.contrincantes[0].nombre + " ha elegido " + bt.contrincantes[0].equipo[0].movimientos[2].nombre;

            DesHabilitarMovimientos(1);

            HabilitarAvanzar();
        }

        private void cuartoMovJugador1_Click(object sender, EventArgs e)
        {
            bt.movSeleccionados[0] = bt.contrincantes[0].equipo[0].movimientos[3];

            label1.Text = bt.contrincantes[0].nombre + " ha elegido " + bt.contrincantes[0].equipo[0].movimientos[3].nombre;

            DesHabilitarMovimientos(1);

            HabilitarAvanzar();
        }

        private void primerMovJugador2_Click(object sender, EventArgs e)
        {
            bt.movSeleccionados[1] = bt.contrincantes[1].equipo[0].movimientos[0];

            label1.Text = bt.contrincantes[1].nombre + " ha elegido " + bt.contrincantes[1].equipo[0].movimientos[0].nombre;

            DesHabilitarMovimientos(2);

            HabilitarAvanzar();
        }

        private void segundoMovJugador2_Click(object sender, EventArgs e)
        {
            bt.movSeleccionados[1] = bt.contrincantes[1].equipo[0].movimientos[1];

            label1.Text = bt.contrincantes[1].nombre + " ha elegido " + bt.contrincantes[1].equipo[0].movimientos[1].nombre;

            DesHabilitarMovimientos(2);

            HabilitarAvanzar();
        }

        private void tercerMovJugador2_Click(object sender, EventArgs e)
        {
            bt.movSeleccionados[1] = bt.contrincantes[1].equipo[0].movimientos[2];

            label1.Text = bt.contrincantes[1].nombre + " ha elegido " + bt.contrincantes[1].equipo[0].movimientos[2].nombre;

            DesHabilitarMovimientos(2);

            HabilitarAvanzar();
        }

        private void cuartoMovJugador2_Click(object sender, EventArgs e)
        {
            bt.movSeleccionados[1] = bt.contrincantes[1].equipo[0].movimientos[3];

            label1.Text = bt.contrincantes[1].nombre + " ha elegido " + bt.contrincantes[1].equipo[0].movimientos[3].nombre;

            DesHabilitarMovimientos(2);

            HabilitarAvanzar();
        }
    }
}
