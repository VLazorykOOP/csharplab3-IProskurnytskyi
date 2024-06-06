// dotnet run --property:DefineConstants="RUN_PERSON"
using System;
using System.Collections.Generic;

class Person
{
    protected string name;
    protected int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public virtual void Show()
    {
        Console.WriteLine($"Name: {this.name}, Age: {this.age}");
    }
}

class Student : Person
{
    protected string university;

    public Student(string name, int age, string university) : base(name, age)
    {
        this.university = university;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"University: {this.university}");
    }
}

class Teacher : Person
{
    protected string department;

    public Teacher(string name, int age, string department) : base(name, age)
    {
        this.department = department;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Department: {this.department}");
    }
}

class DepartmentHead : Teacher
{
    protected int number;

    public DepartmentHead(string name, int age, string department, int number) : base(name, age, department)
    {
      this.number = number;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Years of experience: {this.number}");
    }
}

class Program2
{
#if RUN_PERSON
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        people.Add(new Student("Bob", 20, "Harvard"));
        people.Add(new Teacher("Alice", 35, "Mathematics"));
        people.Add(new DepartmentHead("John", 45, "Computer Science", 20));

        people.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));

        foreach (Person person in people)
        {
            person.Show();
            Console.WriteLine();
        }
    }
#endif
}
