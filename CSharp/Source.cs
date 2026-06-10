using System.Reflection; // пространство имен, содержащее отражение

// ќбычный класс, наследующийс€ от јтрибута, в котором определено все взаимодействие
// ћожно выставить ограничени€ на применение атрибута:
[AttributeUsage(AttributeTargets.Class)]
class AgeValidationAttribute : Attribute
{
    public float Age { get; }
    public AgeValidationAttribute() { }
    public AgeValidationAttribute(float value) => Age = value;
}

// ѕрименение атрибута
//[AgeValidationAttribute]
[AgeValidationAttribute(18.0f)]
class Student
{
    public string Name { get; set; } = "John";
    public float Age { get; set; } = 18.0f;
    public int Score { get; set; } = 2;
    public bool IsAlabuga { get; set; } = false;
    public Student(string name, float age, int score, bool isAlabuga)
    {
        Name = name;
        Age = age;
        Score = score;
        IsAlabuga = isAlabuga;
    }
}

class Source
{
    static void Main(string[] args)
    {
        //      “ема: атрибуты
        // јтрибуты представл€ют собой способ эффективного св€зывани€...
        Student student1 = new Student("David", 18, 1, true);
        Student student2 = new Student("Alex", 17, 5, false);
        Student student3 = new Student("Timur", 17, 3, false);
        List<Student> students = new List<Student>();
        students.Add(student1);
        students.Add(student2);
        students.Add(student3);

        foreach (var student in students)
        {
            Console.WriteLine($"—овершеннолетний ли {student.Name}? - {ValidateAge(student)}");
        }
    }

    static bool ValidateAge(Student student)
    {
        // ќтражение представл€ет собой класс Type
        //Type personType = student.GetType();
        Type personType = typeof(Student);
        // ѕолучаем все атрибуты класса Student
        object[] personAttributes = personType.GetCustomAttributes(false);
        foreach (var attribute in personAttributes)
        {
            if (attribute is AgeValidationAttribute ageValidationAttribute)
            {
                return student.Age >= ageValidationAttribute.Age;
            }
        }
        return true;
    }
}

//      ѕрактика
// 1. Ќаписать программу, включающую в себ€ систему атрибутов и проверку характеристик игрового персонажа с помощью отражени€. Ќужно написать свой класс персонажа, пометить его свойства атрибутами и написать валидатор (наподобие с тем, как делали ValidateAge), который провер€ет корректность параметров перед импровизированном началом игры. ” персонажа переопределить функцию вывода ToString дл€ тестов.
// 2. јтрибуты: имени, здоровь€, уровн€, маны, класса, расы.
// 3. ѕараметры должны иметь ограничени€, например, здоровье не может быть отрицательным, уровень должен быть в заданном диапазоне, им€ не должно быть пустым
// 4. ¬ Main продемонстрировать создание корректного персонажа с атрибутами и некорректного. ¬џвести перссонажей в консоль с помощью Console.WriteLine.