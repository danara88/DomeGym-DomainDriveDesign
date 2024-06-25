using System.Reflection.Metadata.Ecma335;
using ErrorOr;

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

    /// <summary>
    /// Represents the session date
    /// </summary>
    private readonly DateOnly _date;

    /// <summary>
    /// Represents the session start time
    /// </summary>
    private readonly TimeOnly _startTime;

    /// <summary>
    /// Represents the session end time
    /// </summary>
    private readonly TimeOnly _endTime;

    public Session(
        int maxParticipants,
        DateOnly date,
        TimeOnly startTime,
        TimeOnly endTime,
        Guid trainerId,
        Guid? id = null)
    {
        _maxParticipants = maxParticipants;
        _date = date;
        _startTime = startTime;
        _endTime = endTime;
        _id = id ?? Guid.NewGuid();
        _trainerId = trainerId;
    }

    public ErrorOr<Success> ReserveSpot(Participant participant)
    {
        if (_participantsIds.Count >= _maxParticipants)
        {
            return SessionErrors.CannotHaveMoreReservationsThanParticipants;
        }

        _participantsIds.Add(participant.Id);

        return Result.Success;
    }

    public ErrorOr<Success> CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if(isTooCloseToSession(dateTimeProvider.utcNow))
        {
            return SessionErrors.CannotCancelReservationTooCloseToSession;
        }

        if (!_participantsIds.Remove(participant.Id))
        {
            return Error.NotFound(description: "Participant not found.");
        }

        return Result.Success;
    }

    private bool isTooCloseToSession(DateTime utcNow)
    {
        const int MinHours = 24;
        // session time - current time < 24 hours
        return (_date.ToDateTime(_startTime) - utcNow).TotalHours < MinHours;
    }
}
