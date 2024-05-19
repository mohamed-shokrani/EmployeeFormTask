using EmployeeFormTask.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeFormTask.Data;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
            
    }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual  DbSet<JobRole> JobRoles { get; set; }
}
