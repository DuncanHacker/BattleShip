using System;

namespace BattleShip
{
	class Program
	{
		static void Main(string[] args)
		{
			MainMenu();
			Player player1 = new Player("Duncan", ShipFactory());
			Player player2 = new Player("Evil Duncan", ShipFactory());
			Field[,] map = MapCreator();
			MapCoordinates(ref map);
			MapPrinter(map);

			//MapCreator();

		}

		static void MainMenu()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Welcome to Battleship!");
			Console.WriteLine();
		}
		static Ship[] ShipFactory()
		{
			Ship[] fleet = new Ship[5];
			Ship carrier = new Ship("Carrier");
			Ship battleship = new Ship("Battleship");
			Ship destroyer = new Ship("Destroyer");
			Ship submarine = new Ship("Submarine");
			Ship patrolboat = new Ship("Patrol Boat");

			fleet[0] = carrier;
			fleet[1] = battleship;
			fleet[2] = destroyer;
			fleet[3] = submarine;
			fleet[4] = patrolboat;
			return fleet;
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
		static void MapCoordinates(ref Field[,] map)
		{
			for (int i = 0; i < map.GetLength(0); i++)
			{
				for (int j = 0; j < map.GetLength(1); j++)
				{
					map[i, j].Coordinates.xCoordinate = i;
					map[i, j].Coordinates.yCoordinate = j;
				}
			}
		}		
		static void MapPrinter(Field[,] Map)
		{			
			for (int i = 0; i < Map.GetLength(1); i++)
			{
				Console.SetCursorPosition(i, 1);
				for (int j = 0; j < Map.GetLength(1); j++)
				{
					if (Map[i,j].ObjectStatus == ObjectStatus.water)
					{
						Console.ForegroundColor = ConsoleColor.DarkCyan;
						Console.Write("[~]");
					} else if (Map[i, j].ObjectStatus == ObjectStatus.ship)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("[S]");
					} else if (Map[i, j].ObjectStatus == ObjectStatus.destroyedship)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write("[X]");
					}					
				}
				Console.WriteLine();
			}
		}
	}
}
