using GestionPedidos.DAL;
using GestionPedidos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPedidos.Dal
{
    public class PedidoDal
    {
        public DataTable ListarPedidoDal()
        {
            string consulta = "select * from pedido";
            DataTable Lista = conexion.EjecutarDataTabla(consulta, "tabla");
            return Lista;
        }
        public void InsertarPedidoDal(Pedidos p)
        {
            string consulta = "INSERT INTO PEDIDO VALUES (" + p.IdCliente + " , " +
                                                            " '" + p.fecha + "' , " +
                                                            " '" + p.Total + "'," +
                                                          "'Completado')";
            conexion.Ejecutar(consulta);
        }
        public Pedidos ObtenerPedidoIdDal(int id)
        {
            string consulta = "select * from pedido where idpedido=" + id;
            DataTable tabla = conexion.EjecutarDataTabla(consulta, "asdas");
            Pedidos u = new Pedidos();
            if (tabla.Rows.Count > 0)
            {
                u.IdPedido = Convert.ToInt32(tabla.Rows[0]["idpedido"]);
                u.fecha = Convert.ToDateTime(tabla.Rows[0]["fecha"]);
                u.Total = Convert.ToDecimal(tabla.Rows[0]["total"]);
                u.Estado = tabla.Rows[0]["estado"].ToString();
            }
            return u;

        }
        public void EditarPedidoDal(Pedidos p)
        {
            string consulta = "UPDATE PEDIDO SET IDCLIENTE = " + p.IdCliente + "," +
                                      "FECHA = '" + p.fecha + "'," +
                                      "TOTAL = " + p.Total + "," +
                                      "ESTADO = 'Completado' " +
                                      "WHERE IDPEDIDO = " + p.IdPedido;


            conexion.Ejecutar(consulta);
        }
        public void EliminarPedidoDal(int id)
        {
            string consulta = "delete from pedido where idpedido=" + id;
            conexion.Ejecutar(consulta);
        }
        public DataTable HistorialPedidoDal(int id)
        {
            string consulta = "select C.NOMBRE,count(IDPEDIDO) AS Cantidadpedidos,\r\nsum (TOTAL) as totalPedidos\r\nfrom PEDIDO P\r\nInner join CLIENTE C On C.IDCLIENTE=p.IDCLIENTE\r\nWhere P.IdCliente= " + id + "group by C.NOMBRE;";
            DataTable Lista = conexion.EjecutarDataTabla(consulta, "tabla");
            return Lista;
         
        }
    }
}
