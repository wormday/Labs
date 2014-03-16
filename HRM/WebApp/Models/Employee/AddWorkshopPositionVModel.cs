using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hrm.BLL.Entities;

namespace Hrm.WebApp.Models.Employee
{
    public class AddWorkshopPositionVModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeID { get; set; }
        public int WorkshopID { get; set; }
        public int PositionID { get; set; }
    }
}