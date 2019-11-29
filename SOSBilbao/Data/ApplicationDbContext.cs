using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SOSBilbao.Models;

namespace SOSBilbao.Data
{
    // Añadido"IdentityDbContext<Usuario,IdentityRole,string>" para los roles de usuario
    public class ApplicationDbContext : IdentityDbContext<Usuario,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SOSBilbao.Models.Farmacia> Farmacia { get; set; }
        public DbSet<SOSBilbao.Models.Supermercado> Supermercado { get; set; }
        public DbSet<SOSBilbao.Models.ParadaTaxi> ParadaTaxi { get; set; }
        public DbSet<SOSBilbao.Models.Zona> Zona { get; set; }
        public DbSet<SOSBilbao.Models.UsuarioFarmacia> UsuarioFarmacia { get; set; }
        public DbSet<SOSBilbao.Models.UsuarioParadasTaxi> UsuarioParadasTaxi { get; set; }
        public DbSet<SOSBilbao.Models.UsuarioSupermercado> UsuarioSupermercado { get; set; }



    }
}
