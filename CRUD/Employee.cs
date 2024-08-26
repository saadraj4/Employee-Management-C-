using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Employee
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? EmployeeId { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public string? Department { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfJoining { get; set; }
    public double Salary { get; set; }
    public bool IsActive { get; set; }
}
