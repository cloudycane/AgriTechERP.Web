using AgriTechERP.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriTechERP.Core.Entidades
{
    public class OrdenCarritoModel
    {
        public int Id { get; set; }
        public int ProductoSuministradorId { get; set; }
        public ProductoSuministradorModel ProductoSuministrador { get; set; }
        public AprobacionEnum Aprobacion { get; set; }
        public int Cantidad { get; set; }
    }
}
