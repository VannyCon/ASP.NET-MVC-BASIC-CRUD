
using System.ComponentModel.DataAnnotations;

public class Designation
{
    [Key]
    public int Designation_Id { get; set; }
    public string Designated { get; set; }
    public string First { get; set; }
    public string Last { get; set; } 
}
