using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_C
{
    public partial class Error : System.Web.UI.Page
    {
        //Creo esta propiedad porque la propiedad Title no me funciona
        public string MiTitulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MiTitulo = "Error al cargar el voucher!";
            
        }
    }
}