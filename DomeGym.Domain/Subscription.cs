namespace DomeGym.Domain;

public class Subscription
{
    /// <summary>
    /// Represents the unique id of the subscription
    /// </summary>
    private readonly Guid _id;

    /// <summary>
    /// Represents the gyms that are part of the subscription
    /// </summary>
    private readonly List<Guid>? _gymIds;
}
