using EmployeeFormTask.Constants;
using System.ComponentModel.DataAnnotations;

namespace EmployeeFormTask.ViewModels
{
    public class EmployeeCreateUpdateVM
    {
        public int Id { get; set; }
        [StringLength(100), Display(Name = "Employee Name")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Gender")]

        [Range(1, 2, ErrorMessage = "Please select a valid gender.")]

        public Gender Gender { get; set; } = Gender.Unspecified;
        [Display(Name = "Is this your first Appointment")]

        public bool IsFirstAppointment { get; set; }
        [StringLength(700), Display(Name = "Notes")]
        public string? Notes { get; set; }
        [DataType(DataType.Date)]

        [Display(Name = "Start Date")]

        public DateTime StartDate { get; set; }
        [Display(Name = "Notes")]
        public int JobRoleId { get; set; }
        public IEnumerable< JobRoleViewModel>? JobRoles { get; set; }
    }
}
