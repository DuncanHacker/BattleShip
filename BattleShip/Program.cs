using System;

namespace BattleShip
{
	class Program
	{
		static void Main(string[] args)
		{
			bool ActiveGame = false;			
			Player player1 = new Player("Duncan", ShipFactory());
			Player player2 = new Player("Evil Duncan", ShipFactory());
			Field[,] mapp1 = MapCreator();
			Field[,] mapp2 = MapCreator();
			GameStart(player1, player2, mapp1, mapp2);
		}
		static void GameStart(Player player1, Player player2, Field[,] mapp1, Field[,] mapp2)
		{
			MainMenu();			
			MapCoordinates(ref mapp1);
			MapCoordinates(ref mapp2);
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(player1.Name + "'s Map");
			MapPrinter(mapp1);
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine(player2.Name + "'s Map");
			MapPrinter(mapp2);
			Console.ForegroundColor = ConsoleColor.Cyan;
			for (int i = 0; i < 10; i++)
			{
				Console.Write("[" + (i + 1) + "]");
			}
			ShipPlacement(ref player1, ref player2);
		}
		static void MainMenu()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
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
		static void GameLoop(ref bool activeGame, Player player1, Player player2, Field[,] mapp1, Field[,] mapp2)
		{
			while (activeGame == true)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine(player1.Name + "'s Map");
				MapPrinter(mapp1);
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("-----------------------------------------------");
				Console.WriteLine(player2.Name + "'s Map");
				MapPrinter(mapp2);
				Console.ForegroundColor = ConsoleColor.Cyan;
				for (int i = 0; i < 10; i++)
				{
					Console.Write("[" + (i + 1) + "]");
				}
			}
		}
		static void ShipPlacement(ref Player player1, ref Player player2)
		{
			//Player 1 => false, Player 2 => true
			bool ActivePlayer = false;
			int remainingShips = 10;
			while (remainingShips > 0)
			{
				if (!ActivePlayer)
				{
					Console.WriteLine("Player " + player1.Name + " place your ship!");
					Console.WriteLine
						(player1.Name + ", which ship do you want to place? (Type the number: 1-> Carrier(5); 2-> Battleship(4); 3-> Destroyer(3); 4-> Submarine(3); 5-> Patrol Boat(2))");
					int choosenShip = int.Parse(Console.ReadLine());
					choosenShip--;
					for (int i = 0; i < player1.Inventory[choosenShip].Coordinates.Length; i++)
					{
						Console.WriteLine("X Coordinate: ");
						int xcoordinate = int.Parse(Console.ReadLine());
						Console.WriteLine("Y Coordinate: ");
						int ycoordinate = int.Parse(Console.ReadLine());
						player1.Inventory[choosenShip].Coordinates[i] = new Coordinates(xcoordinate, ycoordinate);
						Console.WriteLine(player1.Name + "'s " + player1.Inventory[choosenShip].Name + "'s X coordinate is now: " + player1.Inventory[choosenShip].Coordinates[i].xCoordinate);
						Console.WriteLine(player1.Name + "'s " + player1.Inventory[choosenShip].Name + "'s Y coordinate is now: " + player1.Inventory[choosenShip].Coordinates[i].yCoordinate);
					}					
				}
				else if (ActivePlayer)
				{
					Console.WriteLine("Player " + player2.Name + " place your ship!");
					Console.WriteLine
						(player2.Name + ", which ship do you want to place? (Type the number: 1-> Carrier(5); 2-> Battleship(4); 3-> Destroyer(3); 4-> Submarine(3); 5-> Patrol Boat(2))");
					int choosenShip = int.Parse(Console.ReadLine());
					choosenShip--;
					for (int i = 0; i < player2.Inventory[choosenShip].Coordinates.Length; i++)
					{
						Console.WriteLine("X Coordinate: ");
						int xcoordinate = int.Parse(Console.ReadLine());
						Console.WriteLine("Y Coordinate: ");
						int ycoordinate = int.Parse(Console.ReadLine());
						player2.Inventory[choosenShip].Coordinates[i] = new Coordinates(xcoordinate, ycoordinate);
						Console.WriteLine(player2.Name + "'s " + player2.Inventory[choosenShip].Name + "'s X coordinate is now: " + player2.Inventory[choosenShip].Coordinates[i].xCoordinate);
						Console.WriteLine(player2.Name + "'s " + player2.Inventory[choosenShip].Name + "'s Y coordinate is now: " + player2.Inventory[choosenShip].Coordinates[i].yCoordinate);
					}
				}
				ActivePlayer = !ActivePlayer;
				Console.WriteLine("Remaining ships: " + remainingShips);
				remainingShips--;
			}			
		}
	}
}
