using System;

class VirtualPet
{
    static void Main(string[] args)
    {
        // Pet properties
        string petType = "";
        string petName = "";
        int hunger = 5;      // Scale 1-10
        int happiness = 5;   // Scale 1-10
        int health = 8;      // Scale 1-10
        bool isRunning = true;

        Console.WriteLine("Welcome to Virtual Pet Simulator!");

        // Pet Creation
        Console.WriteLine("\nChoose a pet type:");
        Console.WriteLine("1. Cat");
        Console.WriteLine("2. Dog");
        Console.WriteLine("3. Rabbit");
        Console.Write("Enter your choice (1-3): ");

        int typeChoice;
        while (!int.TryParse(Console.ReadLine(), out typeChoice) || typeChoice < 1 || typeChoice > 3)
        {
            Console.Write("Invalid input. Please enter 1, 2, or 3: ");
        }

        petType = typeChoice switch
        {
            1 => "Cat",
            2 => "Dog",
            3 => "Rabbit",
            _ => "Unknown"
        };

        Console.Write($"Enter a name for your {petType}: ");
        petName = Console.ReadLine();

        Console.WriteLine($"\nWelcome, {petName} the {petType}! Let's take good care of your pet.");

        // Main game loop
        while (isRunning)
        {
            // Display menu
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Feed your pet");
            Console.WriteLine("2. Play with your pet");
            Console.WriteLine("3. Let your pet rest");
            Console.WriteLine("4. Check pet status");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            // Handle user choice
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.Write("Invalid input. Please enter a number between 1 and 5: ");
            }

            switch (choice)
            {
                case 1: // Feed pet
                    Console.WriteLine($"\nYou feed {petName}.");

                    // Decrease hunger (minimum 1)
                    hunger -= 1;
                    if (hunger < 1) hunger = 1;

                    // Increase health (maximum 10)
                    health += 1;
                    if (health > 10) health = 10;

                    Console.WriteLine($"{petName}'s hunger decreases, and health improves slightly.");
                    break;

                case 2: // Play with pet
                    if (hunger >= 7)
                    {
                        Console.WriteLine($"\n{petName} is too hungry to play right now. Try feeding first.");
                    }
                    else
                    {
                        Console.WriteLine($"\nYou play with {petName}.");

                        // Increase happiness (maximum 10)
                        happiness += 2;
                        if (happiness > 10) happiness = 10;

                        // Increase hunger (maximum 10)
                        hunger += 1;
                        if (hunger > 10) hunger = 10;

                        Console.WriteLine($"{petName} is happier, but a little more hungry now.");
                    }
                    break;

                case 3: // Let pet rest
                    Console.WriteLine($"\nYou let {petName} rest.");

                    // Increase health (maximum 10)
                    health += 2;
                    if (health > 10) health = 10;

                    // Decrease happiness (minimum 1)
                    happiness -= 2;
                    if (happiness < 1) happiness = 1;

                    Console.WriteLine($"{petName}'s health improves, but they're a little less happy.");
                    break;

                case 4: // Check status
                    Console.WriteLine($"\n{petName}'s Current Status:");
                    Console.WriteLine($"- Type: {petType}");
                    Console.WriteLine($"- Hunger: {hunger}/10 {GetStatusLabel(hunger)}");
                    Console.WriteLine($"- Happiness: {happiness}/10 {GetStatusLabel(happiness)}");
                    Console.WriteLine($"- Health: {health}/10 {GetStatusLabel(health)}");

                    // Warnings
                    if (hunger <= 2) Console.WriteLine("WARNING: Your pet is starving!");
                    if (happiness <= 2) Console.WriteLine("WARNING: Your pet is depressed!");
                    if (health <= 2) Console.WriteLine("WARNING: Your pet is very sick!");
                    break;

                case 5: // Exit
                    isRunning = false;
                    Console.WriteLine($"\nGoodbye! Thanks for taking care of {petName} the {petType}!");
                    break;
            }

            //Time - based changes
            if (isRunning)
            {
                // Hunger increases over time (maximum 10)
                hunger += 1;
                if (hunger > 10) hunger = 10;

                // Happiness decreases over time (minimum 1)
                happiness -= 1;
                if (happiness < 1) happiness = 1;

                // Health check
                if (hunger >= 8 || happiness <= 3)
                {
                    health -= 1;
                    if (health < 1) health = 1;
                }
            }
        }
    }

    // Helper function for status labels (without using Math methods)
    static string GetStatusLabel(int value)
    {
        if (value <= 2) return "[Critical]";
        if (value <= 4) return "[Low]";
        if (value >= 8) return "[High]";
        return "[Normal]";
    }
}