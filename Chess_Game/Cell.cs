using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chest_Game
{
    public class Cell
    {
        public Point cellPos;
        public Button cellButton;
        public bool occupied;

        public Cell(Point cellPos, Button cellButton)
        {
            this.cellButton = cellButton;
            this.cellPos = cellPos;
        }
    }
}
