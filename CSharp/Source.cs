using System;
using System.Diagnostics;
using System.Numerics;

class Source
{    
    static void Main(string[] args)
    {
        // 1. Инициализация пустого списка 
        List<int> intList = new List<int>();
        // 2. Инциализация списка с 5 объектами
        List<int> intList1 = new List<int>(5);
        // 3. Инициализация списка без фиксированного количества элементов
        List<int> intList2 = new List<int>() { 1, 2, 3, 4, 5};
        // 4. Инициализация списка операцией копирования другого списка
        List<int> intList3 = new List<int>(intList2);

        List<string> fruits = new List<string>();
        fruits.Add("винорез"); // добавление элемента в конец списка
        fruits.AddRange(new[] { "огуград", "редиска" }); // добавление диапазона значений
        fruits.Insert(2, "ромовин"); // вставка значения по индексу
        fruits.InsertRange(1, new[] { "аксидер", "даргуго" }); // вставка диапазона значений по индексу
        
        //Console.WriteLine(fruits.Contains("редиска")); // проверяет наличие содержимого
        //Console.WriteLine(fruits.Exists(fruit => fruit[0] == 'з')); // проверка наличия подходящего элемента по заданному условию. Применяем лямбду для быстрой и удобной записи функции по сравнению нулеового значения по индексу у фрукта
        //Console.WriteLine(fruits.Find(fruit => fruit[0] == 'р')); // поиск первого элемента по условию и возвращение его
        List<string> fruits_all = fruits.FindAll(fruit => fruit[0] == 'р'); // возвращение набора элементов которые удовлетворяют заданному условию
        
        /*foreach (string fruit in fruits_all)
        {
            Console.WriteLine(fruit);
        }*/

        // LinkedList
        // Инициализация связного списка значениями из списка List
        LinkedList<string> linkedFruits = new LinkedList<string>(fruits);
        // В отдельный объект заносим первый узел, для последующего перебора и вывода остальных узлов
        LinkedListNode<string>? currentNode = linkedFruits.First;
        Console.WriteLine("------------");
        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Value);
            currentNode = currentNode.Next;
        }
        Console.WriteLine("------------");
        foreach (string fruit in fruits_all)
        {
            Console.WriteLine(fruit);
        }
        fruits.Clear();
        Console.WriteLine("------------");
        currentNode = linkedFruits.First;
        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Value);
            currentNode = currentNode.Next;
        }        
    }
}

//      Коллекции
// В языке C# имеются готовые реализации абстрактных структур данных.
// Список (List) - аналог контейнера (массива) из языка С++. Такая готовая структура данных позволяет пользоваться удобными функциями по добавлению, удалению, сортировке, обращению по индексу и так далее.
// Связный список (LinkedList) - двусвязный линейный список. Такой список состоит из узлов, то есть объектов класса LinkedListNode<T>. У этого класса есть свойства:
// - Next - возвращает ссылку на следующий узел. Если следующего узла нет, то возвращает null
// - Previous - возвращает ссылку на предыдущий узел. Если предыдущего узла нет, то возвращает null
// - Value - возвращает или устанавливает значение, хранящееся в узле