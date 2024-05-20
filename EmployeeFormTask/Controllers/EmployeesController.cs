namespace EmployeeFormTask.Controllers;
public class EmployeesController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<IActionResult> Index()
    {
        var employess = await _employeeService.GetAllEmployee();
        return View(employess);
    }
    public async Task<IActionResult> Create()
    {
        var jobRoles = await _employeeService.GetAllJobRoles();
        var emp = new EmployeeCreateUpdateVM
           {
            JobRoles = _employeeService.GetJobRoles()
           };
        return View(emp);
    }
    [HttpPost]
    public async Task<IActionResult> Create(EmployeeCreateUpdateVM vM)
    {
        if (!ModelState.IsValid)
        {
            vM.JobRoles = _employeeService.GetJobRoles();
            return View(vM);
        }

        if (!await _employeeService.IsJobRoleExists(vM.JobRoleId))
        {
            ModelState.AddModelError(string.Empty, "Invalid job role.");
            vM.JobRoles = _employeeService.GetJobRoles();
            return View(vM);
        }
      var result  =  await _employeeService.Create(vM);
        if (result)
        {
            return Json(new { success = true });
        }
        return RedirectToAction("Index");
    }

}
