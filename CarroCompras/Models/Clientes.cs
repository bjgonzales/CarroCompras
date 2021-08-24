using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarroCompras.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string FechaNacimientoText
        {
            get
            {
                if (FechaNacimiento == null)
                {
                    return "";
                }
                return FechaNacimiento.Value.ToString("dd/MM/yyyy");
            }
        }
        public decimal? Sueldo { get; set; }
        public int? Edad { get; set; }
    }
}