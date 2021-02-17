using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregate.Administrator
{
    using Turquoise.Administration.Domain.Aggregate.Common;

    [Table("administrator_password", Schema = Schamas.USERS)]
    public class AdministratorPassword : Poco<Guid>
    {
        /// <summary>
        /// Fk
        /// </summary>
        [ForeignKey(nameof(Administrator))]
        public override Guid Id { get => base.Id; set => base.Id = value; }
        public Administrator Administrator { get; set; }

        [Required]
        [Column("hash")]
        public byte[] Hash { get; set; }

        [Required]
        [Column("salt")]
        public byte[] Salt { get; set; }
    }
}
