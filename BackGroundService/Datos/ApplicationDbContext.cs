
using BackGroundTask.Modelos.Dto;
using BackGroundTask.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BackGroundTask.Datos
{
    public class ApplicationDbContext : IdentityDbContext<UsuarioAplicacion>
    { 


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UsuarioAplicacion> UsuariosAplicacion { get; set; }

    }
}
