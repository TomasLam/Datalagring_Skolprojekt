using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databasen1.Models
{
    internal class Comment
    {

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
