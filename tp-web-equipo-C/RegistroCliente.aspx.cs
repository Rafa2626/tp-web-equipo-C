using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_C
{
    public partial class Contact : Page
    {
        List<Cliente> ListaClientes;
        ClienteNegocio Negocio;
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                string VaoucherId = Session["VoucherId"] != null ? Session["VoucherId"].ToString() : "";
            }
        }
        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            List<Cliente> ListaFiltrada;
            Negocio = new ClienteNegocio();
            ListaClientes = Negocio.listarClientes();
            ListaFiltrada = ListaClientes.FindAll(x => x.Documento == txtDni.Text);
            if ( !(ListaFiltrada.Count > 0) )
            {   
                //PrimeroAgregamos al cliente a la db si no lo está
                Cliente aux = new Cliente();
                aux.Documento = txtDni.Text;
                aux.Nombre = textNombre.Text;
                aux.Apellido = textApellido.Text;
                aux.Email = textEmail.Text;
                aux.Direccion = txtDireccion.Text;
                aux.Ciudad = txtCiudad.Text;
                aux.CP = int.Parse(txtCp.Text);
                Negocio.agregar(aux);


                //Volvemos a buscar en la Lista de clientes para obtener el id
                List<Cliente> ListaFiltrada2;
                ClienteNegocio NegocioActualizado = new ClienteNegocio();
                ListaClientes = NegocioActualizado.listarClientes();
                ListaFiltrada2 = ListaClientes.FindAll(x => x.Documento == txtDni.Text);
                Voucher voucherAux = new Voucher();
                voucherAux.IdCliente = ListaFiltrada2[0].Id;
                voucherAux.FechaCanje = DateTime.Now;
                voucherAux.IdPremio = int.Parse(Request.QueryString["IdPremio"]);
                if (Session["VoucherId"] != null)
                {
                    voucherAux.Codigo = Session["VoucherId"].ToString();
                }
                else
                {
                    voucherAux.Codigo = "error";
                }
                VaucherNegocio voucherNegocio = new VaucherNegocio();
                voucherNegocio.modificar(voucherAux);
            }
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Cliente> ListaFiltrada;
                Negocio = new ClienteNegocio();
                ListaClientes = Negocio.listarClientes();
                ListaFiltrada = ListaClientes.FindAll(x => x.Documento == txtDni.Text);

                if (ListaFiltrada.Count > 0)
                {
                    textNombre.Text = ListaFiltrada[0].Nombre;
                    textApellido.Text = ListaFiltrada[0].Apellido;
                    textEmail.Text = ListaFiltrada[0].Email;
                    txtDireccion.Text = ListaFiltrada[0].Direccion;
                    txtCiudad.Text = ListaFiltrada[0].Ciudad;
                    txtCp.Text = ListaFiltrada[0].CP.ToString();

                }
                else
                {
                    textNombre.Text = "";
                    textApellido.Text = "";
                    textEmail.Text = "";
                    txtDireccion.Text = "";
                    txtCiudad.Text = "";
                    txtCp.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
                
            
            
        }
    }
}