using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	public class Player
	{
		public string Name { get; set; }
		public Ship[] Inventory { get; set; }
		public int Health { get; set; }

		public Player(string name, Ship[] inventory)
		{
			Name = name;
			Inventory = inventory;
			Health = 2;
		}
	}
}
