using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

public class MongoDBService
{
    private readonly IMongoCollection<Student> _students;

    public MongoDBService()
    {
        var client = new MongoClient("mongodb://localhost:27017"); // Your MongoDB connection string
        var database = client.GetDatabase("StudentDB");
        _students = database.GetCollection<Student>("Students");
    }

    public List<Student> GetStudents() => _students.Find(emp => true).ToList();

    public Student GetEmployeeById(string id) => _students.Find(student => student.Id == id).FirstOrDefault();

    public void CreateStudent(Student student) => _students.InsertOne(student);

    public void UpdateStudent(string id, Student studentIn) => _students.ReplaceOne(student => student.Id == id, studentIn);

    public void DeleteStudent(string id) => _students.DeleteOne(student => student.Id == id);
}
