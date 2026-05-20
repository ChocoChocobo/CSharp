using System;
using System.Diagnostics;
using System.Numerics;

class Source
{    
    static void Main(string[] args)
    {
        //      ТЕМА: ПАРАЛЛЕЛЬНОЕ И АСИНХРОННОЕ ПРОГРАММИРОВАНИЕ В C#
        // Параллельное программирование - это выполнение двух или нескольких процессов одновременно. Асинхронное - это выполнение нескольких процессов параллельно друг другу, когда один или оба могут заниматься совершенно разными задачами.
        // В языке C# основым средством для параллельного выполнения нескольких задач является библиотека TPL (Task Parallel Library).
        // Объект класса Task принимает в качестве параметра блок кода (функцию). Для несложного кода можно использовать лямбда-выражение.

        // Первый способ создания задачи
        // Task task1 = new Task(PrintInfo);
        // task1.Start();
        // Второй способ создания задачи
        // Task task2 = Task.Factory.StartNew(PrintInfo);
        // Третий способ создания задачи
        // Task task3 = Task.Run(PrintInfo);

        // После запуска задачи этот метод будет выполняться в отдельном потоке. Поскольку данный метод, в котором были запущены задачи, выполняется в своем потоке, он может завершить работу раньше, чем основной поток. Для того, чтобы дождаться выполнения задачи, можно использовать функцию Wait():
        // task3.Wait();

        // Может возникнуть ситуация, при которой очередь задач определяется "самовольно", несмотря на правильную последовательность написанного кода. Это происходит из-за выставления планировщиком задач своих приоритетов для запускаемых задач.
        /*Task task1 = Task.Run(DoTask1);
        Task task2 = Task.Run(DoTask2);
        Task task3 = Task.Run(DoTask3);
        Task.WaitAll(task1, task2, task3);*/
        /*task1.Wait();
        task2.Wait();
        task3.Wait();*/

        // Задача может запускать другую - вложенную. При этом даже если метод, запустивший внешнюю задачу, ждет окончания выполнения внешней задачи...
        // Чтобы внутренняя задача была помечена, как внутренняя, при ее создании нужно указать параметр:
        Task task1 = Task.Run(DoTask1);
        Task task2 = Task.Run(DoTask2);
        Task task3 = Task.Run(DoTask3);
        Task innerTask2 = new Task(DoInnerTask2, TaskCreationOptions.AttachedToParent);
        innerTask2.Start();

        Task.WaitAll(task1, task2, task3);

        // Возвращение результата. Для этого применяются шаблонные объекты класса Task
        Task<int> taskIntReturn = new Task<int>(() => 3 + 3);
        taskIntReturn.Start();
        int taskIntResult = taskIntReturn.Result;
        Console.WriteLine($"Реузльтат работы задачи по складывания значений: {taskIntResult}");

        // Задачу можно продолжить после завершения, передав управление другому объекту:
        Task taskContinue = taskIntReturn.ContinueWith(PrintResult);
    }

    public static void PrintResult(Task<int> task)
    {
        Console.WriteLine($"Результат задачи: {task.Result}");
    }

    public static void DoTask1()
    {
        Console.WriteLine("Начинаю процесс 1.");
        Thread.Sleep(1000);
        Console.WriteLine("Заканчиваю процесс 1.");
    }

    public static void DoTask2()
    {
        Console.WriteLine("Начинаю процесс 2.");
        Thread.Sleep(10000);
        Console.WriteLine("Заканчиваю процесс 2.");
    }

    public static void DoTask3()
    {
        Console.WriteLine("Начинаю процесс 3.");
        Thread.Sleep(5000);
        Console.WriteLine("Заканчиваю процесс 3.");
    }

    public static void DoInnerTask2()
    {
        Console.WriteLine("Начинаю внутренний процесс у Task 2.");
        Thread.Sleep(3000);
        Console.WriteLine("Заканчиваю внутренний процесс у Task 2.");
        
    }
}

//      Практика - написать калькулятор, который высчитывает результат в отдельных задачах Task. Калькулятор включает в себя операции: +, -, /, *, %, MathF.Sqrt (квадрат), MathF.Log (логарифм), MathF.Pow (возведение в степень).
// 0. Программа должна работать в цикле do while, пока пользователь не захочет выйти.
// 1. Написать небольшое меню-обработку комманд пользователя через конструкцию switch;
// 2. В каждом case запускать отдельную задачу в зависимости от выбранного действия пользователем.
// 3. После выполнения задачи нужно считывать результат и печатать в консоль пользователю.
// Примечание: использовать Task, математические функции из класса MathF