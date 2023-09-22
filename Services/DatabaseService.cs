using Databasen1.Context;
using Databasen1.Models;
using Databasen1.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Databasen1.Services
{
    internal class DatabaseService
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tomas\Documents\SQL2\Databasen1\Databasen1\Context\SQL_db.mdf;Integrated Security=True;Connect Timeout=30";

        public void SaveToDatabase(Tenants tenants)
        {
            using (var context = new DataContext())
            {
                var tenantsEntities = new TenantsEntities
                {
                    FirstName = tenants.FirstName,
                    LastName = tenants.LastName,
                    PhoneNr = tenants.PhoneNr,
                    Email = tenants.Email,
                };

                context.Tenants.Add(tenantsEntities);
                context.SaveChanges();
            }
        }

        public void SaveIssueToDatabase(Issue issue)
        {
            using (var context = new DataContext())
            {
                context.Issue.Add(issue);

                // Lägg till kommentarer om de finns
                if (issue.Comments != null && issue.Comments.Any())
                {
                    context.Comment.AddRange(issue.Comments);
                }

                context.SaveChanges();
            }
        }

    }
}
