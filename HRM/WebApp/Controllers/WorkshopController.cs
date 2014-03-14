using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hrm.BLL.Entities;
using Hrm.WebApp.Models.Workshop;

namespace Hrm.WebApp.Controllers
{
    public class WorkshopController : Controller
    {
        #region 列表
        [HttpGet]
        public ActionResult List()
        {
            ListVModel vModel = new ListVModel();
            using (HrmContext db = new HrmContext())
            {
                vModel.WorkshopEntities = db.WorkshopEntities.ToList();
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
                    db.WorkshopEntities.Add(vModel.WorkshopEntity);
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
                var entity = db.WorkshopEntities.Single(o => o.WorkshopID == id);
                db.WorkshopEntities.Remove(entity);
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
                vModel.WorkshopEntity = db.WorkshopEntities.Single(o => o.WorkshopID == id);
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
                    var entity = db.WorkshopEntities.Single(o => o.WorkshopID == vModel.WorkshopEntity.WorkshopID);
                    entity.WorkShopName = vModel.WorkshopEntity.WorkShopName;
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
            }
            return View(vModel);
        }
        #endregion
    }
}
