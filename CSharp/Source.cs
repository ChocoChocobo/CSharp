using System;
using System.Diagnostics;
using System.Numerics;

class Source
{    
    static void Main(string[] args)
    {
        // Инициализация объекта очереди
        // Queue<string> stringsQueue = new Queue<string>(); 
        // Stack<int> intsStack = new Stack<int>();
        // Аналогичным образом со списком эти коллекции инициализируются значениями.
        /*Queue<string> stringsQueue = new Queue<string>(new[] { "Давид", "Лев", "Рия", "Тимур", "Филипп", "Расул", "Андрей", "Тимур Тимурович" });
        // Функция Enqueue добавляет элемент в конец очереди.
        stringsQueue.Enqueue("Родин");
        // Функция Dequeue высвобождает элемент из очереди
        stringsQueue.Dequeue();
        // Функция, принимающая параметр вместимости и убеждающаяся, что текущая вместимость очереди меньше указанной. Если больше, то увеличивает вместимость вдвое.
        Console.WriteLine(stringsQueue.Count);
        Console.WriteLine(stringsQueue.EnsureCapacity(7));
        foreach (string item in stringsQueue)
        {
            Console.WriteLine(item);
        }*/

        /*Stack<string> stringsStack = new Stack<string>(new[] { "Давид", "Лев", "Рия", "Тимур", "Филипп", "Расул", "Андрей", "Тимур Тимурович" });
        stringsStack.Push("Родин"); // Функция, добавляющая элемент на верхушку стека
        string poppedItem = stringsStack.Pop(); // Функция, убирающая и возврающая элемент стека с верхушки
        string? tryPoppedItem = "";
        
        if (stringsStack.TryPop(out tryPoppedItem)) Console.WriteLine($"Элемент успешно изъятирован: {tryPoppedItem}");
        else Console.WriteLine("Провал!");

        Console.WriteLine($"Снятый элемент с верхушки стека: {poppedItem}");
        foreach (string item in stringsStack)
        {
            Console.WriteLine(item);
        }*/

        // Класс Dictionary представляет собой словарь, в котором имеется два шаблонных параметра: TKey - ключ и TValue - значение. Ключи уникальны, так что при вставке новой пары с ранее не существовавшим ключом появится новая пара. При вставке пары с ранее существовавшим ключом, у пары обновится значение.
        // Одна пара в словаре определяется объектом класса KeyValuePair по аналогии с тем, как это работает в связном списке. У данного объекта имеются свойства Key и Value
        Dictionary<string, uint> studentsDictionary = new Dictionary<string, uint>();
        // С помощью функции Add можно вставить элемент, передав ключ, а затем значение
        studentsDictionary.Add("Давид", 2);
        studentsDictionary.Add("Рия", 5);
        studentsDictionary.Add("Лев", 2);
        studentsDictionary.Add("Тимур", 16);
        studentsDictionary.Add("Филипп", 21);
        studentsDictionary.Add("Расул", 7);
        studentsDictionary.Add("Андрей", 0);
        studentsDictionary.Add("Тимур Тимурович", 67);
        // Альтернативно можно добавлять элементы с помощью оператора квадратных скобок, указывая ключ, а через присваивание - значение
        studentsDictionary["Родин"] = 666;

        foreach (KeyValuePair<string, uint> item in studentsDictionary)
        {
            Console.WriteLine($"Студент {item.Key} с оценкой {item.Value}");
        }
    }
}

//      Очереди, стеки и словари
