using InfucareRx.PatientHealthApp.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace InfucareRx.PatientHealthApp.Database
{
    public class InfucareRxPatientHealthAppDbContext : DbContext
    {
        public InfucareRxPatientHealthAppDbContext(DbContextOptions<InfucareRxPatientHealthAppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } 
    }
}