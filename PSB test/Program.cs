using PSB_test;

class Program
{
    public static void Main(string[] args)
    {
        string input = "(\"3:1\", \"2:2\", \"0:1\", \"4:2\", \"3:a\", \"3- 12\")";
        var matchResults = MatchResult.GetResultsFromInput(input);
        MatchResult.PrintTournamentResults(matchResults);
        Console.ReadKey();
    }
}