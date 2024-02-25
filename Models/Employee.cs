
using System.ComponentModel.DataAnnotations;

public class Employee
{
    [Key]
    public int Employee_Id { get; set; }
    public string First { get; set; }
    public string Last { get; set; }
    public string Birthday { get; set; } 
    public string Gender { get; set; } 
    public string Position { get; set; }
}
