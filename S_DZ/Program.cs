using System.Text.Json;

namespace S_DZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            List<Magazine> magazines = new List<Magazine>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(
                    "============================\n" +
                    " 1. Додати журнал\n" +
                    " 2. Показати всі журнали\n" +
                    " 3. Зберегти журнали\n" +
                    " 4. Завантажити журнали\n" +
                    " 0. Вийти\n" +
                    "============================");
                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("============================");
                        Console.Write("Введіть назву журналу: ");
                        string title = Console.ReadLine() ?? string.Empty;
                        Console.Write("Введіть назву видавництва: ");
                        string publisher = Console.ReadLine() ?? string.Empty;
                        Console.Write("Введіть дату випуску: ");
                        string releaseDate = Console.ReadLine() ?? string.Empty;
                        Console.Write("Введіть кількість сторінок: ");
                        int pageCount = int.TryParse(Console.ReadLine(), out int p) ? p : 0;

                        List<Article> articles = new List<Article>();
                        while (true)
                        {
                            Console.WriteLine("Введіть статтю (для завершення введіть 'end'):");
                            Console.Write("Введіть назву статті: ");
                            string articleTitle = Console.ReadLine() ?? string.Empty;
                            if (articleTitle == "end")
                                break;

                            Console.Write("Введіть кількість символів: ");
                            int characterCount = int.TryParse(Console.ReadLine(), out int cc) ? cc : 0;
                            Console.Write("Введіть анонс статті: ");
                            string announcement = Console.ReadLine() ?? string.Empty;

                            articles.Add(new Article(articleTitle, characterCount, announcement));
                        }

                        magazines.Add(new Magazine(title, publisher, releaseDate, pageCount, articles));
                        Console.WriteLine("Журнал додано успішно.");
                        Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("============================");
                        foreach (var magazine in magazines)
                        {
                            Console.WriteLine(magazine);
                        }
                        Console.WriteLine("============================");
                        Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
                        Console.ReadKey();
                        break;

                    case "3":
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string jsonString = JsonSerializer.Serialize(magazines, options);
                        File.WriteAllText("magazines.json", jsonString);
                        Console.WriteLine("Журнали збережено успішно.");
                        Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
                        Console.ReadKey();
                        break;

                    case "4":
                        if (File.Exists("magazines.json"))
                        {
                            string jsonFromFile = File.ReadAllText("magazines.json");
                            magazines = JsonSerializer.Deserialize<List<Magazine>>(jsonFromFile) ?? new List<Magazine>();
                            Console.WriteLine("Журнали завантажено успішно.");
                        }
                        else
                        {
                            Console.WriteLine("Файл збереження не знайдено.");
                        }
                        Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
                        Console.ReadKey();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
