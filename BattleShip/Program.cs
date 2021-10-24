using System;

namespace BattleShip
{
	class Program
	{
		static void Main(string[] args)
		{
			MainMenu();
			ShipFactory();

			MapCreator();

			/*Console.WriteLine("Player 1: ");
			Field[,] Player1Field = new Field[11, 11];
			Field[,] Player2Field = new Field[11, 11];
			Player1Field = MapCreator(Player1Field);*/

		}

		static void MainMenu()
		{
			Console.WriteLine("Welcome to Battleship!");
			Console.WriteLine();
		}

		static Field[,] MapCreator()
		{
			Field[,] map = new Field[10,10];
			for (int i = 0; i < map.GetLength(0); i++)
			{
				for (int j = 0; j < map.GetLength(1); j++)
				{
					map[i, j] = new Field();
				}
			}
			return map;
		}

		static (Ship[], Ship[]) ShipFactory()
		{
			//Creating fleet arrays
			Ship[] fleetp1 = new Ship[5];
			Ship[] fleetp2 = new Ship[5];
			//Building ships
			Ship carrierp1 = new Ship("Carrier", 1);
			Ship carrierp2 = new Ship("Carrier", 2);

			Ship battleshipp1 = new Ship("Battleship", 1);
			Ship battleshipp2 = new Ship("Battleship", 2);

			Ship destroyerp1 = new Ship("Destroyer", 1);
			Ship destroyerp2 = new Ship("Destroyer", 2);

			Ship submarinep1 = new Ship("Submarine", 1);
			Ship submarinep2 = new Ship("Submarine", 2);

			Ship patrolboatp1 = new Ship("Patrol Boat", 1);
			Ship patrolboatp2 = new Ship("Patrol Boat", 2);
			//Placing ships into the arrays, creating the Fleet
			fleetp1[0] = carrierp1;
			fleetp1[1] = battleshipp1;
			fleetp1[2] = destroyerp1;
			fleetp1[3] = submarinep1;
			fleetp1[4] = patrolboatp1;

			fleetp2[0] = carrierp2;
			fleetp2[1] = battleshipp2;
			fleetp2[2] = destroyerp2;
			fleetp2[3] = submarinep2;
			fleetp2[4] = patrolboatp2;

			return (fleetp1, fleetp2);
		}
		static void MapPrinter(Field[,] Map)
		{
			for (int i = 0; i < Map.GetLength(1); i++)
			{
				for (int j = 0; j < Map.GetLength(1); j++)
				{
					Console.Write("|");
					if (Map[i,j].ObjectStatus == ObjectStatus.water)
					{
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.Write("[~]");
					}					
				}
				Console.Write("|");
				Console.WriteLine();
			}
		}
	}
}
