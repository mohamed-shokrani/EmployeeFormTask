using EmployeeFormTask.Constants;
using System.ComponentModel.DataAnnotations;

namespace EmployeeFormTask.ViewModels;
public class EmployeeViewModel
{
    public int Id { get; set; }
    [StringLength(100),Display(Name = "Employee Name")]
    public string Name { get; set; }
    [Display(Name = "Gender")]

    public Gender Gender { get; set; }
    [Display(Name = "First Appointment")]

    public bool IsFirstAppointment { get; set; }
    [StringLength(700), Display(Name = "Notes")]
    public string? Notes { get; set; }
    [Display(Name = "Start Date")]

    public DateTime StartDate { get; set; }

    public JobRoleViewModel JobRoleViewModel { get; set; }

}
