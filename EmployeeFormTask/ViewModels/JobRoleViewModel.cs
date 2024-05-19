using System.ComponentModel.DataAnnotations;

namespace EmployeeFormTask.ViewModels;
public class JobRoleViewModel
{
    public int Id { get; set; }
    [Display(Name = "Role Name")]

    public string RoleName { get; set; }
  
     
}
