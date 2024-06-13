using SWLNBazarHub.EnlaceDatos;
using SWLNBazarHub.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SWLNBazarHub.Controladoras {
    public class CComentariosValoraciones {
        private DBBazar2Entities _context;

        public CComentariosValoraciones() {
            _context = new DBBazar2Entities();
        }

        public void AgregarComentarioValoracion(EComentariosValoraciones eComentarioValoracion) {
            _context.Database.ExecuteSqlCommand(
                "EXEC spAgregarComentarioValoracion @UsuarioID, @ProductoID, @Comentario, @Valoracion",
                new SqlParameter("@UsuarioID", eComentarioValoracion.UsuarioID),
                new SqlParameter("@ProductoID", eComentarioValoracion.ProductoID),
                new SqlParameter("@Comentario", eComentarioValoracion.Comentario ?? (object)DBNull.Value),
                new SqlParameter("@Valoracion", eComentarioValoracion.Valoracion)
            );
        }

        public void ActualizarComentarioValoracion(EComentariosValoraciones eComentarioValoracion) {
            _context.Database.ExecuteSqlCommand(
                "EXEC spActualizarComentarioValoracion @ComentarioID, @Comentario, @Valoracion",
                new SqlParameter("@ComentarioID", eComentarioValoracion.ComentarioID),
                new SqlParameter("@Comentario", eComentarioValoracion.Comentario ?? (object)DBNull.Value),
                new SqlParameter("@Valoracion", eComentarioValoracion.Valoracion)
            );
        }

        public void EliminarComentarioValoracion(int comentarioID) {
            _context.Database.ExecuteSqlCommand(
                "EXEC spEliminarComentarioValoracion @ComentarioID",
                new SqlParameter("@ComentarioID", comentarioID)
            );
        }

        public List<EComentariosValoraciones> ObtenerComentariosValoracionesPorProducto(int productoID) {
            var comentariosValoraciones = _context.Database.SqlQuery<EComentariosValoraciones>(
                "EXEC spObtenerComentariosValoracionesPorProducto @ProductoID",
                new SqlParameter("@ProductoID", productoID)
            ).ToList();

            return comentariosValoraciones;
        }

        public List<EComentariosValoraciones> ObtenerComentariosValoracionesPorUsuario(int usuarioID) {
            var comentariosValoraciones = _context.Database.SqlQuery<EComentariosValoraciones>(
                "EXEC spObtenerComentariosValoracionesPorUsuario @UsuarioID",
                new SqlParameter("@UsuarioID", usuarioID)
            ).ToList();

            return comentariosValoraciones;
        }

        public List<EComentariosValoraciones> ObtenerTodosComentariosValoraciones() {
            var comentariosValoraciones = _context.Database.SqlQuery<EComentariosValoraciones>(
                "EXEC spObtenerTodosComentariosValoraciones"
            ).ToList();

            return comentariosValoraciones;
        }
    }
}