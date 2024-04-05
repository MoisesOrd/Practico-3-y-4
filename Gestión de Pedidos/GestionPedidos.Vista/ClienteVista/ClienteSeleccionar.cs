using GestionPedidos.VISTA.PedidoVista;
using GestionPedidos.BSS;
using GestionPedidos.Bss;

namespace GestionPedidos.VISTA.ClienteVista
{
    public partial class ClienteSeleccionar : Form
    {
        public ClienteSeleccionar()
        {
            InitializeComponent();
        }
        ClienteBSS bss = new ClienteBSS();
        private void ClienteSeleccionar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarClienteBss();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PedidoInterfaz.IdClienteSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int IdPersonaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            PedidoBss bss = new PedidoBss();
            dataGridView1.DataSource = bss.HistorialPedidoBss(IdPersonaSeleccionada);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
