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


        [HttpGet("{pageNumber}")]
        public IActionResult Pagination(int pageNumber)
        {
            var projectTimes = _projectTimeRepository.Pagination(pageNumber);

            return Ok(projectTimes);
        }
    }
}