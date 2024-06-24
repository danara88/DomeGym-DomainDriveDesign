namespace DomeGym.Domain;

public class Trainer
{
    /// <summary>
    /// Represents the unique id of the trainer
    /// </summary>
    private readonly Guid _id;

    /// <summary>
    /// Represents the user id that creates the trainer profile
    /// </summary>
    private readonly Guid _userId;

    /// <summary>
    /// Represents all the sessions that trainer is teaching
    /// </summary>
    private readonly List<Guid>? _sessionIds;
}
