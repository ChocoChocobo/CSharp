using System;
using System.Diagnostics;
using System.Numerics;

class Source
{    
    class RubberDuck : IDisposable // Интерфейс по самостоятельному применению очистки мусора для неуправляемых объектов
    {
        public string Name { get; set; } = "Давид";

        private bool disposed = false;

        // Метод интерфейса IDisposable
        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
            Console.WriteLine($"Жизнь объекта уточки подошла к концу в Dispose...");
        }

        // Метод, переопределяющий Dispose, который отталкивается от флага dispsoed (очищен ли объект)
        // Данный метод нужен для того, чтобы очистить управляемые объекты. После того, как они будут очищены, флаг disposed становится true и происходит очистка неуправляемая
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                // Высвобождаем ресурс
            }
            disposed = true;
        }

        // Неуправляемым кодом занимается разработчик, применяя деструктор или интерфейс IDisposable. К неуправляемому коду относятся API, которыми сборщик мусора не знает как распоряжаться.
        // Деструктор на самом деле это замаскированный метод Finalize(). Компилятор преобразует деструктор в следующую конструкцию:
        /*protected override void Finalize()
        {
            try
            {

            }
            finally
            {
                base.Finalize();
            }
        }*/

        // Деструктор:
        ~RubberDuck()
        {
            // Вопрос 1: Почему данное сообщение не отображается в консоли?
            // Вопрос 2: Когда применять Dispose или деструктор в классе? В чем сущность комбинированного подхода?
            Dispose(false);
            Console.WriteLine("Жизнь объекта уточки подошла к концу в деструкторе...");
        }
    }
    static void SayHi()
    {
        RubberDuck rubberDuck = new RubberDuck();
        rubberDuck.Name = "ПУтя";
        Console.WriteLine(rubberDuck.Name);
        rubberDuck.Name = "Утятя";
        
        // Для явной очистки памяти у объекта можно напрямую вызвать функцию Dispose()
        rubberDuck.Dispose();
    }

    static void Main(string[] args)
    {
        // Сборщик мусора в C# представлен классом GC

        SayHi();
        // Получение памяти, выделенной под кучу в байт
        long memoryInfo = GC.GetTotalMemory(false);
        // Заставить сборщик мусора проивести сборку в соответствии с одним из трех режимов
        GC.Collect(0, GCCollectionMode.Optimized);
        // Функция, приостанавливающая процесс до конца выполнения сборки мусора
        GC.WaitForPendingFinalizers();
        // Функция, позволяющая получить поколение объекта
        int memoryInfoGen = GC.GetGeneration(memoryInfo);

        Console.WriteLine($"Поколение для переменной memoryInfo: {memoryInfoGen}");
        Console.WriteLine(memoryInfo);

        Console.ReadKey();
    }    
}