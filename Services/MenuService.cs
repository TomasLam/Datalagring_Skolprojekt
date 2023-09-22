using Databasen1.Context;
using Databasen1.Models.Entities;
using Databasen1.Models;
using Microsoft.EntityFrameworkCore;
using Databasen1.Services;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Databasen1.Services
{
    internal class MenuService
    {
        public void CreateNewTenant()
        {
            var tenants = new Tenants();

            Console.WriteLine("First name: ");
            tenants.FirstName = Console.ReadLine() ?? "";

            Console.WriteLine("Last name: ");
            tenants.LastName = Console.ReadLine() ?? "";

            Console.WriteLine("PhoneNr: ");
            tenants.PhoneNr = Console.ReadLine() ?? "";

            Console.WriteLine("Email: ");
            tenants.Email = Console.ReadLine() ?? "";

            // Spara hyresgäster till en databas
            SaveToDatabase(tenants);
        }

        public void ListAllTenants()
       {
            using (var context = new DataContext())
            {
                var allTenants = context.Tenants.ToList();

                Console.WriteLine("List of all tenants:");
                foreach (var tenant in allTenants)
                {
                    Console.WriteLine($"ID: {tenant.Id}");
                    Console.WriteLine($"First Name: {tenant.FirstName}");
                    Console.WriteLine($"Last Name: {tenant.LastName}");
                    Console.WriteLine($"Phone Number: {tenant.PhoneNr}");
                    Console.WriteLine($"Email: {tenant.Email}");
                    Console.WriteLine();
                }
            }
        }

            public void ListSpecificTenantByEmail()
            {
                Console.Write("Enter the email of the tenant you want to list: ");
                string emailToFind = Console.ReadLine();

                using (var context = new DataContext())
                {
                    var specificTenant = context.Tenants.FirstOrDefault(t => t.Email == emailToFind);

                    if (specificTenant != null)
                    {
                        Console.WriteLine("Tenant Information:");
                        Console.WriteLine($"ID: {specificTenant.Id}");
                        Console.WriteLine($"First Name: {specificTenant.FirstName}");
                        Console.WriteLine($"Last Name: {specificTenant.LastName}");
                        Console.WriteLine($"Phone Number: {specificTenant.PhoneNr}");
                        Console.WriteLine($"Email: {specificTenant.Email}");
                    }
                    else
                    {
                        Console.WriteLine("Tenant with the provided email not found.");
                    }
                }
        
        }

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

        public void DeleteTenantByEmail()
        {
            Console.Write("Enter the email of the tenant you want to delete: ");
            string emailToDelete = Console.ReadLine();

           using (var context = new DataContext())
            {
                var tenantToDelete = context.Tenants.FirstOrDefault(t => t.Email == emailToDelete);

                if (tenantToDelete != null)
                {
                    context.Tenants.Remove(tenantToDelete);
                    context.SaveChanges();
                    Console.WriteLine("Tenant deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Tenant with the provided email not found.");
                }
            }
      }


        public void UpdateTenantByEmail()
       {
            Console.Write("Enter the email of the tenant you want to update: ");
            string emailToUpdate = Console.ReadLine();

            using (var context = new DataContext())
            {
                var tenantToUpdate = context.Tenants.FirstOrDefault(t => t.Email == emailToUpdate);

                if (tenantToUpdate != null)
                 {
                    Console.WriteLine("Current Tenant Information:");
                    Console.WriteLine($"ID: {tenantToUpdate.Id}");
                    Console.WriteLine($"First Name: {tenantToUpdate.FirstName}");
                    Console.WriteLine($"Last Name: {tenantToUpdate.LastName}");
                    Console.WriteLine($"Phone Number: {tenantToUpdate.PhoneNr}");
                    Console.WriteLine($"Email: {tenantToUpdate.Email}");
                    Console.WriteLine();

                    Console.WriteLine("Enter the new information for the tenant (press Enter to skip a field):");

                    Console.Write("First Name: ");
                    string newFirstName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newFirstName))
                    {
                        tenantToUpdate.FirstName = newFirstName;
                    }

                    Console.Write("Last Name: ");
                    string newLastName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newLastName))
                    {
                        tenantToUpdate.LastName = newLastName;
                    }

                    Console.Write("Phone Number: ");
                    string newPhoneNr = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newPhoneNr))
                    {
                        tenantToUpdate.PhoneNr = newPhoneNr;
                    }

                    Console.Write("Email: ");
                    string newEmail = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newEmail))
                    {
                        tenantToUpdate.Email = newEmail;
                     }

                    context.SaveChanges();
                    Console.WriteLine("Tenant information updated successfully.");
                }
                else
                {
                    Console.WriteLine("Tenant with the provided email not found.");
                }
            }
        }

        public void CreateIssue()
         {
            var issue = new Issue();

            Console.Write("Tenant's First Name: ");
            issue.TenantFirstName = Console.ReadLine() ?? "";

            Console.Write("Tenant's Last Name: ");
            issue.TenantLastName = Console.ReadLine() ?? "";

            Console.Write("Tenant's Email: ");
            issue.TenantEmail = Console.ReadLine() ?? "";

            Console.Write("Tenant's Phone Number: ");
            issue.TenantPhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Description of the Issue: ");
            issue.Description = Console.ReadLine() ?? "";

            // Ange tidpunkten då ärendet skapades
            issue.CreatedAt = DateTime.Now;

            Console.Write("Status of the Issue (e.g., Open, Closed, In Progress): ");
            issue.Status = Console.ReadLine() ?? "";

            Console.Write("Add a comment (press Enter to skip): ");
            var commentText = Console.ReadLine();
            if (!string.IsNullOrEmpty(commentText))
            {
                issue.Comments = new List<Comment>
        {
            new Comment
           { 
                Text = commentText,
                CreatedAt = DateTime.Now
            }
       };
             }


            SaveIssueToDatabase(issue);

            Console.WriteLine("Issue created successfully.");
        }

        
        private void SaveIssueToDatabase(Issue issue)
        {
            using (var context = new DataContext())
            {
                context.Issue.Add(issue);

                // Lägg till kommentarer om det finns
                if (issue.Comments != null && issue.Comments.Any())
                {
                    context.Comment.AddRange(issue.Comments);
                }

                context.SaveChanges();
           
             }
       }


       // private void SaveIssueToDatabase(Issue issue)
        //{
           // throw new NotImplementedException();
        //}

        public void AddCommentToIssue(Issue issue, string commentText)
        {
            var comment = new Comment
            {
                Text = commentText,
                CreatedAt = DateTime.Now
            };

            issue.Comments.Add(comment);

            // Spara ändringar i databasen
            SaveIssueToDatabase(issue);
        }

        public void ListCommentsForIssue(Issue issue)
        {
            Console.WriteLine($"Comments for Issue #{issue.Id}:");
            foreach (var comment in issue.Comments)
            {
                Console.WriteLine($"- {comment.Text} (Created at: {comment.CreatedAt})");
            }
        }


        public void ViewIssue(Issue issue)
        {
            // Visa information om ärendet, inklusive dess befintliga kommentarer

            Console.WriteLine($"Issue ID: {issue.Id}");
            Console.WriteLine($"Tenant: {issue.TenantFirstName} {issue.TenantLastName}");
            Console.WriteLine($"Description: {issue.Description}");
            Console.WriteLine($"Created At: {issue.CreatedAt}");
            Console.WriteLine($"Status: {issue.Status}");
            Console.WriteLine("Comments:");
            foreach (var comment in issue.Comments)
            {
                Console.WriteLine($"- {comment.Text} (Created at: {comment.CreatedAt})");
            }

            // Ge användaren möjlighet att lägga till en kommentar
            Console.WriteLine("Add a Comment (or press Enter to skip): ");
            string commentText = Console.ReadLine();

            if (!string.IsNullOrEmpty(commentText))
            {
                // Anropa funktionen för att lägga till kommentaren
                AddCommentToIssue(issue, commentText);
            }
        }



        public void ListAllIssues()
        {
            using (var context = new DataContext())
            {
                var allIssues = context.Issue.Include(i => i.Comments).ToList();

                Console.WriteLine("List of all issues:");
                foreach (var issue in allIssues)
                {
                    Console.WriteLine($"Issue ID: {issue.Id}");
                    Console.WriteLine($"Tenant: {issue.TenantFirstName} {issue.TenantLastName}");
                    Console.WriteLine($"Description: {issue.Description}");
                    Console.WriteLine($"Created At: {issue.CreatedAt}");
                    Console.WriteLine($"Status: {issue.Status}");
                    Console.WriteLine("Comments:");
                    foreach (var comment in issue.Comments)
                    {
                        Console.WriteLine($"- {comment.Text} (Created at: {comment.CreatedAt})");
                    }
                  
                    Console.WriteLine();


                }
            }
         }


        public void ListSpecificIssue()
        {
            Console.Write("Enter the ID of the issue you want to view: ");
            if (int.TryParse(Console.ReadLine(), out int issueId))
            {
                using (var context = new DataContext())
                {
                    var specificIssue = context.Issue
                        .Include(i => i.Comments)
                        .FirstOrDefault(i => i.Id == issueId);

                    if (specificIssue != null)
                    {
                        Console.WriteLine($"Issue ID: {specificIssue.Id}");
                        Console.WriteLine($"Tenant: {specificIssue.TenantFirstName} {specificIssue.TenantLastName}");
                        Console.WriteLine($"Description: {specificIssue.Description}");
                        Console.WriteLine($"Created At: {specificIssue.CreatedAt}");
                        Console.WriteLine($"Status: {specificIssue.Status}");
                        Console.WriteLine("Comments:");
                        foreach (var comment in specificIssue.Comments)
                        {
                            Console.WriteLine($"- {comment.Text} (Created at: {comment.CreatedAt})");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Issue not found.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid issue ID.");
            }
        }



        public void ChangeIssueStatus()
        {
            Console.Write("Enter the ID of the issue you want to update: ");
            if (int.TryParse(Console.ReadLine(), out int issueId))
            {
                using (var context = new DataContext())
                {
                    var specificIssue = context.Issue.FirstOrDefault(i => i.Id == issueId);

                    if (specificIssue != null)
                    {
                        Console.WriteLine($"Current Status: {specificIssue.Status}");
                        Console.Write("Enter the new status: ");
                        string newStatus = Console.ReadLine();
                        specificIssue.Status = newStatus;
                        context.SaveChanges();
                        Console.WriteLine("Issue status updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Issue not found.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid issue ID.");
            }
        }


    }
}
