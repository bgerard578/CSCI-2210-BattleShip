using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_2210_BattleShip
{
    public abstract class Ship : IHealth, IInfomatic
    {
        private Coord2D Position { get; set; }
        private byte Length { get; set; }
        private DirectionType Direction { get; set; }
        private Coord2D[] Points { get; set; }
        private List<Coord2D> DamagedPoints { get; set; }
        /// <summary>
        /// Base constructor for ships
        /// </summary>
        /// <param name="position">The starting position of a ship</param>
        /// <param name="direction">The direction a ship is facing</param>
        /// <param name="length">The length of a ship (used to calculate the additional points of a ship)</param>
        public Ship(Coord2D position, DirectionType direction, byte length) 
        {
            Position = position;
            Direction = direction;
            Length = length;
            Points = new Coord2D[Length];
            //Creates all the points for a ship using Length and the direction of a ship to calculate
            for (int i = 0; i < Length; i++)
            {
                if (Direction == DirectionType.Horizontal)
                {
                    Points[i] = new Coord2D(Position.x + i, Position.y);
                }
                if(Direction == DirectionType.Vertical)
                {
                    Points[i] = new Coord2D(Position.x, Position.y + i);
                }
            }
            DamagedPoints = new List<Coord2D>();
        }
        /// <summary>
        /// Checks if a location given by the user hits a ship or if it misses/has already been given
        /// </summary>
        /// <param name="point">The position the user selects to target</param>
        /// <returns>returns true if the ship is hit and false if the ship is missed or has already been hit in the given location</returns>
        public bool CheckIfHit(Coord2D point)
        {
            if (DamagedPoints.Contains(point) || !Points.Contains(point)) return false;
            else { return true; }
        }
        /// <summary>
        /// Markes a hit if the ship is hit and does nothing if the ship is missed
        /// </summary>
        /// <param name="point"></param>
        public void TakeDamage(Coord2D point)
        {
            if (CheckIfHit(point)) { DamagedPoints.Add(point); }
            else { }
        }
        /// <summary>
        /// Abstract class for the different ship types
        /// </summary>
        /// <returns>The type of a ship</returns>
        public abstract string GetName();
        /// <summary>
        /// Gives the hit points that a ship has remaining (calculated with the length of the ship and the amount of damaged points the ship has)
        /// </summary>
        /// <returns>The current health of the ship</returns>
        public int GetCurrentHealth()
        {
            return Length - DamagedPoints.Count;
        }
        /// <summary>
        /// Used to get all the information about a ship
        /// </summary>
        /// <returns>All the information for a ship</returns>
        public string GetInfo()
        {
            if (IsDead()) { return $"{GetName()}, UnAlived, MaxHealth:{GetMaxHealth()}, CurrentHealth:{GetCurrentHealth()}, Position:{Position.x.ToString()},{Position.y.ToString()}, Length:{Length.ToString()}, Direction:{Direction.ToString()}"; }
            else { return $"{GetName()}, Alive, MaxHealth:{GetMaxHealth()}, CurrentHealth:{GetCurrentHealth()}, Position:{Position.x.ToString()},{Position.y.ToString()}, Length:{Length.ToString()}, Direction:{Direction.ToString()}"; }
        }
        /// <summary>
        /// Used to get the max health of a ship (calculated with the length
        /// </summary>
        /// <returns>The max health of a ship</returns>
        public int GetMaxHealth()
        {
            return Length;
        }
        /// <summary>
        /// Determines if a ship is dead or alive (using current health)
        /// </summary>
        /// <returns>The states of a ship</returns>
        public bool IsDead()
        {
            if (GetCurrentHealth() <= 0) return true;
            else return false;
        }
    }
}
