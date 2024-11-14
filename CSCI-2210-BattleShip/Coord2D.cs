using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_2210_BattleShip
{
    public struct Coord2D
    {
        public int x;
        public int y;
        /// <summary>
        /// Assembles the Coords of a ship
        /// </summary>
        /// <param name="x">The x position of a ship</param>
        /// <param name="y">The y position of a ship</param>
        public Coord2D (int x, int y) 
        {
            this.x = x;
            this.y = y;
        }

    }
}
