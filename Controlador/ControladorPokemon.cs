using ProyectoPorgramacionIV.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using ProyectoPorgramacionIV.Controlador;

namespace ProyectoPorgramacionIV {
    public class ControladorPokemon
    {
        //inicializa las clases 
        private ModeloPokemon modelo;
        private Form1 vista;
        //inicializa elementos del form
        private PictureBox PictureBoxPokemon;
        private Label lblNombre;
        private Label lblIdPokemon;
        private Label lblTipoPokemon;
        private Label lblMovimiento1;
        private Label lblMovimiento2;
        private Label lblMovimiento3;
        private Label lblMovimiento4;
        private Label lblTipo1;
        private Label lblTipo2;
        private Label lblTipo3;
        private Label lblTipo4;
        private Label lblPotencia1;
        private Label lblPotencia2;
        private Label lblPotencia3;
        private Label lblPotencia4;
        private Label lblNombrePokemon1;
        private Label lblNombrePokemon2;
        private Label lblNombrePokemon3;
        private Label lblNombrePokemon4;
        private Label lblNombrePokemon5;
        private Label lblNombrePokemon6;
        private Label lblNumPokemon1;
        private Label lblNumPokemon2;
        private Label lblNumPokemon3;
        private Label lblNumPokemon4;
        private Label lblNumPokemon5;
        private Label lblNumPokemon6;
        private Label lblTipoP1;
        private Label lblTipoP2;
        private Label lblTipoP3;
        private Label lblTipoP4;
        private Label lblTipoP5;
        private Label lblTipoP6;
        private RichTextBox rtbDescripcionPokemon;
        private PictureBox picPokemon1;
        private PictureBox picPokemon2;
        private PictureBox picPokemon3;
        private PictureBox picPokemon4;
        private PictureBox picPokemon5;
        private PictureBox picPokemon6;
        private Button btnEliminar;

        //inicializa listas 
        private PictureBox[] picPokemonArray;
        private Label[] lblNumPokemonArray = new Label[6];
        private Label[] lblTipoPArray = new Label[6];
        private Label[] lblNombrePokemonArray = new Label[6];
        private bool[] picPokemonOcupado = new bool[6];
        private List<Movimiento> movimientosDelPokemonActual;
        private List<Pokemon> todosLosPokemon;
        private List<string> pokemonesSeleccionados = new List<string>();
        private int indicePokemonActual = 0;
        private int indicePokemonSeleccionado = 0; 
        private int picPokemonSeleccionadoIndex = -1;
        private PictureBox pictureBoxSeleccionadoEliminar = null;
        List<string> pokemonNombres = new List<string>();

        public ControladorPokemon(Form1 vista,PictureBox PictureBoxPokemon, Label labelId, Label labelTipoPokemon, Label movimiento1, Label movimiento2, Label movimiento3, Label movimiento4, Label tipo1, Label tipo2, Label tipo3, Label tipo4, Label potencia1, Label potencia2, Label potencia3, Label potencia4, Label lblNombrePokemon1,
           Label lblNombrePokemon2, Label lblNombrePokemon3, Label lblNombrePokemon4, Label lblNombrePokemon5, Label lblNombrePokemon6, Label lblNumPokemon1, Label lblNumPokemon2, Label lblNumPokemon3, Label lblNumPokemon4, Label lblNumPokemon5, Label lblNumPokemon6,
         Label lblTipoP1, Label lblTipoP2, Label lblTipoP3, Label lblTipoP4, Label lblTipoP5, Label lblTipoP6, RichTextBox descripcionPokemon, Label lblNombre, PictureBox picPokemon1, PictureBox picPokemon2, PictureBox picPokemon3, PictureBox picPokemon4, PictureBox picPokemon5, PictureBox picPokemon6, Button btnEliminar)
        {
            this.modelo = new ModeloPokemon();
            this.vista = vista; 
            this.PictureBoxPokemon = PictureBoxPokemon;
            this.lblIdPokemon = labelId;
            this.lblTipoPokemon = labelTipoPokemon;
            this.lblMovimiento1 = movimiento1;
            this.lblMovimiento2 = movimiento2;
            this.lblMovimiento3 = movimiento3;
            this.lblMovimiento4 = movimiento4;
            this.lblTipo1 = tipo1;
            this.lblTipo2 = tipo2;
            this.lblTipo3 = tipo3;
            this.lblTipo4 = tipo4;
            this.lblPotencia1 = potencia1;
            this.lblPotencia2 = potencia2;
            this.lblPotencia3 = potencia3;
            this.lblPotencia4 = potencia4;
            this.lblNombre = lblNombre;
            this.rtbDescripcionPokemon = descripcionPokemon;
            this.btnEliminar =btnEliminar;
            //agrega las imagenes 
            picPokemonArray = new PictureBox[] { picPokemon1, picPokemon2, picPokemon3, picPokemon4, picPokemon5, picPokemon6 };
            //Agrega el nombre, tipo y id del pokemon a los labels indicados 
            lblNombrePokemonArray[0] = lblNombrePokemon1;
            lblNombrePokemonArray[1] = lblNombrePokemon2;
            lblNombrePokemonArray[2] = lblNombrePokemon3;
            lblNombrePokemonArray[3] = lblNombrePokemon4;
            lblNombrePokemonArray[4] = lblNombrePokemon5;
            lblNombrePokemonArray[5] = lblNombrePokemon6;

            lblNumPokemonArray[0] = lblNumPokemon1;
            lblNumPokemonArray[1] = lblNumPokemon2;
            lblNumPokemonArray[2] = lblNumPokemon3;
            lblNumPokemonArray[3] = lblNumPokemon4;
            lblNumPokemonArray[4] = lblNumPokemon5;
            lblNumPokemonArray[5] = lblNumPokemon6;

            lblTipoPArray[0] = lblTipoP1;
            lblTipoPArray[1] = lblTipoP2;
            lblTipoPArray[2] = lblTipoP3;
            lblTipoPArray[3] = lblTipoP4;
            lblTipoPArray[4] = lblTipoP5;
            lblTipoPArray[5] = lblTipoP6;

            //rastrear si el correspondiente PictureBox en el arreglo picPokemonArray está ocupado o no.
            picPokemonOcupado = new bool[picPokemonArray.Length];
            todosLosPokemon = modelo.ObtenerTodosLosPokemon();
            pokemonNombres = todosLosPokemon.Select(pokemon => pokemon.Nombre).ToList();
            if (pokemonNombres.Count != todosLosPokemon.Count)
            {
                throw new Exception("Error: La cantidad de nombres de Pokémon no coincide con la cantidad de Pokémon.");
            }

            MostrarPokemonActual();
        }


        //Muestra el pokemon en el PictureBoxPokemon junto con sus labels y demas datos
        public void MostrarPokemonActual()
        {
            if (indicePokemonActual >= 0 && indicePokemonActual < todosLosPokemon.Count)
            {
                Pokemon pokemonActual = todosLosPokemon[indicePokemonActual];
                if (pokemonActual.Imagen != null && pokemonActual.Imagen.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(pokemonActual.Imagen))
                    {
                        PictureBoxPokemon.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    PictureBoxPokemon.Image = null;
                }
                //Nombre
                lblNombre.Text = pokemonActual.Nombre;
                lblIdPokemon.Text = $"#{pokemonActual.IdPokemon}";
                lblTipoPokemon.Text = pokemonActual.Tipo;
                //Descripcion
                string descripcion = ObtenerDescripcionDelPokemon(pokemonActual.IdPokemon);
                rtbDescripcionPokemon.Text = descripcion;
                rtbDescripcionPokemon.SelectAll();
                rtbDescripcionPokemon.SelectionAlignment = HorizontalAlignment.Center;

                // Obtener y mostrar los movimientos del Pokémon
                ObtenerYMostrarMovimientosDelPokemon(pokemonActual.IdPokemon);
            }
            else
            {
                // Si no hay Pokémon actual, se pone en null.
                PictureBoxPokemon.Image = null;
                lblNombre.Text = string.Empty;
                lblIdPokemon.Text = string.Empty;
                lblTipoPokemon.Text = string.Empty;
                rtbDescripcionPokemon.Text = string.Empty;
                LimpiarEtiquetasDeMovimientos();
            }
        }
        //Permite mostrar los movimientos 
        private void ObtenerYMostrarMovimientosDelPokemon(int idPokemon)
        {
          
            movimientosDelPokemonActual = modelo.ObtenerMovimientosPorPokemon(idPokemon);
            MostrarMovimientosEnEtiquetas();
        }
        //Los asigna a labels 
        private void MostrarMovimientosEnEtiquetas()
        {
            if (movimientosDelPokemonActual.Count >= 4)
            {
                lblMovimiento1.Text = movimientosDelPokemonActual[0].Nombre;
                lblMovimiento2.Text = movimientosDelPokemonActual[1].Nombre;
                lblMovimiento3.Text = movimientosDelPokemonActual[2].Nombre;
                lblMovimiento4.Text = movimientosDelPokemonActual[3].Nombre;

                // Mostrar los tipos de los movimientos
                lblTipo1.Text = movimientosDelPokemonActual[0].Tipo;
                lblTipo2.Text = movimientosDelPokemonActual[1].Tipo;
                lblTipo3.Text = movimientosDelPokemonActual[2].Tipo;
                lblTipo4.Text = movimientosDelPokemonActual[3].Tipo;

                // Mostrar la potencia de los movimientos
                lblPotencia1.Text = movimientosDelPokemonActual[0].Potencia.ToString();
                lblPotencia2.Text = movimientosDelPokemonActual[1].Potencia.ToString();
                lblPotencia3.Text = movimientosDelPokemonActual[2].Potencia.ToString();
                lblPotencia4.Text = movimientosDelPokemonActual[3].Potencia.ToString();
            }
            else
            {
                LimpiarEtiquetasDeMovimientos();
            }
        }
        // cuando se cambian los pokemones se limpian los labels 
        private void LimpiarEtiquetasDeMovimientos()
        {
            lblMovimiento1.Text = string.Empty;
            lblMovimiento2.Text = string.Empty;
            lblMovimiento3.Text = string.Empty;
            lblMovimiento4.Text = string.Empty;
        }

        //Obtiene la descripcion del pokemon desde la clase modelo 
        private string ObtenerDescripcionDelPokemon(int idPokemon)
        {
           
            return modelo.ObtenerDescripcionDelPokemon(idPokemon);
        }

     //Para los botones de anterior y siguiente
        public void CargarPokemonAnterior()
        {
            if (indicePokemonActual > 0)
            {
                indicePokemonActual--;
                MostrarPokemonActual();
            }
        }

        public void CargarPokemonSiguiente()
        {
            if (indicePokemonActual < todosLosPokemon.Count - 1)
            {
                indicePokemonActual++;
                MostrarPokemonActual();
            }
        }

        //Selecciona la imagen del picturebox y guarda la imagen , el tipo, el nombre y el id de ese pokemon en los labels picPokemon.
        public void SeleccionarImagen()
        {
            string nombrePokemon = lblNombre.Text;

            if (string.IsNullOrWhiteSpace(nombrePokemon))
            {
                MessageBox.Show("No se ha seleccionado un Pokémon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int picPokemonIndex = BuscarPictureBoxDisponible();

            if (picPokemonIndex == -1)
            {
                MessageBox.Show("No hay PictureBox disponibles para colocar la imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (PokemonYaSeleccionado(nombrePokemon))
            {
                MessageBox.Show("¡Este Pokémon ya ha sido seleccionado en otra casilla!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Consulta el modelo para obtener la imagen y el ID del Pokémon
            byte[] imagen = modelo.ObtenerImagenPorNombre(nombrePokemon);
            int idPokemon = modelo.ObtenerIdPokemon(nombrePokemon); 

            if (imagen == null)
            {
                MessageBox.Show("Imagen no encontrada en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Actualiza la etiqueta lblNumPokemon en función del índice actual
            if (indicePokemonSeleccionado < lblNumPokemonArray.Length)
            {
                Label lblNumPokemon = lblNumPokemonArray[picPokemonIndex];

                // Actualiza el valor del ID
                lblIdPokemon.Text = $"#{idPokemon}";

                lblNumPokemon.Text = lblIdPokemon.Text; // Copia el valor del ID

                // Actualiza el índice para el próximo Pokémon
                indicePokemonSeleccionado++;
            }
            else
            {
                MessageBox.Show("Ya se han seleccionado todos los Pokémon disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Actualiza el nombre del Pokémon en el próximo Label disponible
            Label lblNombrePokemon = lblNombrePokemonArray[picPokemonIndex];
            lblNombrePokemon.Text = nombrePokemon;

            // Agrega el nombre del Pokémon seleccionado a la lista de Pokémon seleccionados
            pokemonesSeleccionados.Add(nombrePokemon);

            using (MemoryStream ms = new MemoryStream(imagen))
            {
                picPokemonArray[picPokemonIndex].Image = Image.FromStream(ms);
            }

            // Actualiza el tipo del Pokémon en el próximo Label disponible
            Label lblTipoP = lblTipoPArray[picPokemonIndex];
            lblTipoP.Text = lblTipoPokemon.Text;

            // El picture box se marca como ocupado 
            picPokemonOcupado[picPokemonIndex] = true;
        }

        //Permite que funcione la busqueda de pokemones 
        public void BuscarPokemon(string nombrePokemon)
        {
            Pokemon pokemonBuscado = modelo.ObtenerPokemonPorNombre(nombrePokemon);

            if (pokemonBuscado != null)
            {
                if (pokemonBuscado.Imagen != null && pokemonBuscado.Imagen.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(pokemonBuscado.Imagen))
                    {
                        PictureBoxPokemon.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    PictureBoxPokemon.Image = null;
                }

                lblNombre.Text = pokemonBuscado.Nombre;
                lblIdPokemon.Text = $"#{pokemonBuscado.IdPokemon}";
                lblTipoPokemon.Text = pokemonBuscado.Tipo;

                string descripcion = ObtenerDescripcionDelPokemon(pokemonBuscado.IdPokemon);
                rtbDescripcionPokemon.Text = descripcion;

                ObtenerYMostrarMovimientosDelPokemon(pokemonBuscado.IdPokemon);
            }
            else
            {
                PictureBoxPokemon.Image = null;
                lblNombre.Text = string.Empty;
                lblIdPokemon.Text = string.Empty;
                lblTipoPokemon.Text = string.Empty;
                rtbDescripcionPokemon.Text = string.Empty;
                LimpiarEtiquetasDeMovimientos();
            }
        }


        //Cuando se elimina un pokemon y se selecciona otro permite guardarlo en el picturebox disponible 
        private int BuscarPictureBoxDisponible()
        {
            for (int i = 0; i < picPokemonArray.Length; i++)
            {
                if (picPokemonArray[i].Image == null)
                {
                    return i;
                }
            }
            return -1;
        }
        

        private bool PokemonYaSeleccionado(string nombrePokemon)
        {
            // Verifica si el nombre del Pokémon ya existe en la lista de Pokémon seleccionados
            return pokemonesSeleccionados.Contains(nombrePokemon);
        }

        // para saber si se marca un picture box de algun pokemon
        public void EstablecerPicPokemonSeleccionadoIndex(int index)
        {
            picPokemonSeleccionadoIndex = index;
        }

        public void EliminarPokemon()
        {
            if (pictureBoxSeleccionadoEliminar != null)
            {
                int picPokemonSeleccionadoIndex = picPokemonArray.ToList().IndexOf(pictureBoxSeleccionadoEliminar);

                // Obtiene el nombre del Pokémon que se va a eliminar
                string nombrePokemon = lblNombrePokemonArray[picPokemonSeleccionadoIndex].Text;

                // Elimina la imagen del PictureBox seleccionado
                pictureBoxSeleccionadoEliminar.Image = null;

                // Marca el PictureBox seleccionado como no ocupado
                picPokemonOcupado[picPokemonSeleccionadoIndex] = false;

                // Limpia las etiquetas asociadas al PictureBox seleccionado
                lblNumPokemonArray[picPokemonSeleccionadoIndex].Text = string.Empty;
                lblNombrePokemonArray[picPokemonSeleccionadoIndex].Text = string.Empty;
                lblTipoPArray[picPokemonSeleccionadoIndex].Text = string.Empty;

                // Limpia la lista de Pokémon seleccionados
                pokemonesSeleccionados.Remove(nombrePokemon);

                // Reinicia el PictureBox seleccionado
                pictureBoxSeleccionadoEliminar = null;

                // Actualiza el índice de Pokémon seleccionados
                indicePokemonSeleccionado--;

                // Deshabilita el botón de eliminar
                HabilitarBotonEliminar(false);
            }
        }

        public void MarcarBordePokemon(PictureBox picPokemon)
        {
            // Si hay un PictureBox seleccionado previamente, quita el borde
            if (pictureBoxSeleccionadoEliminar != null)
            {
                pictureBoxSeleccionadoEliminar.BorderStyle = BorderStyle.None;
            }

            // Marca el nuevo PictureBox con un borde negro
            picPokemon.BorderStyle = BorderStyle.FixedSingle;

            // Asigna el nuevo PictureBox seleccionado
            pictureBoxSeleccionadoEliminar = picPokemon;

            // Habilita el botón de eliminar
            HabilitarBotonEliminar(true);
        }



        private void HabilitarBotonEliminar(bool habilitado)
        {
            btnEliminar.Enabled = habilitado;
        }

        public void PictureBoxSeleccionado(int index)
        {
            if (picPokemonOcupado[index])
            {
                picPokemonSeleccionadoIndex = index;
                pictureBoxSeleccionadoEliminar = picPokemonArray[index];

                // Marcar el PictureBox seleccionado con un borde
                pictureBoxSeleccionadoEliminar.BorderStyle = BorderStyle.FixedSingle;

                // Habilitar el botón de eliminar
                HabilitarBotonEliminar(true);
            }
        }


    }

}