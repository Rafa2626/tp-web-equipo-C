using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace tp_web_equipo_C.Modelos
{
    public class Premio
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        [DisplayName("Artículo")]
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public List<Imagen> Imagenes { get; set; }
        [DisplayName("Precio(U$S)")]
        public decimal Precio { get; set; }
    }
}