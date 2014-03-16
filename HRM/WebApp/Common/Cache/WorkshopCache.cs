using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hrm.BLL.Entities;

namespace Hrm.WebApp.Common.Cache
{
    public class WorkshopCache
    {
        public static IList<WorkshopEntity> GetList()
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            var cacheItems = objCache["WorkshopEntities"] as IList<WorkshopEntity>;
            if (cacheItems == null)
            {
                using (HrmContext db = new HrmContext())
                {
                    cacheItems = db.WorkshopEntities.ToList();
                    objCache.Insert("WorkshopEntities", cacheItems);
                }
            }
            return cacheItems;
        }
        public static void Clear()
        {
            HttpRuntime.Cache.Remove("WorkshopEntities");
        }
    }
}