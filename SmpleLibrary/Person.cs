namespace SmpleLibrary;

public enum PersonMaritalStatus
{
    Married,
    Single
}

public class Person
{
    private string Name;
    private string LastName;
    private int Age;
    PersonMaritalStatus MaritalStatus;

    public Person(string name, string lastName, int age)
    {
        Name=name;
        LastName=lastName;
        Age=age;
        MaritalStatus=PersonMaritalStatus.Single;
    }

    public void Print()
    {
        Console.WriteLine($"Person:\nName: {Name}\nLastName: {LastName}\nAge: {Age}");
    }
}

public class Employee : Person
{
    private string Position;
    private decimal Salary;

    public Employee(string name, string lastName, int age, string position, decimal salary) : base(name, lastName, age)
    {
        Position=position;
        Salary=salary;
    }
}
