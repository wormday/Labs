using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hrm.BLL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrm.WebApp.Models.Employee
{
    public class SwitchPositionVModel
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int WorkshopID { get; set; }
        [Required]
        public int PositionID { get; set; }
    }
}