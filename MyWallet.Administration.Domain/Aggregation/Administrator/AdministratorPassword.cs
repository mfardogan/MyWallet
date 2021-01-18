using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyWallet.Administration.Domain.Aggregation.Common;

namespace MyWallet.Administration.Domain.Aggregation.Administrator
{
    [Table(name: "administratorPassword", Schema = Schamas.USERS)]
    public class AdministratorPassword : Entity<Guid>
    {
        /// <summary>
        /// Fk
        /// </summary>
        [ForeignKey(nameof(Administrator))]
        public override Guid Id { get => base.Id; set => base.Id = value; }
        public Administrator Administrator { get; set; }

        [Required]
        [Column(name: "hash")]
        public byte[] Hash { get; set; }

        [Required]
        [Column(name: "salt")]
        public byte[] Salt { get; set; }
    }
}
