using AutoMapper;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers.DTO
{
    using Turquoise.Administration.Domain;
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.SurveyAnswer;
    public sealed class SurveyAnswerViewModelMapper : Profile
    {
        public SurveyAnswerViewModelMapper()
        {
            CreateMap<SurveyAnswer, SurveyAnswerViewModel>();
            CreateMap<SurveyAnswerViewModel, SurveyAnswer>()
                .ForMember(e => e.DoctorId, options =>
                    options.MapFrom(source => Dependency.Get<IIdentity>().DoctorId.Value));

            CreateMap<SurveyAnswerChoice, SurveyAnswerChoiceViewModel>();
            CreateMap<SurveyAnswerChoiceViewModel, SurveyAnswerChoice>()
                .ForMember(e => e.Choice, options => options.Ignore());
        }
    }
}
