using System;
using System.Text.Json;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст");
        string inputText = Console.ReadLine();

        string serialezedText = JsonSerializer.Serialize(inputText);
        Console.WriteLine("Сериализованный текст:");
        Console.WriteLine(serialezedText);

        // Запись сериализованного текста в файл
        using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(serialezedText);
            fs.Write(data, 0, data.Length);
        }

        // Чтение сериализованного текста из файла
        using (FileStream fs = new FileStream("user.json", FileMode.Open, FileAccess.Read))
        {
            using (StreamReader reader = new StreamReader(fs))
            {
                string serializedContent = reader.ReadToEnd();
                string restoredText = JsonSerializer.Deserialize<string>(serializedContent);
                Console.WriteLine("Десериализованный текст:");
                Console.WriteLine(restoredText);
            }
        }
    }
}
