using System;
using System.Diagnostics;
using System.Numerics;
using System.Text;

class Source
{    
    // Функция построения отчета
    public static string BuildReport(int[] values)
    {
        StringBuilder sb = new StringBuilder(values.Length * 4);
        foreach (int value in values)
        {
            if (value % 2 == 0)
            {
                sb.Append(value);
                sb.Append(", ");
            }
        }
        return sb.ToString();
    }

    //  Практика:
    // Оптимизировать следующую функцию, применив StringBuilder и полученные теоретческие знания
    // В комментариях вкратце указать что оптимизировали
    public static string BuildReportv2(List<int> numbers)
    {
        string result = "";

        foreach (int value in numbers.Where(x => x % 2 == 0).ToList())
        {
            result += value.ToString() + ";";
        }

        return result;
    }

    static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4 };
        Console.WriteLine(BuildReport(array));
    }    
}