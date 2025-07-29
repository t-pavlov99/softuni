using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{
    internal class Controller : IController
    {
        private TeamRepository teams;
        private PlayerRepository players;

        public Controller()
        {
            teams = new TeamRepository();
            players = new PlayerRepository();

        }

        private bool ValidPlayerType(string playerType)
        {
            return playerType == typeof(Goalkeeper).Name ||
                playerType == typeof(CenterBack).Name ||
                playerType == typeof(ForwardWing).Name;
        }

        private IPlayer CreatePlayer(string playerType, string playerName)
        {
            switch (playerType)
            {
                case "Goalkeeper": return new Goalkeeper(playerName);
                case "CenterBack": return new CenterBack(playerName);
                case "ForwardWing": return new ForwardWing(playerName);
                default: return null;
            }
        }
        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***League Standings***");
            foreach (ITeam team in teams.Models.OrderByDescending(x => x.PointsEarned).ThenByDescending(x => x.OverallRating).ThenBy(x => x.Name))
            {
                sb.AppendLine(team.ToString());
            }
            return sb.ToString().Trim();
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!players.ExistsModel(playerName))
            {
                return $"Player with the name {playerName} does not exist in the {nameof(PlayerRepository)}.";
            }
            if (!teams.ExistsModel(teamName))
            {
                return $"Team with the name {teamName} does not exist in the {nameof(TeamRepository)}.";
            }
            IPlayer player = players.GetModel(playerName);
            if (player.Team != null)
            {
                return $"Player {playerName} has already signed with {player.Team}.";

            }
            player.JoinTeam(teamName);
            teams.GetModel(teamName).SignContract(player);
            return $"Player {playerName} signed a contract with {teamName}.";

        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam team1 = teams.GetModel(firstTeamName);
            ITeam team2 = teams.GetModel(secondTeamName);
            if (team1.OverallRating == team2.OverallRating)
            {
                team1.Draw();
                team2.Draw();
                return $"The game between {firstTeamName} and {secondTeamName} ends in a draw!";
            }
            ITeam winner = team1;
            ITeam loser = team2;
            if (team1.OverallRating < team2.OverallRating)
            {
                winner = team2;
                loser = team1;
            }
            winner.Win();
            loser.Lose();
            return $"Team {winner.Name} wins the game over {loser.Name}!";

        }

        public string NewPlayer(string typeName, string name)
        {
            if (!ValidPlayerType(typeName))
            {
                return $"{typeName} is invalid position for the application.";
            }
            if (players.ExistsModel(name))
            {
                return $"{name} is already added to the PlayerRepository as {players.GetModel(name).GetType().Name}.";
            }
            players.AddModel(CreatePlayer(typeName, name));
            return $"{name} is filed for the handball league.";

        }

        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
            {
                return $"{name} is already added to the TeamRepository.";

            }
            teams.AddModel(new Team(name));
            return $"{name} is successfully added to the TeamRepository.";

        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{teamName}***");
            foreach (IPlayer player in teams.GetModel(teamName).Players.OrderByDescending(x => x.Rating).ThenBy(x => x.Name))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
