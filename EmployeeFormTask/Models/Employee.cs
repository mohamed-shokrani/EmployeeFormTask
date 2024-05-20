using EmployeeFormTask.Constants;
using System.ComponentModel.DataAnnotations;

namespace EmployeeFormTask.Models;

public class Employee
{
    public int Id { get; set; }
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public bool IsFirstAppointment { get; set; }
    [StringLength(700)]

    public string? Notes { get; set; }
     public DateTime StartDate { get; set; }
    public int JobRoleId { get; set; }
    public JobRole JobRole { get; set; } 
}
