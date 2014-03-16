using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hrm.BLL.Entities;

namespace Hrm.WebApp.Models.Workshop
{
    public class ListVModel
    {
        public IList<WorkshopEntity> WorkshopEntities = new List<WorkshopEntity>();
    }
}