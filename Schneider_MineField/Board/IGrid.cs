using Schneider_MineField.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schneider_MineField.Grid
{
    public interface IGrid
    {
        bool PlaceEntity(Entity entity, Position position);
        Cell GetCell(Position position);
    }
}
