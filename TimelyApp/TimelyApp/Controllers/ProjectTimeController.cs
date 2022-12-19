using Microsoft.AspNetCore.Mvc;
using TimelyApp.Domain.Repositories.Interfaces;

namespace TimelyApp.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectTimeController : ControllerBase
    {
        private readonly IProjectTimeRepository _projectTimeRepository;

        public ProjectTimeController(IProjectTimeRepository projectTimeRepository)
        {
            _projectTimeRepository = projectTimeRepository;
        }


        [HttpGet]
        public IActionResult GetAllProjectTimes()
        {
            var projectTimes = _projectTimeRepository.GetProjectTimes();

            return Ok(projectTimes);
        }

        [HttpPost]
        public IActionResult AddStartingTime()
        {
            _projectTimeRepository.AddNewStartingTime();
            return Ok();
        }


        [HttpPut("{projectName}")]
        public IActionResult AddNewProject(string projectName)
        {
            var isSuccessful = _projectTimeRepository.AddNewProject(projectName);

            if (!isSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPatch("{id}/projectName/{projectName}")]
        public IActionResult EditProjectName(int id, string projectName)
        {
            var projectTime = _projectTimeRepository.EditProjectName(id, projectName);

            if (projectTime == null)
            {
                return NotFound(id);
            }

            return Ok(projectTime);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveProjectTime(int id)
        {
            var isSuccessful = _projectTimeRepository.DeleteProjectTime(id);

            if (!isSuccessful)
            {
                return NotFound(id);
            }

            return Ok();
        }

    }
}