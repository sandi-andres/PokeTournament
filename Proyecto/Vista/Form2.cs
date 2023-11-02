using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Proyecto
{
    public partial class Form2 : Form
    {

        internal List<string> nombres = new List<string>();
        
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("")) nombres.Add(textBox1.Text);
            if (!textBox2.Text.Equals("")) nombres.Add(textBox2.Text);
            if (!textBox3.Text.Equals("")) nombres.Add(textBox3.Text);
            if (!textBox4.Text.Equals("")) nombres.Add(textBox4.Text);
            if (!textBox5.Text.Equals("")) nombres.Add(textBox5.Text);
            if (!textBox6.Text.Equals("")) nombres.Add(textBox6.Text);
            if (!textBox7.Text.Equals("")) nombres.Add(textBox7.Text);
            if (!textBox8.Text.Equals("")) nombres.Add(textBox8.Text);
            if (!textBox9.Text.Equals("")) nombres.Add(textBox9.Text);
            if (!textBox10.Text.Equals("")) nombres.Add(textBox10.Text);
            if (!textBox11.Text.Equals("")) nombres.Add(textBox11.Text);
            if (!textBox12.Text.Equals("")) nombres.Add(textBox12.Text);
            if (!textBox13.Text.Equals("")) nombres.Add(textBox13.Text);
            if (!textBox14.Text.Equals("")) nombres.Add(textBox14.Text);
            if (!textBox15.Text.Equals("")) nombres.Add(textBox15.Text);
            if (!textBox16.Text.Equals("")) nombres.Add(textBox16.Text);

            listBox1.DataSource= nombres;
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            int tamanioTorneo = Convert.ToInt32(comboBoxTamanio.SelectedItem);

            Console.WriteLine("Tamaño torneo: "+tamanioTorneo.ToString());

            int cantidadJugadores = Convert.ToInt32(comboBoxCantidad.SelectedItem);

            Console.WriteLine("Cantidad jugadores: " + cantidadJugadores.ToString());

            Torneo torneo = new Torneo(tamanioTorneo, cantidadJugadores, nombres);

            FormTorneo formtorneo = new FormTorneo(torneo.llavesTorneo);
            formtorneo.Show();

        }
    }
}
