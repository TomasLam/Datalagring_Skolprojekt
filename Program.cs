
using Databasen1.Context;
using Databasen1.Services;


var context = new DataContext();

var menu = new MenuService();


while (true)
{
    Console.Clear();
    Console.WriteLine("---- Guest management ----");
    Console.WriteLine("1. Create new tenant");
    Console.WriteLine("2. List all tenants");
    Console.WriteLine("3. List a specific tenant");
    Console.WriteLine("4. Update tenant");
    Console.WriteLine("5. Delete tenant");
    Console.WriteLine("6. Exit");
    Console.WriteLine("7. Create an issue");
    Console.WriteLine("8. See all issues");
    Console.WriteLine("9. See specific issue");
    Console.WriteLine("10. Change status");
    Console.Write("Pick one of the following: ");


    switch (Console.ReadLine())
    {
        case "1":
            menu.CreateNewTenant();
            break;
        case "2":
            menu.ListAllTenants();
            break;
        case "3":
            menu.ListSpecificTenantByEmail();
            break;
        case "4":
            menu.UpdateTenantByEmail(); 
            break;
        case "5":
            menu.DeleteTenantByEmail();
            break;
        case "6":
            Console.WriteLine("Program closing.");
            return;
        case "7":
            menu.CreateIssue();   
            break;
        case "8":
            menu.ListAllIssues();
            break;
        case "9":
            menu.ListSpecificIssue();
            break;
        case "10":
            menu.ChangeIssueStatus();
            break;
        default:
            Console.WriteLine("Invalid choice, pick again.");
            break;
    }

    Console.WriteLine("\nPress a button to return");
    Console.ReadLine();
}