using MyWallet.Administration.Domain.Aggregation.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Administration.Domain.Aggregation.Administrator
{
    [Table(name: "administrator", Schema = Schamas.USERS)]
    public class Administrator : Entity<Guid>, ICreationAt
    {
        [Required]
        [Column(name: "name")]
        public string Name { get; set; }

        [Required]
        [Column(name: "surname")]
        public string Surname { get; set; }

        [Column(name: "fullName")]
        public string FullName { get; set; }

        [Column(name: "creationAt")]
        public DateTime? CreationAt { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public virtual AdministratorPassword Password { get; set; }
    }
}
