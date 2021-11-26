using System;
using System.IO;

namespace BattleShip
{
	class Program
	{
		static void Main(string[] args)
		{
			bool activeGame = true;			
			Player player1 = new Player("Duncan", ShipFactory());
			Player player2 = new Player("Evil Duncan", ShipFactory());
			Field[,] mapp1 = MapCreator();
			Field[,] mapp2 = MapCreator();
			GameStart(ref activeGame, player1, player2, mapp1, mapp2);
		}
		static void GameStart(ref bool activeGame, Player player1, Player player2, Field[,] mapp1, Field[,] mapp2)
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
			GameLoop(ref activeGame, ref player1, ref player2, mapp1, mapp2);
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
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.Write("[~]");
					} else if (Map[i, j].ObjectStatus == ObjectStatus.ship)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("[S]");
					} else if (Map[i, j].ObjectStatus == ObjectStatus.alreadyshot)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write("[X]");
					}	
				}
				Console.WriteLine();				
			}
		}
		static void GameLoop(ref bool activeGame, ref Player player1, ref Player player2, Field[,] mapp1, Field[,] mapp2)
		{
			int remainingShips = 2;
			while (activeGame == true)
			{
				ShipPlacement(ref player1, ref player2, ref mapp1, ref mapp2, ref remainingShips);
				Battle(ref activeGame, ref player1, ref player2, ref mapp1, ref mapp2);
			}
			Console.WriteLine("Game Over!");
		}
		static void ShipPlacement(ref Player player1, ref Player player2, ref Field[,] mapp1, ref Field[,] mapp2, ref int remainingShips)
		{
			//Player 1 => false, Player 2 => true
			bool ActivePlayer = false;
			
			while (remainingShips > 0)
			{
				if (!ActivePlayer)
				{
					Console.WriteLine("Commander " + player1.Name + " place your ship!");
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
						mapp1[xcoordinate, ycoordinate].ObjectStatus = ObjectStatus.ship;
					}					
				}
				else if (ActivePlayer)
				{
					Console.WriteLine("Commander " + player2.Name + " place your ship!");
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
						mapp2[xcoordinate, ycoordinate].ObjectStatus = ObjectStatus.ship;
					}
				}
				Console.WriteLine("New Maps: ");
				MapPrinter(mapp1);
				Console.WriteLine("-------------------------------------------");
				MapPrinter(mapp2);
				AutoSave(mapp1, mapp2);
				ActivePlayer = !ActivePlayer;
				Console.WriteLine("Remaining ships: " + remainingShips);
				remainingShips--;
			}			
		}
		static void Battle(ref bool activeGame, ref Player player1, ref Player player2, ref Field[,] mapp1, ref Field[,] mapp2)
		{
			//Player 1 => false, Player 2 => true
			bool ActivePlayer = false;
			while (activeGame)
			{
				if (!ActivePlayer)
				{
					Console.WriteLine("Commander " + player1.Name + " what are the coordinates, where we should shoot?");
					int xCoordinate = int.Parse(Console.ReadLine());
					int yCoordinate = int.Parse(Console.ReadLine());
					if (mapp2[xCoordinate, yCoordinate].ObjectStatus == ObjectStatus.ship)
					{
						player2.Health--;
						mapp2[xCoordinate, yCoordinate].ObjectStatus = ObjectStatus.alreadyshot;
					} else
						mapp2[xCoordinate, yCoordinate].ObjectStatus = ObjectStatus.alreadyshot;
					MapPrinter(mapp1);
					Console.WriteLine("----------------------");
					MapPrinter(mapp2);
					Console.WriteLine("Remaining Health for " + player1.Name + ": " + player1.Health);
					Console.WriteLine("Remaining Health for " + player2.Name + ": " + player2.Health);
					AutoSave(mapp1, mapp2);
					if (player1.Health == 0 || player2.Health == 0)
						activeGame = false;
					ActivePlayer = !ActivePlayer;
				} else
				{
					Console.WriteLine("Commander " + player2.Name + " what are the coordinates, where we should shoot?");
					int xCoordinate = int.Parse(Console.ReadLine());
					int yCoordinate = int.Parse(Console.ReadLine());
					if (mapp1[xCoordinate, yCoordinate].ObjectStatus == ObjectStatus.ship)
					{
						player1.Health--;
						mapp1[xCoordinate, yCoordinate].ObjectStatus = ObjectStatus.alreadyshot;
					}
					else
						mapp1[xCoordinate, yCoordinate].ObjectStatus = ObjectStatus.alreadyshot;
					MapPrinter(mapp1);
					Console.WriteLine("-----------------------");
					MapPrinter(mapp2);
					Console.WriteLine("Remaining Health for " + player1.Name + ": " + player1.Health);
					Console.WriteLine("Remaining Health for " + player2.Name + ": " + player2.Health);
					AutoSave(mapp1, mapp2);
					if (player1.Health == 0 || player2.Health == 0)
						activeGame = false;
					ActivePlayer = !ActivePlayer;
				}
			}
		}
		static void AutoSave(Field[,] mapp1, Field[,] mapp2)
		{
			StreamWriter streamWriter = new StreamWriter("savefile.txt");
			for (int i = 0; i < mapp1.GetLength(0); i++)
			{
				for (int j = 0; j < mapp1.GetLength(1); j++)
				{
					if (mapp1[i, j].ObjectStatus == ObjectStatus.water)
						streamWriter.Write("[~]");
					else if (mapp1[i, j].ObjectStatus == ObjectStatus.ship)
						streamWriter.Write("[S]");
					else if (mapp1[i, j].ObjectStatus == ObjectStatus.alreadyshot)
						streamWriter.Write("[X]");
				}
				streamWriter.WriteLine();
			}
			streamWriter.WriteLine("--------------------");
			for (int i = 0; i < mapp2.GetLength(0); i++)
			{
				for (int j = 0; j < mapp2.GetLength(1); j++)
				{
					if (mapp2[i, j].ObjectStatus == ObjectStatus.water)
						streamWriter.Write("[~]");
					else if (mapp2[i, j].ObjectStatus == ObjectStatus.ship)
						streamWriter.Write("[S]");
					else if (mapp2[i, j].ObjectStatus == ObjectStatus.alreadyshot)
						streamWriter.Write("[X]");
				}
				streamWriter.WriteLine();
			}
			streamWriter.Close();
		}
	}
}
