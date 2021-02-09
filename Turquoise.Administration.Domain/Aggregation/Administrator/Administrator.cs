﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.Administrator
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;

    [Table(name: "administrator", Schema = Schamas.USERS)]
    public class Administrator : ConcurrencyEntity<Guid>, IAggregateRoot, ICreationAt
    {
        [Required]
        [Column(name: "name", TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column(name: "surname", TypeName = "varchar(20)")]
        public string Surname { get; set; }

        [Column(name: "full_name")]
        public string FullName { get; set; }

        [Column(name: "creationAt")]
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
