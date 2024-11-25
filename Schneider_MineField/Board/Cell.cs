using Schneider_MineField.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schneider_MineField.Grid
{
    public class Cell
    {
        public Entity? Entity { get; set; }
        public bool IsRevealed { get; set; } = false;
        public Cell(Entity entity)
        {
            Entity = entity;
        }
        public Cell()
        {
            Entity = null;
        }
    }
}
