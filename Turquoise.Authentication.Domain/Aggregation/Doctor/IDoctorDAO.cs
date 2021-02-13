namespace Turquoise.Authentication.Domain.Aggregation.Doctor
{
    using Turquoise.Authentication.Domain.Abstraction;
    public interface IDoctorDAO : IDataAccessObject
    {
        Doctor GetDoctorByEmail(string email);
        DoctorPassword GetPasswordByEmail(string email);
    }
}
