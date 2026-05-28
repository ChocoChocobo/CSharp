using System;
using System.Collections;
using System.Diagnostics;
using System.Numerics;
using System.Text;

class Rat : IDisposable
{
    public string Name { get; set; } = "Крыса";

    public void Dispose()
    {
        Console.WriteLine("Память под крысу очищена");
    }
    
}


//      Практика
// 1. В классе создать метод, которыйы бы возвращал имя объекта класса Rat, который принимает в качестве параметров строку нового имени. В начале метода установить using для нового создаваемого объекта, у которого задается имя, передаваемое в функцию.
// 2. В Main() вызывать вызывать функцию в ConsoleWriteline() и протестировать работу программы.
// 3. Дать ответ на вопрос в комментариях: как происходит вызов Dispose() в конце функции.

class Source
{
    public static string ChangeRatName(string newName)
    {
        using (Rat rat = new Rat())
        {
            rat.Name = newName;
            return rat.Name;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine(ChangeRatName("Пупа"));

        //      Тема: using
        // Ключевое слово using позволяет использовать выражение в качестве условия, для которого будет автоматически применен метод Dispose().
        // Объект, который таким образом используется, должен реализовывать интерфейс IDisposable!
        // using можно использовать вложенно для высвобождения памяти у множества объектов.
        /*using (Rat rat = new Rat())
        {
            //Console.WriteLine($"Имя крысы: {rat.Name}");
        }*/ // В конце блока using вызывается реализованный метод Dispose()

        // По-другому можно определить жизнь объекта на всю функцию:
        /*using Rat rat2 = new Rat();
        rat2.Name = "test";*/
        
    }
}

