using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_web_equipo_C
{
    public partial class SeleccionarPremio : System.Web.UI.Page
    {
        public List<Premio> ListaPremios { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PremioNegocio negocio = new PremioNegocio();
            ListaPremios = negocio.listar();
        }

    }
}