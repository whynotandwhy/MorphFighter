/// <summary>
/// IPart is the core defintion for items that are used to power the fighters
/// </summary>
public interface IPart
{
    /// <summary>
    /// Focus is to represent a mental attribute for fighting
    /// </summary>
    float Focus { get; set; }
    /// <summary>
    /// Effort is to represent a physical attribute for fighting 
    /// </summary>
    float Effort { get; set; }
    /// <summary>
    /// Strength is to represent a secondary physical attribute for fighting 
    /// </summary>
    float Strength { get; set; }
    /// <summary>
    /// Rank is used to do quick comparisons and evaluations of objects
    /// </summary>
    int Rank { get; set; }
}
