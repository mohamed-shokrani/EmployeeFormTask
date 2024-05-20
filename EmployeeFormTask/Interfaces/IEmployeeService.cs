using EmployeeFormTask.ViewModels;

namespace EmployeeFormTask.Interfaces;
public interface IEmployeeService
{
    Task<IReadOnlyList<EmployeeViewModel>> GetAllEmployee();
    Task<bool> Create(EmployeeCreateUpdateVM vM);
    Task<bool> IsJobRoleExists(int id );
    Task<IReadOnlyList<JobRoleViewModel>> GetAllJobRoles();
    IEnumerable<JobRoleViewModel> GetJobRoles();

}
