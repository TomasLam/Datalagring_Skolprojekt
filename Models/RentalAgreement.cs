using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databasen1.Models
{
    internal class RentalAgreement
    {

      
        
            [Key]
            public int Id { get; set; }

            [Required]
            public string TenantsId { get; set; } = null!;
            public Tenants Tenants { get; set; } = null!;

            [Required]
            public string PropertiesId { get; set; } = null!;
            public Properties Property { get; set; } = null!;

            [Column(TypeName = "char(50)")]
            public string AgreementNumbers { get; set; } = null!;
        

    }
}
