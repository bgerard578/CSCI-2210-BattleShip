using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSCI_2210_BattleShip
{
    public static class ShipFactory
    {
        private static readonly Regex Regex = new Regex (@"^(Carrier|Battleship|Destroyer|Submarine|Patrol Boat), (\d+), (h|v), (\d+), (\d+)$",RegexOptions.Compiled);
        /// <summary>
        /// Determins if a description of a ship has all the information needed to make a ship with no problems, and that all the information is within the bounds of the game board
        /// </summary>
        /// <param name="description">The information provided to atempt to make a ship</param>
        /// <returns>True if the information is good, false if the information would cause problems when creating a ship</returns>
        public static bool VerifyShipString(string description) 
        {
            var match = Regex.Match(description);
            string ship = match.Groups[1].Value;
            int shipX = int.Parse(match.Groups[4].Value);
            int shipY = int.Parse(match.Groups[5].Value);
            string shipDirection = match.Groups[3].Value;
            int shipLength = int.Parse(match.Groups[2].Value);
            bool result = true;
            //Make sure that the ship is within all bounds and restrictions
            if (ship != "Battleship" && ship != "Carrier" && ship != "Destroyer" && ship != "Patrol Boat" && ship != "Submarine") { result = false; }
            if (shipLength > 5) { result = false; }
            if (shipDirection != "h" && shipDirection != "v") { result = false; }
            if ((shipDirection == "h" && (shipX + shipLength) > 10) || shipX < 0 ) { result = false; }
            if ((shipDirection == "v" && (shipY + shipLength) > 10) || shipY < 0) { result = false; }
            return result;
        }
        /// <summary>
        /// Pulls the data provided apart and creates a ship
        /// </summary>
        /// <param name="description">The data provided to create a ship</param>
        /// <returns>A created ship</returns>
        /// <exception cref="ArgumentException">Thrown when the data is determined to be bad</exception>
        public static Ship ParseShipString(string description) 
        {
            string shipName;
            int shipLength;
            DirectionType shipDirection;
            int shipX;
            int shipY;
            if (VerifyShipString(description))
            {
                string[] data = description.Split(',');
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].StartsWith(" ")) { data[i] = data[i].Remove(0, 1); }
                }
                shipName = data[0];
                shipLength = int.Parse(data[1]);
                shipX = int.Parse(data[3]);
                shipY = int.Parse(data[4]);
                shipDirection = DirectionType.Horizontal;
                if (data[2] == "h") { shipDirection = DirectionType.Horizontal; }
                else if (data[2] == "v") { shipDirection = DirectionType.Vertical; }
                if (shipName == "Carrier") { return new Carrier(new Coord2D(shipX, shipY), shipDirection); }
                else if (shipName == "Destroyer") { return new Destroyer(new Coord2D(shipX, shipY), shipDirection); }
                else if (shipName == "Patrol Boat") { return new PatrolBoat(new Coord2D(shipX,shipY), shipDirection); }
                else if (shipName == "Submarine") { return new Submarine(new Coord2D(shipX, shipY), shipDirection); }
                else if (shipName == "Battleship") { return new Battleship(new Coord2D(shipX, shipY), shipDirection); }
                else { throw new ArgumentException("Ship type doesn't exist"); }
            }
            else { throw new ArgumentException("Ship data invalid"); }
        }
        /// <summary>
        /// Breaks a file of ship data into individual ships and sends it to ParseShipString() to be made into ships
        /// </summary>
        /// <param name="filePath">The path to the file being used for the game</param>
        /// <returns>An array of all the created ships</returns>
        public static Ship[] ParseShipFile(string filePath) 
        {
            List<Ship> ships = new List<Ship>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string description = reader.ReadLine();
                    if (!description.StartsWith("#"))
                    {
                        ships.Add(ParseShipString(description));
                    }
                }
            }
            return ships.ToArray();
        }
    }
}
