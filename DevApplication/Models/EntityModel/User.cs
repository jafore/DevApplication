namespace DevApplication.Models.EntityModel;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Photo { get; set; }
    public string? FullName { get; set; }
    public string? ContactNo { get; set; }
    public int? RoleId { get; set; }
    public bool? Inactive { get; set; }



}