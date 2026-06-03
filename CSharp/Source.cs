// Интерфейс, позволяющий легко задать какому-либо объекту принадлежность к пулу объектов и реализовать функцию возвращения объекта в пул
using static System.Net.Mime.MediaTypeNames;

public interface IPoolable
{
    void Reset();
}

// class - позволяет сделать шаблонный параметр ссылкой
// new() - требует от шаблонного параметра конструктор без параметров
class ObjectPool<T> where T : class, IPoolable, new()
{
    // Выгоднее всего для реализации пула объектов использовать Stack, реализующий очередь
    private Stack<T> objects;
    private int maxSize;

    public ObjectPool(int maxSize)
    {
        this.maxSize = maxSize;

        // Инициализация стэка
        objects = new Stack<T>(maxSize);

        // Заполнение стэка объектов в зависимости от вместимости
        for (int i = 0; i < maxSize; i++)
        {
            objects.Push(new T());
        }
    }

    // Функция, возвращающая доступное количество объектов в пуле
    public int AvailableCount => objects.Count;

    // Функция, отвечающая за возвращение объекта в пул
    public void ReturnObject(T obj)
    {
        obj.Reset();
        if (objects.Count < maxSize) objects.Push(obj);
    }

    // Функция, отвечающая за резервирование объекта и переиспользование его
    public T RentObject()
    {
        if (objects.Count > 0)
        {
            return objects.Pop();
        }
        else
        {
            return new T();
        }
    }
}

class Bullet : IPoolable
{
    public float Speed {  get; set; }
    public float Damage { get; set; }
    public float X, Y;
    public bool IsActive { get; set; }

    public Bullet()
    {
        Speed = 0;
        Damage = 0;
        X = 0;
        Y = 0;
        IsActive = false;
    }

    public Bullet(float speed, float damage, float x, float y, bool isActive)
    {
        Speed = speed;
        Damage = damage;
        X = x;
        Y = y;
        IsActive = isActive;
    }

    // Функция, инициализирующая объект в пуле.
    // В отличие от конструктора, который вызывается только один раз в самом начале, Init нужен для того, чтобы для уже созданного объекта можно было свободно изменить значения.
    public void Init(float speed, float damage, float x, float y)
    {
        Speed = speed;
        Damage = damage;
        X = x;
        Y = y;
        IsActive = true;
    }

    // Очищает состояние объекта перед возвратом в пул, меняя флаг IsActive на false, обозначая, что объект не активен в пуле.
    public void Reset()
    {
        Speed = 0;
        Damage = 0;
        X = 0;
        Y = 0;
        IsActive = false;
    }
}

class Source
{
    static void Main(string[] args)
    {
        ObjectPool<Bullet> bulletsPool = new ObjectPool<Bullet>(32);

        for (int i = 0; i < 67; i++)
        {
            Bullet bullet = bulletsPool.RentObject();
            bullet.Init(6, 7, 0, 0);

            // Логика объекта, который был взят из пула
            Console.WriteLine($"Пуля {i} была выпущена! Осталось объектов в пуле: {bulletsPool.AvailableCount}");
            
            bulletsPool.ReturnObject(bullet);
        }
    }
}

//      Практика
// Заставить пул истощиться любым способом