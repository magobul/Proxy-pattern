using Proxy_pattern;

class Program
{
    static void Main(string[] args)
    {
        Proxy proxy = new Proxy(TimeSpan.FromSeconds(10));

        // Первый запрос обработан RealSubject
        Console.WriteLine(proxy.Request("Запрос 1"));

        // Второй запрос возвращен из кэша
        Console.WriteLine(proxy.Request("Запрос 1"));

        // Ждем 11 секунд, чтобы кэш истек
        Thread.Sleep(11000);

        // Запрос снова обработан RealSubject
        Console.WriteLine(proxy.Request("Запрос 1"));
    }
}
