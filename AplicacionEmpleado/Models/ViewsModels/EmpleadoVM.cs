using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplicacionEmpleado.Models.ViewsModels
{
    public class EmpleadoVM
    {
        public Empleado oEmpleado { get; set; }

        public List<SelectListItem> oListaCargo { get; set; }

       
    }
}
