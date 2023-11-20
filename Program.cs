class Program
{
    static void Main()
    {
        GameAccount currentUser = new GameAccount();

        Console.WriteLine("Please enter your username:");
        currentUser.userName = Console.ReadLine();

        Console.WriteLine($"Welcome back, {currentUser.userName}!");

        bool repeat = true;
        do
        {
            Console.WriteLine("Enter:");
            Console.WriteLine("1 >>> Play a game");
            Console.WriteLine("2 >>> See player stats");
            Console.WriteLine("3 >>> Quit");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":                    
                    PlayGame(currentUser);
                    break;
                case "2":                    
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
    static void PlayGame(GameAccount currentUser)
    {
        GameAccount currentOpponent = GenerateOpponent(currentUser.currentRating);
        Console.WriteLine($"Your next opponent is \"{currentOpponent.userName}\" rated {currentOpponent.currentRating}.");

        Console.WriteLine("   ...feeling lucky? (Y/N)");
        bool repeat = true;
        do
        {
            string result = Console.ReadLine();
            switch(result)
            {
                case "Y":
                    currentUser.currentRating = currentOpponent.currentRating;
                    Console.WriteLine($"Wow, you won! Your rating is now {currentUser.currentRating}.");
                    repeat = false;
                    break;
                case "N":
                    Console.WriteLine($"Oh no, you lost. Your rating is now {currentUser.currentRating}.");
                    currentUser.currentRating -= (currentOpponent.currentRating - currentUser.currentRating) / 2;
                    if (currentUser.currentRating < 1) currentUser.currentRating = 1;
                    repeat = false;
                    break;
            }
        } while (repeat);

        currentUser.gamesCount++;


        List<PlayedGame> PlayerStats = new List<PlayedGame>();
        PlayerStats.Add(new PlayedGame
        {

        });

    }

    static GameAccount GenerateOpponent(int userRating)
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
        worthyOpponent.currentRating = userRating + rnd.Next(10) + 1;

        return worthyOpponent;
    }
}
class GameAccount
{
    public string userName = "";
    public int currentRating = 1;
    public int gamesCount = 0;
}

class PlayedGame
{
    public string opponentName = "";
    public string gameResult = "";
    public int gameRating = 0;
    public int gameIndex = 0;
}