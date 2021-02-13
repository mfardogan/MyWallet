using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turquoise.Authentication.Domain.Aggregation.Doctor
{
    public class DoctorPassword
    {
        [Required]
        [Column("hash")]
        public byte[] Hash { get; set; }

        [Required]
        [Column("salt")]
        public byte[] Salt { get; set; }
    }
}
