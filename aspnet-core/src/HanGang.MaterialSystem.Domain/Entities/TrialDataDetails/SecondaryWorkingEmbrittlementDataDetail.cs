using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 二次加工脆化试验数据明细
    /// </summary>
    public class SecondaryWorkingEmbrittlementDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 温度（℃）
        /// </summary>
        public decimal? Temperature { get; set; }
        
        /// <summary>
        /// 二次加工脆化试验杯具数据明细
        /// </summary>
        public virtual HashSet<DentResistanceDataDetailLimitStrain> DentResistanceDataDetailLimitStrains { get; set; }=new HashSet<DentResistanceDataDetailLimitStrain>();
    }
}
