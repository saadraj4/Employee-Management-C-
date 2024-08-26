using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

public class MongoDBService
{
    private readonly IMongoCollection<Employee> _employees;

    public MongoDBService()
    {
        var client = new MongoClient("mongodb://localhost:27017"); // Your MongoDB connection string
        var database = client.GetDatabase("EmployeeDB");
        _employees = database.GetCollection<Employee>("Employees");
    }

    public List<Employee> GetEmployees() => _employees.Find(emp => true).ToList();

    public Employee GetEmployeeById(string id) => _employees.Find(emp => emp.Id == id).FirstOrDefault();

    public void CreateEmployee(Employee employee) => _employees.InsertOne(employee);

    public void UpdateEmployee(string id, Employee employeeIn) => _employees.ReplaceOne(emp => emp.Id == id, employeeIn);

    public void DeleteEmployee(string id) => _employees.DeleteOne(emp => emp.Id == id);
}
