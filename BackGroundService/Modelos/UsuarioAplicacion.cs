using Microsoft.AspNetCore.Identity;

namespace BackGroundTask.Modelos
{
    public class UsuarioAplicacion :IdentityUser
    {

        public string Nombres { get; set; }

    }
}
