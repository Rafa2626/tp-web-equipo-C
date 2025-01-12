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
            if (!IsPostBack)
            {
                PremioNegocio negocio = new PremioNegocio();
                ListaPremios = negocio.listar();
                repRepetidor.DataSource = ListaPremios;
                repRepetidor.DataBind();
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            string IdPremio = ((Button)sender).CommandArgument;
            Response.Redirect("RegistroCliente.aspx?IdPremio=" + IdPremio,false);
        }
    }
}