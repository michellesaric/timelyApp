using TimelyApp.Data.Entities.Models;

namespace TimelyApp.Domain.Repositories.Interfaces
{
    public interface IProjectTimeRepository
    {
        List<ProjectTime> GetProjectTimes();

        void AddNewStartingTime();
        bool AddNewProject(string projectName);

        ProjectTime EditProjectName(int id, string projectName);

        bool DeleteProjectTime(int id);
    }
}
