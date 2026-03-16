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

    class Unit
    {
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
            this.x = x; 
			this.y = y;
		}

		public void Attack(Unit other)
		{
			other.TakeDamage(attackDamage);
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

		// EventHandler - делегат!

		// Синтаксис объявления делегата:
		// delegate тип_возвращаемого_значения имя(параметры);

		// Синтаксис переменной делегата:
		// имя_делегата имя_переменной_делегата;

		// Синтаксис присвоения делегату функции:
		// имя_переменной_делегата = имя_функции;

		// Синтаксис вызова функции через делегат:
		// имя_переменной_делагата(параметры);

		// Синтаксис присовения множества функций:
		// имя_переменной_делагата += имя_функции1;
		// имя_переменной_делагата += имя_функции2;

		// Синтаксис удаления функции из делегата:
		// имя_переменной_делагата -= имя_функции1;
	}

	class Source
    {	
		static void Main(string[] args)
        {
			Unit hogRider = new Unit(0, 0, 2048, 4, 383, "Хог", Rarity.Uncommon);

			hogRider.Move(hogRider.Scream, 3, 3);

            /*ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.Arguments = "hog_rider.wav";
			processStartInfo.FileName = "cmd.exe";

			Process process = new Process();
			process.StartInfo = processStartInfo;
			process.Start();*/
		}
	}
}

//		Практика
// 1. Создать поле делегата у класса Unit, которое бы в дальнейшем принимало на себя задачу по смене цвета карты юнита. Например, у хог райдера - оранжевый, у скелетиков - голубой.
// 2. Создать функцию смены цвета юнита, которая бы принимала объект делегата
// 3. Создать две функции с типом возвращаемого значения string, которые бы в зависимости от поля rarity в конструкции switch, возвращали строку с цветом юнита.