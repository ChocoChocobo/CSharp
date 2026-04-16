using System;
using System.Diagnostics;
using System.Numerics;

// Встроенный интерфейс INumber представляет собой реализацию числа
// Обощенный класс вектора
class Vector2D<T> where T : INumber<T>
{
    T x;
    T y;

    public Vector2D(T x, T y)
    {
        this.x = x;
        this.y = y;
    }

    public T X
    {
        get { return x; }
        set { x = value; }
    }

    public T Y
    {
        get { return y; }
        set {  y = value; }
    }

    // Переопределение функции вывода в поток
    public override string ToString()
    {
        return $"({x},{y})";
    }
}

class Source
{    
    static void Main(string[] args)
    {
        Vector2D<int> intVector = new Vector2D<int>(5, 5);
        Console.WriteLine(intVector); // При выводе объекта класса будет вызываться переопределяемый метод ToString()
    }
}

//      Практика
// 1. Создать объекты класса Vector2D с типами данных float, bool, uint
// 2. Создать класс Vector3D наподобие Vector2D, определив для его полей нужные свойства
// 3. 