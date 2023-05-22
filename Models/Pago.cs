using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Models
{
    public class Pago
    {

        public string CondIva { get; set; }
       // public SelectList? CondIva { get; set; }
       // public string? PagoCondIva { get; set; }

        public Double Cuit { get; set; }

        public string RazonSocial { get; set;}
        public string Domicilio { get; set;}
        public string Email { get; set;}
        public string CondVenta { get; set;}

    }
}
