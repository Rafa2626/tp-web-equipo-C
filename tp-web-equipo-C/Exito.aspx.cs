using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace tp_web_equipo_C
{
    public partial class Exito : System.Web.UI.Page
    {
        public string MiTitulo { get; set; }
        PremioNegocio negocio = new PremioNegocio();
        public List<Premio> filtrada;

        List<Premio> Lista = new List<Premio>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MiTitulo = "Exito";
            Lista = negocio.listar();
            filtrada = new List<Premio>();
            int IdPremio = int.Parse(Request.QueryString["IdPremio"]);
            filtrada = Lista.FindAll(x => x.Id == IdPremio);



        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
    }
}