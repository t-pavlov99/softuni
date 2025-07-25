using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
    internal class Controller : IController
    {
        public Controller()
        {
            _resources = new ResourceRepository();
            _members = new MemberRepository();
        }

        private ResourceRepository _resources;
        private MemberRepository _members;

        private bool ValidMemberType(string memberType)
        {
            return memberType == "TeamLead" || memberType == "ContentMember";
        }

        private ITeamMember CreateTeamMember(string memberType, string memberName, string path)
        {
            switch (memberType)
            {
                case "TeamLead":
                    return new TeamLead(memberName, path);
                case "ContentMember":
                    return new ContentMember(memberName, path);
                default:
                    return null;
            }
        }

        private bool ValidResourceType(string resourceType)
        {
            return resourceType == "Exam" || resourceType == "Workshop" || resourceType == "Presentation";
        }

        private IResource CreateNewResource(string resourceType, string resourceName, string creator)
        {
            switch (resourceType)
            {
                case "Exam": return new Exam(resourceName, creator);
                case "Workshop": return new Workshop(resourceName, creator);
                case "Presentation": return new Presentation(resourceName, creator);
                default: return null;
            }
        }
        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resource = _resources.TakeOne(resourceName);
            if (resource.IsTested == false)
            {
                return string.Format(OutputMessages.ResourceNotTested, resourceName);
            }

            ITeamMember teamLead = _members.Models.First(m => m.GetType().Name == "TeamLead");

            if (isApprovedByTeamLead)
            {
                resource.Approve();
                teamLead.FinishTask(resourceName);
                return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resourceName);
            }
            else
            {
                resource.Test();
                return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resourceName);
            }
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (!ValidResourceType(resourceType))
            {
                return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
            }
            ITeamMember? tm = _members.Models.FirstOrDefault(m => m.Path == path);
            if (tm == null)
            {
                return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
            }
            if (tm.InProgress.Contains(resourceName))
            {
                return string.Format(OutputMessages.ResourceExists, resourceName);
            }
            IResource resource = CreateNewResource(resourceType, resourceName, tm.Name);
            tm.WorkOnTask(resourceName);
            _resources.Add(resource);
            return string.Format(OutputMessages.ResourceCreatedSuccessfully, tm.Name, resourceType, resourceName);
        }

        public string DepartmentReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Finished Tasks:");
            foreach (var _resource in _resources.Models.Where(x => x.IsApproved))
            {
                sb.AppendLine($"--{_resource.ToString()}");
            }
            sb.AppendLine("Team Report:");
            sb.AppendLine($"--{_members.Models.First(x => x.GetType().Name == "TeamLead").ToString()}");
            foreach (var _member in _members.Models.Where(x => x.GetType().Name != "TeamLead"))
            {
                sb.AppendLine(_member.ToString());
            }
            return sb.ToString().Trim();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            if (!ValidMemberType(memberType))
            {
                return string.Format(OutputMessages.MemberTypeInvalid, memberType);
            }
            if (_members.Models.Any(m => m.Path == path))
            {
                return string.Format(OutputMessages.PositionOccupied);
            }
            if (_members.Models.Any(m => m.Name == memberName))
            {
                return string.Format(OutputMessages.MemberExists, memberName);
            }

            ITeamMember tm = CreateTeamMember(memberType, memberName, path);
            _members.Add(tm);
            return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);

        }

        public string LogTesting(string memberName)
        {
            ITeamMember creator = _members.Models.FirstOrDefault(m => m.Name == memberName);
            if (creator == null)
            {
                return string.Format(OutputMessages.WrongMemberName);
            }
            IResource resource = _resources.Models.Where(x => x.IsTested == false)
                                                  .Where(x => x.Creator == memberName)
                                                  .OrderBy(x => x.Priority)
                                                  .FirstOrDefault();
            if (resource == null)
            {
                return string.Format(OutputMessages.NoResourcesForMember, memberName);
            }
            ITeamMember teamLead = _members.Models.FirstOrDefault(x => x.GetType().Name == "TeamLead");

            creator.FinishTask(resource.Name);
            teamLead.WorkOnTask(resource.Name);
            resource.Test();
            return string.Format(OutputMessages.ResourceTested, resource.Name);

        }
    }
}
