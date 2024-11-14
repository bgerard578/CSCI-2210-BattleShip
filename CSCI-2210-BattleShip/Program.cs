using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSCI_2210_BattleShip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Used to determin if the game should end or continue
            bool active = true;
            //Used to determin if a selected point is a hit or a miss
            bool hit = false;
            //Used to store the user input provided
            string input;
            //Used to track how many ships have been sunk
            int death = 0;
            //Stores all the ships in the game
            Ship[] ships;
            Console.WriteLine("Pleas provide your file path.");
            ships = ShipFactory.ParseShipFile(Console.ReadLine());
            Console.Clear();
            while (active)
            {
                Console.WriteLine("1: Attack");
                Console.WriteLine("2: Info");
                Console.WriteLine("(type 1 or 2)");
                input = Console.ReadLine();
                if (input == "1") 
                {
                    Console.Clear();
                    Console.WriteLine("Pleas provide coords(x, y)");
                    string coordTemp = Console.ReadLine();
                    string[] coords = coordTemp.Split(",");
                    //Removes potential spaces from the strings
                    for (int i = 0; i < coords.Length; i++)
                    {
                        if (coords[i].StartsWith(" ")) { coords[i] = coords[i].Remove(0, 1); }
                    }
                    //Checks to see if 2 parts for a coord was inputed, if not tells the user their input is invalid
                    if (coords.Length != 2) { Console.Clear(); Console.WriteLine("Invalid Input"); continue; }
                    int coordx;
                    int coordy;
                    //Checks to see if the input can make a coord and if not tells the user their input is invalid
                    if(!int.TryParse(coords[0], out coordx) || !int.TryParse(coords[1], out coordy)) { Console.WriteLine("Invalid Input"); continue; }
                    Coord2D coord = new Coord2D(coordx, coordy);
                    //Checks if the provided coords hit an ships
                    foreach (Ship ship in ships)
                    {
                        if (ship.CheckIfHit(coord)) 
                        {
                            hit = true;
                            if (ship.GetCurrentHealth() - 1 <= 0) { death++; }
                        }
                        ship.TakeDamage(coord);
                    }
                    Console.Clear() ;
                    if (hit) { Console.WriteLine("hit!!"); }
                    else if (!hit) { Console.WriteLine("Miss/AlreadyHitPoint"); }
                    //Resets hit to false for the next round
                    hit = false;
                    //Checks to see if any ships are still alive
                    if (death == ships.Length) { Console.WriteLine("You Win!!!"); active = false; }
                }
                else if (input == "2") 
                {
                    Console.Clear();
                    //Gives all the info for all the ships
                    foreach (Ship ship in ships)
                    {
                        Console.WriteLine(ship.GetInfo());
                    }
                }
                //If 1 or 2 was not selected, Tells the user the inputed value was invalid
                else { Console.Clear();  Console.WriteLine("Invalid Input"); }
            }
        }
    }
}