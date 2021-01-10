public interface ICombatStats 
{
    /// <summary>
    /// Mental resource stat
    /// </summary>
    float Concentration { get;}
    /// <summary>
    /// Mental resource restoration rate stat
    /// </summary>
    float Consciousness { get; }
    /// <summary>
    /// Physical resource stat
    /// </summary>
    float Energy { get;  }
    /// <summary>
    /// Physical resource restoration  rate stat
    /// </summary>
    float Stamina { get; }
    /// <summary>
    /// Health resource stat
    /// </summary>
    float HP { get; }
}
