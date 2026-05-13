using System;
using System.Diagnostics;
using System.Numerics;

class Source
{    
    static void Main(string[] args)
    {
        //      Тема: Работа с текстовыми файлами
        // Для тексотвых файлов применяются объекты классов StreamWrier и StreamReader. Первый предназначен для записи в файл, а второй для чтения из файла.
        // StreamReader
        StreamWriter streamWriter = new StreamWriter("writer.txt", true); // открытие файла
        streamWriter.Write("Hello world!");
        streamWriter.Flush();
        streamWriter.WriteLine("Hello from RPO!");
        // По окончании работы с файлом его необходимо закрыть
        streamWriter.Close();

        StreamReader streamReader = new StreamReader("writer.txt");
        Console.WriteLine(streamReader.Read());
        //Console.WriteLine(streamReader.ReadToEnd());
    }
}

