﻿namespace HanGang.MaterialSystem.Enum
{
    /// <summary>
    /// 材料类型
    /// </summary>
    public enum MaterialType
    {
        其它 = 0,

        #region 冷轧
        冷轧 = 10,
        冷轧烘烤硬化刚 = 20,
        冷轧高强IF钢 = 30,
        冷轧低碳铝镇静钢 = 40,
        冷轧低合金高强度钢 = 50,
        冷轧双相钢 = 60,
        冷轧淬火延性钢 = 70,
        冷轧马氏体钢 = 80,
        冷轧增强成形性双相钢 = 90,
        冷轧IF钢 = 100,
        #endregion

        #region 镀锌
        镀锌 = 110,
        镀锌烘烤硬化钢 = 120,
        镀锌高强IF钢 = 130,
        镀锌低碳铝镇静钢 = 140,
        镀锌低合金高强度钢 = 150,
        镀锌双相钢 = 160,
        镀锌IF钢 = 170,
        镀锌增强成形性双相钢 = 175,
        #endregion

        #region 热轧
        热轧 = 180,
        热轧低碳钢 = 190,
        热轧SAPH系列 = 200,
        热轧QStE结构钢系列 = 210,
        热轧大梁钢 = 220,
        热轧车轮钢轧 = 230,
        热轧双相钢 = 240,
        热轧箱体钢 = 250,
        热轧制动鼓用钢 = 260,
        #endregion

        #region 中板
        中板 = 270,
        中板大梁钢 = 275,
        中板车轮钢 = 280,
        中板车桥钢 = 290,
        中板自卸车厢体用耐磨钢 = 300,
        #endregion
    }
}
