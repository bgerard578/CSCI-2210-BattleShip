using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_2210_BattleShip
{
    internal class Submarine : Ship
    {
        /// <summary>
        /// Creates a submarine
        /// </summary>
        /// <param name="position">The starting position of the ship</param>
        /// <param name="direction">The direction the ship is facing</param>
        public Submarine(Coord2D position, DirectionType direction) : base(position, direction, 3) { }
        public override string GetName() { return "Submarine"; }
    }
}
