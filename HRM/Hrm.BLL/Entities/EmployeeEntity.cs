using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrm.BLL.Entities
{
    public class EmployeeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(100)]
        [Required]
        public string IDCard { get; set; }
        [StringLength(1000)]
        public string Remark { get; set; }
        [StringLength(20)]
        public string JobNumber { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }

        public ICollection<EmployeePositionEntity> EmployeePositionEntities { get; set; }
    }
}
