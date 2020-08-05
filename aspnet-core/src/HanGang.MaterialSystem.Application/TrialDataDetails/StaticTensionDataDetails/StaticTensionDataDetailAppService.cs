using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Manufactories.Dtos;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.StaticTensionDataDetails
{
    /// <summary>
    /// 静态拉伸服务
    /// </summary>
    public class StaticTensionDataDetailAppService : MaterialSystemAppService
    {
        private readonly IRepository<StaticTensionDataDetail, Guid> _staticTensionDataDetailRepository;

        public StaticTensionDataDetailAppService(IRepository<StaticTensionDataDetail, Guid> staticTensionDataDetailRepository)
        {
            _staticTensionDataDetailRepository = staticTensionDataDetailRepository;
        }

        /// <summary>
        /// 添加静态拉伸数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddManufactory(StaticTensionDataDetailDto input)
        {
            var staticTensionDataDetail = new StaticTensionDataDetail
            {
                MaterialTrialDataId = input.MaterialTrialDataId,
                Standard = input.Standard,
                SerialNumber = input.SerialNumber,
                SampleCode = input.SampleCode,
                Length = input.Length,
                Width = input.Width,
                Thickness = input.Thickness,
                Diameter = input.Diameter,
                GaugeDistance = input.GaugeDistance,
                Remark = input.Remark,
                NonProportionalExtendRatio = input.NonProportionalExtendRatio,
                YieldStrength = input.YieldStrength,
                TensileStrength = input.TensileStrength,
                StrainHardening = input.StrainHardening,
                Elongation = input.Elongation,
                PlasticStrainRatio = input.PlasticStrainRatio,
                ModulusOfElasticity = input.ModulusOfElasticity,
                PoissonRatio = input.PoissonRatio,
                MaximumForce = input.MaximumForce,
            };
            await _staticTensionDataDetailRepository.InsertAsync(staticTensionDataDetail);
            return staticTensionDataDetail.Id;
        }

    }
}