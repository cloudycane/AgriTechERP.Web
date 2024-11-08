using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriTechERP.Core.Enums
{
    public enum EstadoProductoProduccion
    {
        NoIniciado = 0,
        EnProduccion = 1,
        PendienteDeAprobacion = 2, 
        EnVentas = 3, 
        Rechazada = 4
    }
}
