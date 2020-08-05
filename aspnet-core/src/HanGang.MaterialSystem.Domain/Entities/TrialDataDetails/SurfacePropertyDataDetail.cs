using System.Collections.Generic;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 表面性能试验数据明细
    /// </summary>
    public class SurfacePropertyDataDetail : BaseTrialDataDetail
    {
        /// <summary>
        /// 表面性能试验粗造度数据明细
        /// </summary>
        public virtual HashSet<SurfacePropertyCoatingWeight> SurfacePropertyCoatingWeights { get; set; } = new HashSet<SurfacePropertyCoatingWeight>();

        /// <summary>
        /// 表面性能试验粗造度数据明细
        /// </summary>
        public virtual HashSet<SurfacePropertyRoughness> SurfacePropertyRoughnesses { get; set; } = new HashSet<SurfacePropertyRoughness>();
    }
}
