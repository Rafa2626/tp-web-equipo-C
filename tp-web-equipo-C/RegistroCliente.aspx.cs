using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace tp_web_equipo_C
{
    public partial class Contact : Page
    {
        List<Cliente> ListaClientes;
        ClienteNegocio Negocio;
        bool Continuar = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!(Continuar))
            //    btnParticipar.Enabled = false;
            //else
            //    btnParticipar.Enabled = true;
            if (!IsPostBack)
            {
                string VaoucherId = Session["VoucherId"] != null ? Session["VoucherId"].ToString() : "";
            }
        }
        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            // Validar si se aceptaron las condiciones
            if (!chkCondiciones.Checked)
            {
                lblNoAcepto.Text = "Debe aceptar las condiciones para continuar.";
                return; 
            }
            else
            {
                lblNoAcepto.Text = ""; 
            }

            List<Cliente> ListaFiltrada;
            Negocio = new ClienteNegocio();
            ListaClientes = Negocio.listarClientes();
            ListaFiltrada = ListaClientes.FindAll(x => x.Documento == txtDni.Text);
            if (!(ListaFiltrada.Count > 0) && Continuar == false)
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
                int IdPremio = voucherAux.IdPremio;
                Response.Redirect("Exito?IdPremio=" + IdPremio, false);
            }
            //si el cliente ya está registrado solo actualizamos los datos del voucher
            else if (Continuar == true)
            {
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
                int IdPremio = voucherAux.IdPremio;
                Response.Redirect("Exito?IdPremio=" + IdPremio, false);
            }
            else
            {
                lblNoContinuar.Text = "Los datos no son válidos!";
            }
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Validar DNI
                if (!string.IsNullOrWhiteSpace(txtDni.Text) && !int.TryParse(txtDni.Text, out int numero))
                {
                    lblValidarDni.Text = "Error: Solo se permiten números en el DNI.";
                    Continuar = false;
                    return;
                }
                else
                {
                    lblValidarDni.Text = "";
                }

                // Validar campos de texto
                string patternSoloLetras = @"^[a-zA-Z\s]+$";
                string patternEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                bool validacionExitosa = true;

                // Validar Nombre
                if (!string.IsNullOrWhiteSpace(textNombre.Text) && !System.Text.RegularExpressions.Regex.IsMatch(textNombre.Text, patternSoloLetras))
                {
                    lblValidarNombre.Text = "Error: Solo se permiten letras en el nombre.";
                    validacionExitosa = false;
                }
                else
                {
                    lblValidarNombre.Text = "";
                }

                // Validar Apellido
                if (!string.IsNullOrWhiteSpace(textApellido.Text) && !System.Text.RegularExpressions.Regex.IsMatch(textApellido.Text, patternSoloLetras))
                {
                    lblValidarApellido.Text = "Error: Solo se permiten letras en el apellido.";
                    validacionExitosa = false;
                }
                else
                {
                    lblValidarApellido.Text = "";
                }

                // Validar Ciudad
                if (!string.IsNullOrWhiteSpace(txtCiudad.Text) && !System.Text.RegularExpressions.Regex.IsMatch(txtCiudad.Text, patternSoloLetras))
                {
                    lblValidarCiudad.Text = "Error: Solo se permiten letras en la ciudad.";
                    validacionExitosa = false;
                }
                else
                {
                    lblValidarCiudad.Text = "";
                }

                // Validar Email
                if (!string.IsNullOrWhiteSpace(textEmail.Text) && !System.Text.RegularExpressions.Regex.IsMatch(textEmail.Text, patternEmail))
                {
                    lblValidarEmail.Text = "Error: Formato de email inválido.";
                    validacionExitosa = false;
                }
                else
                {
                    lblValidarEmail.Text = "";
                }

                // Si hay errores de validación, no continuar
                if (!validacionExitosa)
                {
                    Continuar = false;
                    return;
                }

                // Lógica de búsqueda de clientes en base al DNI
                Negocio = new ClienteNegocio();
                ListaClientes = Negocio.listarClientes();
                List<Cliente> ListaFiltrada = ListaClientes.FindAll(x => x.Documento == txtDni.Text);

                if (ListaFiltrada.Count > 0)
                {
                    // Cargar datos del cliente existente
                    textNombre.Text = ListaFiltrada[0].Nombre;
                    textApellido.Text = ListaFiltrada[0].Apellido;
                    textEmail.Text = ListaFiltrada[0].Email;
                    txtDireccion.Text = ListaFiltrada[0].Direccion;
                    txtCiudad.Text = ListaFiltrada[0].Ciudad;
                    txtCp.Text = ListaFiltrada[0].CP.ToString();
                    lblValidarDni.Text = ""; // Limpiar cualquier error previo
                }
                else
                {
                    // Si no se encuentra, permitir continuar con el registro
                    Continuar = true;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                lblValidarDni.Text = "Ocurrió un error: " + ex.Message;
            }
        }



        protected void txtCp_TextChanged(object sender, EventArgs e)
        {

            if (!(int.TryParse(txtCp.Text, out int numero)))
            {
                lblValidarCP.Text = "Error: Solo se permiten números.";
                Continuar = false;
            }
            else
            {
                lblValidarCP.Text = "";
                Continuar = true;
            }
        }

        

        private bool SoloLetras(string texto)
        {
            foreach(char c in texto)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}