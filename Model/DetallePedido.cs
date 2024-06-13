using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitoRestobar.Controller;

namespace TitoRestobar.Model
{
    public class DetallePedido
    {
        private PedidoController pedidoController;

        public DetallePedido(PedidoController pedidoController)
        {
            this.pedidoController = pedidoController;
        }

        public void VerDetallePedido(DataGridView dgvItems, Label lblFechaApertura, Label lblFechaCierre)
        {
            // Calcular y mostrar el total del pedido
            float totalPedido = pedidoController.CalcularTotalPedido();
            MessageBox.Show($"Total del pedido: {totalPedido:C}");

            // Mostrar la lista de items en el DataGridView
            pedidoController.VerItemsPedido(dgvItems);

            // Mostrar la fecha de apertura y cierre del pedido
            lblFechaApertura.Text = $"Fecha de apertura: {pedidoController.PedidoActual.FechaHoraApertura}";
            lblFechaCierre.Text = $"Fecha de cierre: {pedidoController.PedidoActual.FechaHoraCierre}";
        }
    }
}
