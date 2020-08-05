using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 烘烤硬化试验数据结果明细
    /// </summary>
    public class ReboundDataDetailItem : FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料烘烤硬化试验数据

        /// <summary>
        /// 烘烤硬化试验数据明细
        /// </summary>
        public Guid? ReboundDataDetailId { get; set; }

        /// <summary>
        /// 烘烤硬化试验数据明细
        /// </summary>
        public virtual ReboundDataDetail ReboundDataDetail { get; set; }

        #endregion

        /// <summary>
        /// 凸模圆角半径R(mm)
        /// </summary>
        public decimal? PunchFilletRadius { get; set; }
        
        /// <summary>
        /// 弯曲角度
        /// </summary>
        public decimal? BendingAngle { get; set; }

        /// <summary>
        /// 回弹角度
        /// </summary>
        public decimal? ReboundAngle { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }





    }
}
