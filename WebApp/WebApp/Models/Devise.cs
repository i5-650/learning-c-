using Microsoft.Build.Framework;

namespace WebApp.Models;

public class Devise
{
    public Devise(int id, string? name, double amount)
    {
        Id = id;
        Name = name;
        Amount = amount;
    }

    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public double Amount { get; set; }
}