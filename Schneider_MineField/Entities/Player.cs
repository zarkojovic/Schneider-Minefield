using Schneider_MineField.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schneider_MineField.Entities
{
    public class Player : Entity
    {
        public int Lives { get; set; } = 3;
        public int Score { get; set; } = 0;

        public void HitMine()
        {
            Lives--;
        }
        public bool TryMove(ConsoleKey move, Schneider_MineField.Grid.Grid grid, out Position newPosition)
        {
            // Calculate the new position based on input
            newPosition = Position; // Default to current position

            switch (move)
            {
                case ConsoleKey.W: newPosition = new Position(Position.X, Position.Y - 1); break; // Up
                case ConsoleKey.S: newPosition = new Position(Position.X, Position.Y + 1); break; // Down
                case ConsoleKey.A: newPosition = new Position(Position.X - 1, Position.Y); break; // Left
                case ConsoleKey.D: newPosition = new Position(Position.X + 1, Position.Y); break; // Right
                default:
                    return false; // Invalid move
            }

            // Check if the new position is within bounds of the grid
            if (newPosition.X < 0 || newPosition.X >= grid.Width ||
                newPosition.Y < 0 || newPosition.Y >= grid.Height)
            {
                return false;
            }

            // Valid move
            return true;
        }

        public void UpdatePosition(Position newPosition)
        {
            Position = newPosition;
            Score++; // Increment score for each valid move
        }
    }
}
