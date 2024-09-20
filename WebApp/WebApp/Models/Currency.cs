using Microsoft.Build.Framework;

namespace WebApp.Models;

/// <summary>
/// Represents a currency object to exchange with clients. 
/// </summary>
public class Currency
{
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Currency"/> class.
    /// </summary>
    /// <param name="id">The unique identifier for a currency.</param>
    /// <param name="name">The name of the currency (required).</param>
    /// <param name="amount">The amount relative to euro.</param>
    public Currency(int id, string? name, double amount)
    {
        Id = id;
        Name = name;
        Amount = amount;
    }

    /// <summary>
    /// The currency ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the currency
    /// </summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>
    /// The amount relatively to euro
    /// </summary>
    public double Amount { get; set; }
}