using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	public enum ShipType
	{
		Carrier, Battleship, Destroyer, Submarine, PatrolBoat
	}
	public class Ship
	{
		public string Name { get; set; }		
		public Coordinates[] Coordinates { get; set; }
		public ShipType ShipType { get; set; }
		public int Size { get; set; }

		public Ship(string name)
		{
			Name = name;			
			switch (name)
			{
				case "Carrier":
					Coordinates = new Coordinates[5];
					ShipType = ShipType.Carrier;
					Size = 5;
					break;
				case "Battleship":
					Coordinates = new Coordinates[4];
					ShipType = ShipType.Battleship;
					Size = 4;
					break;
				case "Destroyer":
					Coordinates = new Coordinates[3];
					ShipType = ShipType.Destroyer;
					Size = 3;
					break;
				case "Submarine":
					Coordinates = new Coordinates[3];
					ShipType = ShipType.Submarine;
					Size = 3;
					break;
				case "Patrol Boat":
					Coordinates = new Coordinates[2];
					ShipType = ShipType.Submarine;
					Size = 2;
					break;
				default:
					break;
			}
		}
	}
}
