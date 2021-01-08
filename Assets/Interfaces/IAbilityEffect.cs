/// <summary>
/// The effect an ability will have on a ICombatantStats resorse values
/// </summary>
public interface IAbilityEffect 
{
    /// <summary>
    /// Change to mental resource stat
    /// </summary>
    float Concentration { get; }
    /// <summary>
    /// Change to physical resource stat
    /// </summary>
    float Energy { get; }
    /// <summary>
    /// Change to health resource stat
    /// </summary>
    float HP { get; }
}
