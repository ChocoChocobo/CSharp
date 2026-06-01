
class Week // Пример класса с итератором
{
    private string[] weekDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    // Для того, чтобы определить Enumerator в классе, нужно указать специальный метод GetEnumerator(), который является итератором. Когда будет осуществляться перебор в объекте Week, то будет идти обращение к вызову yield return. Важно, что при обращении к оператору yield return будет сохраняться текущее местоположение. Когда foreach перейдет к следующей итерации для получения нового объект, итератор начнет выполнение с этого места.
    public IEnumerator<string> GetEnumerator()
    {
        for (int i = 0; i < weekDays.Length; i++)
        {
            yield return weekDays[i];
        }
    }
}

class Source
{
    static void Main(string[] args)
    {
        //      Тема: Итераторы и оператор yield
        // Итератор - консрукция, использующая оператор yield для перебора набора значений. Итератор использует :
        // - yield break для прерывания последовательности элементов;
        // - yield return для внесения возвращаемого элемента в последовательность.
        // 1. Пример реализации с помощью возвращаемого значения у функции
        IEnumerator<int> numbers = GetNumbers();
        // 2. Пример итератора в классе
        Week week = new Week();
        foreach (var day in week)
        {
            Console.WriteLine(day);
        }
    }

    static IEnumerator<int> GetNumbers()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return i;
        }
    }
}