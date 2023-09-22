using System.Collections.Generic;
using Databasen1.Models;

internal class Issue
{
    
    
        public int Id { get; set; }
        public string TenantFirstName { get; set; }
        public string TenantLastName { get; set; }
        public string TenantEmail { get; set; }
        public string TenantPhoneNumber { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } // Lägg till ärendestatus
        public List<Comment> Comments { get; set; } // Lista med kommentarer

}

