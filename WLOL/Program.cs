using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.Write("Введіть IP-адресу: ");
        string ipAddress = Console.ReadLine();

        // формуємо URL-запит до API
        string url = $"http://worldtimeapi.org/api/ip/{ipAddress}";

        // виконуємо запит до API
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            // розбираємо JSON-дані в об'єкт
            dynamic data = JsonConvert.DeserializeObject(responseBody);

            // виводимо необхідні дані в консоль
            Console.WriteLine($"Таймзона: {data.timezone}");
            Console.WriteLine($"Дата та час: {data.datetime}");
            Console.WriteLine($"День у році: {data.day_of_year}");
        }
    }
}

