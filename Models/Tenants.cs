using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Databasen1.Models
{
    [Index(nameof(Email), IsUnique = true)]
    internal class Tenants
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

        public ICollection<RentalAgreement> RentalAgreement = new HashSet<RentalAgreement>();

    }
}
