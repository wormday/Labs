using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hrm.BLL.Entities;

namespace Hrm.WebApp.Models.Position
{
    public class ListVModel
    {
        public IList<PositionEntity> PositionEntities = new List<PositionEntity>();
    }
}