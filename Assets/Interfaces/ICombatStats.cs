public interface ICombatStats 
{
    /// <summary>
    /// Mental resource stat
    /// </summary>
    float Concentration { get; set; }
    /// <summary>
    /// Mental resource restoration rate stat
    /// </summary>
    float Consciousness { get; set; }
    /// <summary>
    /// Physical resource stat
    /// </summary>
    float Energy { get; set; }
    /// <summary>
    /// Physical resource restoration  rate stat
    /// </summary>
    float Stamina { get; set; }
    /// <summary>
    /// Health resource stat
    /// </summary>
    float HP { get; set; }
}
