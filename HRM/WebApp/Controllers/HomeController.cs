using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hrm.BLL.Entities;

namespace Hrm.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Hrm.BLL.Entities.HrmContext db = new Hrm.BLL.Entities.HrmContext();
            EmployeeEntity entity = new EmployeeEntity();
            entity.EmployeeID = 0;
            entity.IDCard = "ddd";
            entity.JobNumber = "11";
            entity.JoinDate = DateTime.Now;
            entity.LeaveDate = DateTime.Now;
            entity.Name = "孙武强";
            entity.Remark = "33";
            db.EmployeeEntities.Add(entity);
            db.SaveChanges();
            return View();
        }
    }
}
