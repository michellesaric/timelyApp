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

        public List<ProjectTime> Pagination(int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            var projectTimes = _timelyAppContext
                .ProjectTimes.Skip((pageNumber - 1) * 10)
                .Take(10)
                .ToList();

            return projectTimes;
        }

        public void AddNewStartingTime()
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



    }
}
