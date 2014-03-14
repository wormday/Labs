using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrm.BLL.Entities
{
    public class PositionEntity
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionID { get; set; }
        [StringLength(50)]
        public string PositionName { get; set; }
    }
}
