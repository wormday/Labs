﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hrm.BLL.Entities;
using Hrm.WebApp.Models.Position;

namespace Hrm.WebApp.Controllers
{
    public class PositionController : Controller
    {
        #region 列表
        [HttpGet]
        public ActionResult List()
        {
            ListVModel vModel = new ListVModel();
            using (HrmContext db = new HrmContext())
            {
                vModel.PositionEntities = db.PositionEntities.ToList();
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
                    db.PositionEntities.Add(vModel.PositionEntity);
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
                var entity = db.PositionEntities.Single(o => o.PositionID == id);
                db.PositionEntities.Remove(entity);
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
                vModel.PositionEntity = db.PositionEntities.Single(o => o.PositionID == id);
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
                    var entity = db.PositionEntities.Single(o => o.PositionID == vModel.PositionEntity.PositionID);
                    entity.PositionName = vModel.PositionEntity.PositionName;
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
            }
            return View(vModel);
        }
        #endregion
    }
}
