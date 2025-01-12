using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Permissions;
using System.Web;

namespace Dominio
{
    public class Voucher
    {
        public string Codigo { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaCanje { get; set; }
        public int IdPremio { get; set; }
    }
}