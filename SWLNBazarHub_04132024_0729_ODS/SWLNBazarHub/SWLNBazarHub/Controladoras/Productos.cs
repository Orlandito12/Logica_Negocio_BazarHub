using SWLNBazarHub.EnlaceDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SWLNBazarHub.Entidades;

namespace SWLNBazarHub.Controladoras
{
    public class Productos
    {
        private DBBazar2Entities _context;

        public Productos()
        {
            _context = new DBBazar2Entities();
        }

        public void InsertarProducto(EProductos eProducto)
        {
            _context.Database.ExecuteSqlCommand(
                "EXEC spAgregarProductoConImagen @Nombre, @Descripcion, @Precio, @Stock, @CategoriaID, @ProveedorID, @Estado, @FechaDeEdicion, @ImagenProducto",
                new SqlParameter("@Nombre", eProducto.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@Descripcion", eProducto.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@Precio", eProducto.Precio),
                new SqlParameter("@Stock", eProducto.Stock),
                new SqlParameter("@CategoriaID", eProducto.CategoriaID),
                new SqlParameter("@ProveedorID", eProducto.ProveedorID),
                new SqlParameter("@Estado", eProducto.Estado ?? (object)DBNull.Value),
                new SqlParameter("@FechaDeEdicion", (object)eProducto.FechaDeEdicion ?? DBNull.Value),
                new SqlParameter("@ImagenProducto", (object)eProducto.ImagenProducto ?? DBNull.Value)
            );
        }

        public void ActualizarProducto(EProductos eProducto)
        {
            _context.Database.ExecuteSqlCommand(
                "EXEC spActualizarProducto @ProductoID, @Nombre, @Descripcion, @Precio, @Stock, @Estado, @FechaDeEdicion",
                new SqlParameter("@ProductoID", eProducto.ProductoID),
                new SqlParameter("@Nombre", eProducto.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@Descripcion", eProducto.Descripcion ?? (object)DBNull.Value),
                new SqlParameter("@Precio", eProducto.Precio),
                new SqlParameter("@Stock", eProducto.Stock),
                new SqlParameter("@Estado", eProducto.Estado ?? (object)DBNull.Value),
                new SqlParameter("@FechaDeEdicion", (object)eProducto.FechaDeEdicion ?? DBNull.Value)
            );
        }

        public void ActualizarImagenProducto(int productoId, byte[] imagenBytes) {
            _context.Database.ExecuteSqlCommand(
                "EXEC ActualizarImagenProd @Id, @Imagen",
                new SqlParameter("@Id", productoId),
                new SqlParameter("@Imagen", imagenBytes ?? (object)DBNull.Value)
            );
        }


        public void ActualizarFechaEdicionProducto(int productoID, DateTime fechaDeEdicion)
        {
            _context.Database.ExecuteSqlCommand(
                "EXEC spActualizarFechaEdicionProducto @ProductoID, @FechaDeEdicion",
                new SqlParameter("@ProductoID", productoID),
                new SqlParameter("@FechaDeEdicion", fechaDeEdicion)
            );
        }

        public void ActualizarEstadoProducto(int productoID, string estado)
        {
            _context.Database.ExecuteSqlCommand(
                "EXEC spActualizarEstadoProducto @ProductoID, @Estado",
                new SqlParameter("@ProductoID", productoID),
                new SqlParameter("@Estado", estado ?? (object)DBNull.Value)
            );
        }

        public List<EProductos> ObtenerTodosProductos()
        {
            var productos = _context.Database.SqlQuery<EProductos>(
                "EXEC spObtenerTodosProductos"
            ).ToList();

            return productos;
        }

        public List<EProductos> ObtenerTodosProductosActivos() {
            var productos = _context.Database.SqlQuery<EProductos>(
                "EXEC spObtenerTodosProductos"
            ).ToList();

            var productosActivos = productos.Where(p => p.Estado == "Activo").ToList();

            return productosActivos;
        }

    }
}