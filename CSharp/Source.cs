using System;
using System.Diagnostics;

namespace CSharp
{
    enum Rarity
    {
        Common = 0,
        Uncommon = 1,
        Epic = 2,
        Legendary = 3,
        Champion = 4
    }

    class UnitEventArgs
    {
        public string Message { get; }
        public UnitEventArgs(string message)
        {
            Message = message;
        }
    }

    class Unit
    {
        // Событие в классе осуществляется с помощью ключевого слова event, после которого указывается тип делегата, который представляет событие. Простыми словами: делегат дает ответственность за выполнение определнной функции.
        public delegate void UnitHandler(Unit sender, UnitEventArgs args);
        // В программе можно вызвать это событие как метод, используя имя
        UnitHandler? notify;
        public event UnitHandler Notify
        {
            add // обработать добавление обработчика
            {
                notify += value;
                Console.WriteLine($"{value.Method.Name} был добавлен");
            }
            remove // обработать удаление обработчика
            {
                notify -= value;
                Console.WriteLine($"{value.Method.Name} был удален");
            }
        }

        public delegate string BattleCryDelegate();

        private int x, y;
        private int health, elixirCost, attackDamage;
        private string unitName;
        private Rarity rarity;

        public Unit(int x, int y, int health, int elixirCost, int attackDamage, string unitName, Rarity rarity)
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.elixirCost = elixirCost;
            this.attackDamage = attackDamage;
            this.unitName = unitName;
            this.rarity = rarity;            
        }

        // Функция передвижения юнита принимает в качестве параметра делегат, который возвращает фразу, который выкрикивает юнит
        public void Move(BattleCryDelegate battleCryDelegate, int x, int y)
        {
            Console.WriteLine($"{unitName} передвигается и говорит: {battleCryDelegate.Invoke()}!");
            notify?.Invoke(this, new UnitEventArgs($"Юнит был размещен на позицию {x}:{y}"));
            this.x = x;
            this.y = y;
        }

        public void Attack(Unit other)
        {
            other.TakeDamage(attackDamage);
            notify?.Invoke(this, new UnitEventArgs($"Юнит {other.unitName} получил урон {attackDamage} от {unitName}"));
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public string Scream()
        {
            return "Hooog riiideeeer!";
        }

        public string Cry()
        {
            return "Snickers!";
        }
    }

    class Source
    {
        // Обработчик события Notify
        static void PrintInfo(Unit sender, UnitEventArgs args)
        {
            Console.WriteLine(args.Message);
        }
        static void PrintColorInfo(Unit sender, UnitEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(args.Message);
            Console.ResetColor();
            throw new Exception("Я ошибка");
        }

        static void Main(string[] args)
        {
            Unit hogRider = new Unit(0, 0, 2048, 4, 383, "Хог", Rarity.Uncommon);
            Unit tomb = new Unit(5, 5, 850, 3, 150, "Гробница", Rarity.Uncommon);

            try
            {
                tomb.Notify += PrintInfo;
                hogRider.Notify += PrintColorInfo;

                hogRider.Move(hogRider.Scream, 4, 5);
                hogRider.Attack(tomb);
                hogRider.Move(hogRider.Scream, 4, 5);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}");
            }
            finally
            {
                hogRider.Notify -= PrintColorInfo;
            }

            tomb.Move(tomb.Cry, 10, 10);
        }
    }
}

//      Обработка событий
// События сигнализируют программе о том, что произошло определенное действий, на которое блок программы должен отреагировать
// Применение событий вместо обычного использования функции выгоднее, когда на момент определения класса мы можем точно не знать, какое действие хотим совершить в методе в ответ на действие.
// Пример: счет в банке. При добавлении суммы необходимо уведомить пользователя о поступлении средств. На момент определения класса счета в банке мы, как разработчики, можем быть не уверены каким способом уведомлять пользователя.
// Более того можно создать отдельную библиотеку классов, которая будет содержать этот класс, и добавлять ее в отдельные проекты. Затем уже из этих проектов решать, какое действие должно выполняться.
// Пример: появляется необходимость использования счета в банке в графическом приложении и выводить информацию о ополнении счета в графическом сообщении, а не в консоль.
// Демонстрация вызова события, как обычной функции:
// Notify("юнит был создан!");
// При таком вызове можно столкнуться с тем, что событие равно null в случае, если для него не определен обработчик. Поэтому при вызове события лучше всегда проверять на null
// Первый способ вызова:
// if (Notify != null) Notify("юнит был создан!");
// Второй способ вызова:
// Notify?.Invoke("юнит был создан!");
// Invoke возможно использовать поскольку событие представляет собой делегат
// Invoke позволяет вызвать определнный метод у делегата, передавая в него параметры.
// После того, как программа была уведомлена с помощью вызовов методов делегатов необходимо эти события обработать с помощью обработчика событий.
// Обработчики событий - это методы, которые выполняются при вызове событий. Каждый обработчик по списку параметров и возвращаемому типу должен соответствовать делегату, который представляет событие.
// Для добавления обработчика события применяется операция '+='
// Для удаления обработчика события применяется операция '-='
// В качестве обработчиков событий могут использоваться не только обычные методы, но также делегаты, анонимные методы и лямбда-выражения

// С помощью специальных аксессоров add и remove можно управлять доблавнием и удалением обработчиков.
/*public delegate void UnitHandler(string message);
UnitHandler? notify; - вызывается событие от делегата, которое принимает логику события!
public event UnitHandler Notify
{
    add // обработать добавление обработчика
    {
        notify += value;
        Console.WriteLine($"{value.Method.Name} был добавлен");
    }
    remove // обработать удаление обработчика
    {
        notify -= value;
        Console.WriteLine($"{value.Method.Name} был удален");
    }
}*/

// Нередко при возникновении события обработчику требуется передать некоторую информацию о событии, так называемые Args или аргументы.
// По сравнению с предыдущим вариантом изменяется количество параметров и их использование в обработчике. Передаваемый класс Args выступает в роли контейнера информации, которая нужна для обработчика. Благодаря первому параметру события можно получить информацию об отправителе.

//      Практика
// 1. Реализровать событие, которое срабатывает в тот момент, когда Юнит наносит урон другому Юниту.
// 2. Обрабатывать событие и принимать в качестве параметров объект Юнита и класс UnitAttackEventArgs. Юнит, который обрабатывает событие, должен иметь возможность вернуться. Логика нанесения урона должна помещена в обработчик события!