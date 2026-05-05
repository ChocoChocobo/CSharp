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
            new Student(1, colleges[0].Id, "Андрей", 10),
            new Student(2, colleges[1].Id, "Давид", 1),
            new Student(3, colleges[0].Id, "Рия", 5),
            new Student(4, colleges[0].Id, "Лев", 5),
            new Student(5, colleges[3].Id, "Платон", 5),
            new Student(6, colleges[1].Id, "Алексей", 5),
            new Student(7, colleges[0].Id, "Филипп", 5),
            new Student(8, colleges[3].Id, "Родин", 5),
            new Student(9, colleges[3].Id, "Расул", 120000),
        };

        // В объект поместили перечисляемый элемент принимающий интерфейс IGrouping
        var collegeStudents = from student in students group student by student.CollegeId;

        // При группировке можно сделать выборку в коллекцию объектов класса
        /*var collegeCount = from student in students // берем студента из коллекции студентов
                           group student by student.CollegeId into // группируем их по id
                           collegeGroup select new 
                           { 
                               id = collegeGroup.Key, 
                               student = from stud in collegeGroup select stud 
                           };*/ // создание поля, куда заносятся все студенты
        var collegeCount = from student in students // берем студента из коллекции студентов
                           // для того, чтобы соединить коллекции, необходимо их связать
                           join collegeJoin in colleges // выборка для соединения
                           on student.CollegeId equals collegeJoin.Id // условие соединения
                           select new
                           {
                               studentName = student.Name,
                               studentScore = student.Score,
                               collegeName = collegeJoin.Name,
                           };

        foreach (var item in collegeCount)
        {
            Console.WriteLine($"Имя колледжа: {item.collegeName}, в нем учится {item.studentName}, и его оценка {item.studentScore}");
        }
    }
}

//      Группировка и соединение LINQ
// Для группировки используется оператор group by:
// from объект in название_коллекции group объект by поле_объекта_или_свойство
// При использовании формируется следующий ассоциативный ряд IGrouping<Key, Value>
// Key - отвечает за значение поля или свойства, по которому производилась группировка, а Value - коллекция объектов из коллекции, у которых заданное свойство имеет значение.
// Для соединения нескольких коллекций применяется оператор join:
// from объект in коллекция join объект2 in коллекция

//      Практика
// 1. Создать новый класс военкомата с публичными полями имени и id, для них определить свойства.
// 2. У класса студента добавить новое поле с id военкомата. Отредактировать конструктор.
// 3. Затем с помощью join объединять коллекции студентов и военкоматов и связывать их id. На основе них делать выборку из имени студента, его оценки и имени военкомата.