using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Databasen1.Models.Entities
{
    internal class RentalAgreementEntities
        {
            [Key]  
            public int Id { get; set; }

            [Required]
            public string TenantsId { get; set; } = null!;
        public TenantsEntities Tenants { get; set; } = null!;

            [Required]
            public string PropertiesId { get; set; } = null!;
        public PropertiesEntities Property { get; set; } = null!;

            [Column(TypeName = "char(50)")]
            public string AgreementNumbers { get; set; } = null!;
    }


}
