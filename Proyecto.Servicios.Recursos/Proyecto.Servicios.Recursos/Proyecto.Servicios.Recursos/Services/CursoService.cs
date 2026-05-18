namespace Proyecto.Servicios.Recursos.Services
{
    public class CursoService
    {
        private readonly ConexíonBD conexion;

        /// <summary>
        /// Initializes a new instance of the <see cref="CursoService"/> class.
        /// </summary>
        public CursoService()
        {
            this.conexion = new();
        }
    }
}
