namespace AgriTechERP.Web.Views.ViewModels
{
    public class ProduccionViewModel
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public IEnumerable<int> ProductoSuministradoresIds { get; set; } 
    }
}
