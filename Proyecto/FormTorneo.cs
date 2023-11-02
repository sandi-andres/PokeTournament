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
    public partial class FormTorneo : Form
    {
        List<List<Entrenador>> entrenadores = new List<List<Entrenador>>();
        public FormTorneo(List<List<Entrenador>> entrenadores)
        {
            this.entrenadores = entrenadores;
            InitializeComponent();
        }

        private void FormTorneo_Load(object sender, EventArgs e)
        {

            labelEntrenador1.Text = entrenadores[0][0].nombre.ToString();
            labelEntrenador2.Text = entrenadores[0][1].nombre.ToString();
            
            labelEntrenador9.Text = entrenadores[1][0].nombre.ToString();
            labelEntrenador10.Text = entrenadores[1][1].nombre.ToString();

            if (entrenadores[0].Count > 2)
            {
                labelEntrenador3.Text = entrenadores[0][2].nombre.ToString();
                labelEntrenador4.Text = entrenadores[0][3].nombre.ToString();

                labelEntrenador11.Text = entrenadores[1][2].nombre.ToString();
                labelEntrenador12.Text = entrenadores[1][3].nombre.ToString();
            }
            if (entrenadores[0].Count > 4)
            {
                labelEntrenador5.Text = entrenadores[0][4].nombre.ToString();
                labelEntrenador6.Text = entrenadores[0][5].nombre.ToString();
                labelEntrenador7.Text = entrenadores[0][6].nombre.ToString();
                labelEntrenador8.Text = entrenadores[0][7].nombre.ToString();

                labelEntrenador13.Text = entrenadores[1][4].nombre.ToString();
                labelEntrenador14.Text = entrenadores[1][5].nombre.ToString();
                labelEntrenador15.Text = entrenadores[1][6].nombre.ToString();
                labelEntrenador16.Text = entrenadores[1][7].nombre.ToString();
            }
        }
    }
}
