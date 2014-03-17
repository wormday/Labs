using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrm.BLL.Entities
{
    public class EmployeeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(100)]
        [Required]
        public string IDCard { get; set; }
        [StringLength(1000)]
        public string Remark { get; set; }
        [StringLength(20)]
        public string JobNumber { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }

        public virtual ICollection<EmployeePositionEntity> EmployeePositionEntities { get; set; }

        /// <summary>是否在岗</summary>
        public bool IsInPosition
        {
            get
            {
                if (this.LastPosition == null)
                    return false;
                return (this.LastPosition.EndDate == null);
            }
        }
        /// <summary>最后的岗位</summary>
        public EmployeePositionEntity LastPosition
        {
            get
            {
                return this.EmployeePositionEntities.OrderByDescending(o => o.StartDate).FirstOrDefault();
            }
        }

        public void LeavePosition(DateTime endDate)
        {
            if (!IsInPosition)
                throw new ApplicationException("该员工当前不在任何岗位，无法离岗操作！");
            if (this.LastPosition.StartDate >= endDate)
                throw new ApplicationException(string.Format("离岗时间应该晚于入岗时间{0}", this.LastPosition.StartDate.ToString("yyyy-MM-dd")));
            this.LastPosition.EndDate = endDate;
        }

        public void JoinPosition(DateTime startDate, int positionID, int workshopID)
        {
            if (IsInPosition)
                throw new ApplicationException("该员工当前在岗，如需调整岗位请进行转岗或者离岗操作！");
            if ((this.LastPosition != null) && (this.LastPosition.EndDate.Value >= startDate))
                throw new ApplicationException(string.Format("入岗时间应该晚于上次离岗时间{0}", this.LastPosition.EndDate.Value.ToString("yyyy-MM-dd")));
            EmployeePositionEntity pEntity = new EmployeePositionEntity();
            pEntity.EndDate = null;
            pEntity.StartDate = startDate;
            pEntity.WorkshopID = workshopID;
            pEntity.PositionID = positionID;
            this.EmployeePositionEntities.Add(pEntity);
        }

        public void SwitchPosition(DateTime startDate,int positionID, int workshopID)
        {
            DateTime endDate=startDate.AddDays(-1);
            LeavePosition(endDate);
            JoinPosition(startDate, positionID, workshopID);
        }
    }
}
