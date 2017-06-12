using System;
using System.Collections.Generic;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply;

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

            config
                .CreateMap<Question, QuestionViewModel>()
                .ForMember(
                    dest => dest.Value,
                    opt => opt.MapFrom(src => src.DefaultValue))
                .ForMember(
                    dest => dest.ControlType,
                    opt => opt.MapFrom(src => src.ControlType.Value))
                .ForMember(
                    dest => dest.RelatedData,
                    opt =>
                        opt.MapFrom(
                            src => src.RelatedData.Select(i => new KeyValuePair<string, string>(i.Name, i.Value))))
                .ForMember(
                    dest => dest.Validations,
                    opt => opt.MapFrom(src => src.Validations.Select(i => i.Value)));

            config.CreateMap<QuestionGroup, QuestionGroupViewModel>();

            config.CreateMap<QuoteApplyForm, QuoteApplyFormViewModel>();
        }
    }
}
