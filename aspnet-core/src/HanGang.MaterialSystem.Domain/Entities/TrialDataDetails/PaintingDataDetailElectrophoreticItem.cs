﻿using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HanGang.MaterialSystem.Entities.TrialDataDetails
{
    /// <summary>
    /// 涂装性能-电泳漆膜厚度试验数据结果明细
    /// </summary>
    public class PaintingDataDetailElectrophoreticItem : FullAuditedAggregateRoot<Guid>
    {
        #region 关联材料涂装性能试验数据

        /// <summary>
        /// 涂装性能试验数据明细
        /// </summary>
        public Guid? PaintingDataDetailId { get; set; }

        /// <summary>
        /// 涂装性能试验数据明细
        /// </summary>
        public virtual PaintingDataDetail PaintingDataDetail { get; set; }

        #endregion

        /// <summary>
        /// 厚度
        /// </summary>
        public decimal? PointThick { get; set; }

        /// <summary>
        /// 厚度1
        /// </summary>
        public decimal? PointThickOne { get; set; }

        /// <summary>
        /// 厚度2
        /// </summary>
        public decimal? PointThickTwo { get; set; }

        /// <summary>
        /// 厚度3
        /// </summary>
        public decimal? PointThickThree { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

    }
}
