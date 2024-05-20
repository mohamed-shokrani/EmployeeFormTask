using EmployeeFormTask.Data;
namespace EmployeeFormTask.Services;
public class EmployeeService : IEmployeeService
{
    protected readonly AppDbContext _context;
    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(EmployeeCreateUpdateVM vM)
    {
        var emp = new Employee
        {
            Name = vM.Name,
            IsFirstAppointment = vM.IsFirstAppointment,
            StartDate = vM.StartDate,
            Gender = vM.Gender,
            Notes = vM.Notes,
            JobRoleId = vM.JobRoleId,
        };
        try
        {
            await _context.AddAsync(emp);
            
            return await _context.SaveChangesAsync()>0;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> IsJobRoleExists(int id)
         => await _context.JobRoles.AnyAsync(x => x.Id == id);
    public IEnumerable<JobRoleViewModel> GetJobRoles()
        => [.. _context.JobRoles.Select(x => new JobRoleViewModel
        {
            Id = x.Id,
            RoleName = x.Name,
        })];
    public async Task<IReadOnlyList<EmployeeViewModel>> GetAllEmployee()
    {
        return await _context.Employees.Include(r => r.JobRole)
                           .Select(e => new EmployeeViewModel
                           {
                               Name = e.Name,
                               Gender = e.Gender,
                               Notes = e.Notes,
                               IsFirstAppointment = e.IsFirstAppointment,
                               StartDate = e.StartDate,
                               JobRoleViewModel = new JobRoleViewModel
                               {

                                   RoleName = e.JobRole.Name
                               }
                           }).AsNoTracking().ToListAsync() ?? [];
       
    }
    public async Task < IReadOnlyList< JobRoleViewModel>> GetAllJobRoles()
    {
        return await _context.JobRoles.Select(x => new JobRoleViewModel
                            {
                                Id = x.Id,
                                RoleName = x.Name,
                            }).AsNoTracking().ToListAsync();
    }

}
