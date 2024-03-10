using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSB_test
{
    public class MatchResult
    {
        public MatchResult() { }
        public MatchResult(int team1Result, int team2Result)
        {
            Team1Result = team1Result;
            Team2Result = team2Result;  
        }
        public int Team1Result {  get; set; }
        public int Team2Result { get; set; }
        public static List<MatchResult> GetResultsFromInput(string input)
        {
            input = input.Remove(0, 2);
            input = input.Remove(input.Length - 1);
            input = input.Trim();
            input = input.Replace(" ", "");
            input = input.Replace("-", ":"); //maybe '-' is acceptable so i need to unify it
            List<MatchResult> matchResultsList = new List<MatchResult>();
            int index = 0;
            int team1Result = 0;
            int team2Result = 0;
            bool isExeption = false;
            string oneMatchResult = "";
            bool isLastResult = false;
            while (!isLastResult)
            {
                index = input.IndexOf('\"', 0);
                oneMatchResult = input.Substring(0, index);

                if (!oneMatchResult.Contains<char>(':'))
                {
                    input = input.Remove(0, oneMatchResult.Length + 3);
                    continue;
                }
                else
                {

                    foreach (char c in oneMatchResult)
                    {
                        if (c == ':')
                        {
                            continue;
                        }
                        else
                        {
                            try
                            {
                                string temp = c.ToString();
                                Convert.ToInt32(temp);
                            }
                            catch (Exception ex)
                            {
                                isExeption = true;
                                input = input.Remove(0, oneMatchResult.Length + 3);
                            }
                        }
                    }
                    if (isExeption)
                    {
                        isExeption = false;
                        continue;
                    }
                }
                if (input.Length - 1 == oneMatchResult.Length)
                {

                    isLastResult = true;
                }
                else
                {
                    input = input.Remove(0, oneMatchResult.Length + 3);
                }

                index = oneMatchResult.IndexOf(':');
                team1Result = Convert.ToInt32(oneMatchResult.Substring(0, index));
                oneMatchResult = oneMatchResult.Remove(0, index + 1);
                index = input.IndexOf('\"', 0);
                team2Result = Convert.ToInt32(oneMatchResult);

                matchResultsList.Add(new MatchResult(team1Result, team2Result));
            }
            return matchResultsList;
        }
        public static void PrintTournamentResults(List<MatchResult> matchResults)
        {
            int team1 = 0;
            int team2 = 0;
            int team1Score = 0;
            int team2Score = 0;
            foreach (MatchResult matchResult in matchResults)
            {
                team1 = matchResult.Team1Result;
                team2 = matchResult.Team2Result;
                if (team1 > team2)
                {
                    team1Score += 3;
                }
                else if (team1Score == team2Score)
                {
                    team2Score++;
                    team1Score++;
                }
                else
                {
                    team2Score += 3;
                }
            }
            Console.WriteLine($"\tОчки команды N1:{team1Score}\n\tОчки команды N2:{team2Score}");


        }

    }


}
