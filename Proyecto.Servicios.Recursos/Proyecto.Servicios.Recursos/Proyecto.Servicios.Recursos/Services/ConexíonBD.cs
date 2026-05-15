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
        private int valorEntero;

        public ConexíonBD()
        {
            this.cadenaConexion = $"workstation id=UniReserve.mssql.somee.com;packet size=4096;user id=Danni1204_SQLLogin_1;pwd=oo495l73uv;data source=UniReserve.mssql.somee.com;persist security info=False;initial catalog=UniReserve;TrustServerCertificate=True";
            this.mensajeError = string.Empty;
            this.tieneErrores = false;
            this.resultado = new DataTable();
            this.valorEntero = 0;
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
        public void EjecutarSP(string nombre, Dictionary<string, object>? parametros)
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

        [Obsolete]
        public void EjecutarSPRetornaEntero(string nombre, Dictionary<string, object>? parametros, string nombreVariable)
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
                        SqlParameter idParam = new SqlParameter($"@{nombreVariable}", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        comando.Parameters.Add(idParam);

                        comando.ExecuteNonQuery();

                        this.valorEntero = (int)comando.Parameters[$"@{nombreVariable}"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                this.tieneErrores = true;
                this.mensajeError = ex.Message;
            }
        }

        public int ObtenerValorEntero() => this.valorEntero;

        public bool ExisteErrores() => this.tieneErrores;

        public string ObtenerErrorMensaje() => this.mensajeError;

        public DataTable ObtenerResultadoSP() => this.resultado;
    }
}
