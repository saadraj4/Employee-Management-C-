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
            Console.WriteLine("\nStudents Management System");
            Console.WriteLine("1. Create Students");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Update Students");
            Console.WriteLine("4. Delete Students");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    crudOperations.CreateStudent(mongoService);
                    break;
                case "2":
                    crudOperations.ViewAllStudents(mongoService);
                    break;
                case "3":
                    crudOperations.UpdateStudent(mongoService);
                    break;
                case "4":
                    crudOperations.DeleteStudent(mongoService);
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
