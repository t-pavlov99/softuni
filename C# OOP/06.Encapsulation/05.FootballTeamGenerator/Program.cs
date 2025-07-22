/*
Team;Arsenal
Add;Arsenal;Kieran_Gibbs;75;85;84;92;67
Add;Arsenal;Aaron_Ramsey;95;82;82;89;68
Remove;Arsenal;Aaron_Ramsey
Rating;Arsenal
END
Team;Arsenal
Add;Arsenal;Kieran_Gibbs;75;85;84;92;67
Add;Arsenal;Aaron_Ramsey;195;82;82;89;68
Remove;Arsenal;Aaron_Ramsey
Rating;Arsenal
END
Team;Arsenal
Rating;Arsenal
END
 */
namespace _05.FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string cmd;

            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] parts = cmd.Split(';');
                switch (parts[0])
                {
                    case "Team":
                        try
                        {
                            teams.Add(parts[1], new Team(parts[1]));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "Add":
                        if (!teams.ContainsKey(parts[1]))
                        {
                            Console.WriteLine($"Team {parts[1]} does not exist.");
                        }
                        else
                        {
                            try
                            {
                                teams[parts[1]].AddPlayer(new Player(parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7])));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        break;
                    case "Remove":
                        if (!teams.ContainsKey(parts[1]))
                        {
                            Console.WriteLine($"Team {parts[1]} does not exist.");
                        }
                        else
                        {
                            try
                            {
                                teams[parts[1]].RemovePlayer(parts[2]);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        break;
                    case "Rating":
                        if (!teams.ContainsKey(parts[1]))
                        {
                            Console.WriteLine($"Team {parts[1]} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine($"{parts[1]} - {teams[parts[1]].Rating:f0}");
                        }
                        break;
                }
            }
        }
    }
}
