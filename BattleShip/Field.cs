using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	public enum ObjectStatus
	{
		water, ship, alreadyshot
	}
	public class Field
	{
		public Coordinates Coordinates { get; set; }
		public ObjectStatus ObjectStatus { get; set; }
		public bool Attacked { get; set; }

		public Field()
		{
			Coordinates = new Coordinates();
			Attacked = false;
			ObjectStatus = ObjectStatus.water;
		}
	}
}
