using ProyectoPorgramacionIV.Controlador;
using ProyectoPorgramacionIV.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace ProyectoPorgramacionIV
{
    public partial class Form1 : Form
    {
        //se inicializan controles 
        private ControladorPokemon controlador;
        private int index;
        
        public Form1()
        {
            InitializeComponent();
            //Se llama a los elementos del controlador 
            controlador = new ControladorPokemon(
                this,
                PictureBoxPokemon,
                lblIdPokemon,
                lblTipoPokemon,
                lblMovimiento1,
                lblMovimiento2,
                lblMovimiento3,
                lblMovimiento4,
                lblTipo1,
                lblTipo2,
                lblTipo3,
                lblTipo4,
                lblPotencia1,
                lblPotencia2,
                lblPotencia3,
                lblPotencia4,
                lblNombrePokemon1,
                lblNombrePokemon2,
                lblNombrePokemon3,
                lblNombrePokemon4,
                lblNombrePokemon5,
                lblNombrePokemon6,
                lblNumPokemon1,
                lblNumPokemon2,
                lblNumPokemon3,
                lblNumPokemon4,
                lblNumPokemon5,
                lblNumPokemon6,
                lblTipoP1,
                lblTipoP2,
                lblTipoP3,
                lblTipoP4,
                lblTipoP5,
                lblTipoP6,
            rtbDescripcionPokemon,
                lblNombre,
                picPokemon1,
                picPokemon2,
                picPokemon3,
                picPokemon4,
                picPokemon5,
                picPokemon6,
                btnEliminar
               
            );

            ModeloPokemon modelo = new ModeloPokemon();
        }



        private void btnAnterior_Click(object sender, EventArgs e)
        {
            controlador.CargarPokemonAnterior();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            controlador.CargarPokemonSiguiente();
        }

       
        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
           controlador.SeleccionarImagen();
           controlador.PictureBoxSeleccionado(index);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombrePokemonBuscado = txtBusqueda.Text;
            controlador.BuscarPokemon(nombrePokemonBuscado);
        }

       
        private void PicPokemon1_Click(object sender, EventArgs e)
        {
            controlador.MarcarBordePokemon(picPokemon1);
            controlador.EstablecerPicPokemonSeleccionadoIndex(0);
            index = 0; 
        }

        private void PicPokemon2_Click(object sender, EventArgs e)
        {
            controlador.MarcarBordePokemon(picPokemon2);
            controlador.EstablecerPicPokemonSeleccionadoIndex(0);
            index = 0; 
        }

        private void PicPokemon3_Click(object sender, EventArgs e)
        {
            controlador.MarcarBordePokemon(picPokemon3);
            controlador.EstablecerPicPokemonSeleccionadoIndex(0);
            index = 0; 
        }

        private void PicPokemon4_Click(object sender, EventArgs e)
        {
            controlador.MarcarBordePokemon(picPokemon4);
            controlador.EstablecerPicPokemonSeleccionadoIndex(0);
            index = 0; 
        }
        private void PicPokemon5_Click(object sender, EventArgs e)
        {
            controlador.MarcarBordePokemon(picPokemon5);
            controlador.EstablecerPicPokemonSeleccionadoIndex(0);
            index = 0; 
        }
        private void PicPokemon6_Click(object sender, EventArgs e)
        {
            controlador.MarcarBordePokemon(picPokemon6);
            controlador.EstablecerPicPokemonSeleccionadoIndex(0);
            index = 0; 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            controlador.EliminarPokemon();
        }
    }
}
