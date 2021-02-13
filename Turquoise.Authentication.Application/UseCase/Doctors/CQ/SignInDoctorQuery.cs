using MediatR;

namespace Turquoise.Authentication.Application.UseCase.Doctors.CQ
{
    using Turquoise.Authentication.Application.UseCase.Doctors.DTO;
    public sealed class SignInDoctorQuery : IRequest<DoctorTokenViewModel>
    {
        public DoctorTokenRequestViewModel Doctor { get; set; }
    }
}
