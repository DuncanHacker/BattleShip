using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	public enum ObjectStatus
	{
		water, ship, destroyedship
	}
	public class Field
	{
		public ObjectStatus ObjectStatus { get; set; }

		public Field()
		{
			ObjectStatus = ObjectStatus.water;
		}
	}
}
