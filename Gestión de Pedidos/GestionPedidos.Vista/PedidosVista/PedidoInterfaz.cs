using GestionPedidos.Bss;
using GestionPedidos.Modelo;
using GestionPedidos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using GestionPedidos.BSS;
using GestionPedidos.VISTA.ClienteVista;

namespace GestionPedidos.VISTA.PedidoVista
{
    public partial class PedidoInterfaz : Form
    {
        public PedidoInterfaz()
        {
            InitializeComponent();
        }
        PedidoBss bss = new PedidoBss();
        ClienteBSS bssuser = new ClienteBSS();
        public static int IdClienteSeleccionada = 0;
        private void PedidoInterfaz_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ListarPedidoBss();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pedidos u = new Pedidos();
            u.IdCliente = IdClienteSeleccionada;
            u.Total = Convert.ToDecimal(textBox2.Text);
            u.fecha = dateTimePicker1.Value;

            bss.InsertarPedidoBss(u);
            MessageBox.Show("Se guardó correctamente");

            dataGridView1.DataSource = bss.ListarPedidoBss();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClienteSeleccionar fr = new ClienteSeleccionar();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Cliente p = bssuser.ObtenerClienteIdBss(IdClienteSeleccionada);
                textBox1.Text = p.Nombre + " " + p.Apellido;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int IdPedidoSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Pedidos editarPedido = bss.ObtenerPedidoIdBss(IdPedidoSeleccionada);
            editarPedido.IdCliente = IdClienteSeleccionada;
            editarPedido.fecha = dateTimePicker1.Value;
            editarPedido.Total = Convert.ToDecimal(textBox2.Text);
            bss.EditarPedidoBss(editarPedido);
            MessageBox.Show("Datos Actualizados");

            dataGridView1.DataSource = bss.ListarPedidoBss();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int IdPedidoSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("Esta seguro que lo desea eliminar?", "ELIMINAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bss.EliminarPedidoBss(IdPedidoSeleccionada);
                dataGridView1.DataSource = bss.ListarPedidoBss();
            }
        }
        ClienteBSS bsss = new ClienteBSS();
        private void button5_Click(object sender, EventArgs e)
        {
            int IdPersonaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ClienteDatos fr = new ClienteDatos(IdPersonaSeleccionada);
            bsss.ClienteDatosBSS(IdPersonaSeleccionada);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int IdPersonaSeleccionada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            PedidoBss bss = new PedidoBss();
            dataGridView1.DataSource = bss.HistorialPedidoBss(IdPersonaSeleccionada);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
