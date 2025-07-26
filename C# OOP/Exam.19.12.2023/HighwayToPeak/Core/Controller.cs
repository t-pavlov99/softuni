using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Core
{
    internal class Controller : IController
    {
        public Controller()
        {
            _peaks = new PeakRepository();
            _climbers = new ClimberRepository();
            _baseCamp = new BaseCamp();
            difficulties = new List<string> { "Extreme", "Hard", "Moderate" };
        }

        private PeakRepository _peaks;
        private ClimberRepository _climbers;
        private BaseCamp _baseCamp;
        private List<string> difficulties;
        private bool ValidDifficulty(string difficulty)
        {
            return difficulties.Contains(difficulty);
        }
        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (_peaks.All.Select(x => x.Name).Any(x => x == name))
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, name);
            }
            if (!ValidDifficulty(difficultyLevel))
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }
            _peaks.Add(new Peak(name, elevation, difficultyLevel));
            return string.Format(OutputMessages.PeakIsAllowed, name, _peaks.GetType().Name);
        }

        public string AttackPeak(string climberName, string peakName)
        {
            IClimber climber = _climbers.Get(climberName);
            if (climber == null)
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }
            IPeak peak = _peaks.Get(peakName);
            if (peak == null)
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }
            if (!_baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }
            if (climber.GetType().Name == "NaturalClimber" && peak.DifficultyLevel == "Extreme")
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }
            _baseCamp.LeaveCamp(climberName);
            climber.Climb(peak);
            if (climber.Stamina == 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }
            _baseCamp.ArriveAtCamp(climberName);
            return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
        }

        public string BaseCampReport()
        {
            if (_baseCamp.Residents.Count == 0)
            {
                return "BaseCamp is currently empty.";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseCamp residents:");
            foreach (string name in _baseCamp.Residents)
            {
                IClimber climber = _climbers.Get(name);
                sb.AppendLine($"Name: {name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
            }
            return sb.ToString().Trim();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!_baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }
            IClimber climber = _climbers.Get(climberName);
            if (climber.Stamina == 10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }
            climber.Rest(daysToRecover);
            return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (_climbers.All.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, _climbers.GetType().Name);
            }
            IClimber climber;
            switch (isOxygenUsed)
            {
                case true: climber = new OxygenClimber(name); break;
                case false: climber = new NaturalClimber(name); break;
            }
            _baseCamp.ArriveAtCamp(name);
            _climbers.Add(climber);
            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");
            foreach (IClimber climber in _climbers.All.OrderByDescending(x => x.ConqueredPeaks.Count)
                                                      .ThenBy(x => x.Name))
            {
                sb.AppendLine(climber.ToString());
                foreach (IPeak peak in climber.ConqueredPeaks.Select(x => _peaks.Get(x))
                                                              .OrderByDescending(x => x.Elevation))
                {
                    sb.AppendLine(peak.ToString());
                }
            }


            return sb.ToString().Trim();
        }
    }
}
