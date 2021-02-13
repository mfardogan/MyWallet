using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Authentication.Application.UseCase.Doctors
{
    using Turquoise.Authentication.Domain;
    using Turquoise.Authentication.Domain.Abstraction;
    using Turquoise.Authentication.Domain.Aggregation.Doctor;
    using Turquoise.Authentication.Application.UseCase.Doctors.CQ;
    using Turquoise.Authentication.Application.UseCase.Doctors.DTO;

    public class DoctorQueryHandler : IRequestHandler<SignInDoctorQuery, DoctorTokenViewModel>
    {
        private readonly IDoctorDAO dAO;
        private readonly ServiceProxy<IDoctorDAO> service;

        public DoctorQueryHandler()
        {
            var serviceProxy = new ServiceProxy<IDoctorDAO>();
            (service, dAO) = (serviceProxy, service.DataAccessObject);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<DoctorTokenViewModel> Handle(SignInDoctorQuery request, CancellationToken cancellationToken)
        {
            Doctor doctor = dAO.GetDoctorByEmail(request.Doctor.Email);
            DoctorPassword password = dAO.GetPasswordByEmail(request.Doctor.Email);

            if (!Dependency.Get<IPasswordHasher>().Check(request.Doctor.Password, password.Hash, password.Salt))
            {
                throw new Exception("Email or password is not correct!");
            }

            return service.Success(new DoctorTokenViewModel());
        }
    }
}
