﻿namespace EmployeeFormTask.Models;
public class JobRole
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Employee > Employees { get; set; }
  
}
