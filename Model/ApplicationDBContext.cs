using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using udemy_web_project_01.Model;

namespace udemy_web_project_01.Model
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base (options)
        {

        }

        //the schema that we need
        public DbSet<Book> Book { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<udemy_web_project_01.Model.Config> Config { get; set; }
    }
}
