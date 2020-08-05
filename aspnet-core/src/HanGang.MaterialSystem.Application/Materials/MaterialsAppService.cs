using AutoMapper.QueryableExtensions;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.LinqExtensions;
using HanGang.MaterialSystem.Materials.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.Enum;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HanGang.MaterialSystem.Trials
{
    /// <summary>
    /// 材料服务
    /// </summary>
    public class MaterialAppService : MaterialSystemAppService
    {
        private readonly IRepository<Material> _materialRepository;
        private readonly IRepository<MaterialTrial> _materialTrialRepository;
        private readonly IRepository<MaterialTrialData> _materialTrialDataRepository;
        private readonly IRepository<StaticTensionDataDetail> _staticTensionDataDetailRepository;
        private readonly IRepository<StaticTensionDataDetailStressStrain> _staticTensionDataDetailStressStrainRepository;

        public MaterialAppService(IRepository<Material> materialRepository,
            IRepository<MaterialTrial> materialTrialRepository,
            IRepository<MaterialTrialData> materialTrialDataRepository,
            IRepository<StaticTensionDataDetail> staticTensionDataDetailRepository,
            IRepository<StaticTensionDataDetailStressStrain> staticTensionDataDetailStressStrainRepository)
        {
            _materialRepository = materialRepository;
            _materialTrialRepository = materialTrialRepository;
            _materialTrialDataRepository = materialTrialDataRepository;
            _staticTensionDataDetailRepository = staticTensionDataDetailRepository;
            _staticTensionDataDetailStressStrainRepository = staticTensionDataDetailStressStrainRepository;
        }


        /// <summary>
        /// 数据过滤演示
        /// </summary>
        /// <param name="id"></param>
        public void GetAllDataExample(Guid id)
        {
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
            var staticData1 = _staticTensionDataDetailRepository
                .AsNoTracking()
                .Include(y => y.StaticTensionDataDetailStressStrains)
                .Where(m => m.MaterialTrialData.MaterialTrial.Material.Name == "DC01")
                .ToList();
        }

        /// <summary>
        /// 获取所有材料
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IPagedResult<MaterialDto>> GetMaterials(GetMaterialListInputDto input)
        {
            return _materialRepository
                .AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name))  //按材料名称筛选
                .WhereIf(input.MaterialType.HasValue, x => x.MaterialType == input.MaterialType)   //增加按材料类型筛选
                .WhereIf(input.Model.HasValue, x => x.Model == input.Model)   //增加按型号规格型筛选
                .WhereIf(input.MinModel.HasValue, m => m.Model >= input.MinModel)//按最小型号规格筛选
                .WhereIf(input.MaxModel.HasValue, m => m.Model <= input.MaxModel)//按最大型号规格筛选
                .WhereIf(input.Strength.HasValue, x => x.Strength == input.Strength)  //按屈服强度筛选
                .WhereIf(input.MinStrenth.HasValue, m => m.Strength >= input.MinStrenth)//按最小材料强度筛选
                .WhereIf(input.MaxStrenth.HasValue, m => m.Strength <= input.MaxStrenth)//按最大材料强度筛选
                .WhereIf(input.ManufactoryId.HasValue, x => x.ManufactoryId == input.ManufactoryId)  //按厂家Id度筛选
                 .WhereIf(input.Id.HasValue, x => x.Id == input.Id)  //按厂家Id度筛选
                .OrderBy(input.Sorting)
                .ProjectTo<MaterialDto>(Configuration)
                .ToPageResultAsync(input);
        }

        /// <summary>
        /// 添加材料
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>between types 'System.String' and 'System.Nullable`1[System.Guid]'.”

        public async Task<Guid> AddMaterial(MaterialDto input)
        {
            var material = new Material
            {
                Name = input.Name,
                Model = input.Model,
                Strength = input.Strength,
                MaterialType = input.MaterialType,
                Date = input.Date,               
                TypicalPartId = input.TypicalPartId,
                ManufactoryId = input.ManufactoryId,
            };
            await _materialRepository.InsertAsync(material);
            return material.Id;
        }

        /// <summary>
        /// 更新某个材料信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateTrial(MaterialDto input, Guid id)
        {
            var material = await _materialRepository.GetAsync(id);
            material.Name = input.Name;
            material.Model = input.Model;
            material.Strength = input.Strength;
            material.MaterialType = input.MaterialType;
            material.Date = input.Date;
            material.AppliedVehicleType = input.AppliedVehicleType;
            material.TypicalPartId = input.TypicalPartId;
            material.ManufactoryId = input.ManufactoryId;
            return material.Id;
        }

        /// <summary>
        /// 根据材料Id删除某个材料信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            //var manufactory = await _manufactoryRepository.GetAsync(id);
            await _materialRepository.DeleteAsync(t => t.Id == id);
        }
    }
}