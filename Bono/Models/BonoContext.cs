using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Bono.Models
{
    public class BonoContext : DbContext
    {
        public BonoContext() 
            : base("DefaultConnection") { 
            
        }
        public DbSet<User> User { get; set; }
        public DbSet<DatosBono> DatosBono { get; set; }
        public DbSet<PGracia> PGracia { get; set; }
        public DbSet<ResultadoBono> ResultadoBono { get; set; }
        public DbSet<FlujoEmisor> FlujoEmisor { get; set; }
        public DbSet<FlujoEmisorEsc> FlujoEmisorEsc { get; set; }
        public DbSet<FlujoBonista> FlujoBonista { get; set; }

    }
}