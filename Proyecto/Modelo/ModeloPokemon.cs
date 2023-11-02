using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class ModeloPokemon
    {
        public string connectionString = "Data Source=DESKTOP-K4U6LQP\\SQLEXPRESS;Initial Catalog=Proyecto;Integrated Security=True";
        private List<Pokemon> todosLosPokemon;
        private List<Movimiento> todosLosMovimientos;
        public ModeloPokemon()
        {
            // Inicializa la lista de todos los Pokémon al cargar el modelo
            todosLosPokemon = ObtenerTodosLosPokemon();


        }
        public List<Pokemon> ObtenerTodosLosPokemon()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM Pokemones";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var listaPokemon = new List<Pokemon>();

                        while (reader.Read())
                        {
                            var pokemon = new Pokemon((int)reader["IdPokemon"], (string)reader["Nombre"], reader["Imagen"] as byte[], (string)reader["Tipo"]);

                            listaPokemon.Add(pokemon);
                        }

                        return listaPokemon;
                    }
                }
            }
        }

        //obtener los movimientos del pokemon 
        public List<Movimiento> ObtenerMovimientosPorPokemon(int idPokemon)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT M.IdMovimiento, M.Nombre, M.Tipo, M.Potencia " +
                            "FROM Movimientos M " +
                            "INNER JOIN Pokemones P ON " +
                            "(M.IdMovimiento = P.Movimiento_Num1 OR " +
                            "M.IdMovimiento = P.Movimiento_Num2 OR " +
                            "M.IdMovimiento = P.Movimiento_Num3 OR " +
                            "M.IdMovimiento = P.Movimiento_Num4) " +
                            "WHERE P.IdPokemon = @IdPokemon";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdPokemon", idPokemon);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var listaMovimientos = new List<Movimiento>();

                        while (reader.Read())
                        {
                            var movimiento = new Movimiento
                            (
                                (int)reader["IdMovimiento"],
                                (string)reader["Nombre"],
                                (string)reader["Tipo"],
                                (int)reader["Potencia"]);

                            listaMovimientos.Add(movimiento);
                        }

                        return listaMovimientos;
                    }
                }
            }
        }
        public string ObtenerDescripcionDelPokemon(int idPokemon)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT Descripcion FROM Pokemones WHERE IdPokemon = @IdPokemon";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdPokemon", idPokemon);
                    return (string)command.ExecuteScalar();
                }
            }
        }
        public int ObtenerIdPokemon(string nombrePokemon)
        {
            int pokemonId = -1; // Valor predeterminado si no se encuentra el Pokémon

            // Realiza una consulta a la base de datos para obtener el ID del Pokémon
            string query = "SELECT IdPokemon FROM Pokemones WHERE Nombre = @Nombre";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Nombre", nombrePokemon);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pokemonId = reader.GetInt32(0); // la columna 0 contiene el ID del Pokémon.
                    }
                }
            }

            return pokemonId;
        }

        public byte[] ObtenerImagenPorNombre(string nombrePokemon)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Consulta para obtener la imagen del Pokémon por su nombre
                var query = "SELECT Imagen FROM Pokemones WHERE Nombre = @Nombre";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombrePokemon);

                    // ejecuta la consulta y obtiene la imagen 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            // Lee la imagen desde la base de datos
                            byte[] imagen = (byte[])reader[0];

                            return imagen;
                        }
                    }
                }
            }

            // Si no se encuentra la imagen, devuelve null
            return null;
        }

        public Pokemon ObtenerPokemonPorNombre(string nombrePokemon)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM Pokemones WHERE Nombre = @Nombre";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombrePokemon);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var pokemon = new Pokemon
                            ((int)reader["IdPokemon"], (string)reader["Nombre"], reader["Imagen"] as byte[], (string)reader["Tipo"]);

                            return pokemon;
                        }
                    }
                }
            }

            return null; // Retorna null si no se encuentra el Pokémon con ese nombre
        }

    }
}
