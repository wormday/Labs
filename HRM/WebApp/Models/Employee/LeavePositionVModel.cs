using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hrm.BLL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrm.WebApp.Models.Employee
{
    public class LeavePositionVModel
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}