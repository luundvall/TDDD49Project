using System;

public class Game
{

    static void Main(string [] args)
    {
        Game game = new Game();
        game.run();
        Console.WriteLine("Test");
    }
	public Game()
	{
        Player player1 = new Player();
        Player player2 = new Player();
        UltimateBoard ultimateBoard = new UltimateBoard(this); 

	}

    public void run()
    {
        Console.WriteLine("Test");
    }
}
