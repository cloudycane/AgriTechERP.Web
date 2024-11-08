using AgriTechERP.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriTechERP.Core.Entidades
{
    public class ProduccionModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Nombre del Producto a Producir")]
        public string NombreProducto { get; set; }

        // Lista de productos suministradores (ingredientes) necesarios para la producción
        public List<ProductoSuministradorModel> Ingredientes { get; set; } = new List<ProductoSuministradorModel>();
        public EstadoProductoProduccion EstadoProductoProduccion { get; set; }
    }

}
