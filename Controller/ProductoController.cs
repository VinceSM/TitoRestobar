using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitoRestobar.Dao;
using TitoRestobar.Model;
using SqlException = Microsoft.Data.SqlClient.SqlException;

namespace TitoRestobar.Controller
{
    public class ProductoController
    {
        private readonly DAOProducto daoProducto;

        public ProductoController()
        {
            daoProducto = new DAOProducto();
        }

        public Producto CrearProducto(string nombre, string descripcion, float precio, float costo, bool elaboracion)
        {
            try
            {
                Producto producto = new Producto(nombre, descripcion, precio, costo, elaboracion);
                daoProducto.Guardar(producto);
                return producto;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al crear el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public Producto EliminarProducto(string nombre, string descripcion, float precio, float costo, bool elaboracion)
        {
            try
            {
                Producto producto = new Producto(nombre, descripcion, precio, costo, elaboracion);
                daoProducto.EliminarProductoPorNombre(nombre);
                return producto;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool EliminarProductoPorNombre(string nombre)
        {
            try
            {
                return daoProducto.EliminarProductoPorNombre(nombre);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al eliminar el producto por nombre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public Producto VerProducto(string nombre, string descripcion, float precio, float costo, bool elaboracion)
        {
            try
            {
                Producto producto = new Producto(nombre, descripcion, precio, costo, elaboracion);
                daoProducto.Ver(producto);
                return producto;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al ver el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public Producto ActualizarProducto(string nombre, string descripcion, float precio, float costo, bool elaboracion)
        {
            try
            {
                Producto producto = new Producto(nombre, descripcion, precio, costo, elaboracion);
                daoProducto.Actualizar(producto);
                return producto;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
