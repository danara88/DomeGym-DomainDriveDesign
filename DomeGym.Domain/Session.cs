namespace DomeGym.Domain;

public class Session
{
    /// <summary>
    /// Represents the unique id of the session
    /// </summary>
    private readonly Guid _id;

    /// <summary>
    /// Represents the trainer that is assigned to the session
    /// </summary>
    private readonly Guid _trainerId;

    /// <summary>
    /// Represents all the participants of the session
    /// </summary>
    private readonly List<Guid> _participantsIds = new();

    /// <summary>
    /// Represents maximun participants that a session can have
    /// </summary>
    private readonly int _maxParticipants;

    public Session(int maxParticipants, Guid trainerId, Guid? id = null)
    {
        _maxParticipants = maxParticipants;
        _id = id ?? Guid.NewGuid();
        _trainerId = trainerId;
    }

    public void ReserveSpot(Participant participant)
    {
        if (_participantsIds.Count >= _maxParticipants)
        {
            throw new Exception("Cannot have more reservations than participants.");
        }

        _participantsIds.Add(participant.Id);
    }
}
