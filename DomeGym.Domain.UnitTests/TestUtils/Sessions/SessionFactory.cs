using DomeGym.Domain.UnitTests.TestConstants;

namespace DomeGym.Domain.UnitTests.TestUtils.Sessions;

public static class SessionFactory
{
    public static Session CreateSession(
        int maxParticipants,
        DateOnly? date = null,
        TimeOnly? startTime = null,
        TimeOnly? endTime = null,
        Guid? id = null)
    {
        return new Session(
          maxParticipants,
          date ?? Constants.Session.Date,
          startTime ?? Constants.Session.StartTime,
          endTime ?? Constants.Session.EndTime,
          trainerId: Constants.Trainer.Id,
          id: id ?? Constants.Session.Id
        );
    }
}
