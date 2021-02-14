using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.Administrator
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;

    [Table("administrator", Schema = Schamas.USERS)]
    public class Administrator : ConcurrencyPoco<Guid>, IAggregateRoot, ICreationAt
    {
        [Required]
        [Column("name", TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column("surname", TypeName = "varchar(20)")]
        public string Surname { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("creation_at")]
        public DateTime? CreationAt { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public virtual AdministratorPassword Password { get; set; }

        public void AddPassword(byte[] salt, byte[] hash)
        {
            Password = new AdministratorPassword()
            {
                Hash = hash,
                Salt = salt
            };
        }
    }
}
