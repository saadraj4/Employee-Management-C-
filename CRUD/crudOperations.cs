using System;
public class crudOperations
{
    public static void CreateStudent(MongoDBService mongoService)
    {
        var student = new Student();

        Console.Write("Enter Student ID: ");
        student.StudentId = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Name: ");
        student.Name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Department: ");
        student.Department = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Email: ");
        student.Email = Console.ReadLine() ?? string.Empty;

        student.DateOfJoining = DateTime.Now;

        student.IsActive = true;

        mongoService.CreateStudent(student);
        Console.WriteLine("Student created successfully.");
    }
    public static void ViewAllStudents(MongoDBService mongoService)
    {
        var Students = mongoService.GetStudents();

        if (Students.Count > 0)
        {
            foreach (var emp in Students)
            {
                Console.WriteLine($"\nID: {emp.StudentId}\nName: {emp.Name}\nDepartment: {emp.Department}\nEmail: {emp.Email}\nDate of Joining: {emp.DateOfJoining}\nStatus: {(emp.IsActive ? "Active" : "Inactive")}\n");
            }
        }
        else
        {
            Console.WriteLine("No Students found.");
        }
    }

    public static void UpdateStudent(MongoDBService mongoService)
    {
        Console.Write("Enter Student ID to update: ");
        string? StudentId = Console.ReadLine();

        var student = mongoService.GetStudents().Find(emp => emp.StudentId == StudentId);

        if (student != null && student.Id != null)
        {
            Console.Write("Enter New Name (leave blank to keep current): ");
            string? newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName)) student.Name = newName;


            Console.Write("Enter New Department (leave blank to keep current): ");
            string? newDepartment = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDepartment)) student.Department = newDepartment;

            Console.Write("Enter New Email (leave blank to keep current): ");
            string? newEmail = Console.ReadLine();
            if (!string.IsNullOrEmpty(newEmail)) student.Email = newEmail;

            mongoService.UpdateStudent(student.Id, student);
            Console.WriteLine("Student updated successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public static void DeleteStudent(MongoDBService mongoService)
    {
        Console.Write("Enter Student ID to delete: ");
        string? StudentId = Console.ReadLine();

        var student = mongoService.GetStudents().Find(emp => emp.StudentId == StudentId);

        if (student != null && student.Id != null)
        {
            mongoService.DeleteStudent(student.Id);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}