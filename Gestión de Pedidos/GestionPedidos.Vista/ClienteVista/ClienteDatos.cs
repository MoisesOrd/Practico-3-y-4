using GestionPedidos.Bss;
using GestionPedidos.BSS;
using GestionPedidos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPedidos.VISTA.ClienteVista
{
    public partial class ClienteDatos : Form
    {
        public ClienteDatos(int id)
        {
            idx = id;
            InitializeComponent();
        }
        int idx = 0;
        Cliente c = new Cliente();
        ClienteBSS bss = new ClienteBSS();
        private void ClienteDatos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bss.ClienteDatosBSS(idx);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
