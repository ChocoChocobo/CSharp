using System;
using System.Diagnostics;
using System.Numerics;

struct Point // У функций и конструкторов необходимо в качестве модификатора доступа указывать public, если поле доступно вне объекта класса
{
    public float x, y;

    public Point(float x, float y)
    {
        this.x = x; 
        this.y = y;
    }

    public void Draw()
    {
        Console.WriteLine($"Всем привет! Я точка ({x},{y}).");
    }
}

class Source
{    
    static void Main(string[] args)
    {
        Point point = new Point(5.0f, 6.0f);
        point.Draw();
        Point point1 = point;
        point1.Draw();
    }
}

//      Практика
// Придумать и описать объект в виде структуры. Учесть особенности того для чего используется структура!
// Предусмотреть минимум две переменные и одну функцию, которая бы выводила информацию в консоль.
// В Main() создать объект структуры и вызвать функцию.