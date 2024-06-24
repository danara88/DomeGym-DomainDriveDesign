namespace DomeGym.Domain;

public class Participant
{
    /// <summary>
    /// Represents the unique id of the participant
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Represents the user id that creates the participant profile
    /// </summary>
    private readonly Guid _userId;

    /// <summary>
    /// Represents all the sessions that the participant has reserved
    /// </summary>
    private readonly List<Guid> _sessionIds = new();

    public Participant(Guid userId, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        _userId = userId;
    }
}
