using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_C
{
    public partial class Cajear : System.Web.UI.Page
    {
        List<Voucher> listaVoucher = new List<Voucher>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VaucherNegocio negocio = new VaucherNegocio();
                listaVoucher = negocio.listar();
                Session["listaVoucher"] = listaVoucher; // Guardar en la sesión
            }
            else
            {
                listaVoucher = (List<Voucher>)Session["listaVoucher"]; // Recuperar de la sesión
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)

        {
            List<Voucher> listaFiltrada;
            string filtro = txtVoucher.Text;
            bool utilizado = Utilizado();

            if (filtro != "")
            {
                listaFiltrada = listaVoucher.FindAll(x => x.Codigo.Trim().Equals(filtro.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                listaFiltrada = new List<Voucher>(); // Lista vacía si no se ingresó texto
            }
            if (listaFiltrada.Count > 0 && !utilizado)
            {
                lblResultado.Text = string.Join("<br/>", listaFiltrada.Select(x => $"Código: {x.Codigo}"));
                Session.Add( "VoucherId", txtVoucher.Text);
                Response.Redirect("SeleccionarPremio.aspx", false);

            }
            else if(listaFiltrada.Count > 0) 
            {
                lblResultado.Text = "Voucher ya utilizado";
            }
            else
            {
                lblResultado.Text = "No se encontraron resultados.";
            }

            
        }

        public bool Utilizado()
        {
            VaucherNegocio negocio = new VaucherNegocio();
            listaVoucher = negocio.listar();
            List<Voucher> filtrada = new List<Voucher>();
            filtrada = listaVoucher.FindAll(x => x.Codigo.Trim().Equals(txtVoucher.Text.Trim(), StringComparison.OrdinalIgnoreCase));
            int dni = 0;
            if ( filtrada.Count > 0)
            {
                dni = filtrada[0].IdCliente;
            }
            if ( !(dni == 0) )
            {
                return true;
            }
            return false;
        }
    }
}