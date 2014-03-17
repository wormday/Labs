using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hrm.BLL.Entities
{
    public class WorkshopEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkshopID { get; set; }
        [StringLength(50)]
        [Required]
        public string WorkShopName { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public bool IsTeam { get; set; }

        public int? ParentWorkshopID { get; set; }
        [ForeignKey("ParentWorkshopID")]
        public virtual WorkshopEntity ParentWorkshopEntity { get; set; }

        [InverseProperty("ParentWorkshopEntity")]
        public virtual ICollection<WorkshopEntity> ChildrenWorkshopEntities { get; set; }

    }
}
