class Program
{
    static void Main()
    {
        GameAccount currentUser = new GameAccount();
        List<PlayedGame> PlayerStats = new List<PlayedGame>();

        Console.WriteLine("Please enter your username:");
        currentUser.userName = Console.ReadLine() + "";

        Console.WriteLine($"Welcome back, {currentUser.userName}!");

        bool repeat = true;
        do
        {
            Console.WriteLine("Enter:");
            Console.WriteLine("1 >>> Play a game");
            Console.WriteLine("2 >>> See player stats");
            Console.WriteLine("3 >>> Quit");
            string option = Console.ReadLine() + "";

            switch (option)
            {
                case "1":
                    currentUser.PlayGame(currentUser, PlayerStats);
                    break;
                case "2":
                    if (currentUser.gamesCount != 0)
                    {
                        foreach (var game in PlayerStats)
                        {
                            Console.WriteLine($"Game number {game.gameIndex}" +
                                $" against {game.opponentName}" +
                                $" for {game.gameRating}" +
                                $" rating points resulted in a {game.gameResult}.");
                        }
                    }
                    else Console.WriteLine("No games played yet.");
                    break;
                case "3":
                    Console.WriteLine("Quitting...");
                    repeat = false;
                    break;
                default:
                    Console.WriteLine("Please choose an option to proceed:");
                    break;

            }
        } while (repeat);

    }

}
class GameAccount
{
    public string userName = "";
    public int currentRating = 1;
    public int gamesCount = 0;
    public int accountType = 0;

    public void PlayGame(GameAccount currentUser, List<PlayedGame> PlayerStats)
    {
        GameAccount currentOpponent = GenerateOpponent(currentUser.currentRating);
        Console.WriteLine($"Your next opponent is \"{currentOpponent.userName}\" rated {currentOpponent.currentRating}.");

        Console.WriteLine("   ...feeling lucky? (Y/N)");
        bool repeat = true;
        string result = "";
        do
        {
            string option = Console.ReadLine() + "";
            switch (option)
            {
                case "Y":
                    currentUser.currentRating += (Math.Abs(currentOpponent.currentRating - currentUser.currentRating)) / 2;
                    result = "win";
                    Console.WriteLine($"Wow, you won! Your rating is now {currentUser.currentRating}.");
                    repeat = false;
                    break;
                case "N":
                    currentUser.currentRating -= (currentOpponent.currentRating - currentUser.currentRating) / 2;
                    if (currentUser.currentRating < 1) currentUser.currentRating = 1;
                    result = "loss";
                    Console.WriteLine($"Oh no, you lost. Your rating is now {currentUser.currentRating}.");
                    repeat = false;
                    break;
            }
        } while (repeat);

        currentUser.gamesCount++;
        PlayerStats.Add(new PlayedGame
        {
            opponentName = currentOpponent.userName,
            gameResult = result,
            gameRating = currentOpponent.currentRating,
            gameIndex = currentUser.gamesCount
        }); ;
    }
    public static GameAccount GenerateOpponent(int userRating)
    {
        GameAccount worthyOpponent = new GameAccount();
        string[] namePool =
        {
        "Chad",
        "Jonathan",
        "Steve",
        "Lewis",
        "Lewis",
        "Abby",
        "Caroline",
        "Dan",
        "Emily",
        "Sandy",
        "Gus"
        };
        Random rnd = new Random();
        worthyOpponent.userName = namePool[rnd.Next(10)];
        worthyOpponent.currentRating = userRating + rnd.Next(-10, 10);
        if (worthyOpponent.currentRating < 1) worthyOpponent.currentRating = 1;

        return worthyOpponent;
    }
}
class PlayedGame
{
    public string opponentName = "";
    public string gameResult = "";
    public int gameRating = 0;
    public int gameIndex = 0;
}