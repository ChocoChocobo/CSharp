using System; // системные классы и функции
using System.Collections.Generic; // коллекции, наподобие List, Dictionary и так далее
// using - подключение классов в файл. Наподобие #include в C++
// В отличие от C++ C# позволяет включить в скомпилированный файл только те классы и функции, которые были действительно использованы. Остальное из программы подчищает CLR.

namespace CSharp // пространство имен
{
    class Source
    {
        static void Main(string[] args)
        {
            string userName = "Default";
            string userPassword = "Default";

            int userChoice = 0;
            do
            {
                Console.WriteLine("Вы входите в систему. Для продолжения введите 1. Для выхода введите 0:");
                userChoice = Convert.ToInt32(Console.ReadLine());
                if (userChoice == 0) break;

                Console.WriteLine("Введите имя: ");
                userName = Console.ReadLine();
                
                Console.WriteLine("Введите пароль: ");
                userPassword = Console.ReadLine();

                if (userName == "Апполинарий" && userPassword == "krevetka")
                {
                    Console.WriteLine("Вы вошли в систему!");
                    break;
                }
            } while (userChoice != 0);

            
        }
    }
}

// Компиляция программы на языке C# всегда будет загружаться в память гораздо медленее в первый раз, чем в последующие разы. На это влияет механизм интерпретации языка. В первый раз программе необходимо пройти интерпретацию, после чего будет создан скомпилированный исполняемый файл, который будет гораздо быстрее запускаться