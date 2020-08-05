using AutoMapper;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.StaticTensionDataDetails.Dtos;

namespace HanGang.MaterialSystem.Manufactories
{
    public class StaticTensionDataDetailDtoMapper : Profile
    {
        public StaticTensionDataDetailDtoMapper()
        {
            CreateMap<StaticTensionDataDetail, StaticTensionDataDetailDto>();
        }
    }
}