using System;
using MyWallet.Administration.Domain.Aggregation.Common;

namespace MyWallet.Administration.Domain.Aggregation.Administrator
{
    public class AdministratorViewModel : EntityViewModel<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public DateTime? CreationAt { get; set; }
        public string Password { get; set; }
    }
}
