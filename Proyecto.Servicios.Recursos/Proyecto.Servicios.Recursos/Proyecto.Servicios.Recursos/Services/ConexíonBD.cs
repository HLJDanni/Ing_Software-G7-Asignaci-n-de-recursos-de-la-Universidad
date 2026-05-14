// <copyright file="ConexíonBD.cs" company="AUREA">
// Copyright (c) AUREA. All rights reserved.
// </copyright>

using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Servicios.Recursos.Services
{
    /// <summary>
    /// Clase de conexión de base de datos.
    /// </summary>
    public class ConexíonBD
    {
        private readonly string cadenaConexion;
        private string mensajeError;
        private bool tieneErrores;
        private DataTable resultado;

        public ConexíonBD()
        {
            this.cadenaConexion = $"Server=localhost;Database=PruebaTecnica;Trusted_Connection=True;TrustServerCertificate=True;";
            this.mensajeError = string.Empty;
            this.tieneErrores = false;
            this.resultado = new DataTable();
        }

        [Obsolete]
        public void EjecutarSPRetornaTabla(string nombre, Dictionary<string, object>? parametros)
        {
            this.resultado = new DataTable();

            try
            {
                using (SqlConnection conexion = new SqlConnection(this.cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(nombre, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        if (parametros != null)
                        {
                            foreach (var param in parametros)
                            {
                                comando.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        conexion.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                        {
                            adapter.Fill(this.resultado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.tieneErrores = true;
                this.mensajeError = ex.Message;
            }
        }

        [Obsolete]
        public void EjecutarSP(string nombre, Dictionary<string, object> parametros)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(this.cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(nombre, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        if (parametros != null)
                        {
                            foreach (var param in parametros)
                            {
                                comando.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                this.tieneErrores = true;
                this.mensajeError = ex.Message;
            }
        }

        public bool ExisteErrores() => this.tieneErrores;

        public string ObtenerErrorMensaje() => this.mensajeError;

        public DataTable ObtenerResultadoSP() => this.resultado;
    }
}
