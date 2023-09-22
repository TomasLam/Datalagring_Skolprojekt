using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Databasen1.Models.Entities
{
    internal class PropertiesEntities
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
             public AdressEntities Adress { get; set; } = null!;

        public ICollection<RentalAgreementEntities> RentalAgreement = new HashSet<RentalAgreementEntities>();
        }


}
