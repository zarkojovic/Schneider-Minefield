using Schneider_MineField;

// Get valid dimensions and mine count from the user
(int width, int height, int mineCount) = GetValidGameSettings();

Game game = new Game(width, height, mineCount);
// Set up the game with user-defined settings

// Start the game
game.Start();

static (int width, int height, int mineCount) GetValidGameSettings()
{
    int width, height, mineCount;
    string difficulty;

    // Get grid dimensions from the user
    while (true)
    {
        Console.WriteLine("Enter grid width (e.g., 5-20):");
        if (int.TryParse(Console.ReadLine(), out width) && width > 0)
            break;
        Console.WriteLine("Invalid input! Please enter a positive integer.");
    }

    while (true)
    {
        Console.WriteLine("Enter grid height (e.g., 5-20):");
        if (int.TryParse(Console.ReadLine(), out height) && height > 0)
            break;
        Console.WriteLine("Invalid input! Please enter a positive integer.");
    }

    // Get difficulty level from the user
    while (true)
    {
        Console.WriteLine("Enter difficulty level (easy, medium, hard):");
        difficulty = Console.ReadLine().ToLower();
        if (difficulty == "easy" || difficulty == "medium" || difficulty == "hard")
            break;
        Console.WriteLine("Invalid input! Please enter 'easy', 'medium', or 'hard'.");
    }

    int totalCells = width * height;
    switch (difficulty)
    {
        case "hard":
            mineCount = totalCells / 4;
            break;
        case "medium":
            mineCount = totalCells / 6;
            break;
        case "easy":
            mineCount = totalCells / 8;
            break;
        default:
            mineCount = 1; // Default to 1 mine if something goes wrong
            break;
    }

    return (width, height, mineCount);
}
