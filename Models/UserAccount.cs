
using System.ComponentModel.DataAnnotations;

public class UserAccount
{
    [Key]
    public int UserAccount_Id { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public int Mobile { get; set; } 
    public string Email_Account { get; set; }
    public string Account { get; set; }
    public string Gender { get; set; }
}
