using AgriTechERP.Core.Entidades;

namespace AgriTechERP.Web.Views.ViewModels.ListadoViewModels
{
    public class ListadoProduccionViewModel
    {
        public IEnumerable<ProduccionModel> Producciones { get; set; }
        public string NombreProducto { get; set; }
        public IEnumerable<string> ProductoSuministradores { get; set; } // Changed type to IEnumerable<string>
    }

}
