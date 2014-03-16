using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hrm.BLL.Entities;

namespace Hrm.WebApp.Models.Employee
{
    public class ListVModel
    {
        public IList<EmployeeEntity> EmployeeEntities = new List<EmployeeEntity>();
    }
}