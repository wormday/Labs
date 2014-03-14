using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hrm.BLL.Entities;
using Hrm.WebApp.Models.Employee;

namespace Hrm.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        #region 列表
        [HttpGet]
        public ActionResult List()
        {
            ListVModel vModel = new ListVModel();
            using (HrmContext db = new HrmContext())
            {
                vModel.EmployeeEntities = db.EmployeeEntities.ToList();
            }
            return View(vModel);
        }
        #endregion

        #region 创建
        [HttpPost]
        public ActionResult Create(CreateVModel vModel)
        {
            if (ModelState.IsValid)
            {
                using (HrmContext db = new HrmContext())
                {
                    db.EmployeeEntities.Add(vModel.EmployeeEntity);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
            }
            return View(vModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region 删除
        public ActionResult Remove(int id)
        {
            using (HrmContext db = new HrmContext())
            {
                var entity = db.EmployeeEntities.Single(o => o.EmployeeID == id);
                db.EmployeeEntities.Remove(entity);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        #endregion

        #region 修改
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditVModel vModel = new EditVModel();
            using (HrmContext db = new HrmContext())
            {
                vModel.EmployeeEntity = db.EmployeeEntities.Single(o => o.EmployeeID == id);
            }
            return View(vModel);
        }
        [HttpPost]
        public ActionResult Edit(EditVModel vModel)
        {
            if (ModelState.IsValid)
            {
                using (HrmContext db = new HrmContext())
                {
                    var entity = db.EmployeeEntities.Single(o => o.EmployeeID == vModel.EmployeeEntity.EmployeeID);
                    entity.IDCard = vModel.EmployeeEntity.IDCard;
                    entity.JobNumber = vModel.EmployeeEntity.JobNumber;
                    entity.JoinDate = vModel.EmployeeEntity.JoinDate;
                    entity.LeaveDate = vModel.EmployeeEntity.LeaveDate;
                    entity.Name = vModel.EmployeeEntity.Name;
                    entity.Remark = vModel.EmployeeEntity.Remark;
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
            }
            return View(vModel);
        }
        #endregion

    }
}
