using Schneider_MineField.Grid;
using Schneider_MineField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schneider_MineField.Tests.Game
{
    public class GameTests
    {

        [Fact]
        public void GameInitializationTest()
        {
            // Arrange
            int gridWidth = 5;
            int gridHeight = 5;
            int numberOfMines = 3;

            // Act
            Schneider_MineField.Game game = new Schneider_MineField.Game(gridWidth, gridHeight, numberOfMines);

            // Assert
            Assert.NotNull(game.Grid);
            Assert.Equal(gridWidth, game.Grid.Width);
            Assert.Equal(gridHeight, game.Grid.Height);
            Assert.Equal(numberOfMines, game.Grid.GetEntities<Schneider_MineField.Entities.Mine>().Count);
            Assert.NotNull(game.Grid.GetEntity<Schneider_MineField.Entities.Player>());
            Assert.NotNull(game.Grid.GetEntity<Schneider_MineField.Entities.Exit>());
        }

        [Fact]
        public void PlayerStartsAtTopLeftTest()
        {
            // Arrange
            int gridWidth = 5;
            int gridHeight = 5;
            int numberOfMines = 3;
            Schneider_MineField.Game game = new Schneider_MineField.Game(gridWidth, gridHeight, numberOfMines);

            // Act
            Schneider_MineField.Entities.Player player = game.Grid.GetEntity<Schneider_MineField.Entities.Player>();

            // Assert
            Assert.NotNull(player);
            Assert.Equal(new Position(0, 0), player.Position);
        }

        [Fact]
        public void PlayerHitsMineTest()
        {
            // Arrange
            int gridWidth = 5;
            int gridHeight = 5;
            int numberOfMines = 1;
            Schneider_MineField.Game game = new Schneider_MineField.Game(gridWidth, gridHeight, numberOfMines);
            Schneider_MineField.Entities.Player player = game.Grid.GetEntity<Schneider_MineField.Entities.Player>();
            Schneider_MineField.Entities.Mine mine = game.Grid.GetEntities<Schneider_MineField.Entities.Mine>()[0];

            // Act
            // Simulate moves to place the player on the mine
            player.UpdatePosition(new Position(mine.Position.X - 1, mine.Position.Y));
            game.ProcessPlayerMove(ConsoleKey.D); // Move right to hit the mine

            // Assert
            Assert.Equal(2, player.Lives); // Player should have 2 lives left after hitting the mine
        }

        [Fact]
        public void PlayerReachesExitTest()
        {
            // Arrange
            int gridWidth = 5;
            int gridHeight = 5;
            int numberOfMines = 1;
            Schneider_MineField.Game game = new Schneider_MineField.Game(gridWidth, gridHeight, numberOfMines);
            game.InitializeGame();
            Schneider_MineField.Entities.Player player = game.Grid.GetEntity<Schneider_MineField.Entities.Player>();
            Schneider_MineField.Entities.Exit exit = game.Grid.GetEntity<Schneider_MineField.Entities.Exit>();

            // Act
            // Simulate moves to place the player on the exit
            player.UpdatePosition(new Position(exit.Position.X - 1, exit.Position.Y));
            game.ProcessPlayerMove(ConsoleKey.D); // Move right to reach the exit

            // Assert
            Assert.Equal(exit.Position, player.Position);
        }

        [Fact]
        public void InvalidMoveTest()
        {
            // Arrange
            int gridWidth = 5;
            int gridHeight = 5;
            int numberOfMines = 1;
            Schneider_MineField.Game game = new Schneider_MineField.Game(gridWidth, gridHeight, numberOfMines);
            Schneider_MineField.Entities.Player player = game.Grid.GetEntity<Schneider_MineField.Entities.Player>();
            Position initialPosition = player.Position;

            // Act
            game.ProcessPlayerMove(ConsoleKey.LeftArrow); // Invalid move

            // Assert
            Assert.Equal(initialPosition, player.Position);
        }

    }
}
