using HanGang.MaterialSystem.Dtos;
using HanGang.MaterialSystem.Enum;
using System;

namespace HanGang.MaterialSystem.BakeHardeningDataDetails.Dtos
{
    public class BakeHardeningDataDetailDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id { get; set; }
        /// <summary>
        /// BH值
        /// </summary>

        public int? BH { get; set; }



    }
}