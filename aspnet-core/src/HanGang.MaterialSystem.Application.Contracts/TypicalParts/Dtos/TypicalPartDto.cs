namespace HanGang.MaterialSystem.TypicalParts.Dtos
{
    public class TypicalPartDto
    {
        public System.Guid Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 应用车型
        /// </summary>
        public string AppliedVehicleType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}