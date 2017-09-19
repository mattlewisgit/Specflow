namespace Vitality.Website.App_Start
{
    using Areas.Global.Models;
    using Areas.Presales.ComponentTemplates.FeatureBlocks;
    using Areas.Presales.ComponentTemplates.QuoteApply;
    using Areas.Presales.ComponentTemplates.TellForm;
    using AutoMapper;
    using System.Collections.Generic;
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


            config.CreateMap<FieldValidator, FieldValidatorViewModel>()
                .ForMember(
                    dest => dest.Parameters,
                    opt => opt.MapFrom(src => src.Parameters.AllKeys.ToDictionary(i => i, i => src.Parameters[i])));

            config.CreateMap<Question, QuestionViewModel>()
                .ForMember(
                    dest => dest.Key,
                    opt => opt.MapFrom(src => src.Key.Value))
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
                            src => src.RelatedData.Select(i => new KeyValuePair<string, string>(i.Name, i.Value))));

            config.CreateMap<QuestionGroup, QuestionGroupViewModel>()
                .ForMember(
                    dest => dest.Key,
                    opt => opt.MapFrom(src => src.Key.Value))
                .ForMember(
                    dest => dest.BasedOnKey,
                    opt => opt.MapFrom(src => src.BasedOnKey.Value))
                .ForMember(
                    dest => dest.BasedOnValues,
                    opt =>
                        opt.MapFrom(
                            src => string.IsNullOrEmpty(src.BasedOnValues) ? null : src.BasedOnValues.Split(',')));

            config.CreateMap<QuoteApplyFooter, QuoteApplyFooterViewModel>()
                .ForMember(
                    dest => dest.CallToAction,
                    opt => opt.MapFrom(src => src.CallToAction.Url))
                .ForMember(
                    dest => dest.ContactNumber,
                    opt => opt.MapFrom(src => src.ContactNumber.Value))
                .ForMember(
                    dest => dest.OpeningHoursText,
                    opt => opt.MapFrom(src => src.OpeningHoursText.Value));


            config.CreateMap<Benefit, BenefitViewModel>()
                .ForMember(
                    dest => dest.Code,
                    opt => opt.MapFrom(src => src.Code.Value))
                     .ForMember(
                    dest => dest.SelectedOption,
                    opt => opt.MapFrom(src => src.SelectedOption.Value));

            config.CreateMap<BenefitOption, BenefitOptionViewModel>()
                .ForMember(
                    dest => dest.Code,
                    opt => opt.MapFrom(src => src.Code.Value));

            config.CreateMap<Permutation, PermutationViewModel>()
                .ForMember(
                    dest => dest.CoreModules,
                    opt => opt.MapFrom(src => src.CoreModules.Select(c => c.Value)))
                .ForMember(
                    dest => dest.ExternalIdentifier,
                    opt => opt.MapFrom(src => src.ExternalIdentifier.Value));

            config.CreateMap<QuoteResult, QuoteResultViewModel>()
                .ForMember(
                    dest => dest.AlternativeCallToAction,
                    opt => opt.MapFrom(src => src.AlternativeCallToAction.Url))
                .ForMember(
                    dest => dest.CallToAction,
                    opt => opt.MapFrom(src => src.CallToAction.Url))
                .ForMember(
                    dest => dest.ServiceOutagePage,
                    opt => opt.MapFrom(src => src.ServiceOutagePage.Url));

            config.CreateMap<TellForm, TellFormViewModel>()
                .ForMember(
                    dest => dest.AdditionalData,
                    opt =>
                        opt.MapFrom(
                            src => src.AdditionalData.AllKeys.ToDictionary(i => i, i => src.AdditionalData[i])))
                .ForMember(
                    dest => dest.PostAction,
                    opt => opt.MapFrom(src => src.PostAction.Endpoint))
                .ForMember(
                    dest => dest.RedirectTo,
                    opt => opt.MapFrom(src => $"{src.RedirectTo.Url}?{src.RedirectTo.Query}"))
                .ForMember(
                    dest => dest.ServiceOutagePage,
                    opt => opt.MapFrom(src => src.ServiceOutagePage.Url));

        }
    }
}
