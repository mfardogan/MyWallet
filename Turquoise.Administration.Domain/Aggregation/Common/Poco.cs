using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Administration.Domain.Aggregation.Common
{
    public abstract class Poco<TPk> : Entity
    {
        public Poco() { }
        public Poco(TPk id) => Id = id;

        /// <summary>
        /// Primary key column
        /// </summary>
        [
            Key,
            Column("id", Order = 0)
        ]
        public virtual TPk Id { get; set; }

        /// <summary>
        /// Row guid
        /// </summary>
        [Column("row_guid",TypeName = "uuid", Order = 1)]
        public Guid? RowGuid { get; set; }
    }
}
