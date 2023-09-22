using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Databasen1.Models.Entities
{
    internal class AdressEntities
    {
        [Key]
        public int Id { get; set; }
       
        [Column(TypeName ="nvarchar(50)")]
        public string StreetName { get; set; } = null!;

        [Column(TypeName ="char(10)")]
        public string StreetNr { get; set; } = null!;

        [Column(TypeName = "char(5)")]
        public string PostalCode { get; set; } = null!;

        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = null!;

        public ICollection<PropertiesEntities> Properties = new HashSet<PropertiesEntities>();

    }


}
