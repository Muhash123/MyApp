using Microsoft.EntityFrameworkCore;
using MyApp.Core.Enteties;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infrastucture.Data
{
    public  class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):DbContext(options)
    {

        public DbSet<Student> Students { get; set; }
    }
}
