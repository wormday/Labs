using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrm.BLL.Entities
{
    public class EmployeePositionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int EmployeePositionID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public int PositionID { get; set; }
        [Required]
        public int WorkshopID { get; set; }
        public virtual PositionEntity PositionEntity { get; set; }
        public virtual WorkshopEntity WorkshopEntity { get; set; }
    }
}
