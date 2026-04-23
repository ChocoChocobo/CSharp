using System;
using System.Diagnostics;
using System.Numerics;

// Класс-ячейка коллекции
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public uint Score { get; set; }

    public Student(int id, string name, uint score)
    {
        Id = id;
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
        // Вариант инициализации коллекции с пользовательским типом данных
        List<Student> students = new List<Student>
        {
            new Student(1, "Андрей", 10),
            new Student(2, "Давид", 1),
            new Student(3, "Рия", 5),
        };
        // В переменную помещаем выборочные значения из коллекции в соответствии с условием
        //            временный объект              обращение к полю
        var names = from student in students select student.Name;
        foreach (string item in names)
        {
            Console.WriteLine(item);
        }

        var studentPerformances = from student in students select new StudentPerformance(student.Name, student.Score);
        foreach (var item in studentPerformances)
        {
            Console.WriteLine($"Студент {item.Name} с оценкой {item.Score}");
        }
    }
}

//      Практика
// 1. Создать элементарный класс животого, у которого есть поля имени, цвета, кол-ва ног
// 2. Создать класс-агрегатор, у которого есть поля имени и кол-ва ног
// 3. В Main создать список животных в количестве 5 объектов и с помощью LINQ-выражения в объект животных выбрать объекты класса-агрегатора
// 4. Создать две очереди четырехногих и двуногих животных. При перечислении в цикле foreach всех объектов класса-агрегатора, сравнивать с полем кол-ва ног и помещать животных в очереди.
