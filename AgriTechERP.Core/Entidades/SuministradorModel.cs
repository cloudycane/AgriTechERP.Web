using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriTechERP.Core.Entidades
{
    public class SuministradorModel
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string CIF {  get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoContacto { get; set; }
        

    }
}
