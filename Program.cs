namespace ConsoleAppHW2102ex5;

 class Program
{
    static Semaphore semaphore = new Semaphore(3, 3); 
    static void Main(string[] args)
    {
        Console.WriteLine($"Главный поток запущен в {DateTime.Now:T}");

        for (int i = 0; i < 10; i++)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadTask));
            thread.Start(i + 1); 
        }
        Console.ReadLine(); 
        Console.WriteLine($"Главный поток завершил работу в {DateTime.Now:T}");
    }
    static void ThreadTask(object obj)
    {
        Console.WriteLine($"Поток {obj} запрашивает доступ в {DateTime.Now:T}");
        semaphore.WaitOne(); // Запрашиваем доступ к ресурсу
        int threadId = (int)obj;
        Console.WriteLine($"Поток {threadId} начал выполнение в {DateTime.Now:T}.");
        Random random = new Random();
        for (int i = 0; i < 5; i++) 
        {
            int randomNumber = random.Next(100); 
            Console.WriteLine($"Поток {threadId}: {randomNumber}");
            Thread.Sleep(200); 
        }

        Console.WriteLine($"Поток {threadId} завершил выполнение в {DateTime.Now:T}.");
        semaphore.Release(); 
        Console.WriteLine($"Поток {threadId} освободил семафор в {DateTime.Now:T}");
    }
}