using System;
using System.Diagnostics;
using System.Numerics;

// Класс учебного заведения для студента
class College
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public College(int id, string? name)
    {
        Id = id;
        Name = name;
    }
}

// Класс-ячейка коллекции
class Student
{
    public int Id { get; set; }
    public int CollegeId { get; set; }
    public string Name { get; set; }
    public uint Score { get; set; }

    public Student(int id, int collegeId, string name, uint score)
    {
        Id = id;
        CollegeId = collegeId;
        Name = name;
        Score = score;
    }
}

// Класс-агрегатор, который бы описывал объект, агрегирующий информацию из класса ячейки
class StudentPerformance
{
    public string Name { get; set; }
    public uint Score { get; set; }

    public StudentPerformance(string name, uint score)
    {
        Name = name;
        Score = score;
    }
}

class Source
{    
    static void Main(string[] args)
    {
        List<College> colleges = new List<College>
        {
            new College(0, "IT TOP"),
            new College(1, "VOLSU"),
            new College(2, "VSPU"),
            new College(3, "ALABUGA"),
        };

        List<Student> students = new List<Student>
        {
            new Student(1, 0, "Андрей", 10),
            new Student(2, 2, "Давид", 1),
            new Student(3, 1, "Рия", 5),
            new Student(4, 3, "Расул", 120000),
        };

        // В объект поместили перечисляемый элемент принимающий интерфейс IGrouping
        var collegeStudents = from student in students group student by student.CollegeId;        

        // При группировке можно сделать выборку в коллекцию объектов класса
        var collegeCount = from student in students // берем студента из коллекции студентов
                           group student by student.CollegeId into // группируем их по id
                           collegeGroup select new { id = collegeGroup.Key, count = collegeGroup.Count() }; // 

        foreach (var item in collegeCount)
        {
            Console.WriteLine(item);
            Console.WriteLine($"id колледжа: {item.id}, количество: {item.count}");
        }
    }
}

//      Группировка и соединение LINQ
// Для группировки используется оператор group by:
// from объект in название_коллекции group объект by поле_объекта_или_свойство
// При использовании формируется следующий ассоциативный ряд IGrouping<Key, Value>
// Key - отвечает за значение поля или свойства, по которому производилась группировка, а Value - коллекция объектов из коллекции, у которых заданное свойство имеет значение.

//      Практика github.com/ChocoChocobo
// 1. Расширить существующий студентов на 10 элементов
// 2. С помощью LINQ-запроса делать группировку объектов студентов по оценкам и сделать выборку в коллекцию объектов, которая должна содержать имя и оценку.