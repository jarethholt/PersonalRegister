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

        /* Next steps:
         * Next I would add a few functions here to control the interactive
         * program flow. It would consist of:
         * - 1. A function to add a new employee to the registry by providing
         *      name and salary at the command line;
         * - 2. A function to display the current registry; and
         * - 3. A function to display a menu and ask the user to choose one of the above.
         * Then Main would consist of the interactivity needed to run these three functions.
         * Unfortunately I am out of time for the assignment but hope to come back to this later.
         */
    }
}
