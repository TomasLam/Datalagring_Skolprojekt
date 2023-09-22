using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databasen1.Models
{
    internal class Properties
    {
       
        
            [Key]
            public int Id { get; set; }

            [Column(TypeName = "nvarchar(50)")]
            public string PropertyName { get; set; } = null!;

            [Column(TypeName = "nvarchar(50)")]
            public string TypeOfBuilding { get; set; } = null!;

            [Column(TypeName = "char(5)")]
            public string BuildYear { get; set; } = null!;

            [Required]
            public int AdressId { get; set; }
            public Adress Adress { get; set; } = null!;

            public ICollection<RentalAgreement> RentalAgreement = new HashSet<RentalAgreement>();
        

    }
}
