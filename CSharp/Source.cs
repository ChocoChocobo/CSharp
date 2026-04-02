using System;
using System.Diagnostics;

class Animal
{
	public int paws = 4;
	public string name = "Животный";

	public Animal(int paws, string name)
	{
		this.paws = paws;
		this.name = name;
	}

	public void Drink() => Console.WriteLine($"{name} пъёт!");
}

// Синтаксис:
// class имя_наследника : имя_базового_класса
class Cat : Animal
{
	public int extraLives = 8;

	// Инициализация родительского класса
	public Cat(int extraLives, int paws, string name) : base(paws, name)
	{
		this.extraLives = extraLives;
	}

	public void Fall(int amount)
	{
        Console.WriteLine($"{name} упало на {amount} урона :(");
		extraLives -= amount;
    }
}

class Racoon : Animal
{
	public float garbageCollected = 0;

	public Racoon(float garbageCollected, int paws) : base(paws, "ик Полоскун")
	{
		this.garbageCollected = garbageCollected;
	}

	public void CollectGarbage(float garbageCollected)
	{
		Console.WriteLine($"Енот{name} собрал {garbageCollected} кг мусора.");
		this.garbageCollected += garbageCollected;
	}
}

class Source
{
	static void Main(string[] args)
	{
		Cat cat = new Cat(8, 4, "Шарик");
		Racoon racoon = new Racoon(0, 4);

		cat.Drink();
		cat.Fall(1);

		racoon.Drink();
		racoon.CollectGarbage(1);

		// Преобразование производного класса к базовому
		Animal animal = cat;
		animal.Drink();

		// Операторы as и is являются операторами явного преобразования одного объекта класса в другой
		Animal animal1 = racoon as Animal;
		// Оператор is применяется для проверки на сущность объекта и используется в качестве условия
		// Вернется true если объект имеет значения со сравниваемым типом данных и наоборот вернется false
		if (racoon is Animal)
		{
			racoon.CollectGarbage(5);
		}
	}
}

//		Практика
// 1. Создать базовый класс типа музыкального инструмента, содержащий конструктор и 3 различных поля с разными типами данных, имеющие свойства get, set. Предусмотреть функцию взаимодействия с инструментом, которая бы подходила любому типу инструмента.
// 2. Создать два производных класса от типа музыкального инструмента, содержащие 2 различных поля с разными типами данных, имеющие свойства get, set. Предусмотреть уникальную функцию для взаимодействия с данным типом инструмента. В конструкторе инициализировать базовый класс через base.
// 3. Продемонстрировать функционал объектов и проверять, если созданный объект является, например, гитарой, выводить в сообщение в консоль.