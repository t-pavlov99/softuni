using FootballManager.Core.Contracts;
using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Repositories;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Core
{
    internal class MyController : IController
    {
        private List<Type> managerTypes;
        private List<string> managerTypeNames;

        public MyController()
        {
            championship = new TeamRepository();
            //managerTypes = Assembly.GetAssembly(GetType()).GetTypes().Where(x => x.BaseType == typeof(Manager)).ToList();

            //managerTypeNames = managerTypes.Select(x =>  x.Name).ToList();
            managerTypes = new List<Type> { typeof(AmateurManager), typeof(SeniorManager), typeof(ProfessionalManager) };
            managerTypeNames = new List<string> { "AmateurManager", "SeniorManager", "ProfessionalManager" };
        }
        private bool ValidManager(string managerTypeName)
        {
            return managerTypeNames.Contains(managerTypeName);
        }
        private IManager? CreateManager(string managerTypeName, string managerName)
        {
            if (!ValidManager(managerTypeName))
                return null;
            return (IManager)Activator.CreateInstance(
                managerTypes.Where(x => x.Name == managerTypeName).Single(),
                managerName);

            //if (managerTypeName == typeof(AmateurManager).Name)
            //{
            //    return new AmateurManager(managerName);
            //}
            //if (managerTypeName == typeof(SeniorManager).Name)
            //{
            //    return new SeniorManager(managerName);
            //}
            //if (managerTypeName == typeof(ProfessionalManager).Name)
            //{
            //    return new ProfessionalManager(managerName);
            //}
            //return null;
        }

        private TeamRepository championship;
        public string ChampionshipRankings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Ranking Table***");

            int indexer = 1;
            foreach (var team in championship.Models.OrderByDescending(x => x.ChampionshipPoints)
                                                    .ThenByDescending(x => x.PresentCondition))
            {
                sb.AppendLine($"{indexer++}. {team.ToString()}/{team.TeamManager.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
        public string JoinChampionship(string teamName)
        {
            if (championship.Models.Count == championship.Capacity)
            {
                return OutputMessages.ChampionshipFull;
            }
            if (championship.Exists(teamName))
            {
                return string.Format(OutputMessages.TeamWithSameNameExisting, teamName);
            }
            championship.Add(new Team(teamName));
            return string.Format(OutputMessages.TeamSuccessfullyJoined, teamName);
        }

        public string MatchBetween(string teamOneName, string teamTwoName)
        {
            if (!championship.Exists(teamOneName) || !championship.Exists(teamTwoName))
            {
                return OutputMessages.OneOfTheTeamDoesNotExist;
            }
            ITeam team1 = championship.Get(teamOneName);
            ITeam team2 = championship.Get(teamTwoName);
            string toReturn;
            if (team1.PresentCondition == team2.PresentCondition)
            {
                team1.GainPoints(1);
                team2.GainPoints(1);
                toReturn = string.Format(OutputMessages.MatchIsDraw, teamOneName, teamTwoName);
            }
            else if (team1.PresentCondition > team2.PresentCondition)
            {
                team1.GainPoints(3);
                if (team1.TeamManager != null)
                {
                    team1.TeamManager.RankingUpdate(5);
                }
                if (team2.TeamManager != null)
                {
                    team2.TeamManager.RankingUpdate(-5);
                }
                toReturn = string.Format(OutputMessages.TeamWinsMatch, teamOneName, teamTwoName);
            }
            else
            {
                team2.GainPoints(3);
                if (team2.TeamManager != null)
                {
                    team2.TeamManager.RankingUpdate(5);
                }
                if (team1.TeamManager != null)
                {
                    team1.TeamManager.RankingUpdate(-5);
                }
                toReturn = string.Format(OutputMessages.TeamWinsMatch, teamTwoName, teamOneName);
            }
            return toReturn;
        }
        public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
        {
            if (!championship.Exists(droppingTeamName))
            {
                return string.Format(OutputMessages.DroppingTeamDoesNotExist, droppingTeamName);
            }
            if (championship.Exists(promotingTeamName))
            {
                return string.Format(OutputMessages.TeamWithSameNameExisting, promotingTeamName);
            }
            ITeam promotingTeam = new Team(promotingTeamName);

            bool badManager = true;

            foreach (ITeam t in championship.Models.Where(t => t.TeamManager != null))
            {
                if (t.TeamManager.Name == managerName)
                {
                    badManager = false;
                }
            }
            if (!ValidManager(managerTypeName))
            {
                badManager = false;
            }
            var manager = badManager ? CreateManager(managerTypeName, managerName) : null;

            promotingTeam.SignWith(manager);

            championship.Remove(droppingTeamName);
            championship.Add(promotingTeam);

            foreach (ITeam t in championship.Models)
            {
                t.ResetPoints();
            }
            return string.Format(OutputMessages.TeamHasBeenPromoted, promotingTeamName);
        }

        public string SignManager(string teamName, string managerTypeName, string managerName)
        {
            if (!championship.Exists(teamName))
            {
                return string.Format(OutputMessages.TeamDoesNotTakePart, teamName);
            }

            if (!ValidManager(managerTypeName))
            {
                return string.Format(OutputMessages.ManagerTypeNotPresented, managerTypeName);
            }

            ITeam team = championship.Get(teamName);
            if (team.TeamManager != null)
            {
                return string.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, team.TeamManager.Name);
            }

            foreach (ITeam t in championship.Models.Where(t => t.TeamManager != null))
            {
                if (t.TeamManager.Name == managerName)
                {
                    return string.Format(OutputMessages.ManagerAssignedToAnotherTeam, managerName);
                }
            }
            team.SignWith(CreateManager(managerTypeName, managerName));
            return string.Format(OutputMessages.TeamSuccessfullySignedWithManager, managerName, teamName);
        }

    }
}
