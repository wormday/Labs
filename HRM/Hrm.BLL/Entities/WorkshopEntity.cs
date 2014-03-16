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
        public string Color { get; set; }
    }
}
