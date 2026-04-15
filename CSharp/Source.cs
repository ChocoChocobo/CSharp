using System;
using System.Diagnostics;

// Абстрактный класс животного, определяющий функционал только для классов одной природы, то есть животных!
abstract class Animal
{
    public abstract void Move();
    public abstract void Eat();
}

// Интерфейс, определяющий функционал для движимых объектов.
// ОНИ МОГУТ БЫТЬ РАЗНОЙ ПРИРОДЫ!
public interface IMovable 
{
    public void Move();
    public void CollisionDetect() // пример-функция столкновения
    {
        Console.WriteLine("Объект столкнулся с другим объектом.");
    }
}

class ComputerMouse : IMovable
{
    public void Move() => Console.WriteLine("Мышь движется");
}

class Racoon : Animal
{
    public override void Eat() => Console.WriteLine("Енотик ест");
    public override void Move() => Console.WriteLine("Енотик ходит");
}

class Source
{    
    static void Main(string[] args)
    {
        Racoon racoon = new Racoon();
        racoon.Move();
        racoon.Eat();

        ComputerMouse computerMouse = new ComputerMouse();
        computerMouse.Move();
    }
}

//      Практика
// 1. Дополнить программу новым интерфейсом функционала клички. В интерфейсе должны быть поле имени с определенными get и set свойствами и функция, которая бы в консоль выводила кличку животного в консоли.
// 2. В Main создать массив зоопарка, который должен хранить в себе объекты интерфейсов.
// 3. Дополнить классы животных функцией Pet(), которая выводит в консоль о том, что пользователь гладит животное + имя
// 4. Просить пользователя ввести имя животного, которое он хочет погладить.
// 5. В цикле перебирать каждое животное и сравнивать его имя со вводом пользователя. Если есть совпадение, то вызывать функцию Pet() от перечисляемого объекта.