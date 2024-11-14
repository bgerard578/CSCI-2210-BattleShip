using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_2210_BattleShip
{
    internal class PatrolBoat : Ship
    {
        /// <summary>
        /// Creates a PatrolBoat
        /// </summary>
        /// <param name="position">The starting position of the ship</param>
        /// <param name="direction">The direction the ship is facing</param>
        public PatrolBoat(Coord2D position, DirectionType direction) : base(position, direction, 2) { }
        /// <summary>
        /// Gives the type of ship
        /// </summary>
        /// <returns>The type of ship</returns>
        public override string GetName() { return "PatrolBoat"; }
    }
}
