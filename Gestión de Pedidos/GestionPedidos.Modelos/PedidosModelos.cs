using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPedidos.Modelos
{
    public class Pedidos
    {
        public int IdPedido { get; set; }

        public int IdCliente { get; set;}

        public DateTime fecha { get; set;}

        public decimal Total { get; set;}

        public string Estado { get; set;}
    }
}
