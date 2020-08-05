using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.Enum;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.MaterialTrials.Dtos;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;
using HanGang.MaterialSystem.Trials.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.Enum;
using HanGang.MaterialSystem.Trials.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.MaterialTrials
{
    /// <summary>
    /// 材料试验服务
    /// </summary>
    public class MaterialTrialAppService : MaterialSystemAppService
    {
        private readonly IRepository<Trial> _trialRepository;
        private readonly IRepository<Material> _materialRepository;
        private readonly IRepository<MaterialTrial> _materialtrialRepository;
        private readonly IRepository<MaterialTrialData> _materialTrialDataRepository;
        private readonly IRepository<StaticTensionDataDetail> _staticTensionDataDetailRepository;
        private readonly IRepository<StaticTensionDataDetailStressStrain> _staticTensionDataDetailStressStrainRepository;


        public MaterialTrialAppService(
            IRepository<Trial> trialRepository,
            IRepository<Material> materialRepository,
            IRepository<MaterialTrial> materialTrialRepository,
            IRepository<MaterialTrialData> materialTrialDataRepository,
            IRepository<StaticTensionDataDetail> staticTensionDataDetailRepository,
            IRepository<StaticTensionDataDetailStressStrain> staticTensionDataDetailStressStrainRepository)
        {
            _trialRepository = trialRepository;
            _materialRepository = materialRepository;
            _materialtrialRepository = materialTrialRepository;
            _materialTrialDataRepository = materialTrialDataRepository;
            _staticTensionDataDetailRepository = staticTensionDataDetailRepository;
            _staticTensionDataDetailStressStrainRepository = staticTensionDataDetailStressStrainRepository;
        }


        /// <summary>
        /// 根据材料id获取对应实验项目
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public List<TrialDto> GetTrialItemByMaterialId(Guid materialId)
        {
            //1.根据材料Id找到这个材料做了哪些试验
            var trials = _materialtrialRepository
                .AsNoTracking()
                .Include(m => m.Trial)
                .ThenInclude(y => y.Parent)
                .Where(m => m.MaterialId == materialId)
                .Select(n => n.Trial)
                .ToList();
            //2.返回此材料做的所有实验项目
            return ObjectMapper.Map<List<Trial>, List<TrialDto>>(trials);
        }


        /// <summary>
        /// 寻找静态拉伸数据明细
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="trialType"></param>
        public List<StaticTensionDataDetailDto> GetStaticTensionDataDetails(Guid materialId)
        {
            //寻找静态拉伸数据明细
            var staticData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .Where(m => m.MaterialTrial.Material.Id == materialId)
                .SelectMany(n => n.StaticTensionDataDetails)
                .ToList();
            return ObjectMapper.Map<List<StaticTensionDataDetail>, List<StaticTensionDataDetailDto>>(staticData);
            
        }



        /// <summary>
        /// 获取所有材料试验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IPagedResult<MaterialTrialDto>> GetMaterialTrials(GetMaterialTrialListInputDto input)
        {
            return _materialtrialRepository
                .AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name))
                .WhereIf(input.MaterialId.HasValue, x => x.MaterialId == input.MaterialId)   //按材料id查询材料试验
                .OrderBy(input.Sorting)
                .ProjectTo<MaterialTrialDto>(Configuration)
                .ToPageResultAsync(input);
        }


        /// <summary>
        /// 根据材料试验Id获取某个材料试验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MaterialTrialDto> GetMaterialTrialById(Guid id)
        {
            var materialtrial = await _materialtrialRepository.GetAsync(id);
            return ObjectMapper.Map<MaterialTrial, MaterialTrialDto>(materialtrial);
        }

        /// <summary>
        /// 添加材料试验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> AddMaterialTrial(AddMaterialTrialInputDto input)
        {
            var materialtrial = new MaterialTrial
            {
                Name = input.Name,
                Code = input.Code,
                Remark = input.Remark,
                MaterialId = input.MaterialId,
                TrialId = input.TrialId
            };
            await _materialtrialRepository.InsertAsync(materialtrial);
            return materialtrial.Id;
        }

        /// <summary>
        /// 更新某个材料试验信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateMaterialTrial(MaterialTrialDto input)
        {
            var materialtrial = await _materialtrialRepository.GetAsync(input.Id);
            materialtrial.Name = input.Name;
            materialtrial.Code = input.Code;
            materialtrial.Remark = input.Remark;
            materialtrial.MaterialId = input.MaterialId;
            materialtrial.TrialId = input.TrialId;
            return materialtrial.Id;
        }

        /// <summary>
        /// 根据材料试验Id删除某个材料试验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            //var manufactory = await _manufactoryRepository.GetAsync(id);
            await _materialtrialRepository.DeleteAsync(m => m.Id == id);
        }




        /// <summary>
        /// 数据过滤演示 同步方法演示
        /// </summary>
        /// <param name="id"></param>
        public List<TrialDto> GetAllDataExample(Guid id)
        {
            //1.根据材料Id找到这个材料做了哪些试验
            var trials = _materialtrialRepository
                .AsNoTracking()
                .Where(m => m.MaterialId == id)
                .Select(n => n.Trial)
                .ToList();
            //2、返回此材料做了哪些试验的  试验数据明细信息
            return ObjectMapper.Map<List<Trial>, List<TrialDto>>(trials);

            //寻找静态拉伸数据明细
            var staticData = _materialTrialDataRepository
                .AsNoTracking()
                .Include(x => x.StaticTensionDataDetails)
                .ThenInclude(y => y.StaticTensionDataDetailStressStrains)
                .Where(m => m.MaterialTrial.Trial.TrialType == TrialType.静态拉伸
                            && m.MaterialTrial.Material.Id == id
                            && m.MaterialTrial.Material.Strength < 500
                            && m.MaterialTrial.Material.Strength > 200)
                .SelectMany(n => n.StaticTensionDataDetails)
                .ToList();

            //直接取静态拉伸试验数据
            var staticData1 = _staticTensionDataDetailRepository.AsNoTracking()
                .Include(y => y.StaticTensionDataDetailStressStrains)
                .Where(m => m.MaterialTrialData.MaterialTrial.Material.Name == "DC01")
                .ToList();
        }
    }
}