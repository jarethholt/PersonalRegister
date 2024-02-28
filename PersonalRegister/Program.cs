namespace PersonalRegister;

internal class Program
{
    // Make the registry a class member to reference in all functions
    private static Registry registry = new();
    static void Main(string[] args)
    {
        // Example of how the Registry should be used
        registry.AddEmployee("Jareth Holt", 40000.00m);
        registry.AddEmployee("Gunilla Svensson", 70000.00m);
        registry.AddEmployee("Sergej Malyshev", 60000.00m);
        registry.AddEmployee("Ana Ng", 55000.00m);
        registry.DisplayRegistry();
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

    static void DisplayMenu()
    {
        // Display a menu for the user to interact with
        Console.Clear();
        Console.WriteLine("Please select an option:");
        Console.WriteLine();
        Console.WriteLine("   1: Add an employee to the registry");
        Console.WriteLine("   2: View the current registry");
        Console.WriteLine("exit: Exit this program");
        Console.WriteLine();
        Console.Write("Your choice: ");
        return;
    }

    private static void AddEmployee()
    {
        // Interface for adding an employee
        string? readResult;
        string name;
        decimal salary;
        Console.Clear();
        Console.WriteLine("Add an employee to the registry");
        Console.WriteLine();

        // Get the employee's name
        do
        {
            Console.Write("Employee name: ");
            readResult = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(readResult))
            {
                Console.WriteLine("The employee name cannot be empty.");
                continue;
            }
            name = readResult;
            break;
        } while (true);
        Console.WriteLine();

        // Get the employee's salary
        do
        {
            Console.Write("Employee salary: ");
            readResult = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(readResult))
            {
                Console.WriteLine("The employee salary cannot be empty.");
                continue;
            }
            if (!decimal.TryParse(readResult, out salary))
            {
                Console.WriteLine($"Could not parse {readResult} as a number.");
                continue;
            }
            break;
        } while (true);
        Console.WriteLine();

        // Display summary
        Console.WriteLine($"Adding employee '{name}' with salary {salary:C} to the registry");
        registry.AddEmployee(name, salary);
        Console.WriteLine("Press enter to continue.");
        _ = Console.ReadLine();
    }

    private static void DisplayRegistry()
    {
        // Display the current state of the registry
        Console.Clear();
        registry.DisplayRegistry();
        Console.WriteLine();
        Console.WriteLine("Press enter to continue.");
        _ = Console.ReadLine();
    }
}
