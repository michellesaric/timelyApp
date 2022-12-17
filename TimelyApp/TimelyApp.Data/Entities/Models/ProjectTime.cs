using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelyApp.Data.Entities.Models
{
    public class ProjectTime
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime? EndingTime { get; set; }
        public TimeSpan? Duration { get; set; } 
    }
}
