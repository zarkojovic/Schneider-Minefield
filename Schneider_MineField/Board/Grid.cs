using Schneider_MineField.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schneider_MineField.Grid
{
    public class Grid : IGrid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Cell[,] Cells { get; set; }
        public HashSet<Position> OccupiedPositions { get; set; }
        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[width, height];
            OccupiedPositions = new HashSet<Position>();

            // Initialize cells
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }
        }
        public Cell GetCell(Position position)
        {
            return Cells[position.X, position.Y];
        }

        public bool PlaceEntity(Entity entity, Position position)
        {
            if (IsPositionValid(position) && !OccupiedPositions.Contains(position))
            {
                Cells[position.X, position.Y].Entity = entity;
                entity.Position = position;
                OccupiedPositions.Add(position);
                return true;
            }
            return false; // Position is either invalid or occupied
        }

        public Position GetRandomEmptyPosition()
        {
            Random rand = new Random();
            Position position;
            do
            {
                position = new Position(rand.Next(Width), rand.Next(Height));
            } while (OccupiedPositions.Contains(position));
            return position;
        }

        private bool IsPositionValid(Position position)
        {
            return position.X >= 0 && position.X < Width && position.Y >= 0 && position.Y < Height;
        }

        public void DisplayBoard(Player player)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var cell = Cells[x, y];
                    if (player.Position.Equals(new Position(x, y)))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("P "); // Player
                    }
                    else if (cell.Entity is Exit)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("E "); // Exit
                    }
                    else if (cell.Entity is Mine mine && cell.IsRevealed)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("M "); // Revealed mine
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(". "); // Empty or hidden
                    }
                }
                Console.WriteLine(); // Move to the next row
            }
        }

        public List<T> GetEntities<T>() where T : Entity
        {
            List<T> entities = new List<T>();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (Cells[x, y].Entity is T entity)
                    {
                        entities.Add(entity);
                    }
                }
            }
            return entities;
        }

        public T GetEntity<T>() where T : Entity
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (Cells[x, y].Entity is T entity)
                    {
                        return entity;
                    }
                }
            }
            return null;
        }
    }
}
