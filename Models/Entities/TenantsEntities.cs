using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Databasen1.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    internal class TenantsEntities
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = null!;

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;

        [Column(TypeName = "char(25)")]
        public string PhoneNr { get; set; } = null!;

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = null!;

        public ICollection<RentalAgreementEntities> RentalAgreement = new HashSet<RentalAgreementEntities>();

    }


}
