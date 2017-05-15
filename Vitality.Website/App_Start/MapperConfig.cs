namespace Vitality.Website.App_Start
{
    using Areas.Presales.ComponentTemplates.FeatureBlocks;
    using AutoMapper;
    using System.Linq;

    public static class MapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(SetMapping);
            Mapper.Configuration.AssertConfigurationIsValid();
        }

        private static void SetMapping(IMapperConfigurationExpression config)
        {
            config
                .CreateMap<VacancyList, VacancyListViewModel>()
                .ForMember(
                    dest => dest.Departments,
                    opt => opt.MapFrom(src => src.Departments.Select(l => l.Value)))
                .ForMember(
                    dest => dest.FeedSettingsEndpoint,
                    opt => opt.MapFrom(src => src.FeedSettings.Endpoint))
                .ForMember(
                    dest => dest.FeedSettingsType,
                    opt => opt.MapFrom(src => src.FeedType))
                .ForMember(
                    dest => dest.FeedSettingsMockDataFileUrl,
                    opt => opt.MapFrom(src => src.FeedSettings.MockDataFile.Url))
                .ForMember(
                    dest => dest.Locations,
                    opt => opt.MapFrom(src => src.Locations.Select(l => l.Value)))
                .ForMember(
                    dest => dest.VacancyClosesOn,
                    opt => opt.MapFrom(src => src.ClosesOnText));
        }
    }
}
