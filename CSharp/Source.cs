using System;
using System.Diagnostics;
using System.Numerics;

// Интерфейс, определяющий поля пиццы
public interface IPizza
{
    string Name { get; }
    string Topping { get; }
    double Price { get; }
    bool IsEatable { get; }
    bool IsNull { get; }
}

// Конкретный класс пиццы
public class AnanasPizza : IPizza
{
    public string? Name { get; set; }
    public string? Topping { get; set; }
    public double Price { get; set; }
    public bool IsEatable { get; set; }

    // Поле определяющее нулевой ли объект
    public bool IsNull => false;

    public AnanasPizza(string name, string topping, double price, bool isEatable) 
    {
        Name = name;
        Topping = topping;
        Price = price;
        IsEatable = isEatable;
    }    
}

// "Нулевой" класс пиццы, обозначающий поведение по умолчанию
public class NullAnanasPizza : IPizza
{
    // Задаем нулевому объекту класса значения по умолчанию
    public string Name => "Я пицца";
    public string Topping => "Без начинки";
    public double Price => 0.0;
    public bool IsEatable => false;

    // Поле определяющее нулевой ли объект
    public bool IsNull => true;
    
}

public class Order
{
    public string Name { get; set; }
    public IPizza Pizza { get; set; }

    public Order(string name, IPizza? pizza) 
    {
        Name = name;

        // Поле пиццы у заказа инициализурется либо задаваемой пиццей, если не ноль, либо создается объект нулевой   
        Pizza = pizza ?? new NullAnanasPizza();
    }
}

class Source
{    
    static void Main(string[] args)
    {
        Order order = new Order("Заказ 0", null);
        Console.WriteLine(order.Pizza.Name);

        Order order1 = new Order("Заказ 1", new AnanasPizza("Давид", "В ананасе", 1.0, false));
        Console.WriteLine(order1.Pizza.Name);
    }    
}

//      Практика
// Продемонстрировать введение нулевого объекта на примере наследования от абстрактного класса:
// 1. Создать абстрактный класс пиццы с полями названия, стоимости и начинки;
// 2. Создать наследуемый конкретный класс пиццы;
// 3. Создать класс заказа и продемонстрировать работу с оператором ?? при инициализации поля заказа;
// 4. В Main создать пару объектов с нулем и с настоящим объектом.