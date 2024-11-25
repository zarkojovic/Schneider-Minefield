using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Schneider_MineField.Grid;
using Schneider_MineField.Entities;

namespace Schneider_MineField.Tests.Grid
{
    public class GridTests
    {
        [Fact]
        public void GridInitializationTest()
        {
            // Arrange
            int width = 5;
            int height = 5;

            // Act
            Schneider_MineField.Grid.Grid grid = new Schneider_MineField.Grid.Grid(width, height);

            // Assert
            Assert.Equal(width, grid.Width);
            Assert.Equal(height, grid.Height);
            Assert.NotNull(grid.Cells);
            Assert.Equal(width, grid.Cells.GetLength(0));
            Assert.Equal(height, grid.Cells.GetLength(1));
        }

        [Fact]
        public void PlaceEntityTest()
        {
            // Arrange
            int width = 5;
            int height = 5;
            Schneider_MineField.Grid.Grid grid = new Schneider_MineField.Grid.Grid(width, height);
            Schneider_MineField.Entities.Player player = new Schneider_MineField.Entities.Player();
            Position position = new Position(2, 2);

            // Act
            bool result = grid.PlaceEntity(player, position);

            // Assert
            Assert.True(result);
            Assert.Equal(player, grid.GetCell(position).Entity);
            Assert.Contains(position, grid.OccupiedPositions);
        }

        [Fact]
        public void PlaceEntityInvalidPositionTest()
        {
            // Arrange
            int width = 5;
            int height = 5;
            Schneider_MineField.Grid.Grid grid = new Schneider_MineField.Grid.Grid(width, height);
            Schneider_MineField.Entities.Player player = new Schneider_MineField.Entities.Player();
            Position invalidPosition = new Position(-1, -1);

            // Act
            bool result = grid.PlaceEntity(player, invalidPosition);

            // Assert
            Assert.False(result);
            Assert.DoesNotContain(invalidPosition, grid.OccupiedPositions);
        }

        [Fact]
        public void GetRandomEmptyPositionTest()
        {
            // Arrange
            int width = 5;
            int height = 5;
            Schneider_MineField.Grid.Grid grid = new Schneider_MineField.Grid.Grid(width, height);

            // Act
            Position position = grid.GetRandomEmptyPosition();

            // Assert
            Assert.True(position.X >= 0 && position.X < width);
            Assert.True(position.Y >= 0 && position.Y < height);
            Assert.DoesNotContain(position, grid.OccupiedPositions);
        }

        [Fact]
        public void GetEntitiesTest()
        {
            // Arrange
            int width = 5;
            int height = 5;
            Schneider_MineField.Grid.Grid grid = new Schneider_MineField.Grid.Grid(width, height);
            Schneider_MineField.Entities.Player player = new Schneider_MineField.Entities.Player();
            Schneider_MineField.Entities.Mine mine = new Schneider_MineField.Entities.Mine();
            grid.PlaceEntity(player, new Position(0, 0));
            grid.PlaceEntity(mine, new Position(1, 1));

            // Act
            List<Schneider_MineField.Entities.Player> players = grid.GetEntities<Schneider_MineField.Entities.Player>();
            List<Schneider_MineField.Entities.Mine> mines = grid.GetEntities<Schneider_MineField.Entities.Mine>();

            // Assert
            Assert.Single(players);
            Assert.Equal(player, players[0]);
            Assert.Single(mines);
            Assert.Equal(mine, mines[0]);
        }

        [Fact]
        public void GetEntityTest()
        {
            // Arrange
            int width = 5;
            int height = 5;
            Schneider_MineField.Grid.Grid grid = new Schneider_MineField.Grid.Grid(width, height);
            Schneider_MineField.Entities.Player player = new Schneider_MineField.Entities.Player();
            grid.PlaceEntity(player, new Position(0, 0));

            // Act
            Schneider_MineField.Entities.Player retrievedPlayer = grid.GetEntity<Schneider_MineField.Entities.Player>();

            // Assert
            Assert.NotNull(retrievedPlayer);
            Assert.Equal(player, retrievedPlayer);
        }
    }
}
