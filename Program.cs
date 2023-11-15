class Program
{
    static void Main()
    {
        GameAccount currentUser = new GameAccount();

        Console.WriteLine("Please enter your username:");
        currentUser.userName = Console.ReadLine();

        Console.WriteLine($"Welcome back, {currentUser.userName}!");
        Console.WriteLine("Enter:");
        Console.WriteLine("1 >>> Play a game");
        Console.WriteLine("2 >>> See player stats");
        Console.WriteLine("3 >>> Quit");

        bool repeat = true;
        Console.WriteLine("Please choose an option to proceed:");

        do
        {
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    //
                    Console.WriteLine("opt 1");
                    repeat = false;
                    break;
                case "2":
                    //
                    Console.WriteLine("opt 2");
                    repeat = false;
                    break;
                case "3":
                    //
                    Console.WriteLine("opt 3");
                    repeat = false;
                    break;

            }
            if (repeat) Console.WriteLine("Choose one of the options above.");
        } while (repeat);

    }
}

class GameAccount
{
    public string userName = "";
    public int currentRating = 1;
    public int gamesCount = 0;
}
