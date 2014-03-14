using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Hrm.BLL.Entities
{
    public class HrmContext:DbContext
    {
        public DbSet<EmployeeEntity> EmployeeEntities { get; set; }
        public DbSet<PositionEntity> PositionEntities { get; set; }
        public DbSet<WorkshopEntity> WorkshopEntities { get; set; }
    }
}
