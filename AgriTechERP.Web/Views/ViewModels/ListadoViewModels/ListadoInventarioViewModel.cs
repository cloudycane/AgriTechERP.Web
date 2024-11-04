using AgriTechERP.Core.Entidades;

namespace AgriTechERP.Web.Views.ViewModels.ListadoViewModels
{
    public class ListadoInventarioViewModel
    {
        public IEnumerable<InventarioModel> Inventario { get; set; }
    }
}
