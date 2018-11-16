using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Psp.Models
{
    public class CuttingToolsContext : DbContext
    {
        public DbSet<Drill> Drills { get; set; }
        public DbSet<Cutter> Cutters { get; set; }
        public DbSet<MillingCutter> MillingCutters { get; set; }
        
    }
}