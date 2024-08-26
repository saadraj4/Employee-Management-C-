using System;

class Program
{
    static void Main(string[] args)
    {
        var mongoService = new MongoDBService();
        var crudOperations = new crudOperations();
        bool continueRunning = true;

        while (continueRunning)
        {
            Console.WriteLine("\nEmployee Management System");
            Console.WriteLine("1. Create Employee");
            Console.WriteLine("2. View All Employees");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    crudOperations.CreateEmployee(mongoService);
                    break;
                case "2":
                    crudOperations.ViewAllEmployees(mongoService);
                    break;
                case "3":
                    crudOperations.UpdateEmployee(mongoService);
                    break;
                case "4":
                    crudOperations.DeleteEmployee(mongoService);
                    break;
                case "5":
                    continueRunning = false;
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    
}
