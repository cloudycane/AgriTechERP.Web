using AgriTechERP.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriTechERP.Core.Entidades
{
    public class ProductoSuministradorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Nombre de Producto")]
        public string NombreProducto { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Descripción de Producto")]
        public string Descripcion { get; set; }
        
        [Display(Name = "Suministrador/Proveedor")]
        public int SuministradorId { get; set; }
        public SuministradorModel Suministrador { get; set;}

        [Display(Name = "Moneda Preferida")]
        public MonedaPreferenciaEnum MonedaPreferida {  get; set; }

        [Display(Name = "Coste de Producto")]
        public decimal CosteProducto { get; set; }

       
        
    }
}
