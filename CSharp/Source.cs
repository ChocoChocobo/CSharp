using System;
using System.Diagnostics;

namespace CSharp
{	
	class DivideException : Exception
	{
		private int i, j;
		public DivideException(int i, int j)
		{
			this.i = i;
			this.j = j;
		}

		public override string Message
		{
			get
			{
				return $"Деление на 0 в дроби: {i} / {j}";
			}
		}
	}

	class Source
    {	
		// ? у типа данных сигнализирует о том, что значение может быть равно null
		static int Divide(int[]? array, int i, int j)
		{
			if (array[j] == 0)
			{
				throw new DivideException(array[i], array[j]);
			}
			return array[i] / array[j];
		}

		static void Main(string[] args)
        {
			int[]? array = { 1, 2, 3, 0 };

			try
			{
                Console.WriteLine($"Деление выполнено: {Divide(array, 0, 3)}");
			}
			catch (DivideByZeroException zeroException)
			{
                Console.WriteLine(zeroException.Message);
			}
			catch (NullReferenceException nullException)
			{
                Console.WriteLine(nullException.Message);
            }
			catch (IndexOutOfRangeException indexException)
			{
                Console.WriteLine(indexException.Message);
            }
			catch (DivideException divideException)
			{
                Console.WriteLine(divideException.Message);
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
			}
			finally
			{
                Console.WriteLine("Несмотря на все исключения деление отработало!");
			}
        }
	}
}

// Exception:
//		DivideByZeroException
//		ArgumentOutOfRangeException
//		IndexOutOfRangeException
//		ArgumentException
//		InvalidCastException
//		NullReferenceException

// Свойства класса Exception:
// InnerException
// Message
// Source
// StackTrace
// TargetSite

//		Практика 
// Написать класс обработки исключения, наследующийся от Exception, хранящий в себе поле с массивом и переопределяющий сообщение о том, что массив не проинициализирован.