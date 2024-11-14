using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_2210_BattleShip
{
    internal class Battleship : Ship
    {
        /// <summary>
        /// Creates a Battleship
        /// </summary>
        /// <param name="position">Starting position of the ship</param>
        /// <param name="direction">Direction the ship is facing</param>
        public Battleship(Coord2D position, DirectionType direction) : base(position, direction, 4) { }
        /// <summary>Gives the type of the ship
        /// </summary>
        /// <returns>The type of the ship</returns>
        public override string GetName() { return "Battleship"; }
    }
}
