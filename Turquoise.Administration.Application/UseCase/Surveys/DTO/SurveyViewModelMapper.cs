using AutoMapper;

namespace Turquoise.Administration.Application.UseCase.Surveys.DTO
{
    using Turquoise.Administration.Domain.Aggregation.Survey;
    public sealed class SurveyViewModelMapper : Profile
    {
        public SurveyViewModelMapper()
        {
            CreateMap<Survey, SurveyViewModel>();
            CreateMap<SurveyViewModel, Survey>()
                .ForMember(e => e.CreationAt, options => options.Ignore())
                .ForMember(e => e.ChoiceGroup, options => options.Ignore());

            CreateMap<SurveyBranch, SurveyBranchViewModel>();
            CreateMap<SurveyBranchViewModel, SurveyBranch>();
        }
    }
}
