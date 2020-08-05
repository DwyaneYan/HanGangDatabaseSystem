using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 高速拉伸试验数据明细
    /// </summary>
    public class HighSpeedStrechDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 取样方向
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 测试指标
        /// </summary>
        public string TestTarget { get; set; }

        /// <summary>
        /// 屈服强度Rp(MPa)
        /// </summary>
        public decimal? YieldStrength { get; set; }

        /// <summary>
        /// 抗拉强度Rm(MPa)
        /// </summary>
        public decimal? TensileStrength { get; set; }

        /// <summary>
        /// 断后伸长率
        /// </summary>
        public decimal? Elongation { get; set; }
        
        /// <summary>
        /// 拉伸速度(m/s)
        /// </summary>
        public decimal? StretchingSpeed { get; set; }

        /// <summary>
        /// 高速拉伸试验数据明细
        /// </summary>
        public virtual HashSet<HighSpeedStrechDataDetailStressStrain> HighSpeedStrechDataDetailStressStrains { get; set; } = new HashSet<HighSpeedStrechDataDetailStressStrain>();
    }
}
