using System.Data.Entity;
using System.Data.Entity.Infrastructure;
//using Assignments.PersonDetails.Domain.Models.Mapping;

namespace Assignments.PersonDetails.Domain.Models
{
    public partial class EmployeeDatabaseContext : DbContext
    {
        static EmployeeDatabaseContext()
        {
            Database.SetInitializer<EmployeeDatabaseContext>(null);
        }

        public EmployeeDatabaseContext()
            : base("Name=EmployeeDatabaseContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
