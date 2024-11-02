using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriTechERP.Core.Entidades
{
    public class ProductoSuministradorModel
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int SuministradorId { get; set; }
        public SuministradorModel Suministrador { get; set;}
        
    }
}
