using System;
public class crudOperations
{
    public static void CreateEmployee(MongoDBService mongoService)
    {
        var employee = new Employee();

        Console.Write("Enter Employee ID: ");
        employee.EmployeeId = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Name: ");
        employee.Name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Position: ");
        employee.Position = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Department: ");
        employee.Department = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Email: ");
        employee.Email = Console.ReadLine() ?? string.Empty;

        employee.DateOfJoining = DateTime.Now;

        Console.Write("Enter Salary: ");
        string salaryInput = Console.ReadLine()?? string.Empty;

        if (double.TryParse(salaryInput, out double salary))
        {
            employee.Salary = salary;
        }
        else
        {
            Console.WriteLine("Invalid salary input. Setting salary to 0.");
            employee.Salary = 0;
        }

        employee.IsActive = true;

        mongoService.CreateEmployee(employee);
        Console.WriteLine("Employee created successfully.");
    }
    public static void ViewAllEmployees(MongoDBService mongoService)
    {
        var employees = mongoService.GetEmployees();

        if (employees.Count > 0)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"\nID: {emp.EmployeeId}\nName: {emp.Name}\nPosition: {emp.Position}\nDepartment: {emp.Department}\nEmail: {emp.Email}\nDate of Joining: {emp.DateOfJoining}\nSalary: {emp.Salary}\nStatus: {(emp.IsActive ? "Active" : "Inactive")}\n");
            }
        }
        else
        {
            Console.WriteLine("No employees found.");
        }
    }

    public static void UpdateEmployee(MongoDBService mongoService)
    {
        Console.Write("Enter Employee ID to update: ");
        string? employeeId = Console.ReadLine();

        var employee = mongoService.GetEmployees().Find(emp => emp.EmployeeId == employeeId);

        if (employee != null && employee.Id != null)
        {
            Console.Write("Enter New Name (leave blank to keep current): ");
            string? newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName)) employee.Name = newName;

            Console.Write("Enter New Position (leave blank to keep current): ");
            string? newPosition = Console.ReadLine();
            if (!string.IsNullOrEmpty(newPosition)) employee.Position = newPosition;

            Console.Write("Enter New Department (leave blank to keep current): ");
            string? newDepartment = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDepartment)) employee.Department = newDepartment;

            Console.Write("Enter New Email (leave blank to keep current): ");
            string? newEmail = Console.ReadLine();
            if (!string.IsNullOrEmpty(newEmail)) employee.Email = newEmail;

            Console.Write("Enter New Salary (leave blank to keep current): ");
            string? salaryInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(salaryInput)) employee.Salary = Convert.ToDouble(salaryInput);

            mongoService.UpdateEmployee(employee.Id, employee);
            Console.WriteLine("Employee updated successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    public static void DeleteEmployee(MongoDBService mongoService)
    {
        Console.Write("Enter Employee ID to delete: ");
        string? employeeId = Console.ReadLine();

        var employee = mongoService.GetEmployees().Find(emp => emp.EmployeeId == employeeId);

        if (employee != null && employee.Id != null)
        {
            mongoService.DeleteEmployee(employee.Id);
            Console.WriteLine("Employee deleted successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }
}