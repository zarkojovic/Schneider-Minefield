using Schneider_MineField.Entities;
using Schneider_MineField.Grid;

namespace Schneider_MineField
{
    public class Game
    {
        private Grid.Grid grid;
        private Player player;
        private List<Mine> mines;
        private Exit exit;
        private int gridWidth;
        private int gridHeight;
        private int numberOfMines;

        public Grid.Grid Grid { get => grid; set => grid = value; }

        // Add a constructor to initialize the game
        public Game(int gridWidth, int gridHeight, int numberOfMines)
        {
            this.gridWidth = gridWidth;
            this.gridHeight = gridHeight;
            this.numberOfMines = numberOfMines;
            InitializeGame();
        }

        public void InitializeGame()
        {
            Grid = new Grid.Grid(gridWidth, gridHeight);
            mines = new List<Mine>();

            // Place Player
            player = new Player();
            Grid.PlaceEntity(player, new Position(0, 0)); // Player always starts at the top-left

            // Place Exit
            exit = new Exit();
            Grid.PlaceEntity(exit, Grid.GetRandomEmptyPosition());

            // Place Mines
            for (int i = 0; i < numberOfMines; i++)
            {
                Mine mine = new Mine();
                Position minePosition = Grid.GetRandomEmptyPosition();
                Grid.PlaceEntity(mine, minePosition);
                mines.Add(mine);
            }
        }

        public void Start()
        {
            while (player.Lives > 0)
            {
                Console.Clear();
                Grid.DisplayBoard(player); // Show the current state of the board

                Console.WriteLine($"Lives: {player.Lives} | Score: {player.Score}");
                Console.WriteLine("Enter your move (W/A/S/D):");
                var move = Console.ReadKey().Key;

                ProcessPlayerMove(move);

                // Check if the player has reached the exit
                if (player.Position.Equals(exit.Position))
                {
                    Console.Clear();
                    RevealAllMines();
                    Grid.DisplayBoard(player); // Show the player on the exit cell
                    Console.WriteLine("You reached the exit! You win!");
                    DisplayFinalResult();
                    return; // End the game
                }
            }

            if (player.Lives <= 0)
            {
                Console.Clear();
                RevealAllMines();
                Grid.DisplayBoard(player); // Show the final state of the board with all mines revealed
                Console.WriteLine("Game over! You ran out of lives.");
                DisplayFinalResult();
            }
        }

        public void ProcessPlayerMove(ConsoleKey move)
        {
            // Attempt to move the player
            if (player.TryMove(move, grid, out Position newPosition))
            {
                var cell = grid.GetCell(newPosition);

                if (cell.Entity is Mine)
                {
                    player.HitMine();
                    cell.IsRevealed = true; // Reveal the mine
                }

                // Update the player's position
                player.UpdatePosition(newPosition);
            }
            else
            {
                Console.WriteLine("Invalid move! Either out of bounds or incorrect input.");
            }
        }

        private void RevealAllMines()
        {
            foreach (var mine in mines)
            {
                var cell = grid.GetCell(mine.Position);
                cell.IsRevealed = true;
            }
        }

        private void DisplayFinalResult()
        {
            Console.WriteLine("\n--- Final Result ---");
            Console.WriteLine($"Steps Taken: {player.Score}");
            Console.WriteLine($"Lives Remaining: {player.Lives}");
            Console.WriteLine("---------------------");
            Console.ReadLine(); // Wait for user input before closing
        }
    }
}
