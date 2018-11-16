using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Psp.Models
{
    public class DrillInitializer : DropCreateDatabaseIfModelChanges<CuttingToolsContext>
    {
        protected override void Seed(CuttingToolsContext db)
        {
            
            db.Drills.Add(new Drill { Name = "Drill123", Diametr = 123, TotalLength = 12, WorkLength=3, Standart="abc1" });
            db.Drills.Add(new Drill { Name = "Drill66", Diametr = 666, TotalLength = 66, WorkLength = 6, Standart = "hell2" });
            db.Drills.Add(new Drill { Name = "Drill007", Diametr = 7, TotalLength = 4, WorkLength = 3, Standart = "bond3" });

            db.MillingCutters.Add(new MillingCutter { Name = "Cutter123", Diametr = 123, TotalLength = 12, WorkLength = 3, Standart = "abc1" });
            db.MillingCutters.Add(new MillingCutter { Name = "Drill66", Diametr = 666, TotalLength = 66, WorkLength = 6, Standart = "hell2" });
            db.MillingCutters.Add(new MillingCutter { Name = "Drill007", Diametr = 7, TotalLength = 4, WorkLength = 3, Standart = "bond3" });

            db.Cutters.Add(new Cutter { Name = "Drill123", Diametr = 123, TotalLength = 12, WorkLength = 3, Standart = "abc1" });
            db.Cutters.Add(new Cutter { Name = "Drill66", Diametr = 666, TotalLength = 66, WorkLength = 6, Standart = "hell2" });
            db.Cutters.Add(new Cutter { Name = "Drill007", Diametr = 7, TotalLength = 4, WorkLength = 3, Standart = "bond3" });

            base.Seed(db);
        }
    }
}