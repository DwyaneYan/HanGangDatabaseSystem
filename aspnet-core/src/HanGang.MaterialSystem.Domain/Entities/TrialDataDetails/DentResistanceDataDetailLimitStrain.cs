using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 抗凹性能主次应变试验数据明细
    /// </summary>
    public class DentResistanceDataDetailLimitStrain : FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料抗凹性能试验数据

        /// <summary>
        /// 抗凹性能试验数据明细
        /// </summary>
        public Guid? DentResistanceDataDetailId { get; set; }

        /// <summary>
        /// 抗凹性能试验数据明细
        /// </summary>
        public virtual DentResistanceDataDetail DentResistanceDataDetail { get; set; }

        #endregion

        /// <summary>
        /// 主应变
        /// </summary>
        public decimal? MainStrain { get; set; }

        /// <summary>
        /// 次应变
        /// </summary>
        public decimal? SecondaryStrain { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }
    }
}
