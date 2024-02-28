namespace PersonalRegister;

internal class Program
{
    // Make the registry a class member to reference in all functions
    private static Registry registry = new();
    static void Main(string[] args)
    {
        /* Primary application interface
         * Need to present the user with a menu and manage their choices.
         */
        bool exit = false;
        do
        {
            string choice = DisplayMenu();
            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    DisplayRegistry();
                    break;
                case "exit":
                    exit = true;
                    break;
                default:
                    // Should not reach this point
                    break;
            }
        } while (!exit);
    }

    static string DisplayMenu()
    {
        // Display a menu for the user to interact with
        Console.Clear();
        Console.WriteLine("Please select an option:");
        Console.WriteLine();
        Console.WriteLine("   1: Add an employee to the registry");
        Console.WriteLine("   2: View the current registry");
        Console.WriteLine("exit: Exit this program");
        Console.WriteLine();

        // Parse the user's choice
        string? readResult;
        string[] validChoices = ["1", "2", "exit"];
        do
        {
            Console.Write("Your choice: ");
            readResult = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(readResult))
            {
                Console.WriteLine("The choice cannot be empty; type 'exit' to exit.");
                continue;
            }
            readResult = readResult.ToLower().Trim();
            if (!validChoices.Contains(readResult))
            {
                Console.WriteLine($"Could not parse the option '{readResult}'.");
                continue;
            }
            break;
        } while (true);
        return readResult;
    }

    private static void AddEmployee()
    {
        // Interface for adding an employee
        bool exit = false;
        do
        {
            string? readResult;
            string name;
            decimal salary;
            Console.Clear();
            Console.WriteLine("Add an employee to the registry");
            Console.WriteLine(new string('-', "Add an employee to the registry".Length));
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
            Console.WriteLine(
                $"Adding employee '{name}' with salary {salary:C} to the registry");
            registry.AddEmployee(name, salary);
            Console.WriteLine();

            // Ask to register another employee
            do
            {
                Console.Write("Add another employee (y/n)? ");
                readResult = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(readResult))
                {
                    continue;
                }

                string choice = readResult.ToLower().Trim()[..1];
                if (choice == "n")
                {
                    exit = true;
                    break;
                }
                else if (choice == "y")
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Could not parse input '{readResult}'");
                }
            } while (true);
        } while (!exit);

        // Pause before continuing
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
