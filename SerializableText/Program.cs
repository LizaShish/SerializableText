using System;
using System.Text.Json;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "user.json";
        bool continueRunning = true;

        if (File.Exists(filePath))
        { 
            string serializedContent = File.ReadAllText(filePath);
              if(!string.IsNullOrEmpty(serializedContent))
              {
                try
                {
                    string restoredText = JsonSerializer.Deserialize<string>(serializedContent);
                    Console.WriteLine("Сохраненный тескт");
                    Console.WriteLine(restoredText);
                }
                catch(JsonException e) 
                {
                    Console.WriteLine("Ошибка чтения файла JSON: " + e.Message);
                }
              }
        }
        else
        {
            Console.WriteLine("Файл user.json не найден. Будет создан новый файл.");
        }

        while (continueRunning)
        {
            Console.WriteLine("\nВыберите действие:\n1. Ввести новый текст\n2. Выход");
            string action = Console.ReadLine();

            if(action == "1")
            {
                Console.WriteLine("Введите текст");
                string inputText = Console.ReadLine();

                string serialezedText = JsonSerializer.Serialize(inputText);

                File.WriteAllText(filePath, serialezedText);
                
                Console.WriteLine("Текст сохранен");
            }
            else if(action == "2")
            {
                continueRunning = false;
                Console.WriteLine("Выход из программы.");

            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, выберите 1 или 2.");
            }
        }
    }
}
