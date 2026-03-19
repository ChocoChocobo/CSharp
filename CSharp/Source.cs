using System;
using System.Diagnostics;

namespace CSharp
{	
	class Source
    {	
		// ? у типа данных сигнализирует о том, что значение может быть равно null
		static int Divide(int[]? array, int i, int j)
		{
			return array[i] / array[j];
		}

		static void Main(string[] args)
        {
			int[]? array = null;

			try
			{
                Console.WriteLine($"Деление выполнено: {Divide(array, 0, 1)}");
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
// Необходимо воспроизвести ошибки в той же самой программе оставшиеся блоки catch: IndexOutOfRangeException, DivideByZeroException