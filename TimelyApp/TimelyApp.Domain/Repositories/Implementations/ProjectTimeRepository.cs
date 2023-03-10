using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelyApp.Data.Entities;
using TimelyApp.Data.Entities.Models;
using TimelyApp.Domain.Repositories.Interfaces;

namespace TimelyApp.Domain.Repositories.Implementations
{
    internal class ProjectTimeRepository : IProjectTimeRepository
    {
        private readonly TimelyAppContext _timelyAppContext;

        public ProjectTimeRepository(TimelyAppContext timelyContext)
        {
            _timelyAppContext = timelyContext;
        }

        public List<ProjectTime> GetProjectTimes()
        {
            var projectTimes = _timelyAppContext
                .ProjectTimes
                .ToList();

            return projectTimes;
        }

        public void AddNewStartingTime()
        {
            var projectTime = _timelyAppContext.ProjectTimes
                           .OrderByDescending(pT => pT.Id)
                           .FirstOrDefault();
            if (projectTime == null || (projectTime.ProjectName != null && projectTime.EndingTime != null && projectTime.Duration != null))
            {
                _timelyAppContext.ProjectTimes.Add(new ProjectTime
                {
                    ProjectName = null,
                    StartingTime = DateTime.Now,
                    EndingTime = null,
                    Duration = null
                });
                _timelyAppContext.SaveChanges();
            }
            else
            {
                return;
            };
        }

        public bool AddNewProject(string projectName)
        {
            var projectTime = _timelyAppContext.ProjectTimes
                            .OrderByDescending(pT => pT.Id)
                            .FirstOrDefault();
            if (projectTime == null || (projectTime.ProjectName == null && projectTime.EndingTime == null && projectTime.Duration == null))
            {
                projectTime.ProjectName = projectName;
                projectTime.EndingTime = DateTime.Now;
                projectTime.Duration = projectTime.EndingTime - projectTime.StartingTime;
                _timelyAppContext.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public ProjectTime EditProjectName(int id, string projectName)
        {
            var projectTime = _timelyAppContext.ProjectTimes.Find(id);

            if (projectTime == null)
            {
                return null;
            }

            projectTime.ProjectName = projectName;
            _timelyAppContext.SaveChanges();
            return projectTime;
        }

        public bool DeleteProjectTime(int id)
        {
            var projectTime = _timelyAppContext.ProjectTimes.Find(id);

            if (projectTime == null)
            {
                return false;
            }

            _timelyAppContext.ProjectTimes.Remove(projectTime);
            _timelyAppContext.SaveChanges();

            return true;
        }
    }
}
