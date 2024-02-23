
using System.ComponentModel.DataAnnotations;

public class Department
{
    [Key]
    public int Department_Id { get; set; }
    public string Name { get; set; }
    public string Manager { get; set; }
    public string Location { get; set; } 
}
