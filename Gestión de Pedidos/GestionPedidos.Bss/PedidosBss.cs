using GestionPedidos.Dal;
using GestionPedidos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPedidos.Bss
{
    public class PedidoBss
    {
        PedidoDal dal = new PedidoDal();
        public DataTable ListarPedidoBss()
        {
            return dal.ListarPedidoDal();
        }

        public void InsertarPedidoBss(Pedidos pedido)
        {
            dal.InsertarPedidoDal(pedido);
        }
        public Pedidos ObtenerPedidoIdBss(int id)
        {
            return dal.ObtenerPedidoIdDal(id);
        }
        public void EditarPedidoBss(Pedidos p)
        {
            dal.EditarPedidoDal(p);
        }
        public void EliminarPedidoBss(int id)
        {
            dal.EliminarPedidoDal(id);
        }
        public DataTable HistorialPedidoBss(int id)
        {
            return dal.HistorialPedidoDal(id);
        }
    }
}
