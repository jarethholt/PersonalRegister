namespace PersonalRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example of how the Registry should be used
            Registry registry = new();
            registry.AddEmployee("Jareth Holt", 40000.00m);
            registry.AddEmployee("Gunilla Svensson", 70000.00m);
            registry.AddEmployee("Sergej Malyshev", 60000.00m);
            registry.AddEmployee("Ana Ng", 55000.00m);
            Console.WriteLine(registry.ToString());
            Console.ReadLine();
        }
    }
}
