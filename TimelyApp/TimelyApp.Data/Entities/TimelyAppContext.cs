using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelyApp.Data.Entities.Models;

namespace TimelyApp.Data.Entities
{
    public class TimelyAppContext : DbContext
    {
        public TimelyAppContext(DbContextOptions<TimelyAppContext> options) : base(options)
        {
        }

        public DbSet<ProjectTime> ProjectTimes { get; set; }
    }
}
