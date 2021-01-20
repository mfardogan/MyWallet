using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Administration.Domain.Aggregation.Administrator
{
    using MyWallet.Administration.Domain.Abstraction;
    using MyWallet.Administration.Domain.Aggregation.Common;

    [Table(name: "administrator", Schema = Schamas.USERS)]
    public class Administrator : Entity<Guid>, IAggregationRoot, ICreationAt, IHasConcurrency
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

        [Timestamp]
        [Column(name: "row_version", Order = 2)]
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public virtual AdministratorPassword Password { get; set; }
    }
}
