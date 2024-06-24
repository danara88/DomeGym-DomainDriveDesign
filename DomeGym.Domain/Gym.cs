namespace DomeGym.Domain;

public class Gym
{
    /// <summary>
    /// Represents the unique id of the gym
    /// </summary>
    private readonly Guid _id;

    /// <summary>
    /// Represents the rooms that are part of the gym
    /// </summary>
    private readonly List<Guid>? _roomIds;
}
