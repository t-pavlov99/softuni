using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Core
{
    internal class Controller : IController
    {
        public Controller()
        {
            _divers = new DiverRepository();
            _fish = new FishRepository();
        }

        private DiverRepository _divers;
        private FishRepository _fish;

        private bool ValidDiverType(string type)
        {
            return type == "FreeDiver" || type == "ScubaDiver";
        }

        private IDiver CreateDiver(string type, string name)
        {
            switch (type)
            {
                case "FreeDiver": return new FreeDiver(name);
                case "ScubaDiver": return new ScubaDiver(name);
                default: return null;
            }
        }

        private bool ValidFishType(string type)
        {
            return type == "ReefFish" || type == "DeepSeaFish" || type == "PredatoryFish";
        }

        private IFish CreateFish(string type, string name, double points)
        {
            switch (type)
            {
                case "ReefFish": return new ReefFish(name, points);
                case "DeepSeaFish": return new DeepSeaFish(name, points);
                case "PredatoryFish": return new PredatoryFish(name, points);
                default: return null;
            }
        }
        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diver = _divers.GetModel(diverName);
            if (diver == null)
            {
                return string.Format(OutputMessages.DiverNotFound, "DiverRepository", diverName);
            }
            IFish fish = _fish.GetModel(fishName);
            if (fish == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }
            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }
            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);


            }
            if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(fish);
                    return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
                }
                else
                {
                    diver.Miss(fish.TimeToCatch);
                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }
            diver.Hit(fish);
            return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);


        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**Nautical-Catch-Challenge**");
            foreach (IDiver diver in _divers.Models.Where(x => !x.HasHealthIssues)
                                                   .OrderByDescending(x => x.CompetitionPoints)
                                                   .ThenByDescending(x => x.Catch.Count)
                                                   .ThenBy(x => x.Name))
            {
                sb.AppendLine(diver.ToString());
            }
            return sb.ToString().Trim();
        }                                   

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (!ValidDiverType(diverType))
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }
            if (_divers.Models.Any(x => x.Name == diverName))
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, "DiverRepository");
            }
            IDiver diver = CreateDiver(diverType, diverName);
            _divers.AddModel(diver);
            return string.Format(OutputMessages.DiverRegistered, diverName, "DiverRepository");
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = _divers.GetModel(diverName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");
            foreach (string fish in diver.Catch)
            {
                sb.AppendLine(_fish.GetModel(fish).ToString());
            }
            return sb.ToString().Trim();
        }

        public string HealthRecovery()
        {
            int count = 0;
            foreach (IDiver diver in _divers.Models.Where(x => x.HasHealthIssues))
            {
                count++;
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }
            return $"Divers recovered: {count}";
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (!ValidFishType(fishType))
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }
            if (_fish.Models.Any(x => x.Name == fishName))
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, "FishRepository");
            }
            _fish.AddModel(CreateFish(fishType, fishName, points));
            return string.Format(OutputMessages.FishCreated, fishName);
        }
    }
}
