using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	public class Coordinates
	{
		public int xCoordinate { get; set; }
		public int yCoordinate { get; set; }
		public Coordinates()
		{

		}
		public Coordinates(int x, int y)
		{
			xCoordinate = x;
			yCoordinate = y;
		}
	}
}
