namespace DomeGym.Domain;

public class Room
{
    /// <summary>
    /// Represents the unique id of the room
    /// </summary>
    private readonly Guid _id;

    /// <summary>
    /// Represents the sessions that are part of the room
    /// </summary>
    private readonly List<Guid>? _sessionIds;
}
