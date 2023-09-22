using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databasen1.Models
{
    internal class Adress
    {
       
        
            [Key]
            public int Id { get; set; }

            [Column(TypeName = "nvarchar(50)")]
            public string StreetName { get; set; } = null!;

            [Column(TypeName = "char(10)")]
            public string StreetNr { get; set; } = null!;

            [Column(TypeName = "char(5)")]
            public string PostalCode { get; set; } = null!;

            [Column(TypeName = "nvarchar(50)")]
            public string City { get; set; } = null!;

            public ICollection<Properties> Properties = new HashSet<Properties>();

        public static implicit operator Adress(string v)
        {
            throw new NotImplementedException();
        }
    }
}
