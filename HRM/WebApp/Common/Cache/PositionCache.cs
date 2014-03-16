using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hrm.BLL.Entities;

namespace Hrm.WebApp.Common.Cache
{
    public class PositionCache
    {
        public static IList<PositionEntity> GetList()
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            var cacheItems = objCache["PositionEntities"] as IList<PositionEntity>;
            if (cacheItems == null)
            {
                using (HrmContext db = new HrmContext())
                {
                    cacheItems = db.PositionEntities.ToList();
                    objCache.Insert("PositionEntities", cacheItems);
                }
            }
            return cacheItems;
        }
        public static void Clear()
        {
            HttpRuntime.Cache.Remove("PositionEntities");
        }
    }
}