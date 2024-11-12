using Microsoft.AspNetCore.Identity;

namespace AgriTechERP.Core.Entidades.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? NombreCompleto { get; set; }
        

    }
}
