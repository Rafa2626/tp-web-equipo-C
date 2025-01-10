using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_web_equipo_C.Datos;
using tp_web_equipo_C.Modelos;

namespace Negocio
{
    public class VaucherNegocio
    {
        public List<Voucher> listar()
        {
            List<Voucher> lista = new List<Voucher>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT CodigoVoucher AS Codigo, IdCliente, FechaCanje, IdArticulo AS IdPremio FROM Vouchers");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Voucher aux = new Voucher();
                    if (!(datos.Lector["IdCliente"] is DBNull))
                        aux.IdCliente = (int)datos.Lector["IdCliente"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["FechaCanje"] is DBNull))
                        aux.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    if (!(datos.Lector["IdPremio"] is DBNull))
                        aux.IdPremio = (int)datos.Lector["IdPremio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
