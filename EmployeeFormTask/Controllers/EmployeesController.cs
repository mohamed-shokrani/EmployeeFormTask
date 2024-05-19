using EmployeeFormTask.Data;
using EmployeeFormTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeFormTask.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
             var employess =await _context.Employees.Include(r=>r.JobRole)
                                .Select(e => new EmployeeViewModel
                                 {
                                     Name = e.Name,
                                     Gender = e.Gender,
                                     Notes = e.Notes,
                 
                                     IsFirstAppointment = e.IsFirstAppointment,
                                     StartDate = e.StartDate,
                                     JobRoleViewModel = new JobRoleViewModel
                                     {
                                         Id = e.JobRoleId,
                                         RoleName =e.JobRole.Name
                                     } 
             }).ToListAsync();
            return View(employess);
        }
    }
}
