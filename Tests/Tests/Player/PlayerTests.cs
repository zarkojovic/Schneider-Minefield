using Schneider_MineField.Enums;
using Schneider_MineField.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schneider_MineField.Tests.Player
{
    public class PlayerTests
    {
        [Fact]
        public void PlayerInitializationTest()
        {
            // Arrange & Act
            Schneider_MineField.Entities.Player player = new Schneider_MineField.Entities.Player();

            // Assert
            Assert.Equal(3, player.Lives);
            Assert.Equal(0, player.Score);
        }

        [Fact]
        public void HitMineTest()
        {
            // Arrange
            Schneider_MineField.Entities.Player player = new Schneider_MineField.Entities.Player();

            // Act
            player.HitMine();

            // Assert
            Assert.Equal(2, player.Lives);
        }

        [Fact]
        public void TryMoveValidMoveTest()
        {
            // Arrange
            Schneider_MineField.Grid.Grid grid = new Schneider_MineField.Grid.Grid(5, 5);
            Schneider_MineField.Entities.Player player = new Schneider_MineField.Entities.Player();
            player.UpdatePosition(new Position(2, 2)); // Set player to a valid starting position
            Position newPosition;

            // Act
            bool result = player.TryMove(ConsoleKey.W, grid, out newPosition);

            // Assert
            Assert.True(result); // Moving up from (2, 2) should be valid
            Assert.Equal(new Position(2, 1), newPosition); // New position should be (2, 1)

        }

        [Fact]
        public void TryMoveInvalidMoveTest()
        {
            // Arrange
            Schneider_MineField.Grid.Grid grid = new Schneider_MineField.Grid.Grid(5, 5);
            Schneider_MineField.Entities.Player player = new Schneider_MineField.Entities.Player();
            Position newPosition;

            // Act
            bool result = player.TryMove(ConsoleKey.Z, grid, out newPosition);

            // Assert
            Assert.False(result);
            Assert.Equal(player.Position, newPosition);
        }

        [Fact]
        public void UpdatePositionTest()
        {
            // Arrange
            Schneider_MineField.Entities.Player player = new Schneider_MineField.Entities.Player();
            Position newPosition = new Position(1, 1);

            // Act
            player.UpdatePosition(newPosition);

            // Assert
            Assert.Equal(newPosition, player.Position);
            Assert.Equal(1, player.Score);
        }
    }
}
